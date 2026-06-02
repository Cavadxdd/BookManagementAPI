using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.DTOs;
using BookManagement.Application.Interfaces;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Enums;

namespace BookManagement.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();

        return books.Select(b => MapToDto(b));
    }

    public async Task<BookDto?> GetByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
            return null;

        return MapToDto(book);
    }

    public async Task<BookDto> CreateAsync(CreateBookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Year = dto.Year,
            Price = dto.Price,
            Genre = dto.Genre
        };

        var created = await _bookRepository.CreateAsync(book);
        return MapToDto(created);
    }

    public async Task<BookDto?> UpdateAsync(int id, UpdateBookDto dto)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
            return null;

        book.Title = dto.Title;
        book.Author = dto.Author;
        book.Year = dto.Year;
        book.Price = dto.Price;
        book.Genre = dto.Genre;


        await _bookRepository.UpdateAsync(book);
        return MapToDto(book);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _bookRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BookDto>> GetByGenreAsync(Genre genre)
    {
        var books = await _bookRepository.GetByGenreAsync(genre);
        return books.Select(b => MapToDto(b));
    }

    private static BookDto MapToDto(Book book) => new BookDto
    {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        Year = book.Year,
        Price = book.Price,
        Genre = book.Genre.ToString()
    };
}
