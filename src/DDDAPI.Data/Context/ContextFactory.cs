using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DDDAPI.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        public ContextDB CreateDbContext(string[] args)
        {
            //Usado para criar as Migrações
            var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=<NomeBanco>;Uid=root;Pwd=<SenhaBanco>";
            var optionsBuilder = new DbContextOptionsBuilder<ContextDB> ();
            optionsBuilder.UseMySql (connectionString, new MySqlServerVersion(new Version(8, 0 , 21)),
                mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
            );
            return new ContextDB (optionsBuilder.Options);
        }
    }
}
