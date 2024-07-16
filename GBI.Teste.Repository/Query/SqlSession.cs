using GBI.Teste.Repository.Context;
using System.Data;
using System.Data.SqlClient;

namespace GBI.Teste.Repository.Query
{
    public sealed class SqlSession : IDisposable
    {
        #region construtores

        /// <summary>
        /// construtor da classe SqlSession
        /// </summary>
        /// <param name="context">contexto de dados de dados</param>
        public SqlSession(GBITesteSqlContext context)
        {
            SqlConnection = new SqlConnection(context.SqlConnString);
        }

        #endregion

        #region métodos

        /// <summary>
        /// enderra a conexão com o banco de dados
        /// </summary>
        public void Dispose() => SqlConnection.Close();

        #endregion

        #region propriedades

        public IDbConnection SqlConnection { get; private set; }

        #endregion

        #region destrutor

        ~SqlSession(){ Dispose(); }

        #endregion
    }
}
