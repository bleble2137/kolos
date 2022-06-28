
using System.ComponentModel.DataAnnotations;

namespace kolos.DTO
{
    public class FileDto
    {

        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }
        [Required]
        public int FileSize { get; set; }

        public virtual TeamDto Team { get; set; }
    }
}
