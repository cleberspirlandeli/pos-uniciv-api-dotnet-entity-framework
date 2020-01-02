using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorasController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public EditorasController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editora>>> GetAll()
        {
            return await _context.Editoras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editora>> GetById(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);

            if (editora == null)
                return NotFound();

            return editora;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Editora editora)
        {
            _context.Editoras.Add(editora);
            await _context.SaveChangesAsync();

            return Ok(editora);
        }

    }
}