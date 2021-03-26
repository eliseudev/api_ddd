using DDDAPI.Data.MappingEntity;
using DDDAPI.Data.Seeds;
using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Context
{
    public class ContextDB : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<ItemICMSEntity> ItemICMSs { get; set; }
        public DbSet<ItemPisCofinsEntity> ItemPisCofinss { get; set; }
        public DbSet<MunicipioEntity> Municipios { get; set; }
        public DbSet<UFEntity> UFs { get; set; }
        public DbSet<UsuarioAPIEntity> UsuarioAPIs { get; set; }

        public ContextDB (DbContextOptions<ContextDB> options) : base (options) {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            
            modelBuilder.Entity<CEPEntity> (new CEPMap().Configure);

            //Exigindo que para cada item exija um ItemPisCofins
            modelBuilder.Entity<ItemEntity> (new ItemMap().Configure);
            modelBuilder.Entity<ItemICMSEntity> (new ItemICMSMap().Configure);
            modelBuilder.Entity<ItemPisCofinsEntity> (new ItemPisCofinsMap().Configure);
            modelBuilder.Entity<MunicipioEntity> (new MunicipioMap().Configure);
            modelBuilder.Entity<UFEntity> (new UFMap().Configure);
            modelBuilder.Entity<UsuarioAPIEntity> (new UsuarioAPIMap().Configure);


            UFSeeds.PovoarUFs(modelBuilder);
        }
    }
}
