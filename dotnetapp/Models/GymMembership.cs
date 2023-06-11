using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class GymMembership
{
    public int id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Joining date is required")]
    [DataType(DataType.Date)]
    public DateTime JoiningDate { get; set; }
    
    [Required(ErrorMessage = "Membership type is required")]
    [StringLength(20, ErrorMessage = "Membership type cannot exceed 20 characters")]
    public string MembershipType { get; set; }
    
    [Required(ErrorMessage = "Expiry date is required")]
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }
}
}
