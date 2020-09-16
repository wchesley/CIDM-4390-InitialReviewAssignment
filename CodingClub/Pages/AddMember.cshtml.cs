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
    public class AddMember : PageModel
    {
        private readonly ILogger<AddMember> _logger;
        private readonly CodingClub.Data.CodingClubContext _context;

        [BindProperty]
        [Required]
        [Display(Name = "First Name: ")]
        public string fName { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Last Name: ")]
        public string lName { get; set; }


        public AddMember(ILogger<AddMember> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            _logger.LogInformation("Add Member page.. ");
        }

        public async Task<IActionResult> OnPost()
        {
            var newMember = new ClubMember
            {
                FName = fName,
                LName = lName,
                ClubTitle = "Prospect",
                IsAdmin = false,
                DuesPaid = false
            };
            try
            {
                _context.ClubMember.Add(newMember);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Added new member {newMember}");
                
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Error saving newMember to db");
            }
            return RedirectToPage("Members");
        }
    }
}