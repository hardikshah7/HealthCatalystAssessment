using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCatalystAssessment.Models
{
    public class User
    {
        // MaxLength for FirstName, LastName and Address is specified
        // based on what I think is reasonable. In certain cases, we may need to remove these limitations
        // or increase length depending on the data we are working with.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        public byte Age { get; set; }

        public ICollection<Interest> Interests { get; set; }
    }
}