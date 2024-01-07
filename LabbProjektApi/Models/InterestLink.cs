namespace LabbProjektApi.Models
{
    public class InterestLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }


        public virtual Interest Interests { get; set; }
        public virtual User Users { get; set; }
    }
}
