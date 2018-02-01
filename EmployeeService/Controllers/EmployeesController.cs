using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    // [RequireHttps]
    //[BasicAuthentication]
    [Authorize]
    public class EmployeesController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            try
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
            catch (Exception ex)
            {
                ErrorClass.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);

            }
        }
        
        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var empObj = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (empObj != null)
                        return Request.CreateResponse(HttpStatusCode.OK, empObj);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, 
                            "The Employee with ID = " + id + " is NOT found");

                }
            }
            catch (Exception ex)
            {
                ErrorClass.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Here for this post method if we don't return anything then we get HttpResponse code of 
        // 204 No Content(Actually we dont want this reponse)

        //We need to set a CREATED response and send the object or record created to show whats added
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
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
            //catch(Exception)
            //We actually don't catch a general exception like 
            //this(without using its object) do an operation for whatever the error may occur

            catch (Exception ex)
            {
                //var ErrorMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest,"THERE IS SOMETHING WRONG IN INPUT");
                var ErrorMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                ErrorClass.ErrorLogger(ex);

                return ErrorMessage;
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var empObj = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (empObj != null)
                    {
                        entities.Employees.Remove(empObj);//The issue here is we need to save changes to the DB or it wont effect 
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, empObj);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "The Employee with ID = "+id + " is NOT found");

                }
            }
            catch (Exception ex)
            {
                ErrorClass.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        //Here we are forcing the web api controller to take the id parameter from RequestBody and
        // the employee data with which we need to update in the Uri
        public HttpResponseMessage Put([FromBody] int id, [FromUri] Employee employee)
        {
            try
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
            catch (Exception ex)
            {
                ErrorClass.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
                
    }
}
