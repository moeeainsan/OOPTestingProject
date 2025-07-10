using MedicineManagementProject.Domain;
using System;
using System.Collections.Generic;

namespace MedicineManagementProject.Application
{
    public interface IMedicineRepository
    {
        void Save(Medicine medicine);
        Medicine FindByName(string name);
        IEnumerable<Medicine> GetAll();
        void Delete(Medicine medicine);
    }
}
