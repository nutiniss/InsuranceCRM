using System.ComponentModel.DataAnnotations;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Klient : ISoftDeletable
    {
        [Key]
        [Display(Name = "Klient")]
        public int IdKlienta { get; set; }

        [Required(ErrorMessage = "Imię klienta jest wymagane")]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko klienta jest wymagane")]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }

        [Display(Name = "PESEL")]
        public string Pesel { get; set; } = string.Empty;

        [Display(Name = "NIP")]
        public string Nip { get; set; } = string.Empty;

        [Display(Name = "REGON")]
        public string Regon { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail")]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Phone(ErrorMessage = "Podaj poprawny numer telefonu")]
        [Display(Name = "Telefon")]
        public required string Telefon { get; set; }

        [Display(Name = "Data urodzenia")]
        public DateTime? DataUrodzenia { get; set; }


        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;
        public ICollection<Oferta> Oferty { get; set; } = new List<Oferta>();
        public ICollection<Polisa> Polisy { get; set; } = new List<Polisa>();
        public ICollection<Zgloszenie> Zgloszenia { get; set; } = new List<Zgloszenie>();
        public ICollection<Wiadomosc> Wiadomosci { get; set; } = new List<Wiadomosc>();
    }
}
