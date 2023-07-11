using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class Nprefix
{
    public int IdPrefix { get; set; }

    public string? PrefixIndex { get; set; }

    public string? InstitutionLabel { get; set; }

    public string? PrefixGroupId { get; set; }

    public string? BinStart { get; set; }

    public string? BinEnd { get; set; }

    public string? IndexIssuerBitmap { get; set; }

    public string? CardLengthType { get; set; }

    public string? CardLengthMin { get; set; }

    public string? CardLengthMax { get; set; }

    public string? PinFlag { get; set; }

    public string? Reseau { get; set; }

    public string? Message { get; set; }

    public string? Limit { get; set; }
}
