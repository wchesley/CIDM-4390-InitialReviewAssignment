using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations; 

namespace CodingClub.Pages
{
    public class CreateContent : PageModel
    {
        private readonly ILogger<CreateContent> _logger; 
        private readonly CodingClub.Data.CodingClubContext _context;
        [BindProperty]
        [Display(Name = "Title: ")]
        [MinLength(1)] 
        public string contentTitle {get; set; }
        [BindProperty]
        [Display(Name = "Body: ")]
        public string contentBody {get; set;} 

        public CreateContent(ILogger<CreateContent> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger; 
            _context = context; 
        }

        
        public void OnGet()
        {
        
        }

        public void OnPost()
        {
            //do something to save user created content here. 
            var newContent = new Content
            {
                ContentTitle = contentTitle, 
                ContentBody = contentBody, 
                //add whoever is logged in as the author
            };
        }
    }
}