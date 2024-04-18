
namespace WebBaoDoi.Models
{
    public class Idea
    {
        public int Id { get; set; }
        public string IdeaName { get; set; }
        public string Description { get; set; }
        public string FacultyName { get; set; }
        public string FileUpload { get; set; }
        public string ImageUrl { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
