namespace LabbProjektApi.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public virtual User Users { get; set; }
    }
}
