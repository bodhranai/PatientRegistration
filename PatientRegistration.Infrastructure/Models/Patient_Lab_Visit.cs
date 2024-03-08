using System;
using System.Collections.Generic;

namespace PatientRegistration.Infrastructure.Models;

public partial class Patient_Lab_Visit
{
    public int Id { get; set; }

    public int Patient_id { get; set; }

    public string? Lab_name { get; set; }

    public string? Lab_test_request { get; set; }

    public string? Result_date { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_At { get; set; }
}
