using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Apolices
{
    public class DetailsModel : PageModel
    {
        private readonly Repository.Context _context;

        public DetailsModel(Repository.Context context)
        {
            _context = context;
        }

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
    }
}