using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Common;

public interface ISoftDeletable
{
    [Display(Name = "Status rekordu")]
    string StatusRekordu { get; set; }
}
