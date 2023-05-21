using System;
using System.Collections.Generic;

namespace AdvertisingAgency;

public partial class Order
{
    public int OrderNumber { get; set; }

    public DateTime? DateOfOrder { get; set; }

    public int? ClientCode { get; set; }

    public int? OrderCode { get; set; }

    public int? Count { get; set; }

    public float? Price { get; set; }

    public virtual Client? ClientCodeNavigation { get; set; }

    public virtual OrdersList? OrderCodeNavigation { get; set; }
}
