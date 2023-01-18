using System;
using System.Collections.Generic;

namespace SiparisYonetimi.Common.Models.QueryModels
{
    public class CompanyDetailViewModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public bool isActive { get; set; }
        public string OrderReleaseStartTime { get; set; }
        public string OrderReleaseEndTime { get; set; }
        public virtual ICollection<ProductDetailViewModel> ProductList { get; set; }
        public virtual ICollection<OrderDetailViewModel> Orders { get; set; }
    }
}
