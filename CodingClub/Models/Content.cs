using System;
using System.Collections.Generic;

namespace CodingClub.Modles
{
    public class Content
    {
        public int ContentID {get; set;}
        public ClubMember Creator {get; set;}
        public string ContentTitle {get; set;}
        
        //Avoided naming the bulk of the contents property the same as the class name: 
        public string FullContent {get; set;}
    }
}