using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace EmployeeService.Controllers
{
    public class CrudClass
    {
        public Employee GetEmployeeWithId(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var empObj = entities.Employees.FirstOrDefault(e => e.ID == id);
                return empObj;
            }
        }
        public List<Employee> GetAllEmployees()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            string g = "ALL";
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
               
                switch (g)
                {
                    case "ALL":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.ToList());
                    case "MALE":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToUpper() == "MALE").ToList());
                    case "FEMALE":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToUpper() == "FEMALE").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                        //"The given gender value " + gender + " is not valid. It accepts only All, Male, Female");
                }

            }
        }
        public HttpResponseMessage AddEmployee(Employee employee)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Employees.Add(employee);
                entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                //message.Headers.Location = new Uri(Request.RequestUri.AbsolutePath+employee.ID);

                return message;
            }
        }
        public HttpResponseMessage DeleteEmployee(int id, EmployeeDBEntities entities)
        {
            var empObj = entities.Employees.FirstOrDefault(e => e.ID == id);
            if (empObj != null)
            {
                entities.Employees.Remove(empObj);//The issue here is we need to save changes to the DB or it wont effect 
                entities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, empObj);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "The Employee with ID = " + id + " is NOT found");
        }
        public HttpResponseMessage UpdateEmployee(int id, Employee employee)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var empObj = entities.Employees.FirstOrDefault(e => e.ID == id);
                if (empObj != null)
                {
                    empObj.FirstName = employee.FirstName;
                    empObj.LastName = employee.LastName;
                    empObj.Gender = employee.Gender;
                    empObj.Salary = employee.Salary;

                    entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, empObj);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The Employee with ID = " + id + " is NOT found");

            }
        }
    }
}