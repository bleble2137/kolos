using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos.Models
{
    public class File
    {
        [Key]
        public int FileID { get; set; }
        public int TeamID { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        [MaxLength(4)]
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }
    }

}
