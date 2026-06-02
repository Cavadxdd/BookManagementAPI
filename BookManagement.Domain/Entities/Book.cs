using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using BookManagement.Domain.Enums;

namespace BookManagement.Domain.Entities;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    public int Year { get; set; }

    public decimal Price { get; set; }

    public Genre Genre { get; set; }
}