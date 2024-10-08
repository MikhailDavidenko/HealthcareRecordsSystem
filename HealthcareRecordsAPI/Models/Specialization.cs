﻿using System.Numerics;

namespace HealthcareRecordsAPI.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
