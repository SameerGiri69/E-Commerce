using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain.Enum;

namespace Application.ViewModels
{
    public class AddProductViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? StockQuantity { get; set; }
        public IFormFile? ProductPhoto { get; set; }
        [ForeignKey("Category")]
        public ProductCategory? ProductCategory { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
