using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Enums;

namespace BookManagement.Application.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(Book book);
    Task UpdateAsync(Book book);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Book>> GetByGenreAsync(Genre genre);
}
