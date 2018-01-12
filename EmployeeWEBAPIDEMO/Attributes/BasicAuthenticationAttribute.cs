using System;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeWEBAPIDEMO.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //In if we check where the request body contains any Authorization Header
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                                                    .CreateResponse(System.Net.HttpStatusCode.Unauthorized);

            }
            else
            {
                //Here we get the parameter of authorization header in request body and it is base64 ecoded
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                //The authenticationToken above has the username and password in the form of username:password encoded into base64
                //Now we have two things to do
                //1. Decode this base64 to normal string
                //2. Seperate the two strings w.r.t ':' using split function

               string decodedAuthenticationToken = Encoding.UTF8.
                                                    GetString(Convert.FromBase64String(authenticationToken));

               string[] userPass = decodedAuthenticationToken.Split(':');
               string username = userPass[0];
               string password = userPass[1];

                if (EmployeeSecurity.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                                                .CreateResponse(System.Net.HttpStatusCode.Unauthorized); 
                }


            }
        }

       
    }
}