using System;

namespace Api.Model
{
    public class Customer
    {
    public Guid CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    }
}