using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CodingClub.Pages
{
    public class Team : PageModel
    {
        private readonly ILogger<Team> _logger;
        private readonly CodingClub.Data.CodingClubContext _context;
        public List<Teams> TeamData { get; set; }

        public Team(ILogger<Team> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Will prolly need a parameter here to get the specific teams page: 
        public async Task<IActionResult> OnGet()
        {
            TeamData = await (from t in _context.Teams
                              orderby t.TeamID
                              select t).ToListAsync();
            return Page();
        }
    }
}