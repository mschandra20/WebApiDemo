using EmployeeDataAccess;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWEBAPIDEMO.Controllers
{
    public class AdventureController : ApiController
    {
        public HttpResponseMessage GetPeople()
        {
            try
            {
                using (AdventureWorksEntities entities = new AdventureWorksEntities())
                {
                    if (typeof(AdventureWorksEntities).IsSerializable)//By this we came to know 
                                                    //AdventureWorksEntities class is not serializable
                    {

                        return Request.CreateResponse(HttpStatusCode.OK,
                                   entities.Addresses.Where(y => y.City == "Renton").Take(100).ToList());

                        // return Request.CreateResponse(HttpStatusCode.NotFound,
                    }

                    return Request.CreateResponse(HttpStatusCode.NotFound, 
                        "The requested object is not serilizable");
                }
            }
            catch (Exception ex)
            {
                ErrorClass er = new ErrorClass();
                er.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);

            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (AdventureWorksEntities entities = new AdventureWorksEntities())
                {
                    var empObj = entities.Addresses.FirstOrDefault(e => e.AddressID == id);
                    if (empObj != null)
                        return Request.CreateResponse(HttpStatusCode.OK, empObj);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "The Address with ID = " + id + " is NOT found");

                }
            }
            catch (Exception ex)
            {
                ErrorClass er = new ErrorClass();
                er.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Here for this post method if we don't return anything then we get HttpResponse code of 
        // 204 No Content(Actually we dont want this reponse)

        //We need to set a CREATED response and send the object or record created to show whats added
        public HttpResponseMessage Post([FromBody]Address ad)
        {
            try
            {
                using (AdventureWorksEntities entities = new AdventureWorksEntities())
                {
                    entities.Addresses.Add(ad);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, ad);
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
                ErrorClass er = new ErrorClass();
                er.ErrorLogger(ex);

                return ErrorMessage;
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (AdventureWorksEntities entities = new AdventureWorksEntities())
                {
                    var empObj = entities.Addresses.FirstOrDefault(e => e.AddressID == id);
                    if (empObj != null)
                    {
                        entities.Addresses.Remove(empObj);//The issue here is we need to save changes to the DB or it wont effect 
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, empObj);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "The Address with ID = " + id + " is NOT found");

                }
            }
            catch (Exception ex)
            {
                ErrorClass er = new ErrorClass();
                er.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Here we are forcing the web api controller to take the id parameter from RequestBody and
        // the employee data with which we need to update in the Uri
        public HttpResponseMessage Put(int id, [FromUri] Address ad)
        {
            try
            {
                using (AdventureWorksEntities entities = new AdventureWorksEntities())
                {
                    var empObj = entities.Addresses.FirstOrDefault(e => e.AddressID == id);
                    if (empObj != null)
                    {
                        empObj.AddressLine1 = ad.AddressLine1;
                        empObj.AddressLine2 = ad.AddressLine2;
                        empObj.City = ad.City;
                        empObj.StateProvince= ad.StateProvince;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, empObj);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "The Employee with ID = " + id + " is NOT found");

                }
            }
            catch (Exception ex)
            {
                ErrorClass er = new ErrorClass();
                er.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
