using System.ComponentModel.DataAnnotations;

namespace ServiceApp.Models
{
    public class ServiceOrders
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool PowerAdapter { get; set; }
        public bool IsFixed { get; set; }
    }
}
