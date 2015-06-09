using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class FontViewer_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlRegion.Items.Clear();
            for (int nCount = 1; nCount < 257; nCount++)
            {
                ddlRegion.Items.Add(new ListItem(nCount.ToString() + "-رايۇن", nCount.ToString()));

            }
        }
        //string str = Session["FontPath"].ToString();
        if (Session["FontPath"]==null)
        {
            btnView.Enabled = false;
        }
        else
        {
            btnView.Enabled = true;
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuFont.HasFile)
        {
            if (fuFont.FileName.EndsWith(".ttf",StringComparison.OrdinalIgnoreCase))
            {
                string strFontPath = makeFileName(fuFont.FileName);
                fuFont.PostedFile.SaveAs(strFontPath);
                lblFont.Text = fuFont.FileName + " خەت نۇسخىسى يۈكلىنىپ بولدى.";
                Session["FontName"] = fuFont.FileName;
                Session["FontPath"] = strFontPath;
                btnView.Enabled = true;
            }
            
        }
    }

    private string makeFileName(string strFileName)
    {
        string strPath = Server.MapPath("Fonts");
        string strIP = Request.UserHostAddress.Replace('.','_');
        string strDate=DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+
            DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()+DateTime.Now.Second.ToString()+DateTime.Now.Millisecond.ToString();
        return strPath+"\\"+strIP + "__" + strDate+"_"+strFileName;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Session["Region"] = ddlRegion.SelectedValue;
        Session["SampleText"] = txtSampleText.Text;
        imgFont.ImageUrl = "DrawFont.aspx";
    }
    protected void cvFont_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (fuFont.FileName.EndsWith(".ttf",StringComparison.OrdinalIgnoreCase))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}
