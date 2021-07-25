using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Apolices
{
    public class EditModel : PageModel
    {
        private readonly Repository.Context _context;

        public EditModel(Repository.Context context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Apolice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApoliceExists(Apolice.IdApolice))
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

        private bool ApoliceExists(int id)
        {
            return _context.Apolice.Any(e => e.IdApolice == id);
        }
    }
}