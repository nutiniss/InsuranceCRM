using System.Globalization;
using System.Text;
using Firma.Data.Data.Ubezpieczenia;

namespace Firma.PortalWWW.Services;

public static class PolicyPdfGenerator
{
    public static byte[] Generate(Polisa polisa)
    {
        var lines = new[]
        {
            "Potwierdzenie polisy",
            $"Numer polisy: {polisa.NumerPolisy}",
            $"Status: {polisa.Status}",
            $"Produkt: {polisa.ProduktUbezpieczeniowy?.Nazwa ?? "Produkt ubezpieczeniowy"}",
            $"Kategoria: {polisa.ProduktUbezpieczeniowy?.Kategoria ?? "-"}",
            string.Empty,
            "Dane klienta",
            $"Imie i nazwisko: {polisa.Klient?.Imie} {polisa.Klient?.Nazwisko}".Trim(),
            $"E-mail: {polisa.Klient?.Email ?? "-"}",
            $"Telefon: {polisa.Klient?.Telefon ?? "-"}",
            string.Empty,
            "Okres ochrony i skladka",
            $"Poczatek ochrony: {polisa.PoczatekOchrony:dd.MM.yyyy}",
            $"Koniec ochrony: {polisa.KoniecOchrony:dd.MM.yyyy}",
            $"Skladka: {polisa.Skladka.ToString("C", CultureInfo.CurrentCulture)}",
            string.Empty,
            "Opiekun polisy",
            $"Agent: {FormatAgent(polisa.Uzytkownik)}",
            $"E-mail agenta: {polisa.Uzytkownik?.Email ?? "-"}",
            string.Empty,
            $"Dokument wygenerowano: {DateTime.Now:dd.MM.yyyy HH:mm}",
            "Dokument ma charakter informacyjny i zostal wygenerowany w portalu klienta."
        };

        var content = BuildPageContent(lines);
        return BuildPdf(content);
    }

    private static string FormatAgent(Uzytkownik? uzytkownik)
    {
        return uzytkownik is null ? "-" : $"{uzytkownik.Imie} {uzytkownik.Nazwisko}";
    }

    private static string BuildPageContent(IEnumerable<string> lines)
    {
        var builder = new StringBuilder();
        builder.AppendLine("BT");
        builder.AppendLine("/F1 20 Tf");
        builder.AppendLine("72 770 Td");

        var firstLine = true;
        foreach (var rawLine in lines)
        {
            var line = NormalizeForPdf(rawLine);
            if (!firstLine)
            {
                builder.AppendLine("0 -24 Td");
            }

            builder.Append('(').Append(EscapePdfText(line)).AppendLine(") Tj");
            if (line == "Potwierdzenie polisy")
            {
                builder.AppendLine("/F1 12 Tf");
            }

            firstLine = false;
        }

        builder.AppendLine("ET");
        return builder.ToString();
    }

    private static byte[] BuildPdf(string content)
    {
        var contentBytes = Encoding.ASCII.GetBytes(content);
        var objects = new[]
        {
            "1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n",
            "2 0 obj\n<< /Type /Pages /Kids [3 0 R] /Count 1 >>\nendobj\n",
            "3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Resources << /Font << /F1 4 0 R >> >> /Contents 5 0 R >>\nendobj\n",
            "4 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>\nendobj\n",
            $"5 0 obj\n<< /Length {contentBytes.Length} >>\nstream\n{content}endstream\nendobj\n"
        };

        using var stream = new MemoryStream();
        WriteAscii(stream, "%PDF-1.4\n");
        var offsets = new List<long> { 0 };

        foreach (var pdfObject in objects)
        {
            offsets.Add(stream.Position);
            WriteAscii(stream, pdfObject);
        }

        var xrefOffset = stream.Position;
        WriteAscii(stream, $"xref\n0 {objects.Length + 1}\n");
        WriteAscii(stream, "0000000000 65535 f \n");
        foreach (var offset in offsets.Skip(1))
        {
            WriteAscii(stream, $"{offset:0000000000} 00000 n \n");
        }

        WriteAscii(stream, $"trailer\n<< /Size {objects.Length + 1} /Root 1 0 R >>\nstartxref\n{xrefOffset}\n%%EOF");
        return stream.ToArray();
    }

    private static void WriteAscii(Stream stream, string value)
    {
        var bytes = Encoding.ASCII.GetBytes(value);
        stream.Write(bytes, 0, bytes.Length);
    }

    private static string EscapePdfText(string value)
    {
        return value.Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("(", "\\(", StringComparison.Ordinal)
            .Replace(")", "\\)", StringComparison.Ordinal);
    }

    private static string NormalizeForPdf(string value)
    {
        var normalized = value.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder(normalized.Length);

        foreach (var character in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(character) == UnicodeCategory.NonSpacingMark)
            {
                continue;
            }

            builder.Append(character switch
            {
                'ł' => 'l',
                'Ł' => 'L',
                'đ' => 'd',
                'Đ' => 'D',
                _ => character <= 127 ? character : '-'
            });
        }

        return builder.ToString();
    }
}
