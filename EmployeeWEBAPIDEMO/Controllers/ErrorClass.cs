using System;
using System.IO;

namespace EmployeeWEBAPIDEMO.Controllers
{
    //static interface IError
    // {
    //     //This method logs error to txt file
    //     void ErrorLogger(Exception ex);

    // }
    public static class ErrorClass//:IError
    {
        //This method logs error to txt file
       public static void ErrorLogger(Exception ex)
        {
            string filename="OtherErrors";
            if (ex.StackTrace.Contains("EmployeesController"))
            filename = "ErrorLogger";
            else if(ex.StackTrace.Contains("AdventureController"))
            filename = "AdventureError";

            string path = @"C:\Users\SHARATHCHANDRA\documents\visual studio 2017\Projects\EmployeeWEBAPIDEMO\EmployeeWEBAPIDEMO\ErrorLogFile\"+filename+".txt";


            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(Environment.NewLine
                                    + "Message: " + ex.Message
                                    + Environment.NewLine
                                    + "StackTrace: " + ex.StackTrace
                                    + Environment.NewLine
                                    + "Date: " + DateTime.Now
                                    + Environment.NewLine
                                    + "Source: " + ex.Source
                                    + Environment.NewLine);
                for (int i = 0; i < 5; i++)
                {
                    writer.Write("------------------------------------");
                }
            }
        }

        
    }
}