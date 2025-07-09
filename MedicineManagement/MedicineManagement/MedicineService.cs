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

        

        public void RegisterMedicine(string name, int quantity, DateTime expiry)
        {
            medicines.Add(new Medicine
            {
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


        public bool UpdateMedicine(string name, int newQuantity, DateTime newExpiry)
        {
            var medicine = medicines.FirstOrDefault(m => m.Name == name);
            if (medicine != null)
            {
                medicine.Quantity = newQuantity;
                medicine.ExpiryDate = newExpiry;
                return true;
            }
            return false;
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
    }
}

