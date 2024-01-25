using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; } = "User";

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
