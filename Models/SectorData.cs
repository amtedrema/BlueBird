namespace BlueBird.Models
{
    public class SectorData : SectorBase
    {
        public Guid? ParentId { get; set; }
        public SectorData Parent { get; set; }
        public ICollection<SectorData> Children { get; set; }
    }
}
