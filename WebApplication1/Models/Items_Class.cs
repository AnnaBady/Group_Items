namespace WebApplication1.Models
{
    public class Items_Class
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ItemImage { get; set; }

        public Groups_Class Groups { get; set; }

    }
}
