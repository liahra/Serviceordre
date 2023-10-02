namespace Serviceordre.Models
{
    public class ServiceOrder
    {
        public int ServiceOrderID { get; set; }
        public int OrderNum { get; set; }
        public DateTime OrderDate { get; set; }
        public string? CustomerName { get; set; }
    }
}
