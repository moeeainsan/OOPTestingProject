using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTestingProject.OOP
{
    internal class HealthChecking
    {

        public interface IHealthService
        {
            string GetServiceName();
            string RunService(string patientName);
        }



        public class BloodTestService : IHealthService
        {

            public string GetServiceName() => "血液検査";

            public string RunService(string patientName)
            {
                return $"{patientName}さんが血液診断を受けました";
            }


        }
        public class HealthCheckSystem
        {
            private readonly List<IHealthService> _service;

            public HealthCheckSystem(List<IHealthService> service)
            {
                this._service = service;
            }

            public void RunAllService(string patientName)
            {

                Console.WriteLine($"健康診断を開始します {patientName}");

                foreach (var service in _service)
                {

                    Console.WriteLine($"{service.GetServiceName()}:{service.RunService(patientName)}");

                    Console.WriteLine("Finish Health Check");

                }

                

            }
        }
    }
}
