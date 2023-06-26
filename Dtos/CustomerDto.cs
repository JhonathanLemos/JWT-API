using NetCoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Dtos
{
    public class CustomerDto : Entity
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        public string NomeCliente { get; set; }
    }
}
