using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Vidas
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Context _context;

        public DeleteModel(Repository.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Vida Vida { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vida = await _context.Vida.FirstOrDefaultAsync(m => m.IdVida == id);

            if (Vida == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vida = await _context.Vida.FindAsync(id);

            if (Vida != null)
            {
                if (await _context.ApoliceVida.AnyAsync(x => x.IdApolice == id && x.DataCancelamento == null))
                {
                    throw new Exception("Necessário remover a associação com apólices antes");
                }

                if (await _context.Vida.AnyAsync(x => x.IdSeguradoPrincipal == id && x.DataCancelamento == null))
                {
                    throw new Exception("Necessário remover a associação com vida segurado principal antes");
                }

                Vida.DataCancelamento = DateTime.Now;

                _context.Vida.Update(Vida);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}