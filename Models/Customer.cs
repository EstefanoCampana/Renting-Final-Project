using System.ComponentModel.DataAnnotations;

namespace Renting.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact Number is required.")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        // handwritten notes for if customer is banned or is eligible for a discount
        public bool IsBanned { get; set; } = false;
        public bool HasDiscount { get; set; } = false;

        public Customer() { }

        public Customer(int customerId, string firstName, string lastName, string contactNumber, string email)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Email = email;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void ApplyDiscount()
        {
            HasDiscount = true;
        }

        public void BanCustomer()
        {
            IsBanned = true;
        }

        public override string ToString()
        {
            string status = IsBanned ? "BANNED" : "Active";
            string discount = HasDiscount ? " (10% Discount Eligible)" : "";
            return $"[{CustomerId}] {GetFullName()} - {status}{discount}";
        }
    }
}