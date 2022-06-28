using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos.Models
{
    public class Membership
    {
        [Key]
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }
        public virtual Member Member { get; set; }
    }
}
