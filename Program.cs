using System;
using MedicineManagementProject.Application;
using MedicineManagementProject.Infrastructure;

class Program
{
    static void Main(string[] args)
    {
        var repository = new MedicineRepository();
        var useCase = new MedicineUseCase(repository);

        // Register
        useCase.RegisterMedicine("アスピリン", 10, new DateTime(2025, 12, 31));
        useCase.RegisterMedicine("パラセタモール", 5, new DateTime(2026, 5, 1));

        // Update quantity and expiry
        useCase.UpdateMedicine("アスピリン", -2, new DateTime(2026, 1, 15));
        useCase.UpdateMedicine("アスピリン", -2, new DateTime(2026, 1, 15));
        useCase.UpdateMedicine("アスピリン", +8, new DateTime(2026, 1, 15));



        // Delete a medicine
        useCase.DeleteMedicine("パラセタモール");

        // Show all medicines
        var allMedicines = useCase.GetAllMedicines();
        Console.WriteLine("=== 医薬品一覧 ===");
        foreach (var med in allMedicines)
        {
            Console.WriteLine(med); // .ToString() is automatically called
        }
    }
}
