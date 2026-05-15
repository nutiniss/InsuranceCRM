using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data.Ubezpieczenia;

namespace Firma.Data.Data;

public class FirmaContext : DbContext
{
    public FirmaContext(DbContextOptions<FirmaContext> options)
        : base(options)
    {
    }

    public DbSet<Oferta> Oferta { get; set; } = default!;

    public DbSet<Klient> Klient { get; set; } = default!;

    public DbSet<OfertaMarketingowa> OfertaMarketingowa { get; set; } = default!;

    public DbSet<ProduktUbezpieczeniowy> ProduktUbezpieczeniowy { get; set; } = default!;

    public DbSet<Uzytkownik> Uzytkownik { get; set; } = default!;

    public DbSet<Wiadomosc> Wiadomosc { get; set; } = default!;

    public DbSet<Wycena> Wycena { get; set; } = default!;

    public DbSet<Zadanie> Zadanie { get; set; } = default!;

    public DbSet<Zgloszenie> Zgloszenie { get; set; } = default!;

    public DbSet<Polisa> Polisa { get; set; } = default!;
}
