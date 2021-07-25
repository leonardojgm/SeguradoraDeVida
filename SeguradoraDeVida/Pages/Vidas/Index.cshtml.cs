using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Vidas
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Context _context;

        public IndexModel(Repository.Context context)
        {
            _context = context;
        }

        public IList<Vida> Vida { get; set; }

        public async Task OnGetAsync()
        {
            Vida = await _context.Vida.ToListAsync();
        }
    }
}