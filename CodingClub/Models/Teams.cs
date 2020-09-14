using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingClub
{
    public class Teams
    {
        [Key]
        public int TeamID {get; set;}
        public string ProjectName {get; set;}
        public string ProjectDescription {get; set; }
        public ClubMember TeamLeader {get; set;}
        public ICollection<ClubMember> TeamMembers {get; set; }
    }
}