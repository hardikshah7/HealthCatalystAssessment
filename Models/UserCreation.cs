using System.Collections.Generic;

namespace HealthCatalystAssessment.Models
{
    public class UserCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public byte Age { get; set; }
        public List<string> Interests { get; set; }
    }
}
