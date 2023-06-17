using System.Data.SqlClient;

namespace Connectivity
{
    class Linq
    {
        public void GetTugas1()
        {
            SqlConnection conn = MyConnection.Get();
            var employee = new Employee();
            var department = new Department();
            var location = new Location();
            var country = new Country();
            var region = new Region();
            // Method Syntax
            var employees = employee.GetAll()
                            .Join(department.GetAll(), e => e.DepartmentId, d => d.Id, (e, d) => new { e, d })
                            .Join(location.GetAll(), ed => ed.d.LocationId, l => l.Id, (ed, l) => new { ed.e, ed.d, l })
                            .Join(country.GetAll(), edl => edl.l.CountryId, c => c.Id, (edl, c) => new { edl.e, edl.d, edl.l, c })
                            .Join(region.GetAll(), edlc => edlc.c.RegionId, r => r.Id, (edlc, r) => new { edlc.e, edlc.d, edlc.l, edlc.c, r })
                            .Select(emp => new
                            {
                                ID = emp.e.Id,
                                fullName = string.Concat(emp.e.FirstName, " ", emp.e.LastName),
                                Email = emp.e.Email,
                                Phone = emp.e.PhoneNumber,
                                Salary = emp.e.Salary,
                                Department = emp.d.Name,
                                Address = emp.l.StreetAddress,
                                Country = emp.c.Name,
                                Region = emp.r.Name
                            })
                            .Take(5);

            // Query Syntax
            /*var employess = (from e in employee.GetAllEmployee()
                             join d in department.GetAllDepartment() on e.DepartmentId equals d.Id
                             join l in location.GetAllLocation() on d.LocationId equals l.Id
                             join c in country.GetAllCountry() on l.CountryId equals c.Id
                             join r in region.GetAllRegion() on c.RegionId equals r.Id
                             select new
                             {
                                 ID = e.Id,
                                 fullName = string.Concat(e.FirstName, " ", e.LastName),
                                 Email = e.Email,
                                 Phone = e.PhoneNumber,
                                 Salary = e.Salary,
                                 Department = d.Name,
                                 Address = l.StreetAddress,
                                 Country = c.Name,
                                 Region = r.Name
                             }).Take(5);*/
            Console.Clear();
            foreach (var emp in employees)
            {
                Console.WriteLine();
                Console.WriteLine($"ID\t\t : {emp.ID}");
                Console.WriteLine($"Full Name\t : {emp.fullName}");
                Console.WriteLine($"Email\t\t : {emp.Email}");
                Console.WriteLine($"Phone Number\t : {emp.Phone}");
                Console.WriteLine($"Salary\t\t : {emp.Salary}");
                Console.WriteLine($"Department Name  : {emp.Department}");
                Console.WriteLine($"Address\t\t : {emp.Address}");
                Console.WriteLine($"Country\t\t : {emp.Country}");
                Console.WriteLine($"Region\t\t : {emp.Region}");
                Console.WriteLine();
            }
            Console.WriteLine("Prees Return to back");
            Console.ReadKey();
            LinqMenu();
        }

        public void GetTugas2()
        {
            var employee = new Employee();
            var department = new Department();

            // Method Syntax
            var employees = department.GetAll()
                            .Join(employee.GetAll(), d => d.Id, e => e.DepartmentId, (d, e) => new { Department = d, Employee = e })
                            .GroupBy(x => x.Department.Name)
                            .Where(g => g.Count() > 3)
                            .Select(g => new
                            {
                                DeptName = g.Key,
                                TotalEmployee = g.Count(),
                                MinSalary = g.Min(e => e.Employee.Salary),
                                MaxSalary = g.Max(e => e.Employee.Salary),
                                Average = g.Average(e => e.Employee.Salary)
                            });

            // Query Syntax
            /*var employees = from d in department.GetAllDepartment()
                            join e in employee.GetAllEmployee() on d.Id equals e.DepartmentId
                            group e by d.Name into eGroup
                            where eGroup.Count() > 3
                            select new
                            {
                                DeptName = eGroup.Key,
                                TotalEmployee = eGroup.Count(),
                                MinSalary = eGroup.Min(e => e.Salary),
                                MaxSalary = eGroup.Max(e => e.Salary),
                                Average = eGroup.Min(e => e.Salary),
                            };*/
            Console.Clear();
            foreach (var emp in employees)
            {
                Console.WriteLine($"Department Name : {emp.DeptName}");
                Console.WriteLine($"Total Employee  : {emp.TotalEmployee}");
                Console.WriteLine($"Min Salary\t: {emp.MinSalary}");
                Console.WriteLine($"Max Salary\t: {emp.MaxSalary}");
                Console.WriteLine($"Average Salary  : {emp.Average}");
                Console.WriteLine();
            }
            Console.WriteLine("Prees Return to back");
            Console.ReadKey();
            LinqMenu();
        }
        public void LinqMenu()
        {
            Console.Clear();
            Console.WriteLine("     Menu LINQ     ");
            Console.WriteLine("--------------");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Exit");

            try
            {
                Console.Write("Select Menu : ");
                int InputPilihan = int.Parse(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        GetTugas1();
                        break;
                    case 2:
                        GetTugas2();
                        break;
                    case 3:
                        new Menu().MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        LinqMenu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
