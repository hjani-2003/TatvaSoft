using Microsoft.AspNetCore.Mvc;
using Practice_Books.Models;
using Practice_Books.Services;

namespace Practice_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookServices _bookService;
        public BooksController(BookServices bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Books>> Get() => _bookService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Books> Get(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
        [HttpPost]
        public ActionResult<Books> Post(Books book)
        {
            _bookService.Add(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Books book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = _bookService.GetById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _bookService.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
