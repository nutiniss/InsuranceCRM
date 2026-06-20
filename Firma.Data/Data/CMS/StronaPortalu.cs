using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.CMS;

public class StronaPortalu : ISoftDeletable
{
    [Key]
    [Display(Name = "Strona portalu")]
    public int IdStronyPortalu { get; set; }

    [Required(ErrorMessage = "Wpisz adres strony")]
    [MaxLength(80, ErrorMessage = "Adres strony może mieć maksymalnie 80 znaków")]
    [RegularExpression("^[a-z0-9-]+$", ErrorMessage = "Adres może zawierać tylko małe litery, cyfry i myślniki")]
    [Display(Name = "Adres strony")]
    public required string Slug { get; set; }

    [Required(ErrorMessage = "Wpisz tytuł w menu")]
    [MaxLength(40, ErrorMessage = "Tytuł w menu może mieć maksymalnie 40 znaków")]
    [Display(Name = "Tytuł w menu")]
    public required string TytulMenu { get; set; }

    [Required(ErrorMessage = "Wpisz tytuł strony")]
    [MaxLength(120, ErrorMessage = "Tytuł strony może mieć maksymalnie 120 znaków")]
    [Display(Name = "Tytuł strony")]
    public required string Tytul { get; set; }

    [MaxLength(160, ErrorMessage = "Nagłówek pomocniczy może mieć maksymalnie 160 znaków")]
    [Display(Name = "Nagłówek pomocniczy")]
    public string? NaglowekPomocniczy { get; set; }

    [Required(ErrorMessage = "Wpisz treść strony")]
    [Column(TypeName = "nvarchar(MAX)")]
    [Display(Name = "Treść")]
    public required string Tresc { get; set; }

    [Required(ErrorMessage = "Wpisz kolejność wyświetlania")]
    [Display(Name = "Kolejność")]
    public int Kolejnosc { get; set; }

    [Display(Name = "Widoczna w menu")]
    public bool CzyWidocznaWMenu { get; set; } = true;

    [Display(Name = "Aktywna")]
    public bool CzyAktywna { get; set; } = true;

    [Display(Name = "Data utworzenia")]
    public DateTime DataUtworzenia { get; set; } = DateTime.Now;

    [Display(Name = "Data modyfikacji")]
    public DateTime? DataModyfikacji { get; set; }

    [Display(Name = "Status rekordu")]
    public string StatusRekordu { get; set; } = RecordStatus.Active;
}
