using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Firma.Intranet.Models.Ubezpieczenia;

    public class FirmaContext : DbContext
    {
        public FirmaContext (DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<Firma.Intranet.Models.Ubezpieczenia.Oferta> Oferta { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.Klient> Klient { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.OfertaMarketingowa> OfertaMarketingowa { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.ProduktUbezpieczeniowy> ProduktUbezpieczeniowy { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.Uzytkownik> Uzytkownik { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.Wiadomosc> Wiadomosc { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.Wycena> Wycena { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.Zadanie> Zadanie { get; set; } = default!;

public DbSet<Firma.Intranet.Models.Ubezpieczenia.Zgloszenie> Zgloszenie { get; set; } = default!;
    }
