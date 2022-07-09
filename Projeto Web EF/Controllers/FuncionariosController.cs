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
    public class FuncionariosController : Controller
    {
        private readonly EFContexto _context;

        public FuncionariosController(EFContexto context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
              return View(new FuncionariosNegocio(_context).PesquisarTodos());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var funcionarios = new FuncionariosNegocio(_context).PesquisarPorId(id);    
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomedoFuncionario,NumerodaCarteiradeTrabalho,Cpf,Função")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarios);
                new FuncionariosNegocio(_context).Incluir(funcionarios);
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarios);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var funcionarios = new FuncionariosNegocio(_context).PesquisarPorId(id);
            if (funcionarios == null)
            {
                return NotFound();
            }
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomedoFuncionario,NumerodaCarteiradeTrabalho,Cpf,Função")] Funcionarios funcionarios)
        {
            if (id != funcionarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    new FuncionariosNegocio(_context).Atualizar(funcionarios);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionariosExists(funcionarios.Id))
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
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var funcionarios = new FuncionariosNegocio(_context).PesquisarPorId(id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'EFContexto.Funcionarios'  is null.");
            }
            var funcionarios = new FuncionariosNegocio(_context).PesquisarPorId(id);
            if (funcionarios != null)
            {
                new FuncionariosNegocio(_context).Excluir(funcionarios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionariosExists(int id)
        {
          return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
