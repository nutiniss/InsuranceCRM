using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Oferta : ISoftDeletable
    {
        [Key]
        [Display(Name = "Oferta")]
        public int IdOferty { get; set; }

        [Required(ErrorMessage = "Numer oferty jest wymagany")]
        [Display(Name = "Numer oferty")]
        public required string NumerOferty { get; set; }

        [Required(ErrorMessage = "Data utworzenia oferty jest wymagana")]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        [Display(Name = "Data ważności")]
        public DateTime? DataWaznosci { get; set; }

        [Required(ErrorMessage = "Status oferty jest wymagany")]
        [Display(Name = "Status oferty")]
        public required string Status { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Przypis")]
        public decimal Przypis { get; set; }

        [ForeignKey("Klient")]
        [Display(Name = "Klient")]
        public int IdKlienta { get; set; }
        [Display(Name = "Klient")]
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        [Display(Name = "Opiekun")]
        public int IdUzytkownika { get; set; }
        [Display(Name = "Opiekun")]
        public Uzytkownik? Uzytkownik { get; set; }

        [ForeignKey("ProduktUbezpieczeniowy")]
        [Display(Name = "Produkt")]
        public int IdProduktuUbezpieczeniowego { get; set; }
        [Display(Name = "Produkt")]
        public ProduktUbezpieczeniowy? ProduktUbezpieczeniowy { get; set; }

        public Wycena? Wycena { get; set; }
        public Polisa? Polisa { get; set; }

        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;
        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}
