using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class PosIdentification
{
    public string IdTerminal { get; set; } = null!;

    public string? IdMerchant { get; set; }

    public string? Outlet { get; set; }

    public string? Address { get; set; }

    public string? Mcc { get; set; }

    public string? City { get; set; }

    public string? Password { get; set; }

    public string? CountryCodeNum { get; set; }

    public string? CountryCodeAlpha { get; set; }

    public string? Port { get; set; }
}
