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
