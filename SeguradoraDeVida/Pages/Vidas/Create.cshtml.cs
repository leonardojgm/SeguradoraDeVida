using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Vidas
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
            Vida = new Vida
            {
                VidasPossiveis = await _context.Vida.Where(x => x.Tipo == "Segurado Principal").ToListAsync()
            };

            return Page();
        }

        [BindProperty]
        public Vida Vida { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vida.Add(Vida);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}