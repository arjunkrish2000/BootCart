namespace BootCart.Model.RequestModels
{
    public enum UserType
    {
        Customer,
        Seller
    }
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
     

        public String Gender { get; set; }
        public UserType UserTypes { get; set; }

        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [StringLength(45)]
        public String Email { get; set; }

        public String PhoneNumber { get; set; }

        }

    
}
