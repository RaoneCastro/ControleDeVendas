using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class ProdutoModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Informe o Nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Descrição do produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o Preco Unitário do produto")]
        public decimal? Preco_Unitario { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade em Estoque do produto")]
        public decimal? Quantidade_Estoque { get; set; }

        [Required(ErrorMessage = "Informe a Unidade de Medida do produto")]
        public string Unidade_Medida { get; set; }

        [Required(ErrorMessage = "Informe o Link da Imagem do produto")]
        public string Link_Foto { get; set; }

    }
}
