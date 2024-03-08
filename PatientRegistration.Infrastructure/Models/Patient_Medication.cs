using System;
using System.Collections.Generic;

namespace PatientRegistration.Infrastructure.Models;

public partial class Patient_Medication
{
    public int Patient_id { get; set; }

    public int Visit_id { get; set; }

    public string? Medicine_Name { get; set; }

    public string? Dosage { get; set; }

    public string? Frequency { get; set; }

    public string? Prescribed_By { get; set; }

    public string? Prescription_Date { get; set; }

    public string? Prescription_period { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}
