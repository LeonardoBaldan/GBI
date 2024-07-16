using GBi.Teste.UnitTest.Helpers;
using GBI.Teste.Model.Cadastro;
using GBI.Teste.WebApi;
using GBI.Teste.WebApi.Model.Cadastro;
using System;
using Xunit;

namespace GBi.Teste.UnitTest
{
    public class UsuarioTeste
    {
        [Fact]
        public async void CriarUsuarioNoBancoDeDados()
        {
            // Arrange
            var usuario = new UsuarioViewModel()
            {
                Id = new Guid("3687E632-E386-49FF-9304-F98840B65BA1"),
                Nome = "Leonardo Baldan Azevedo",
                RG = "24402327X",
                DataEmissao = DateTime.Now,
                CPF = "25234113850",
                Celular = 997870433,
                DataCadastro = DateTime.Now
            };

            var entity = UsuarioModel.UsuarioFactory.ObterModel(usuario.Id,
                usuario.Nome,
                usuario.RG,
                usuario.DataEmissao,
                usuario.CPF,
                usuario.Celular,
                usuario.DataCadastro);

            await using var context = new MockDb().CreateDbContext();

            // Act
            var result = UsuarioEndPoint.IncluirUsuario(entity, context);

            // Asserts
            Assert.NotNull(result);
            Assert.Collection(context.tb_gbi_usuario, usuario =>
            {
                Assert.Equal(new Guid("3687E632-E386-49FF-9304-F98840B65BA1"), usuario.Id);
                Assert.Equal("Leonardo Baldan Azevedo", entity.Nome);
                Assert.Equal("25234113850", usuario.CPF);
                Assert.Equal("24402327X", usuario.RG);
                Assert.Equal(997870433, usuario.Celular);
            });
        }
    }
}