using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectToDb.DataModel;

namespace ConnectToDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SchoolDBContext context = new SchoolDBContext())
            {
                var a = context;
                var b = 1 + 2;
                Student student = new Student();
                student.StudentName = "Vaysa";
                //book.Title = "Кобзар";
                //book.Author = "Шевченко";

                context.Students.Add(student);
                context.SaveChanges();

            }
            Console.WriteLine("Done");
        }
    }
}
