using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Vidas
{
    public class DetailsModel : PageModel
    {
        private readonly Repository.Context _context;

        public DetailsModel(Repository.Context context)
        {
            _context = context;
        }

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
    }
}