using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        [MaxLength(50)]
        public string TeamName { get; set; }
        [MaxLength(500)]
        public string? TeamDescription { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
    }
}
