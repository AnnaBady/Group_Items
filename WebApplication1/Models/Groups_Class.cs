using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace WebApplication1.Models
{
    public class Groups_Class
    {
        public Groups_Class()
        {
            Items = new HashSet<Items_Class>();
        }
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<Items_Class> Items { get; set; }
    }
}
