
using DataAccessLayer;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    // [RequireHttps]
    //[BasicAuthentication]
    [Serializable]
    [Authorize]
    public class EmployeesController : ApiController
    {
        CrudClass cd = new CrudClass();

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
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
              
                Employee empObj = cd.GetEmployeeWithId(id);
                if (empObj != null)
                    return Request.CreateResponse(HttpStatusCode.OK, empObj);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "The Employee with ID = " + id + " is NOT found");
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
            if (employee != null)
            {
                try
                {
                    return cd.AddEmployee(employee);

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
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Employee Object is null. The form submission is not done properly");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    return cd.DeleteEmployee(id, entities);

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
                return cd.UpdateEmployee(id, employee);
            }
            catch (Exception ex)
            {
                ErrorClass.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //private List<Employee> GetAllEmployees()
        //{
        //    string username = Thread.CurrentPrincipal.Identity.Name;
        //    string g = "ALL";
        //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //    {

        //        switch (g)
        //        {
        //            case "ALL":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.Employees.ToList());
        //            case "MALE":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.Employees.Where(e => e.Gender.ToUpper() == "MALE").ToList());
        //            case "FEMALE":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.Employees.Where(e => e.Gender.ToUpper() == "FEMALE").ToList());
        //            default:
        //                return Request.CreateResponse(HttpStatusCode.BadRequest);
        //                //"The given gender value " + gender + " is not valid. It accepts only All, Male, Female");
        //        }

        //    }
        //}

    }
}
