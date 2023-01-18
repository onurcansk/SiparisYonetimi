using System;
using System.Collections.Generic;

namespace SiparisYonetimi.Common.Models.QueryModels
{
    public class OrderDetailViewModel
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<ProductDetailViewModel> Products { get; set; }
    }
}
