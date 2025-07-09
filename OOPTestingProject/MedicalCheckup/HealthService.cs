using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTestingProject.MedicalCheckup
{
    internal class HealthService
    {

        public interface IHealthCheck {

            string HealthCheckName();
        }

        public class BloodTestCheck:IHealthCheck
        {
            public string HealthCheckName() => "血液検査";
        }

         public class XRayTestCheck:IHealthCheck
        {
            public string HealthCheckName()=> "X線テストチェック";
        }
        public class WholeBodyCheck:IHealthCheck
        {
            public string HealthCheckName() => "全身チェック";
        }

       

        }

    }

