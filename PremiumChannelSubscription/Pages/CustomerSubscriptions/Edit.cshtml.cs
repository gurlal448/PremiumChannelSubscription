using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremiumChannelSubscription.BusinessLayer;
using PremiumChannelSubscription.Data;

namespace PremiumChannelSubscription.CustomerSubscriptions
{
    public class EditModel : PageModel
    {
        private readonly PremiumChannelSubscription.Data.PremiumChannelDataContext _context;

        public EditModel(PremiumChannelSubscription.Data.PremiumChannelDataContext context)
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
           ViewData["ServiceID"] = new SelectList(_context.PremiumServices, "ServiceID", "ServiceName");
           ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerSubscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerSubscriptionExists(CustomerSubscription.CustomerSubscriptionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerSubscriptionExists(int id)
        {
            return _context.CustomerSubscriptions.Any(e => e.CustomerSubscriptionID == id);
        }
    }
}
