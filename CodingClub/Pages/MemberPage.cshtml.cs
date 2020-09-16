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
    public class MemberPage : PageModel
    {
        private readonly ILogger<MemberPage> _logger;
        private readonly CodingClub.Data.CodingClubContext _context;

        public ClubMember SingleMember { get; set; }

        [BindProperty]
        [Required]
        public string fName { get; set; }
        [BindProperty]
        [Required]
        public string lName { get; set; }
        [BindProperty]
        [Required]
        public string clubTitle { get; set; }
        [BindProperty]
        [Required]
        //TODO: Fix DuesPaid check box, either way it returns false at the moment
        public bool duesPaid { get; set; }

        public MemberPage(ILogger<MemberPage> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? MemberId)
        {
            if (MemberId == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    SingleMember = await _context.ClubMember.FindAsync(MemberId);
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e, $"Error retreiving club member \n{MemberId}");
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPost(int MemberId)
        {
            SingleMember = await _context.ClubMember.FindAsync(MemberId);

            SingleMember.FName = fName;
            SingleMember.LName = lName;
            SingleMember.ClubTitle = clubTitle;
            SingleMember.DuesPaid = duesPaid;
            try
            {
                _context.Update(SingleMember);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Error updating member");
            }

            return RedirectToPage("Members");
        }
    }
}