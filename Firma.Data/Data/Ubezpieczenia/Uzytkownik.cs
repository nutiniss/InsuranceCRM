using System.ComponentModel.DataAnnotations;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia
{
    public class Uzytkownik : ISoftDeletable
    {
        [Key]
        public int IdUzytkownika { get; set; }

        [Required(ErrorMessage = "Imię użytkownika jest wymagane")]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko użytkownika jest wymagane")]
        public required string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail")]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Rola użytkownika jest wymagana")]
        public required string Rola { get; set; }

        [Display(Name = "Aktywny")]
        public bool CzyAktywny { get; set; } = true;


        [Display(Name = "Status rekordu")]
        public string StatusRekordu { get; set; } = RecordStatus.Active;
        public ICollection<Oferta> Oferty { get; set; } = new List<Oferta>();
        public ICollection<Polisa> Polisy { get; set; } = new List<Polisa>();
        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
        public ICollection<Wiadomosc> Wiadomosci { get; set; } = new List<Wiadomosc>();
        public ICollection<OfertaMarketingowa> OfertyMarketingowe { get; set; } = new List<OfertaMarketingowa>();
    }
}
