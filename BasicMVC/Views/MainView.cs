namespace BasicMVC.Views
{
    public class MainView
    {
        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("      Main Menu     ");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Countries");
            Console.WriteLine("2. Regions");
            Console.WriteLine("3. Locations");
            Console.WriteLine("4. Jobs");
            Console.WriteLine("5. Departments");
            Console.WriteLine("6. Employees");
            Console.WriteLine("7. Histories");
            Console.WriteLine("8. LINQ");
            Console.WriteLine("9. Exit");
            Console.WriteLine();
            Console.Write("Select Tabel: ");
        }

        public void NotFound()
        {
            Console.WriteLine("Data Not Found");
        }

        public void SuccessInsert()
        {
            Console.WriteLine("Data add successfully ");
        }

        public void FailedInsert()
        {
            Console.WriteLine("Data failed to add");
        }

        public void SuccessUpdate()
        {
            Console.WriteLine("Data update successfully ");
        }

        public void FailedUpdate()
        {
            Console.WriteLine("Data failed to update");
        }

        public void SuccessDelete()
        {
            Console.WriteLine("Data delete successfully ");
        }

        public void FailedDelete()
        {
            Console.WriteLine("Data failed to delete");
        }

        public static void ErrorHandling(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
