using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Housing_Disrepair_Calculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mainDiv.Visible = true;
            MoreDiv.Visible = false;
            LessDiv.Visible = false;
        }
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double total = 0.0;
        if (ddlSeverity.SelectedValue == "5")
        {
            total = (Convert.ToDouble(ddlRent.SelectedValue) * Convert.ToDouble(ddlYears.SelectedValue) * 52);

            if (ddlReplacement.SelectedValue != "0")
            {
                total = total + Convert.ToDouble(ddlReplacement.SelectedValue);
            }
        }
        else
        {
             total=((Convert.ToDouble(ddlRent.SelectedValue) * Convert.ToDouble(ddlYears.SelectedValue) * 52)/5)+(520*(Convert.ToDouble(ddlSeverity.SelectedValue)-1));
         
		
		     if (ddlReplacement.SelectedValue != "0")
            {
                total = total + Convert.ToDouble(ddlReplacement.SelectedValue);
            }
        }
        if (total > 10000)
        {
            mainDiv.Visible = false;
            MoreDiv.Visible = true;
            LessDiv.Visible = false;
            lblClaim.Text = "£" + total;
            lblclaimheading.Text = "£" + total;
        }
        else
        {
            mainDiv.Visible = false;
            MoreDiv.Visible = false;
            LessDiv.Visible = true;
            lblLess.Text = "£" + total;
            lblclaimheading.Text = "£" + total;
        }

        
    }


    private void calculate()
    {
        double total = 0.0;
        if (ddlSeverity.SelectedValue == "1")
        {
            total = (Convert.ToDouble(ddlRent.SelectedValue) * Convert.ToDouble(ddlYears.SelectedValue) * 52) / 5;

            if (ddlReplacement.SelectedValue != "0")
            {
                total = total + Convert.ToDouble(ddlReplacement.SelectedValue);
            }
        }
        else if (ddlSeverity.SelectedValue == "2")
        {
            total = ((Convert.ToDouble(ddlRent.SelectedValue) * Convert.ToDouble(ddlYears.SelectedValue) * 52) / 5) + (520);


            if (ddlReplacement.SelectedValue != "0")
            {
                total = total + Convert.ToDouble(ddlReplacement.SelectedValue);
            }
        }
        else if (ddlSeverity.SelectedValue == "3")
        {
            total = ((Convert.ToDouble(ddlRent.SelectedValue) * Convert.ToDouble(ddlYears.SelectedValue) * 52) / 5) + (520 * 3);


            if (ddlReplacement.SelectedValue != "0")
            {
                total = total + Convert.ToDouble(ddlReplacement.SelectedValue);
            }
        }
        else if (ddlSeverity.SelectedValue == "4")
        {
            total = ((Convert.ToDouble(ddlRent.SelectedValue) * Convert.ToDouble(ddlYears.SelectedValue) * 52) / 5) + (520 * 5);


            if (ddlReplacement.SelectedValue != "0")
            {
                total = total + Convert.ToDouble(ddlReplacement.SelectedValue);
            }
        }
        else if (ddlSeverity.SelectedValue == "4")
        {
            total = ((Convert.ToDouble(ddlRent.SelectedValue) * Convert.ToDouble(ddlYears.SelectedValue) * 52) / 5) + (520 * 8);


            if (ddlReplacement.SelectedValue != "0")
            {
                total = total + Convert.ToDouble(ddlReplacement.SelectedValue);
            }
        }
    }
   
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        mainDiv.Visible = true;
        MoreDiv.Visible = false;
        LessDiv.Visible = false;
    }
}