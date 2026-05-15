using System.ComponentModel.DataAnnotations;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.Ubezpieczenia;

public class PozycjaSlownika : ISoftDeletable
{
    [Key]
    [Display(Name = "Pozycja słownika")]
    public int IdPozycjiSlownika { get; set; }

    [Required(ErrorMessage = "Typ słownika jest wymagany")]
    [StringLength(100)]
    [Display(Name = "Typ słownika")]
    public required string Typ { get; set; }

    [Required(ErrorMessage = "Wartość słownika jest wymagana")]
    [StringLength(200)]
    [Display(Name = "Wartość")]
    public required string Wartosc { get; set; }

    [Display(Name = "Kolejność")]
    public int Kolejnosc { get; set; }

    [Display(Name = "Aktywna")]
    public bool CzyAktywna { get; set; } = true;

    [Display(Name = "Status rekordu")]
    public string StatusRekordu { get; set; } = RecordStatus.Active;
}
