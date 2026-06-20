namespace Firma.Intranet.Models;

public class NotificationViewModel
{
    public int UnreadMessagesCount { get; set; }
    public int NewTicketsCount { get; set; }
    public IReadOnlyList<NotificationItemViewModel> Items { get; set; } = [];
    public int TotalCount => UnreadMessagesCount + NewTicketsCount;
}

public class NotificationItemViewModel
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Icon { get; set; }
    public required string Controller { get; set; }
    public required string Action { get; set; }
}
