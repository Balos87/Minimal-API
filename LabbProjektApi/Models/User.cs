using System.Data.SqlClient;
using LabbProjektApi.Connections;
using LabbProjektApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data.SqlTypes;
using System.Linq;
using System.Configuration.Assemblies;

namespace LabbProjektApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<InterestLink> InterestLinks { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
