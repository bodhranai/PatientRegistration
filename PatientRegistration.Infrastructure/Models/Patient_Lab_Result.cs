using System;
using System.Collections.Generic;

namespace PatientRegistration.Infrastructure.Models;

public partial class Patient_Lab_Result
{
    public int Id { get; set; }

    public int Lab_visit_id { get; set; }

    public string? Test_name { get; set; }

    public string? Test_result { get; set; }

    public string? Test_observation { get; set; }

    public string? Attachments { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}
