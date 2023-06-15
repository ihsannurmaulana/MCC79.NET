namespace Connectivity
{
    class Linq
    {
        public void GetTugas1()
        {
            var employee = new Employee();
            var department = new Department();
            var location = new Location();
            var country = new Country();
            var region = new Region();

            var employess = (from e in employee.GetAllEmployee()
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
                             }).Take(5);
            Console.Clear();
            foreach (var emp in employess)
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

            var employees = from d in department.GetAllDepartment()
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
                            };
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
            Console.WriteLine("1. Tugas Nomor 1");
            Console.WriteLine("2. Tugas Nomor 2");
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
