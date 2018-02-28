using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace СhamomileWeb.Models.Entities
{
    public class Category
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
