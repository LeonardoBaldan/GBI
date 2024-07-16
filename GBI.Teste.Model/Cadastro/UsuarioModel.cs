using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GBI.Teste.Model.Cadastro
{
    public class UsuarioModel
    {
        #region propriedades

        [Required]
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(70)]
        [JsonPropertyName("nome")]
        public string Nome { get; private set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(15)]
        [JsonPropertyName("rg")]
        public string RG { get; private set; }

        [Required]
        [Column(TypeName = "datetime")]
        [JsonPropertyName("dataEmissao")]
        public DateTime DataEmissao { get; private set; }

        [Required]
        [Column(TypeName = "char")]
        [StringLength(11)]
        [JsonPropertyName("cpf")]
        public string CPF { get; private set; }

        [Required]
        [Column(TypeName = "bigint")]
        [JsonPropertyName("celular")]
        public long Celular { get; private set; }

        [Required]
        [Column(TypeName = "DateTime")]
        [JsonPropertyName("dataCadastro")]
        public DateTime DataCadastro { get; private set; }

        #endregion

        #region factory

        public static class UsuarioFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">código de registro do usuário</param>
            /// <param name="nome">nome do usuário</param>
            /// <param name="rg">rg do usuário</param>
            /// <param name="dataEmissao">data de emissão do rg</param>
            /// <param name="cpf">cpf do usuário</param>
            /// <param name="celular">celular do usuário</param>
            /// <param name="dataCadastro">data de cadastro do usuário</param>
            /// <returns>retorna o model com os dados para o cadastro do usuário</returns>
            public static UsuarioModel ObterModel(Guid id,
                string nome,
                string rg,
                DateTime dataEmissao,
                string cpf,
                long celular,
                DateTime dataCadastro) => new UsuarioModel
                {
                    Id = id,
                    Nome = nome,
                    RG = rg,
                    DataEmissao = dataEmissao,
                    CPF = cpf,
                    Celular = celular,
                    DataCadastro = dataCadastro
                };

            /// <summary>
            /// obtém o model com o id do registro do usuário
            /// </summary>
            /// <param name="id"></param>
            /// <returns>retorna o model com os dados para o cadastro do usuário</returns>
            public static UsuarioModel ObterModel(Guid id)
            => new UsuarioModel
            {
                Id = id
            };
        }

        #endregion
    }
}