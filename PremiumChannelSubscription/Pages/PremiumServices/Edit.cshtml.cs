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

namespace PremiumChannelSubscription.PremiumServices
{
    public class EditModel : PageModel
    {
        private readonly PremiumChannelSubscription.Data.PremiumChannelDataContext _context;

        public EditModel(PremiumChannelSubscription.Data.PremiumChannelDataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PremiumService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(PremiumService.ServiceID))
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

        private bool ServiceExists(int id)
        {
            return _context.PremiumServices.Any(e => e.ServiceID == id);
        }
    }
}
