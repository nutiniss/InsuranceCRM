using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Wiadomosc
    {
        [Key]
        public int IdWiadomosci { get; set; }

        [Required(ErrorMessage = "Temat wiadomości jest wymagany")]
        public required string Temat { get; set; }

        [Required(ErrorMessage = "Treść wiadomości jest wymagana")]
        [Display(Name = "Treść")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Typ wiadomości jest wymagany")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Data utworzenia wiadomości jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data wysłania")]
        public DateTime? DataWyslania { get; set; }

        [Display(Name = "Przeczytana")]
        public bool CzyPrzeczytana { get; set; }

        [ForeignKey("Klient")]
        public int? IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        public int IdUzytkownika { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }
    }
}
