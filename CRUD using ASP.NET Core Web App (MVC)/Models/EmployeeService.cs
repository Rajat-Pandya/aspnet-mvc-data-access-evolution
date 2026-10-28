namespace CRUD_using_ASP.NET_Core_Web_App__MVC_.Models
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employees> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employees? GetEmployeesById(int id)
        {
            return _context.Employees.Find(id);
        }
        public void AddEmployee(Employees employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void UpdateEmployee(Employees employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
