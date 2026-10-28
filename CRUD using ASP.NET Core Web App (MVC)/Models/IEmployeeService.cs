namespace CRUD_using_ASP.NET_Core_Web_App__MVC_.Models
{
    public interface IEmployeeService
    {
        IEnumerable<Employees> GetAllEmployees();
        Employees? GetEmployeesById(int id);
        void AddEmployee(Employees employee);
        void UpdateEmployee(Employees employee);
        void DeleteEmployee(int id);
    }
}
