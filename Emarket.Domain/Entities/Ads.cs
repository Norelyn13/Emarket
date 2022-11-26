using Emarket.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Core.Domain.Entities
{
    public class Ads : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? UrlPrimary { get; set; }
        public string? UrlSecondary { get; set; }
        public string? UrlThird { get; set; }
        public string? UrlFourth { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        //Navigation Property
        public Category Category { get; set; }
        public User User { get; set; }



    }
}
