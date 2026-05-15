using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Polisa : ISoftDeletable
    {
        [Key]
        public int IdPolisy { get; set; }

        [Required(ErrorMessage = "Numer polisy jest wymagany")]
        [Display(Name = "Numer polisy")]
        public required string NumerPolisy { get; set; }

        [Required(ErrorMessage = "Początek ochrony jest wymagany")]
        [Display(Name = "Początek ochrony")]
        public DateTime PoczatekOchrony { get; set; }

        [Required(ErrorMessage = "Koniec ochrony jest wymagany")]
        [Display(Name = "Koniec ochrony")]
        public DateTime KoniecOchrony { get; set; }

        [Required(ErrorMessage = "Składka jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Składka")]
        public decimal Skladka { get; set; }

        [Required(ErrorMessage = "Status polisy jest wymagany")]
        public required string Status { get; set; }

        [ForeignKey("Klient")]
        public int IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("Uzytkownik")]
        public int IdUzytkownika { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }

        [ForeignKey("ProduktUbezpieczeniowy")]
        public int IdProduktuUbezpieczeniowego { get; set; }
        public ProduktUbezpieczeniowy? ProduktUbezpieczeniowy { get; set; }

        [ForeignKey("Oferta")]
        public int? IdOferty { get; set; }
        public Oferta? Oferta { get; set; }


        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;
        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}
