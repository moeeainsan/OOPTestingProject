using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTestingProject.MedicalCheckup
{
    internal class Reservation
    {
        
            public Patient patient { get; }
            public HealthService.IHealthCheck check { get; }

            public Reservation(Patient _patient,HealthService.IHealthCheck _check)
            {
                patient = _patient;
                check = _check;
            }

            public void Contact()
            {
            Console.WriteLine($"予約終了{patient.Name}さんは{check.HealthCheckName()}が終了です");

        }




    }
}
