using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [MinLength(2)]
        public string WedderOne { get; set; }

        [Required]
        [MinLength(2)]
        public string WedderTwo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime WeddingDate { get; set; }

        [Required]
        [MinLength(6)]
        public string Address { get; set; }

        [Required]
        public int UserId { get; set; }
        
        public List<Connection> Guests { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}