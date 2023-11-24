﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookVilla.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Price per night")]
        [Range(10, 10000)]
        public double Price { get; set; }
        public int Sqft { get; set; }
        [Range(1, 10)]
        public int Occupancy { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }
    }
}
