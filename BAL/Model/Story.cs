using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Model
{
    public class Story
    {
        public int Id { get; set; }

        public string? StoryName { get; set; }

        public int StoryTypeId { get; set; }

        public bool? IsActive { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get;set; }
    }
}
