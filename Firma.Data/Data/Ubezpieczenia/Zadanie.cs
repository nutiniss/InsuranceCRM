using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Zadanie : ISoftDeletable
    {
        [Key]
        [Display(Name = "Zadanie")]
        public int IdZadania { get; set; }

        [Required(ErrorMessage = "Nazwa zadania jest wymagana")]
        [Display(Name = "Nazwa zadania")]
        public required string Nazwa { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; } = string.Empty;

        [Required(ErrorMessage = "Typ zadania jest wymagany")]
        [Display(Name = "Typ zadania")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Status zadania jest wymagany")]
        [Display(Name = "Status zadania")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Data utworzenia zadania jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data realizacji")]
        public DateTime? DataRealizacji { get; set; }

        [ForeignKey("Klient")]
        [Display(Name = "Klient")]
        public int? IdKlienta { get; set; }
        [Display(Name = "Klient")]
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        [Display(Name = "Opiekun")]
        public int? IdUzytkownika { get; set; }
        [Display(Name = "Opiekun")]
        public Uzytkownik? Uzytkownik { get; set; }

        [ForeignKey("Zgloszenie")]
        [Display(Name = "Zgłoszenie")]
        public int? IdZgloszenia { get; set; }
        [Display(Name = "Zgłoszenie")]
        public Zgloszenie? Zgloszenie { get; set; }

        [ForeignKey("Oferta")]
        [Display(Name = "Oferta")]
        public int? IdOferty { get; set; }
        [Display(Name = "Oferta")]
        public Oferta? Oferta { get; set; }

        [ForeignKey("Polisa")]
        [Display(Name = "Polisa")]
        public int? IdPolisy { get; set; }
        [Display(Name = "Polisa")]
        public Polisa? Polisa { get; set; }
        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;

    }
}
