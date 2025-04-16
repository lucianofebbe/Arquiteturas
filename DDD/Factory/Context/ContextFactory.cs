using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DbContext = Infrastructure.Data.Context.Context;

namespace Factory.Context
{
    //Para rodar as migrações use o cmd abaixo
    //dotnet ef migrations add NomeDaMigration -s Factory -p Infrastructure

    public class ContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
        public DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=C:\Users\lucia\Documents\Empresa\Arquiteturas\DDD\Infrastructure\Data\Db\DataBaseDDD.mdf;
                    Integrated Security=True;
                    Connect Timeout=30");

            return new DbContext(optionsBuilder.Options);
        }
    }
}
