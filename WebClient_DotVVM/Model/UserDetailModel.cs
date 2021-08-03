using System;
using System.ComponentModel.DataAnnotations;

namespace WebClient_DotVVM.Model
{
    public class UserDetailModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
