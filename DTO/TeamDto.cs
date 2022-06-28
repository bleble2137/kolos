using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace kolos.DTO
{
    public class TeamDto
    {
        [Required]
        public int TeamID;
        [Required]
        public int OrganizationID;
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }
        [MaxLength(500)]
        public string TeamDescription { get; set; }
        public virtual OrganizationDto Organization { get; set; }

    }
}
