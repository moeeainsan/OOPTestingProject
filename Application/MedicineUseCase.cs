using MedicineManagementProject.Domain;
using System;
using System.Collections.Generic;

namespace MedicineManagementProject.Application
{
    public class MedicineUseCase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineUseCase(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public void RegisterMedicine(string name, int quantity, DateTime expiry)
        {
            var medicine = new Medicine(name, quantity, expiry);
            _medicineRepository.Save(medicine);
        }

        public bool UpdateMedicine(string name, int deltaQuantity, DateTime? newExpiry = null)
        {
            var medicine = _medicineRepository.FindByName(name);
            if (medicine == null)
                return false;

            medicine.ChangeQuantity(deltaQuantity);

            if (newExpiry.HasValue)
                medicine.UpdateExpiry(newExpiry.Value);

            _medicineRepository.Save(medicine);
            return true;
        }

        public bool DeleteMedicine(string name)
        {
            var medicine = _medicineRepository.FindByName(name);
            if (medicine == null)
                return false;

            _medicineRepository.Delete(medicine);
            return true;
        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return _medicineRepository.GetAll();
        }
    }
}
