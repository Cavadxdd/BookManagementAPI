using BookManagement.Application.DTOs;
using BookManagement.Application.Interfaces;
using BookManagement.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _bookService.GetByIdAsync(id);

        if (book is null)
            return NotFound($"Book with id {id} not found.");

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
    {
        var created = await _bookService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookDto dto)
    {
        var updated = await _bookService.UpdateAsync(id, dto);

        if (updated is null)
            return NotFound($"Book with id {id} not found.");

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _bookService.DeleteAsync(id);

        if (!result)
            return NotFound($"Book with id {id} not found.");

        return NoContent(); 
    }

    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetByGenre(Genre genre)
    {
        var books = await _bookService.GetByGenreAsync(genre);
        return Ok(books);
    }

}