using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CodingClub.Pages
{
    public class CreateTeam : PageModel
    {
        private readonly ILogger<CreateTeam> _logger;
        private readonly CodingClub.Data.CodingClubContext _context;

        [BindProperty]
        public List<ClubMember> teamMembers { get; set; }
        [BindProperty]
        [Required]
        public ClubMember teamLeader { get; set; }
        [BindProperty]
        [Required]
        public string projectDescription { get; set; }
        [BindProperty]
        [Required]
        public string projectName { get; set; }
        
        public SelectList teamLeaders { get; set; }


        public CreateTeam(ILogger<CreateTeam> logger, CodingClub.Data.CodingClubContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            teamMembers = await (from m in _context.ClubMember
                                 orderby m.MemberID
                                 select m).ToListAsync();
            var teamList = (from m in _context.ClubMember orderby m.FName select m).ToList();
            teamLeaders = new SelectList(teamList, "MemberID", "FName");
            _logger.LogInformation("TEST: " + teamLeaders.ToString());
            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //good ol hacky solution, but it works for now: I couldnt' seem to get the form data properly otherwise :( )
            var thing = Request.Form["TeamLeader"];
            int.TryParse(thing, out int TLID); 
            var newTeamLead = await _context.ClubMember.FirstOrDefaultAsync(tl => tl.MemberID == TLID); 
            var newTeam = new Teams
            {
                ProjectDescription = projectDescription,
                ProjectName = projectName,
                TeamLeader = newTeamLead,
                TeamMembers = teamMembers
            };
            try
            {
                _context.Teams.Add(newTeam);
                await _context.SaveChangesAsync();
                return RedirectToPage("Team");
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Error creating Team");
                return Page();
            }
        }
    }
}