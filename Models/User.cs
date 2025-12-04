namespace PickupExpressApp.Client.Models
{
    public enum UserRole
    {
        Customer,
        Employee
    }

    public class User
    {
        public int UserId { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public UserRole Role { get; set; }

        public string? Password { get; set; }

        // Nav Properties
        public ICollection<Order>? Orders { get; set; }
    }
}