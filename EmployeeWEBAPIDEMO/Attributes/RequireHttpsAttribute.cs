using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeWEBAPIDEMO.Attributes
{
    public class RequireHttpsAttribute: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Here in if block we write the code to redirect the incoming
            //http requesting page to https page
            if (actionContext.Request.RequestUri.Scheme!=Uri.UriSchemeHttps)
            {
                actionContext.Response = 
                    actionContext.Request.CreateResponse(HttpStatusCode.Found);//It shows the page is found

                actionContext.Response.Content =
                    new StringContent("<p>Use https instead of http</P>", Encoding.UTF8, "text/html");
                //In the above statement we set which content is sent in response

                //The below statements build the Uri where we need to redirect
                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
                uriBuilder.Scheme = Uri.UriSchemeHttps;
                uriBuilder.Port =44308;

                //Setting the Uri where the page is redirected to
                //(it is constructed by the UriBuilder class above)
                actionContext.Response.Headers.Location = uriBuilder.Uri;

            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}