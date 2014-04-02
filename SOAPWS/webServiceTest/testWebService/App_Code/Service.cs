using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
    }

    [WebMethod]
    public int Add(int x, int y)
    {
        return x + y;
    }

    [WebMethod]
    public int Subtract(int x, int y)
    {
        return x - y;
    }

    [WebMethod]
    public int Multiply(int x, int y)
    {
        return x * y;
    }
}
    

