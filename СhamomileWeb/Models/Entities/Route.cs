using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace СhamomileWeb.Models.Entities
{
    public class Route
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public string Dispatch { get; set; }
        [Required]
        public string Delivery { get; set; }
        [Required]
        public double Distance { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }
    }
}
