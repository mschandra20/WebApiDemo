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
