using System;

namespace OOPTestingProject.OOP
{
    internal class HealthInsuranceDI
    {
        // 1. インターフェース
        public interface IInsuranceProvider
        {
            string GetInsuranceDetails(string patientName);
        }

       

        // 2. 実装クラス
        public class HealthInsuranceProvider : IInsuranceProvider
        {
            public string GetInsuranceDetails(string patientName)
            {
                return $"Patient {patientName} is covered under Basic Health Insurance.";
            }
        }

        // 3. サービスクラス
        public class InsuranceService
        {
            private readonly IInsuranceProvider _provider;

            public InsuranceService(IInsuranceProvider provider)
            {
                _provider = provider;
            }

            public void PrintInsuranceInfo(string patientName)
            {
                string info = _provider.GetInsuranceDetails(patientName);
                Console.WriteLine(info);
            }
        }

        // ✅ 4. Mainメソッド（同じクラス内）
      
    }
}
