using GBI.Teste.Repository.Interface;
using GBI.Teste.Model.Cadastro;
using GBI.Teste.Repository.Context;

namespace GBI.Teste.Repository
{
    public class UsuarioCommand : ICommand<UsuarioModel>
    {
        #region atributos

        private readonly GBITesteSqlContext _context;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe UsuarioCommand
        /// </summary>
        /// <param name="context">contexto do banco de dados</param>
        public UsuarioCommand(GBITesteSqlContext context)
        {
            _context = context;
        }

        #endregion

        #region métodos

        /// <summary>
        /// método utilizada para efetiar o cadastro do usuário na base de dados
        /// </summary>
        /// <param name="entity">entidade UsuarioModel</param>
        public void Incluir(UsuarioModel entity)
        {
            _context.Add(UsuarioModel.UsuarioFactory.ObterModel(entity.Id, entity.Nome, entity.RG, entity.DataEmissao, entity.CPF, entity.Celular, entity.DataCadastro));
            _context.SaveChanges();
        }

        /// <summary>
        /// método utilizada para alterar o registro do usuário na base de dados
        /// </summary>
        /// <param name="entity">entidade UsuarioModel</param>
        public void Alterar(UsuarioModel entity)
        {
            _context.Update(UsuarioModel.UsuarioFactory.ObterModel(entity.Id, entity.Nome, entity.RG, entity.DataEmissao, entity.CPF, entity.Celular, entity.DataCadastro));
            _context.SaveChanges();
        }

        /// <summary>
        /// método utilizada para excluir o registro do usuário na base de dados
        /// </summary>
        /// <param name="id">id do registro de usuário</param>
        public void Excluir(Guid id)
        {
            _context.Remove(UsuarioModel.UsuarioFactory.ObterModel(id));
            _context.SaveChanges();
        }

        #endregion
    }
}