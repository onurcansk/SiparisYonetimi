namespace SiparisYonetimi.Api.Domain.Models
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
