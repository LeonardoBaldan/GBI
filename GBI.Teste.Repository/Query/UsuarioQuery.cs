using GBI.Teste.Model.Cadastro;
using GBI.Teste.Repository.Interface;
using Dapper;
using System.Text;
using GBI.Teste.Repository.Context;

namespace GBI.Teste.Repository.Query
{
    public class UsuarioQuery : IQuery<UsuarioModel>
    {
        #region atributos

        private readonly SqlSession _dbSession;

        #endregion

        #region construtores

        public UsuarioQuery(GBITesteSqlContext context)
        {
            _dbSession = new SqlSession(context);
        }

        #endregion


        #region métodos

        /// <summary>
        /// método utilizado para obter o registro pelo id do usuário
        /// </summary>
        /// <param name="id">id de registro do usuário</param>
        /// <returns>retorna o registro a partir do id do usuário informado</returns>
        public UsuarioModel? Obter(Guid id)
            => _dbSession.SqlConnection.Query<UsuarioModel>($"{Query} where Id = '{ id }'", new { Id = id }).FirstOrDefault();

        /// <summary>
        /// método utilizado para obter a lista dos usuários cadastrados
        /// </summary>
        /// <returns>retorna a lista completa de usuários cadastrados</returns>
        public IEnumerable<UsuarioModel> Listar()
            => _dbSession.SqlConnection.Query<UsuarioModel>($"{Query}");

        #endregion

        #region propriedades

        private StringBuilder Query => new StringBuilder()
                .Append(" select Id")
                .Append(", Nome")
                .Append(", RG")
                .Append(", DataEmissao")
                .Append(", CPF")
                .Append(", Celular")
                .Append(", DataCadastro")
                .Append(" from tb_gbi_usuario");

        #endregion
    }
}
