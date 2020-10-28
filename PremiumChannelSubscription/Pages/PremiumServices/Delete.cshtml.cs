using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PremiumChannelSubscription.BusinessLayer;
using PremiumChannelSubscription.Data;

namespace PremiumChannelSubscription.PremiumServices
{
    public class DeleteModel : PageModel
    {
        private readonly PremiumChannelSubscription.Data.PremiumChannelDataContext _context;

        public DeleteModel(PremiumChannelSubscription.Data.PremiumChannelDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PremiumService PremiumService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PremiumService = await _context.PremiumServices.FirstOrDefaultAsync(m => m.ServiceID == id);

            if (PremiumService == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PremiumService = await _context.PremiumServices.FindAsync(id);

            if (PremiumService != null)
            {
                _context.PremiumServices.Remove(PremiumService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
