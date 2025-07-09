using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManagement.MedicineManagement
{
    internal class MedicineService
    {
        private List<Medicine> medicines = new List<Medicine>();
        private int nextId = 1;


        public void RegisterMedicine(string name, int quantity, DateTime expiry)
        {
            medicines.Add(new Medicine
            {
                Id = nextId++,
                Name = name,
                Quantity = quantity,
                ExpiryDate = expiry
            });

            
        }

        internal IEnumerable<object> GetAll()
        {
            return medicines;
        }



        internal bool HasData()
        {
            return medicines.Count > 0;
        }


        //public bool UpdateMedicine(string name, int newQuantity, DateTime newExpiry)
        //{
        //    var medicine = medicines.FirstOrDefault(m => m.Name == name);
        //    if (medicine != null)
        //    {
        //        medicine.Quantity = newQuantity;
        //        medicine.ExpiryDate = newExpiry;
        //        return true;
        //    }
        //    return false;
        //}

        public bool UpdateMedicine(string name, int deltaQuantity, DateTime? newExpiry = null)
        {
            var med = medicines.FirstOrDefault(m =>
                m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (med == null)
                return false;

            Console.WriteLine($"更新前の数量: {med.Quantity}");

            if (deltaQuantity < 0) // 負の値 = 減算
            {
                int amountToSubtract = Math.Abs(deltaQuantity);
                if (med.Quantity < amountToSubtract)
                {
                    Console.WriteLine("エラー: 在庫不足のため減算できません");
                    return false;
                }
                med.Quantity += deltaQuantity; // 負の値を加算 = 減算
                Console.WriteLine($"医薬品『{med.Name}』の数量を {deltaQuantity} しました。現在数量: {med.Quantity}");
            }
            else if (deltaQuantity > 0) // 正の値 = 加算
            {
                med.Quantity += deltaQuantity;
                Console.WriteLine($"医薬品『{med.Name}』の数量を +{deltaQuantity} しました。現在数量: {med.Quantity}");
            }
            else // 0 = 変更なし
            {
                Console.WriteLine("数量変更なし");
            }

            if (newExpiry.HasValue)
            {
                med.ExpiryDate = newExpiry.Value;
                Console.WriteLine($"有効期限を {med.ExpiryDate:yyyy-MM-dd} に更新しました");
            }

            return true;
        }
        public bool DeleteMedicine(string name)
        {
            var medicine = medicines.FirstOrDefault(m => m.Name == name);
            if (medicine != null)
            {
                medicines.Remove(medicine);
                return true;
            }
            return false;
        }

        public bool Exists(string name)
        {
            return medicines.Any(m => m.Name == name);
        }
    }
}

