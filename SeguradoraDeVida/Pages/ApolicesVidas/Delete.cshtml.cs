using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.ApolicesVidas
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Context _context;

        public DeleteModel(Repository.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ApoliceVida ApoliceVida { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApoliceVida = await _context.ApoliceVida.FirstOrDefaultAsync(m => m.IdApoliceVida == id);

            if (ApoliceVida == null)
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

            ApoliceVida = await _context.ApoliceVida.FindAsync(id);

            if (ApoliceVida != null)
            {
                ApoliceVida.DataCancelamento = DateTime.Now;

                _context.ApoliceVida.Update(ApoliceVida);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}