using System;
using System.ComponentModel.DataAnnotations;

namespace WebAdmin.Models
{
    public class UserRawViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }

    public class UserDetailViewModel
    {
        public int Id { get; set; }
         
        [Display(Name = "Username"), Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        [ Display(Name = "Email Address"), Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "IsActive"), Required]
        public bool IsActive { get; set; }

        [Display(Name = "Created Date"), Required]
        [DisplayFormat( DataFormatString = "{0:dd/mm/yyyy}" )]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated Date"), Required]
        [DisplayFormat( DataFormatString = "{0:dd/mm/yyyy}" )]
        public DateTime LastUpdatedDate { get; set; }
    }

    public class UserCreateViewModel
    {
        [Display(Name = "Username"), Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        [Display(Name = "Password"), Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Email Address"), Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "IsActive"), Required]
        public bool IsActive { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat( DataFormatString = "{0:dd/mm/yyyy}" )]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        [DisplayFormat( DataFormatString = "{0:dd/mm/yyyy}" )]
        public DateTime LastUpdatedDate { get; set; }

        public UserCreateViewModel()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
            LastUpdatedDate = DateTime.Now;
        }
    }
    public class UserUpdatePasswordViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password"), Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}