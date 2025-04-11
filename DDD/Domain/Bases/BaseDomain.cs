namespace Domain.Bases
{
    public class BaseDomain
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
    }
}
