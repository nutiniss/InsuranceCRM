using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Zgloszenie
    {
        [Key]
        public int IdZgloszenia { get; set; }

        [Required(ErrorMessage = "Numer zgłoszenia jest wymagany")]
        [Display(Name = "Numer zgłoszenia")]
        public required string NumerZgloszenia { get; set; }

        [Required(ErrorMessage = "Tytuł zgłoszenia jest wymagany")]
        [Display(Name = "Tytuł")]
        public required string Tytul { get; set; }

        [Required(ErrorMessage = "Opis zgłoszenia jest wymagany")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Typ zgłoszenia jest wymagany")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Status zgłoszenia jest wymagany")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Data utworzenia zgłoszenia jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data zamknięcia")]
        public DateTime? DataZamkniecia { get; set; }

        [ForeignKey("Klient")]
        public int IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        public int? IdUzytkownika { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }

        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}
