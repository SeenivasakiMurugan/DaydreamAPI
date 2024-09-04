namespace Daydream.BAL.Model
{
    public class Part
    {
        public int PartId { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public int ChapterId {  get; set; }

        public bool? IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
