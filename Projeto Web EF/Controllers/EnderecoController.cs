using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;
using Projeto_Web_EF.Negocio;

namespace Projeto_Web_EF.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EFContexto _context;

        public EnderecoController(EFContexto context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index()
        {
            return View(new EnderecoNegocio(_context).PesquisarTodos());
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var endereco = new EnderecoNegocio(_context).PesquisarPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rua,Numero,Bairro,Cidade,Cep")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                new EnderecoNegocio(_context).Incluir(endereco);
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var endereco = new EnderecoNegocio(_context).PesquisarPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rua,Numero,Bairro,Cidade,Cep")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    new EnderecoNegocio(_context).Atualizar(endereco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var endereco = new EnderecoNegocio(_context).PesquisarPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Endereco == null)
            {
                return Problem("Entity set 'EFContexto.Endereco'  is null.");
            }
            var endereco = new EnderecoNegocio(_context).PesquisarPorId(id);
            if (endereco != null)
            {
                new EnderecoNegocio(_context).Excluir(endereco);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
          return _context.Endereco.Any(e => e.Id == id);
        }
    }
}
