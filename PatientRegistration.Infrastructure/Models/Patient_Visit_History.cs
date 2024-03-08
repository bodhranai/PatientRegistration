using System;
using System.Collections.Generic;

namespace PatientRegistration.Infrastructure.Models;

public partial class Patient_Visit_History
{
    public int Id { get; set; }

    public int? Patient_id { get; set; }

    public DateTime? Visit_Date { get; set; }

    public string? Doctor_Name { get; set; }

    public string? Nurse_Name1 { get; set; }

    public string? Nurse_Name2 { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_At { get; set; }
}
