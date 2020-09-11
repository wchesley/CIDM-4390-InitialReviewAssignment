using System; 
using System.Collections.Generic;

namespace CodingClub.Modles
{
    public class Teams
    {
        public int TeamID {get; set;}
        public string ProjectName {get; set;}
        public string ProjectDescription {get; set; }
        public ClubMember TeamLeader {get; set;}
        public ICollection<ClubMember> TeamMembers {get; set; }
    }
}