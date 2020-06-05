using BoxingUnboxing;
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
        static void Main(string[] args)
        {
            //Reference behaviour

            Employee emp = new Employee();
            emp.Name = "Mayur";

            Console.WriteLine($"Employee origianl name is {emp.Name }  {emp.GetHashCode()}");

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
