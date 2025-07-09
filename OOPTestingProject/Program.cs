

using OOPTestingProject.MedicalCheckup;
using static OOPTestingProject.OOP.HealthChecking;
class Program
{

    

    static void Main(string[] args)
    {

        string patientName = "鈴木さん";
        var service = new List<IHealthService>
                  {
                      new BloodTestService()


                  };

        var check = new HealthCheckSystem(service);
        check.RunAllService(patientName);
        Console.ReadLine();



        var system = new ReservationSystem();

        Console.WriteLine("📝 健康診断予約システム");
        Console.Write("お名前を入力してください: ");
        string name = Console.ReadLine();

        system.ShowServices();
        Console.Write("予約したいサービスの番号を入力してください: ");
        int choice = int.Parse(Console.ReadLine());

        var reservation = system.MakeReservation(name, choice);
        reservation.Contact();

        Console.WriteLine("ご利用ありがとうございました！");
        Console.ReadLine();



    }
}
