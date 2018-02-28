using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace СhamomileWeb.Models.Entities
{
    public class RouteTable
    {
        public int Id { get; set; }
        public string Dispatch { get; set; }
        public string Delivery { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int OrderCount { get; set; }
        public int CanceledCount { get; set; }
        public int CompletedCount { get; set; }
        public int RefundedCount { get; set; }
        public double Percent { get; set; }
    }
}   
