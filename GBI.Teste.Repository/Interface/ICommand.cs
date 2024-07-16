namespace GBI.Teste.Repository.Interface
{
    public interface ICommand<T> where T : class
    {
        #region métodos

        void Incluir(T entity);
        void Alterar(T entity);
        void Excluir(Guid id);

        #endregion
    }
}
