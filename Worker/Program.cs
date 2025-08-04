using System.Globalization;
using Worker.Entities;
using Worker.Entities.Enums;

namespace Worker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department name: ");
            string? deptname = Console.ReadLine();
            
            Console.WriteLine("Enter worker data: ");
            
            Console.Write("Name: ");
            string? name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Level: (Junior/Pleno/Senior): ");
            string? levelname = Console.ReadLine();
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(levelname);
            
            Console.WriteLine();

            Console.Write("Base Salary: ");
            double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();
            
            //Instanciando os objetos
            Department dept = new Department(deptname); //Instanciando o departamento
            Entities.Worker worker = new Entities.Worker(name, workerLevel, basesalary, dept);//Instanciando o objeto trabalhador


            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contracts data: ");
                
                Console.Write("Date (DD/MM/YYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                
                //Instanciando o contrato 
                HourContract contract = new HourContract(date, valuePerHour, hours);
                //Adicionando o contrato na lista de contratos 
                worker.AddContract(contract);
                
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");

            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear} : {worker.Income(year, month).ToString("F2",
                CultureInfo.InvariantCulture)}");
        }
    }
}