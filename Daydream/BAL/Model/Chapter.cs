namespace Daydream.BAL.Model
{
    public class Chapter
    {
        public int ChapterId { get; set; }

        public string? ChapterName { get; set; }

        public int StoryId { get; set; }

        public List<Part>? Parts { get; set; }

        public bool? IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }    

        public int ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get;set; }
    }
}
