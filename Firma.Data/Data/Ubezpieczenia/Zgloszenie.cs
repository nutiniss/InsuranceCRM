using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Zgloszenie : ISoftDeletable
    {
        [Key]
        [Display(Name = "Zgłoszenie")]
        public int IdZgloszenia { get; set; }

        [Required(ErrorMessage = "Numer zgłoszenia jest wymagany")]
        [Display(Name = "Numer zgłoszenia")]
        public required string NumerZgloszenia { get; set; }

        [Required(ErrorMessage = "Tytuł zgłoszenia jest wymagany")]
        [Display(Name = "Tytuł")]
        public required string Tytul { get; set; }

        [Required(ErrorMessage = "Opis zgłoszenia jest wymagany")]
        [Display(Name = "Opis")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Typ zgłoszenia jest wymagany")]
        [Display(Name = "Typ zgłoszenia")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Status zgłoszenia jest wymagany")]
        [Display(Name = "Status zgłoszenia")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Data utworzenia zgłoszenia jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data zamknięcia")]
        public DateTime? DataZamkniecia { get; set; }

        [ForeignKey("Klient")]
        [Display(Name = "Klient")]
        public int IdKlienta { get; set; }
        [Display(Name = "Klient")]
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        [Display(Name = "Opiekun")]
        public int? IdUzytkownika { get; set; }
        [Display(Name = "Opiekun")]
        public Uzytkownik? Uzytkownik { get; set; }


        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;
        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}
