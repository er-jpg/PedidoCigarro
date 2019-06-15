using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PedidoCigarro.Models;

namespace PedidoCigarro.Models
{
    public class Cigarro
    {
        [Key]
        [Display(Name = "Registro")]
        public int? IdCigarro { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        [Display(Name = "Cigarro")]
        public string NomeCigarro { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}