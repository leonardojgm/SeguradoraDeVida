using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Apolices
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Context _context;

        public DeleteModel(Repository.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Apolice Apolice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apolice = await _context.Apolice.FirstOrDefaultAsync(m => m.IdApolice == id);

            if (Apolice == null)
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

            Apolice = await _context.Apolice.FindAsync(id);

            if (Apolice != null)
            {
                if (await _context.ApoliceVida.AnyAsync(x => x.IdApolice == id && x.DataCancelamento == null))
                {
                    throw new Exception("Necessário remover a associação com vida antes");
                }

                Apolice.DataCancelamento = DateTime.Now;

                _context.Apolice.Update(Apolice);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}