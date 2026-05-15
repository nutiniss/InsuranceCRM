using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data.Ubezpieczenia;

    public class FirmaContext : DbContext
    {
        public FirmaContext (DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<Firma.Data.Data.Ubezpieczenia.Oferta> Oferta { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.Klient> Klient { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.OfertaMarketingowa> OfertaMarketingowa { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.ProduktUbezpieczeniowy> ProduktUbezpieczeniowy { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.Uzytkownik> Uzytkownik { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.Wiadomosc> Wiadomosc { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.Wycena> Wycena { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.Zadanie> Zadanie { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.Zgloszenie> Zgloszenie { get; set; } = default!;

public DbSet<Firma.Data.Data.Ubezpieczenia.Polisa> Polisa { get; set; } = default!;
    }
