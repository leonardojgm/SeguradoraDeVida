using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.ApolicesVidas
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Context _context;

        public IndexModel(Repository.Context context)
        {
            _context = context;
        }

        public IList<ApoliceVida> ApoliceVida { get; set; }

        public async Task OnGetAsync()
        {
            ApoliceVida = await _context.ApoliceVida.ToListAsync();
        }
    }
}