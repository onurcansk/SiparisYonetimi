using MediatR;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiparisYonetimi.Common.Models.RequestModels
{
    public class UpdateCompanyCommand : IRequest<Guid>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        [DefaultValue("07:30:00")]
        public string OrderReleaseStartTime { get; set; }
        [Required]
        [DefaultValue("10:30:00")]
        public string OrderReleaseEndTime { get; set; }
    }
}
