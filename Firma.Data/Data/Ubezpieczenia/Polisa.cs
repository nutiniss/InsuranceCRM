using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Polisa : ISoftDeletable
    {
        [Key]
        [Display(Name = "Polisa")]
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
        [Display(Name = "Status polisy")]
        public required string Status { get; set; }

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

        [ForeignKey("Oferta")]
        [Display(Name = "Oferta")]
        public int? IdOferty { get; set; }
        [Display(Name = "Oferta")]
        public Oferta? Oferta { get; set; }


        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;
        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}
