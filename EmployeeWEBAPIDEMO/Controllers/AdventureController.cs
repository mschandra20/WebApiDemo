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
        public HttpResponseMessage GetPeople(string gender = "All")
        {
            try
            {
                using (AdventureWorksEntities entities = new AdventureWorksEntities())
                {

                    switch (gender.ToUpper())
                    {
                        case "ALL":
                            return Request.CreateResponse(HttpStatusCode.OK,
                                entities.Addresses.Where(a=>a.City=="Renton").ToList());
                        //case "MR":
                        //    return Request.CreateResponse(HttpStatusCode.OK,
                        //        entities.People.Where(e => e.Title.ToUpper() == "MR").ToList());
                        //case "MS":
                        //    return Request.CreateResponse(HttpStatusCode.OK,
                        //        entities.People.Where(e => e.Title.ToUpper() == "MS").ToList());
                        default:
                            return Request.CreateResponse(HttpStatusCode.NotFound,
                                "The given gender value " + gender + " is not valid. It accepts only All, MR, MS");
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorClass er = new ErrorClass();
                er.ErrorLogger(ex);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);

            }
        }
        //}
        //    private static void ErrorLogger(Exception ex)
        //    {
        //        //if(ex.)
        //        string path = @"C:\Users\SHARATHCHANDRA\documents\visual studio 2017\Projects\EmployeeWEBAPIDEMO\EmployeeWEBAPIDEMO\ErrorLogFile\ErrorLogger.txt";
        //        using (StreamWriter writer = new StreamWriter(path, true))
        //        {
        //            writer.WriteLine(Environment.NewLine
        //                            + "Message: " + ex.Message
        //                            + Environment.NewLine
        //                            + "StackTrace: " + ex.StackTrace
        //                            + Environment.NewLine
        //                            + "Date: " + DateTime.Now
        //                            + Environment.NewLine
        //                            + "Source: " + ex.Source 
        //                            + Environment.NewLine);
        //            for (int i = 0; i < 5; i++)
        //            {
        //                writer.Write("------------------------------------");
        //            }
        //        }
        //    }
        
    }
}
