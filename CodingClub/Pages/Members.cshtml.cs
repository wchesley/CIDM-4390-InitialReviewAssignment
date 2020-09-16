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
    public class Members : PageModel
    {
        private readonly ILogger<Members> _logger; 
        private readonly CodingClub.Data.CodingClubContext _context; 
        public IQueryable<ClubMember> members {get; set;}
        public Members(ILogger<Members> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger; 
            _context = context; 
        }

        public void OnGet()
        {
            members = from m in _context.ClubMember select m; 
        }

        //when passing the id back from JS script, the var apparently has to be the same name the model function is looking for: 
        public async Task<IActionResult> OnPost(int? MemberId)
        {
            _logger.LogInformation($"On post fired...{MemberId.ToString()}");
            if(MemberId == null)
            {
                return NotFound(); 
            }
            ClubMember MemberToDelete = await _context.ClubMember.FindAsync(MemberId);
            if(MemberToDelete == null)
            {
                return NotFound(); 
            }
            else
            {
                try
                {
                    _context.ClubMember.Remove(MemberToDelete); 
                    await _context.SaveChangesAsync(); 
                }
                catch(Exception e)
                {
                    _logger.LogWarning(e, "Error removing Member");
                }
            }
            return RedirectToPage("./Members"); 
        }
    }
}