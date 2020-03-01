
using Microsoft.AspNetCore.Identity;

namespace BlueInsuranceTest.Domain.Entities
{
    public class User : IdentityUser
    {
        public long? StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
