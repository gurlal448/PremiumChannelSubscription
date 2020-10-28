using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PremiumChannelSubscription.BusinessLayer;
using PremiumChannelSubscription.Data;

namespace PremiumChannelSubscription.PremiumServices
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
            return Page();
        }

        [BindProperty]
        public PremiumService PremiumService { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PremiumServices.Add(PremiumService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
