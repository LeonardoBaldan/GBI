using GBI.Teste.Model.Cadastro;
using Microsoft.EntityFrameworkCore;

namespace GBI.Teste.Repository.Context
{
    public class GBITesteSqlContext : DbContext
    {
        #region construtores

        /// <summary>
        /// construtor da classe GBITesteSqlContext
        /// </summary>
        /// <param name="options">opções de configuração para acesso aos componentes do banco de dados</param>
        public GBITesteSqlContext(DbContextOptions<GBITesteSqlContext> options) : base(options)
        {
            SqlConnString = base.Database.GetConnectionString();
        }

        #endregion

        #region propriedades do banco de dados

        public string? SqlConnString { get; private set; }
        public DbSet<UsuarioModel>? tb_gbi_usuario { get; set; }

        #endregion
    }
}
