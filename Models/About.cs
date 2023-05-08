﻿using System.ComponentModel.DataAnnotations;

namespace url_shortener.Models
{
    public class About
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
