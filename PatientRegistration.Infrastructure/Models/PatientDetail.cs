using System;
using System.Collections.Generic;

namespace PatientRegistration.Infrastructure.Models;

public partial class PatientDetail
{
    public int Id { get; set; }

    public string first_name { get; set; } = null!;

    public string? middle_name { get; set; }

    public string last_name { get; set; } = null!;

    public DateTime dob { get; set; }

    public string? address { get; set; }

    public string? city { get; set; }

    public string? state { get; set; }

    public string? zip { get; set; }
}
