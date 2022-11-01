using System;

namespace RookiesWebAPI.Models
{
    public class PersonDetailModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? BirthPlace { get; set; }
    }
}