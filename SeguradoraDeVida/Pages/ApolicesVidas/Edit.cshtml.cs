using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.ApolicesVidas
{
    public class EditModel : PageModel
    {
        private readonly Repository.Context _context;

        public EditModel(Repository.Context context)
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

            ApoliceVida.ApolicesPossiveis = await _context.Apolice.Where(x => x.DataCancelamento == null).ToListAsync();
            ApoliceVida.VidasPossiveis = await _context.Vida.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApoliceVida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApoliceVidaExists(ApoliceVida.IdApoliceVida))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ApoliceVidaExists(int id)
        {
            return _context.ApoliceVida.Any(e => e.IdApoliceVida == id);
        }
    }
}