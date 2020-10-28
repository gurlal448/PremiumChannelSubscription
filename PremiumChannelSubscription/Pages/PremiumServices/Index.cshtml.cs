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
    public class IndexModel : PageModel
    {
        private readonly PremiumChannelSubscription.Data.PremiumChannelDataContext _context;

        public IndexModel(PremiumChannelSubscription.Data.PremiumChannelDataContext context)
        {
            _context = context;
        }

        public IList<PremiumService> PremiumService { get;set; }

        public async Task OnGetAsync()
        {
            PremiumService = await _context.PremiumServices.ToListAsync();
        }
    }
}
