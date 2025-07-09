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
    }
}

