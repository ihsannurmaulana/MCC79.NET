namespace BasicMVC.Views
{
    public class MessageView
    {
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
