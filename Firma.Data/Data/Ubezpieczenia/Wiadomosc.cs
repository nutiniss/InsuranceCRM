using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Wiadomosc : ISoftDeletable
    {
        [Key]
        [Display(Name = "Wiadomość")]
        public int IdWiadomosci { get; set; }

        [Required(ErrorMessage = "Temat wiadomości jest wymagany")]
        [Display(Name = "Temat")]
        public required string Temat { get; set; }

        [Required(ErrorMessage = "Treść wiadomości jest wymagana")]
        [Display(Name = "Treść")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Typ wiadomości jest wymagany")]
        [Display(Name = "Typ wiadomości")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Data utworzenia wiadomości jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data wysłania")]
        public DateTime? DataWyslania { get; set; }

        [Display(Name = "Przeczytana")]
        public bool CzyPrzeczytana { get; set; }

        [ForeignKey("Klient")]
        [Display(Name = "Klient")]
        public int? IdKlienta { get; set; }
        [Display(Name = "Klient")]
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        [Display(Name = "Opiekun")]
        public int IdUzytkownika { get; set; }
        [Display(Name = "Opiekun")]
        public Uzytkownik? Uzytkownik { get; set; }
        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;

    }
}
