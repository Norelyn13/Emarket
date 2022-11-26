using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Core.Application.ViewModels.Ad
{
    public class AdsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Urls { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public DateTime? LastUpdate { get; set; }
        public DateTime Creadted { get; set; }
        public string CreatedBy { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
