using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Xml.Linq;

namespace BootCart.Model
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public String HouseName { get; set; }

        public String PostOffice { get; set; }
        public int Pincode { get; set; }
        public String City { get; set; }

        public String District { get; set; }
        public String State { get; set; }
        public String LandMark { get; set; }

        public String AlternateMobileNumber { get; set; }

        public String Type { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }



    }

}