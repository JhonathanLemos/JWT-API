using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NetCoreAPI.Models
{
    public class Customer : Entity
    {
        public string NomeCliente { get; set; }

        [JsonIgnore]
        public IEnumerable<Product> Produtos { get; set; }
    }
}
