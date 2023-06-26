using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Dtos
{
    public class ProductDto : Entity
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Id do Cliente deve ser diferente de 0")]
        public long CustomerId { get; set; }
    }
}
