using System.ComponentModel.DataAnnotations;
using Firma.Data.Data.Ubezpieczenia;

namespace Firma.PortalWWW.Models;

public class ClientPortalListViewModel<T>
{
    public required string Title { get; init; }
    public required string Eyebrow { get; init; }
    public required string Description { get; init; }
    public required string SummaryLabel { get; init; }
    public required string SummaryCaption { get; init; }
    public required IReadOnlyList<T> Items { get; init; }
}

public class ClientPortalOffersViewModel
{
    public required IReadOnlyList<Oferta> PersonalOffers { get; init; }
    public required IReadOnlyList<OfertaMarketingowa> MarketingOffers { get; init; }
}

public class ClientPortalMessagesViewModel : ClientPortalListViewModel<Wiadomosc>
{
    public required PortalMessageFormViewModel NewMessage { get; init; }
    public required IReadOnlyList<Uzytkownik> Agents { get; init; }
}

public class ClientPortalClaimsViewModel : ClientPortalListViewModel<Zgloszenie>
{
    public required PortalClaimFormViewModel NewClaim { get; init; }
    public required IReadOnlyList<Uzytkownik> Agents { get; init; }
}

public class PortalMessageFormViewModel
{
    [Required(ErrorMessage = "Wybierz agenta")]
    [Display(Name = "Agent")]
    public int IdUzytkownika { get; set; }

    [Required(ErrorMessage = "Temat wiadomości jest wymagany")]
    [StringLength(120, ErrorMessage = "Temat może mieć maksymalnie 120 znaków")]
    [Display(Name = "Temat")]
    public string Temat { get; set; } = string.Empty;

    [Required(ErrorMessage = "Treść wiadomości jest wymagana")]
    [StringLength(2000, ErrorMessage = "Treść może mieć maksymalnie 2000 znaków")]
    [Display(Name = "Treść")]
    public string Tresc { get; set; } = string.Empty;
}

public class PortalClaimFormViewModel
{
    [Required(ErrorMessage = "Tytuł zgłoszenia jest wymagany")]
    [StringLength(120, ErrorMessage = "Tytuł może mieć maksymalnie 120 znaków")]
    [Display(Name = "Tytuł")]
    public string Tytul { get; set; } = string.Empty;

    [Required(ErrorMessage = "Opis zgłoszenia jest wymagany")]
    [StringLength(2000, ErrorMessage = "Opis może mieć maksymalnie 2000 znaków")]
    [Display(Name = "Opis")]
    public string Opis { get; set; } = string.Empty;

    [Required(ErrorMessage = "Wybierz typ zgłoszenia")]
    [Display(Name = "Typ zgłoszenia")]
    public string Typ { get; set; } = "Pytanie o polisę";
}
