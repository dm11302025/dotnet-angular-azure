using System;
using System.Collections.Generic;

namespace HandsOnFnFetchingData.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double Salary { get; set; }

    public string Designation { get; set; } = null!;

    public DateTime JoinDate { get; set; }
}
