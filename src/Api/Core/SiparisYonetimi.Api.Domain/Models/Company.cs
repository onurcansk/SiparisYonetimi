namespace SiparisYonetimi.Api.Domain.Models
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public bool isActive { get; set; }
        public TimeSpan OrderReleaseStartTime { get; set; }
        public TimeSpan OrderReleaseEndTime { get; set; }
        public virtual ICollection<Product> ProductList { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
