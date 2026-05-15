using System.ComponentModel.DataAnnotations;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class ProduktUbezpieczeniowy : ISoftDeletable
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


        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;
        public ICollection<Oferta> Oferty { get; set; } = new List<Oferta>();
        public ICollection<Polisa> Polisy { get; set; } = new List<Polisa>();
    }
}
