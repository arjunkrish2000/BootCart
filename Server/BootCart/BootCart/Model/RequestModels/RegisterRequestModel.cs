﻿namespace BootCart.Model.RequestModels
{
   
    public class RegisterRequestModel
    {


        [Required]
        [StringLength(15)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
     

        public string Gender { get; set; }
       
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [StringLength(45)]
        public String Email { get; set; }

        public String PhoneNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        //[Required]
        //[StringLength(20)]
        //[Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }

    }

    
}
