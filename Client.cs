using System;
using System.Collections.Generic;

namespace AdvertisingAgency;

public partial class Client
{
    public int IdClient { get; set; }

    public string? ClientSurname { get; set; }

    public string? ClientName { get; set; }

    public string? Clien { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Adress { get; set; }

    public string? Passport { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
