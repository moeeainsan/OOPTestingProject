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
                Console.WriteLine("3. 医薬品を更新する");
                Console.WriteLine("4. 医薬品を削除する");
                Console.WriteLine("5. 終了する");
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
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;

                    case "5":
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


        static void Update()
        {
            //    Console.Write("更新する薬の名前を入力してください: ");
            //    string name = Console.ReadLine();

            //    Console.Write("新しい数量を入力してください: ");
            //    if (!int.TryParse(Console.ReadLine(), out int newQuantity))
            //    {
            //        Console.WriteLine("数量は整数で入力してください。");
            //        return;
            //    }
            //    Console.Write("新しい有効期限を入力してください (yyyy-MM-dd): ");
            //    if (!DateTime.TryParse(Console.ReadLine(), out DateTime newExpiryDate))
            //    {
            //        Console.WriteLine("有効な日付形式で入力してください。");
            //        return;
            //    }


            //    bool updated = service.UpdateMedicine(name, newQuantity, newExpiryDate);
            //    Console.WriteLine(updated ? "更新成功" : "更新失敗：薬が見つかりません。");
            //}

            Console.Write("更新する薬の名前を入力してください: ");
            string name = Console.ReadLine();

            Console.Write("増減数量を入力してください (+/-数値): ");
            if (!int.TryParse(Console.ReadLine(), out int delta))
            {
                Console.WriteLine("数量は整数で入力してください。");
                return;
            }

            Console.Write("新しい有効期限を入力してください (yyyy-MM-dd) [変更しない場合はEnter]: ");
            string expiryInput = Console.ReadLine();
            DateTime? newExpiry = null;
            if (!string.IsNullOrWhiteSpace(expiryInput))
            {
                if (DateTime.TryParse(expiryInput, out DateTime dt))
                    newExpiry = dt;
                else
                {
                    Console.WriteLine("有効な日付形式で入力してください。");
                    return;
                }
            }

            // サービスに更新を依頼
            bool success = service.UpdateMedicine(name, delta, newExpiry);
            if (success)
                Console.WriteLine("=== 更新成功 ===");
            else
                Console.WriteLine("=== 更新失敗：名前不正または在庫不足 ===");
        }
    

        static void Delete()
            {
                Console.Write("削除する薬の名前を入力してください: ");
                string name = Console.ReadLine();

                bool deleted = service.DeleteMedicine(name);
                Console.WriteLine(deleted ? "削除成功" : "削除失敗：薬が見つかりません。");
            }
        }

    }




