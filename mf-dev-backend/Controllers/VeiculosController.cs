using mf_dev_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context) 
        {
            _context = context;
        }

        // INDEX.VIEW
        // A função Index() é responsável por retornar a lista de veículos cadastrados.
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();
            return View(dados);
        }

        // CREATE
        // A função Create() é responsável por retornar a view de criação de veículos.
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(veiculo);
        }


        //EDIT
        // A função Edit() é responsável por retornar a view de edição de veículos.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if(id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        // VIEW
        // A função Detail() é responsável por detalhar cada um dos veículos
    
        public async Task<IActionResult> Details(int? id)
        {
            //Verifica se o Id é nulo
            if (id == null)
                return NotFound();

            // Faz a busca do veículo no banco de dados dentro do contexto
            var veiculo = await _context.Veiculos.FindAsync(id);

            // Verifica se o veículo existe
            if (veiculo == null)
                return NotFound();

            // Retorna a view com o veículo encontrado
            return View(veiculo);
        }


        // DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            //Verifica se o Id é nulo
            if (id == null)
                return NotFound();

            // Faz a busca do veículo no banco de dados dentro do contexto
            var veiculo = await _context.Veiculos.FindAsync(id);

            // Verifica se o veículo existe
            if (veiculo == null)
                return NotFound();

            // Retorna a view com o veículo encontrado
            return View(veiculo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            //Verifica se o Id é nulo
            if (id == null)
                return NotFound();

            // Faz a busca do veículo no banco de dados dentro do contexto
            var veiculo = await _context.Veiculos.FindAsync(id);

            // Verifica se o veículo existe
            if (veiculo == null)
                return NotFound();

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            // Retorna a view com o veículo encontrado
            return RedirectToAction("Index");
        }
    }
}
