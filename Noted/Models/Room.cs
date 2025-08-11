using System.ComponentModel.DataAnnotations;

namespace Noted.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        public bool RoomBooked { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Room price must be greater than zero.")]
        [DataType(DataType.Currency)]
        public double RoomPrice { get; set; }
        [Required]
        [RoomLocationValidation(ErrorMessage = "Room location must be either 'fc1' or 'fc2'.")]
        public string RoomLocation { get; set; }
        [Required]
        public int RoomCapacity { get; set; }=1; // Default value
        public Room()
        {
            RoomBooked = false;
        }
        public class RoomLocationValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var location = value as string;
                if (location == "fc1" || location == "fc2")
                {
                    return ValidationResult.Success!;
                }
                return new ValidationResult(ErrorMessage ?? "Room location must be either 'fc1' or 'fc2'.");
            }
        }
    }
}