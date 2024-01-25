using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Order";

        public IList<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
