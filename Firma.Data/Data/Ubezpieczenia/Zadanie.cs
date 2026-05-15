using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Zadanie : ISoftDeletable
    {
        [Key]
        public int IdZadania { get; set; }

        [Required(ErrorMessage = "Nazwa zadania jest wymagana")]
        [Display(Name = "Nazwa zadania")]
        public required string Nazwa { get; set; }

        public string Opis { get; set; } = string.Empty;

        [Required(ErrorMessage = "Typ zadania jest wymagany")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Status zadania jest wymagany")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Data utworzenia zadania jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data realizacji")]
        public DateTime? DataRealizacji { get; set; }

        [ForeignKey("Klient")]
        public int? IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        public int? IdUzytkownika { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }

        [ForeignKey("Zgloszenie")]
        public int? IdZgloszenia { get; set; }
        public Zgloszenie? Zgloszenie { get; set; }

        [ForeignKey("Oferta")]
        public int? IdOferty { get; set; }
        public Oferta? Oferta { get; set; }

        [ForeignKey("Polisa")]
        public int? IdPolisy { get; set; }
        public Polisa? Polisa { get; set; }
        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;

    }
}
