using System;
using System.Collections.Generic;

namespace kolos.DTO
{
    public class MembershipDto
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }
        public TeamDto Team { get; set; }
        public MemberDto Member { get; set; }
    }
}
