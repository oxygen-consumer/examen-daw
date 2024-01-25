using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Product";

        public IList<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
