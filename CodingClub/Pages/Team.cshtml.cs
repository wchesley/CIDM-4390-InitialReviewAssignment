using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodingClub.Pages
{
    public class Team : PageModel
    {
        private readonly ILogger<Team> _logger; 
        private readonly CodingClub.Data.CodingClubContext _context; 
        public IQueryable<Teams> TeamData; 

        public Team(ILogger<Team> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger; 
            _context = context; 
        }

        //Will prolly need a parameter here to get the specific teams page: 
        public void OnGet()
        {
            TeamData = from t in _context.Teams select t; 
        }
    }
}