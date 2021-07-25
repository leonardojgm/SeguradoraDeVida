using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Vidas
{
    public class EditModel : PageModel
    {
        private readonly Repository.Context _context;

        public EditModel(Repository.Context context)
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

            Vida.VidasPossiveis = await _context.Vida.Where(x => x.Tipo == "Segurado Principal").ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VidaExists(Vida.IdVida))
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

        private bool VidaExists(int id)
        {
            return _context.Vida.Any(e => e.IdVida == id);
        }
    }
}