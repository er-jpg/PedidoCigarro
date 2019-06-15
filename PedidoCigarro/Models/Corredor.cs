using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using PedidoCigarro.Models;

namespace PedidoCigarro.Models
{
    // Vem serializar tudo, meu amor
    [DataContract]
    public class Corredor
    {
        public Corredor() { }

        // faz outro construtor, vai, mas pra gerar o JSON também pfv
        public Corredor(string label, int y)
        {
            this.NomeCorredor = label;
            this.QtdePedidos = y;
        }

        [Key]
        [Display(Name = "Registro")]
        public int? IdCorredor { get; set; }

        [Required]
        [MaxLength(200), MinLength(5)]
        [Display(Name = "Corredor")]
        // mostra quem é que manda no esquema
        [DataMember(Name = "label")]
        public string NomeCorredor { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        [Display(Name = "Carro")]
        public string Carro { get; set; }

        [Required]
        [Display(Name = "Realizados")]
        // mostra quem é o resultado do esquema
        [DataMember(Name = "y")]
        public int QtdePedidos { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}