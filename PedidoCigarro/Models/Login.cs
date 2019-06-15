using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PedidoCigarro.Models
{
    public class Login
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}