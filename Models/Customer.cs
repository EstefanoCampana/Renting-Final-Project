using System.ComponentModel.DataAnnotations;

namespace Renting.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
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