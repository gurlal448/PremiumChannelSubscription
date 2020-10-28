using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PremiumChannelSubscription.BusinessLayer;
using PremiumChannelSubscription.Data;

namespace PremiumChannelSubscription.CustomerSubscriptions
{
    public class DeleteModel : PageModel
    {
        private readonly PremiumChannelSubscription.Data.PremiumChannelDataContext _context;

        public DeleteModel(PremiumChannelSubscription.Data.PremiumChannelDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerSubscription CustomerSubscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerSubscription = await _context.CustomerSubscriptions
                .Include(s => s.Service)
                .Include(s => s.Customer).FirstOrDefaultAsync(m => m.CustomerSubscriptionID == id);

            if (CustomerSubscription == null)
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

            CustomerSubscription = await _context.CustomerSubscriptions.FindAsync(id);

            if (CustomerSubscription != null)
            {
                _context.CustomerSubscriptions.Remove(CustomerSubscription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
