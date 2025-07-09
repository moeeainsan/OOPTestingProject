using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManagement.MedicineManagement
{
    internal class MainProgram
    {
        static MedicineService service = new MedicineService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== 医薬品管理システム ===");
                Console.WriteLine("1. 医薬品を登録する");
                Console.WriteLine("2. 医薬品一覧を表示する");
                Console.WriteLine("3. 終了する");
                Console.Write("選択してください: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        ShowList();
                        break;
                    case "3":
                        Console.Write("本当に終了しますか？（y/n）: ");
                        string confirm = Console.ReadLine()?.Trim().ToLower();

                        if (confirm == "y" || confirm == "yes")
                        {
                            Console.WriteLine("終了します。");
                            return; // プログラムを終了
                        }
                        else
                        {
                            Console.WriteLine("キャンセルしました。");
                        }
                        break;
                    default:
                        Console.WriteLine("無効な入力です。");
                        break;
                }
            }
        }

        static void Register()
        {
            Console.Write("薬の名前を入力してください: ");
            string name = Console.ReadLine();

            Console.Write("数量を入力してください: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("数量は整数で入力してください。");
                return;
            }

            Console.Write("有効期限を入力してください (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime expiryDate))
            {
                Console.WriteLine("有効な日付形式で入力してください。");
                return;
            }

            service.RegisterMedicine(name, quantity, expiryDate);
            Console.WriteLine("登録が完了しました。");
        }

        static void ShowList()
        {
            if (!service.HasData())
            {
                Console.WriteLine("登録されている医薬品はありません。");
                return;
            }

            Console.WriteLine("\n--- 医薬品一覧 ---");
            foreach (var m in service.GetAll())
            {
                Console.WriteLine(m);
            }
        }
    }

}

