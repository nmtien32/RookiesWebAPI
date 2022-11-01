using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RookiesWebAPI.Models
{
    public class PersonUpdateModel
    {
        [Required, DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? BirthPlace { get; set; }
    }
}