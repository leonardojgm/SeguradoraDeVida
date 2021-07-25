using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.ApolicesVidas
{
    public class CreateModel : PageModel
    {
        private readonly Repository.Context _context;

        public CreateModel(Repository.Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ApoliceVida = new ApoliceVida
            {
                ApolicesPossiveis = await _context.Apolice.Where(x => x.DataCancelamento == null).ToListAsync(),
                VidasPossiveis = await _context.Vida.ToListAsync()
            };

            return Page();
        }

        [BindProperty]
        public ApoliceVida ApoliceVida { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ApoliceVida.Add(ApoliceVida);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}