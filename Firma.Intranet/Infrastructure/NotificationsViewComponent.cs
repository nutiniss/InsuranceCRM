using Firma.Data.Data;
using Firma.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Infrastructure;

public class NotificationsViewComponent : ViewComponent
{
    private readonly FirmaContext _context;

    public NotificationsViewComponent(FirmaContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var unreadMessages = await _context.Wiadomosc.CountAsync(w => !w.CzyPrzeczytana);
        var newTickets = await _context.Zgloszenie.CountAsync(z => z.Status == "Nowe");

        var items = new List<NotificationItemViewModel>();
        if (unreadMessages > 0)
        {
            items.Add(new NotificationItemViewModel
            {
                Title = "Nowe wiadomości",
                Description = $"Nieprzeczytane wiadomości: {unreadMessages}",
                Icon = "bi-envelope-exclamation",
                Controller = "Wiadomosc",
                Action = "Index"
            });
        }

        if (newTickets > 0)
        {
            items.Add(new NotificationItemViewModel
            {
                Title = "Nowe zgłoszenia klientów",
                Description = $"Zgłoszenia ze statusem Nowe: {newTickets}",
                Icon = "bi-life-preserver",
                Controller = "Zgloszenie",
                Action = "Index"
            });
        }

        return View(new NotificationViewModel
        {
            UnreadMessagesCount = unreadMessages,
            NewTicketsCount = newTickets,
            Items = items
        });
    }
}
