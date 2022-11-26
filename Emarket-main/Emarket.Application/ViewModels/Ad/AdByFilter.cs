using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Core.Application.ViewModels.Ad
{
    public class AdByFilter
    {
        public List<int>? categoryId { get; set; } = new();
        public string? keyword { get; set; }
    }
}
