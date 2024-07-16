using GBI.Teste.Model.Cadastro;
using Microsoft.EntityFrameworkCore;

namespace GBI.Teste.Repository.Context
{
    public class UsuarioDbContext : DbContext
    {
        #region construtores

        /// <summary>
        /// construtor da classe UsuarioDbContext
        /// </summary>
        /// <param name="options">opções de configuração para acesso aos componentes do banco de dados</param>
        public UsuarioDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region propriedades do banco de dados

        public DbSet<UsuarioModel> tb_gbi_usuario { get; set; }

        #endregion
    }
}
