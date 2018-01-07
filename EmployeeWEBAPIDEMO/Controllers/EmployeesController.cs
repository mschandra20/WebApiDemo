﻿using EmployeeDataAccess;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWEBAPIDEMO.Controllers
{
    public class EmployeesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var EmployeeList = entities.Employees.ToList();
                    
                    return Request.CreateResponse(HttpStatusCode.OK, EmployeeList);
                }
            }
            catch(Exception ex)
            {
                ErrorLogger(ex);
               return Request.CreateErrorResponse(HttpStatusCode.NotFound,ex);
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
                        return Request.CreateResponse(HttpStatusCode.NotFound, empObj);

                }
            }
            catch(Exception ex)
            {
                ErrorLogger(ex);
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
                ErrorLogger(ex);

                return ErrorMessage;
            }
        }


        //This method logs error to txt file
        private static void ErrorLogger(Exception ex)
        {
            string path = @"C:\Users\SHARATHCHANDRA\documents\visual studio 2017\Projects\EmployeeWEBAPIDEMO\EmployeeWEBAPIDEMO\ErrorLogFile\ErrorLogger.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("Message: " + ex.Message + "\n"
                                + "StackTrace: " + ex.StackTrace
                                +"Date: "+DateTime.Now 
                                + Environment.NewLine);

                writer.WriteLine(Environment.NewLine + "------------------------------------");
            }
        }
    }
}
