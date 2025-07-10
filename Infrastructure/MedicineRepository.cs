using MedicineManagementProject.Application;
using MedicineManagementProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicineManagementProject.Infrastructure
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly List<Medicine> _medicines = new();
        private int _nextId = 1;

        public void Save(Medicine medicine)
        {
            if (medicine.Id == 0)
            {
                medicine.SetId(_nextId++);
                _medicines.Add(medicine);
            }
            else
            {
                var existing = _medicines.FirstOrDefault(m => m.Id == medicine.Id);
                if (existing != null)
                {
                    existing.UpdateFrom(medicine);
                }
            }
        }

        public Medicine FindByName(string name)
        {
            return _medicines.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _medicines;
        }

        public void Delete(Medicine medicine)
        {
            _medicines.Remove(medicine);
        }
    }
}
