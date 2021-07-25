using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.ApolicesVidas
{
    public class DetailsModel : PageModel
    {
        private readonly Repository.Context _context;

        public DetailsModel(Repository.Context context)
        {
            _context = context;
        }

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
    }
}