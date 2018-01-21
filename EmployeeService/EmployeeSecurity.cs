using EmployeeDataAccess;
using System;
using System.Linq;

namespace EmployeeWEBAPIDEMO
{
    public static class EmployeeSecurity
    {
        /// <summary>
        /// This method checks whether the username and password match the record in database and return true or false
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string username, string password)
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                return entity
                      .Users
                      .Any(user => user.Username
                                       .Equals(username,StringComparison.OrdinalIgnoreCase) 
                                && user.Password == password);
            }
        }
    }
}