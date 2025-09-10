using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Hair
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
    }


    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MaidenName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? BirthDate { get; set; }
        public string? Image { get; set; }
        public string? BloodGroup { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? EyeColor { get; set; }
        public Hair? Hair { get; set; }
    }

    public class UsersResponse
    {
        public List<User>? Users { get; set; } // This class has List to hold multiple User objects
    }
}