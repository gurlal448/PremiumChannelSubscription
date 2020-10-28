using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PremiumChannelSubscription.BusinessLayer;
using PremiumChannelSubscription.Data;

namespace PremiumChannelSubscription.CustomerSubscriptions
{
    public class CreateModel : PageModel
    {
        private readonly PremiumChannelSubscription.Data.PremiumChannelDataContext _context;

        public CreateModel(PremiumChannelSubscription.Data.PremiumChannelDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ServiceID"] = new SelectList(_context.PremiumServices, "ServiceID", "ServiceName");
        ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerName");
            return Page();
        }

        [BindProperty]
        public CustomerSubscription CustomerSubscription { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerSubscriptions.Add(CustomerSubscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
