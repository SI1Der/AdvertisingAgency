using System;
using System.Collections.Generic;

namespace AdvertisingAgency;

public partial class OrdersList
{
    public int IdOrder { get; set; }

    public string? OrderName { get; set; }

    public float? OrderPrice { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
