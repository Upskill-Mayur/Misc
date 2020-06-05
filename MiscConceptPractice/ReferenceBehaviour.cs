namespace ReferenceBehaviour
{
    public class Employee
    {
        public string Name { get; set; }

        public static void ChangeEmployeeName(Employee emp, string newName)
        {
            emp.Name = newName;
        }

        public static void ChangeEmployeeNamePassByRef(ref Employee emp, string newName)
        {
            emp = new Employee();
            emp.Name = newName;
        }
    }
        

}