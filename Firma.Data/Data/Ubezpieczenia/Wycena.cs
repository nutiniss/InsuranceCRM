using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Wycena
    {
        [Key]
        public int IdWyceny { get; set; }

        [Required(ErrorMessage = "Data wyceny jest wymagana")]
        [Display(Name = "Data wyceny")]
        public DateTime DataWyceny { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Metoda wyceny jest wymagana")]
        [Display(Name = "Metoda wyceny")]
        public required string MetodaWyceny { get; set; }

        [Required(ErrorMessage = "Wartość przedmiotu ubezpieczenia jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Wartość przedmiotu ubezpieczenia")]
        public decimal WartoscPrzedmiotuUbezpieczenia { get; set; }

        [Required(ErrorMessage = "Suma ubezpieczenia jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Suma ubezpieczenia")]
        public decimal SumaUbezpieczenia { get; set; }

        [Required(ErrorMessage = "Składka jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Składka")]
        public decimal Skladka { get; set; }

        public string Uwagi { get; set; } = string.Empty;

        [ForeignKey("Oferta")]
        public int IdOferty { get; set; }
        public Oferta? Oferta { get; set; }
    }
}
