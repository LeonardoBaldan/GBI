using GBI.Teste.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace GBi.Teste.UnitTest.Helpers
{
    public class MockDb : IDbContextFactory<UsuarioDbContext>
    {
        public UsuarioDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<UsuarioDbContext>()
                .UseInMemoryDatabase($"InMemorySqlServer-{DateTime.Now.ToFileTimeUtc}")
                .Options;

            return new UsuarioDbContext(options);
        }
    }
}
