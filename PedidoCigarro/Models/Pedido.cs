using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PedidoCigarro.Models;

namespace PedidoCigarro.Models
{
    public class Pedido
    {
        [Key]
        [Display(Name = "Registro")]
        public int? IdPedido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pedido é obrigatório.")]
        [Display(Name = "Pedido")]
        public string NomePedido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Data é obrigatória.")]
        [Display(Name = "Realizado")]
        [Column(TypeName = "Date")]
        public DateTime Data { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Valor total é obrigatório.")]
        [Display(Name = "Total")]
        public float Total { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Pago { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CEP é obrigatório.")]
        [StringLength(8, ErrorMessage = "Tamanho inválido para CEP")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Rua é obrigatório.")]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bairro é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O tamanho máximo para a rua é de 255 caracteres")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Cidade é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O tamanho máximo para a cidade é de 255 caracteres")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado é obrigatório.")]
        [StringLength(2)]
        [Display(Name = "UF")]
        public string UF { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Número é obrigatório.")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        // Foreign keys
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório escolher um cigarro.")]
        public int? IdCigarro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório escolher um Corredor.")]
        public int? IdCorredor { get; set; }

        public Cigarro Cigarro { get; set; }
        public Corredor Corredor { get; set; }
    }
}