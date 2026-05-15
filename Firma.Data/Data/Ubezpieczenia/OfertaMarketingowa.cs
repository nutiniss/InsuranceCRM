using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class OfertaMarketingowa : ISoftDeletable
    {
        [Key]
        public int IdOfertyMarketingowej { get; set; }

        [Required(ErrorMessage = "Tytuł oferty marketingowej jest wymagany")]
        [Display(Name = "Tytuł")]
        public required string Tytul { get; set; }

        [Required(ErrorMessage = "Treść oferty marketingowej jest wymagana")]
        [Display(Name = "Treść")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Grupa docelowa jest wymagana")]
        [Display(Name = "Grupa docelowa")]
        public required string GrupaDocelowa { get; set; }

        [Required(ErrorMessage = "Data utworzenia oferty marketingowej jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data publikacji")]
        public DateTime? DataPublikacji { get; set; }

        [Display(Name = "Data ważności")]
        public DateTime? DataWaznosci { get; set; }

        [Display(Name = "Aktywna")]
        public bool CzyAktywna { get; set; } = true;

        [ForeignKey("Uzytkownik")]
        public int IdUzytkownika { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }
        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;

    }
}
