using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeguradoraDeVida.Pages.Apolices
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Context _context;

        public IndexModel(Repository.Context context)
        {
            _context = context;
        }

        public IList<Apolice> Apolice { get; set; }

        public async Task OnGetAsync()
        {
            Apolice = await _context.Apolice.ToListAsync();
        }
    }
}