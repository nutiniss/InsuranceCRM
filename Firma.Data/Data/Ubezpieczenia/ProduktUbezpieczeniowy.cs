using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class ProduktUbezpieczeniowy
    {
        [Key]
        public int IdProduktuUbezpieczeniowego { get; set; }

        [Required(ErrorMessage = "Kod produktu jest wymagany")]
        public required string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Kategoria produktu jest wymagana")]
        public required string Kategoria { get; set; }

        public string Opis { get; set; } = string.Empty;

        [Display(Name = "Aktywny")]
        public bool CzyAktywny { get; set; } = true;

        public ICollection<Oferta> Oferty { get; set; } = new List<Oferta>();
        public ICollection<Polisa> Polisy { get; set; } = new List<Polisa>();
    }
}
