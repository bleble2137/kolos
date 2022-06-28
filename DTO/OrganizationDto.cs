using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace kolos.DTO
{
    public class OrganizationDto
    {
        [Required]
        [MaxLength(100)]
        public string OrganizationName { get; set; }
        [Required]
        [MaxLength(50)]
        public string OrganizationDomain { get; set; }
    }
}
