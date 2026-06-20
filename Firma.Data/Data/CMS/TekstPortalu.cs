using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Common;

namespace Firma.Data.Data.CMS;

public class TekstPortalu : ISoftDeletable
{
    [Key]
    [Display(Name = "Tekst portalu")]
    public int IdTekstuPortalu { get; set; }

    [Required(ErrorMessage = "Wpisz klucz tekstu")]
    [MaxLength(120, ErrorMessage = "Klucz może mieć maksymalnie 120 znaków")]
    [Display(Name = "Klucz")]
    public required string Klucz { get; set; }

    [Required(ErrorMessage = "Wpisz tytuł")]
    [MaxLength(120, ErrorMessage = "Tytuł może mieć maksymalnie 120 znaków")]
    [Display(Name = "Tytuł")]
    public required string Tytul { get; set; }

    [Required(ErrorMessage = "Wpisz treść")]
    [Column(TypeName = "nvarchar(MAX)")]
    [Display(Name = "Treść")]
    public required string Tresc { get; set; }

    [Display(Name = "Kolejność")]
    public int Kolejnosc { get; set; }

    [Display(Name = "Aktywny")]
    public bool CzyAktywny { get; set; } = true;

    [Display(Name = "Data utworzenia")]
    public DateTime DataUtworzenia { get; set; } = DateTime.Now;

    [Display(Name = "Data modyfikacji")]
    public DateTime? DataModyfikacji { get; set; }

    [Display(Name = "Status rekordu")]
    public string StatusRekordu { get; set; } = RecordStatus.Active;
}
