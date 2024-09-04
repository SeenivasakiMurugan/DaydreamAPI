using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Daydream.BAL.Model
{
    public class Story
    {
        public int StoryId { get; set; }

        public string? StoryName { get; set; }

        public int StoryTypeId { get; set; }

        public List<Chapter>? Chapters { get; set; }

        public string? Image { get; set; }

        public bool? IsActive { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
