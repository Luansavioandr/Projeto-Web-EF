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
    public class CarroController : Controller
    {
        private readonly EFContexto _context;

        public CarroController(EFContexto context)
        {
            _context = context;
        }

        // GET: Carro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.ToListAsync());
        }

        // GET: Carro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carro/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cor,Ano,Placa")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                new CarroNegocio(_context).Incluir(carro);
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carro/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var carro = new CarroNegocio(_context).PesquisarPorId(id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cor,Ano,Placa")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    new CarroNegocio(_context).Atualizar(carro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
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
            return View(carro);
        }

        // GET: Carro/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            new CarroNegocio(_context).Excluir(new Carro { Id = id });

            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}
