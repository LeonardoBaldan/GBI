namespace GBI.Teste.Repository.Interface
{
    public interface IQuery<T> where T : class
    {
        #region métodos

        IEnumerable<T> Listar();

        T? Obter(Guid id);

        #endregion
    }
}
