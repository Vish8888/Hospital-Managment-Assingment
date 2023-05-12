using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managment.Areas.User.Models
{
    public class PatiantModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        public string Address { get; set; }
        
        [DisplayName("Medical Condition")]
        public string MedicalCondition { get; set; }
        
        [DisplayName("Follow up")]
        public string Followup { get; set; }
    }
}
