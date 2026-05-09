using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Intranet.Models.Ubezpieczenia
{
    public class Oferta
    {
        [Key]
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
        public required string Status { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Przypis")]
        public decimal Przypis { get; set; }

        [ForeignKey("Klient")]
        public int IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        public int IdUzytkownika { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }

        [ForeignKey("ProduktUbezpieczeniowy")]
        public int IdProduktuUbezpieczeniowego { get; set; }
        public ProduktUbezpieczeniowy? ProduktUbezpieczeniowy { get; set; }

        public Wycena? Wycena { get; set; }
        public Polisa? Polisa { get; set; }
        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}
