using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Dtos
{
    public class CreateProductDto : Entity
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório")]
        public long CustomerId { get; set; }
    }
}
