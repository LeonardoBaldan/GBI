using GBI.Teste.Model.Cadastro;
using GBI.Teste.Repository.Context;

namespace GBI.Teste.WebApi
{
    public class UsuarioEndPoint
    {
        public static IResult IncluirUsuario(UsuarioModel p, UsuarioDbContext db)
        {
            db.Add(p);
            db.SaveChanges();

            return Results.Ok($"Usuário {p.Id} cadastrado com sucesso!");
        }
    }
}
