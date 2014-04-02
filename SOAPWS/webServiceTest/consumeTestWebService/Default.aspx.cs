using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtX.Text != string.Empty
        && txtY.Text != string.Empty)
        {
            try
            {
                int x = Convert.ToInt32(txtX.Text);
                int y = Convert.ToInt32(txtY.Text);

                ArithmeticService.Service service = new ArithmeticService.Service();

                Label1.Text = "Sum: " + service.Add(x, y).ToString();
                Label2.Text = "Difference: " + service.Subtract(x, y).ToString();
                Label3.Text = "Multiplication: " + service.Multiply(x, y).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
