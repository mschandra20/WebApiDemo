using DataAccessLayer;
using System.Collections.Generic;

namespace EmployeeService.Controllers
{
    public interface ICrudClass
    {
         Employee GetEmployeeWithId(int id);
         List<Employee> GetAllEmployees();
         Employee AddEmployee(Employee employee);
         Employee DeleteEmployee(int id, EmployeeDBEntities entities);
         Employee UpdateEmployee(int id, Employee employee);
         Employee IdExists(int id, EmployeeDBEntities entities);

    }
}