using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class Prefix
{
    public int IdPrefix { get; set; }

    public string PrefixGroup { get; set; } = null!;

    public string? LibelleInstitution { get; set; }

    public string? PointVente { get; set; }

    public string? BinStart { get; set; }

    public string? BinEnd { get; set; }

    public string? PrefixCode { get; set; }

    public string? CardLengthType { get; set; }

    public string? CardLengthMin { get; set; }

    public string? CardLengthMax { get; set; }

    public string? PinFlag { get; set; }

    public string? ServiceCode { get; set; }

    public string? CodeLongue { get; set; }

    public string? GcodePin { get; set; }

    public string? Message1 { get; set; }

    public string? Message2 { get; set; }

    public string? PlafondCarte { get; set; }
}
