using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookManagement.Domain.Enums;

namespace BookManagement.Application.DTOs
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(100)]
        public string Author { get; set; }

        [Range(1000, 2100, ErrorMessage = "Year must be between 1000 and 2100")]
        public int Year { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public Genre Genre { get; set; }
    }
}
