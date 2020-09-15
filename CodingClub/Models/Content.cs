using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingClub
{
    public class Content
    {
        [Key]
        public int ContentID {get; set;}
        public ClubMember Creator {get; set;}
        public string ContentTitle {get; set;}
        
        //Avoided naming the bulk of the contents property the same as the class name: 
        public string ContentBody {get; set;}
    }
}