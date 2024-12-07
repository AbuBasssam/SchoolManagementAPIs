using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class PaginatingResult
    {
        public int NumberOfPages { get; set; }
        public  int TotalCount { get; set; }
    }
}
