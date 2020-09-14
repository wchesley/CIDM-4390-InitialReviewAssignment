using System; 
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;

namespace CodingClub
{
    public class ClubMember
    {
        [Key]
        public int MemberID {get; set; }
        public string FName {get; set; }
        public string LName {get; set; }
        public string ClubTitle {get; set;}
        public bool IsAdmin {get; set; }
        public bool DuesPaid {get; set; }
        public ICollection<Content> CreatedContent {get; set; }
        public int Team {get; set; }
    }
}