using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.DTO
{
    public class MemberDto
    {
        [Required]
        public string MemberName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MemberSurname { get; set; }
        [MaxLength(20)]
        public string MemberNickName { get; set; }
    }
}
