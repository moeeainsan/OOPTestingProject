using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static OOPTestingProject.MedicalCheckup.HealthService;

namespace OOPTestingProject.MedicalCheckup
{
    internal class ReservationSystem
    {

        private readonly List<HealthService.IHealthCheck> service;
        public ReservationSystem()
        {

            service = new List<HealthService.IHealthCheck>
            {
                new BloodTestCheck(),
                new XRayTestCheck(),
                new WholeBodyCheck()


            };

           
  
        }
        public void ShowServices()
        {
            Console.WriteLine("利用可能なサビス");
            for(int i=0;i<service.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {service[i].HealthCheckName()}");
            }
        }

        public Reservation MakeReservation(string patientName, int serviceNumber)
        {
            var patient = new Patient(patientName);
            var services = service[serviceNumber - 1];

            return new Reservation(patient, services);
        }
    }
}
