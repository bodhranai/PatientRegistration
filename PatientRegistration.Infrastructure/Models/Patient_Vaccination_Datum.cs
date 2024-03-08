using System;
using System.Collections.Generic;

namespace PatientRegistration.Infrastructure.Models;

public partial class Patient_Vaccination_Data
{
    public int Id { get; set; }

    public int? Patient_id { get; set; }

    public string? Vaccine_name { get; set; }

    public DateTime? Vaccine_date { get; set; }

    public string? Administered_by { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}
