using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GBI.Teste.WebApi.Model.Cadastro
{
    public class UsuarioViewModel
    {
        #region propriedades

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("rg")]
        public string RG { get; set; }

        [JsonPropertyName("dataEmissao")]
        public DateTime DataEmissao { get; set; }

        [JsonPropertyName("cpf")]
        public string CPF { get; set; }

        [JsonPropertyName("celular")]
        public long Celular { get; set; }

        [JsonPropertyName("dataCadastro")]
        public DateTime DataCadastro { get; set; }

        #endregion
    }
}