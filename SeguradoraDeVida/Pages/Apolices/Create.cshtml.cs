using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Apolices
{
    public class CreateModel : PageModel
    {
        private readonly Repository.Context _context;

        public CreateModel(Repository.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Apolice Apolice { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Apolice.Add(Apolice);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}