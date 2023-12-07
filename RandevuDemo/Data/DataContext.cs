using Microsoft.EntityFrameworkCore;
using RandevuDemo.Data.Entities;

namespace RandevuDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<KuaforDukkaniEntitiy> KuaforDukkanlari { get; set; }
        public DbSet<KuaforEntitiy> Kuaforler { get; set; }
        public DbSet<MusteriEntitiy> Musteriler { get; set; }
        public DbSet<RandevuEntitiy> Randevular { get; set; }
        public DbSet<RandevuDurumEntitiy> RandevuDurumlar { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KuaforDukkaniEntitiy>().HasMany(q => q.Kuaforler).WithOne(q => q.KuaforDukkani).HasForeignKey(q => q.KuaforDukkaniId);

            modelBuilder.Entity<RandevuEntitiy>().HasOne(q => q.Durum);
            modelBuilder.Entity<RandevuEntitiy>().HasOne(q => q.Kuafor).WithMany(q => q.Randevular).HasForeignKey(q => q.KuaforId);


        }
    }
}
