using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EmployeeService.Controllers
{
    public abstract class CrudClass: ICrudClass
    {
        public Employee GetEmployeeWithId(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return IdExists(id,entities);
            }
        }
        public List<Employee> GetAllEmployees()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
           
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
               return entities.Employees.ToList();
            }
                  
        }

        public Employee AddEmployee(Employee employee)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Employees.Add(employee);
                entities.SaveChanges();
               //message.Headers.Location = new Uri(Request.RequestUri.AbsolutePath+employee.ID);
                return employee;
            }
        }


        public Employee DeleteEmployee(int id, EmployeeDBEntities entities)
        {
            Employee empObj = IdExists(id, entities);
            if (empObj != null)
            {
                entities.Employees.Remove(empObj);//The issue here is we need to save changes to the DB or it wont effect 
                entities.SaveChanges();
                return empObj;
            }
            else
            {
                return null;
            }
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                Employee empObj = IdExists(id, entities);
                if (empObj != null)
                {
                    empObj.FirstName = employee.FirstName;
                    empObj.LastName = employee.LastName;
                    empObj.Gender = employee.Gender;
                    empObj.Salary = employee.Salary;

                    entities.SaveChanges();
                    return empObj;

                }
                else
                    return null;

            }
        }



        public Employee IdExists(int id, EmployeeDBEntities entities)
        {
            return entities.Employees.FirstOrDefault(e => e.ID == id);
            
        }



    }


}