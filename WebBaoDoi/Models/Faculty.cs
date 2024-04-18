using System.ComponentModel.DataAnnotations;

namespace WebBaoDoi.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        [Required, StringLength(50)]
        public string FacultyName { get; set; }
    }
}
