using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace CodingClub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CodingClub.Data.CodingClubContext _context;
        public IQueryable<Content> content; 

        public IndexModel(ILogger<IndexModel> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public void OnGet()
        {
            try
            {
                //content = from c in _context.Content select c; 
            }
            catch(Exception e)
            {
                _logger.LogWarning(e, "Error reading content"); 
            }
            
        }
    }
}
