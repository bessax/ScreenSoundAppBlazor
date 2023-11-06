using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.Shared.Context;

public class ScreenSoundContext: IdentityDbContext
{
    public ScreenSoundContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound3;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound3;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString);
    }
}
