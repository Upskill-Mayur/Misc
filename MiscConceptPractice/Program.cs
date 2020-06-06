using BoxingUnboxing;
using PracticeDelegates;
using ReferenceBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConceptPractice
{
    class Program
    {
        static void CustomPhotoProcessFilter(Photo photo)
        {
            Console.WriteLine("Custom filter applied on photo through delegate call");
        }

        static void CustomActionProcessFilter(Photo photo)
        {
            Console.WriteLine("Custom filter applied on photo through Action<> delegate call");
        }
        static void Main(string[] args)
        {
            //Delegates and Action<> delegates
            PhotoProcessor processor = new PhotoProcessor();
            processor.DefaultProcess("abc");
            PhotoProcessor.FilterHandler filterHandler = CustomPhotoProcessFilter;
            processor.CustomProcess(filterHandler);
            processor.CustomActionProcess(CustomActionProcessFilter);

            //Reference behaviour
            Employee emp = new Employee();
            emp.Name = "Mayur";

            Console.WriteLine($"Employee original name is {emp.Name }  {emp.GetHashCode()}");

            Employee.ChangeEmployeeName(emp, "Mangesh");
            Console.WriteLine($"Employee changed name is {emp.Name}  {emp.GetHashCode()}");

            //Observer that name and hashcode both changeds means reference is pointing to new object created.
            Employee.ChangeEmployeeNamePassByRef(ref emp, "Santosh");
            Console.WriteLine($"Employee changed name after pass by ref is {emp.Name}  {emp.GetHashCode()}");


            //Boxing Unboxing
            TestBoxUnbox.Box();


        }
    }
}
