using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain.Entities;
using NetChallenge.Domain.Entities.Common;

namespace NetChallenge.Persistence.Context
{
    public class MsSqlDbContext : DbContext
    {
        #region CTOR
        public MsSqlDbContext(DbContextOptions options) : base(options) { }
        #endregion

        #region Entity 
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        #endregion

        #region On Model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>()
                .HasMany(c => c.CarrierConfigurations)
                .WithOne(cc => cc.Carrier)
                .HasForeignKey(cc => cc.CarrierId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Carrier)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CarrierId);

        }

        #endregion

        // Ready
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedAt = DateTime.UtcNow,
                    EntityState.Deleted => data.Entity.DeletedAt = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
