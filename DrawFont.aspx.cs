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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

public partial class FontViewer_DrawFont : System.Web.UI.Page
{
    int nLeft = 77;
    int nTop = 180;
    protected void Page_Load(object sender, EventArgs e)
    {
        Draw();
    }


    private void Draw()
    {

        Bitmap objBitMap = new Bitmap(794, 1123);
        Graphics objGraph = Graphics.FromImage(objBitMap);
        objGraph.FillRectangle(new SolidBrush(Color.White), 0, 0, 794, 1123);

        DrawTable(objGraph);
        drawFont(objGraph);
        drawHeaderAndFooter(objGraph);

        Response.ContentType = "image/jpeg";
        objBitMap.Save(Response.OutputStream, ImageFormat.Jpeg);
        objBitMap.Dispose();
    }

    private void DrawTable( Graphics objGraph)
    {
        
       
      
        Color objColor = Color.Black;
        Point pnt = new Point(0, 0);
        
        Point phStart = new Point();
        Point phEnd = new Point();
        Point pvStart = new Point();
        Point pvEnd = new Point();
        for (int nCount = 0; nCount < 0x11; nCount++)
        {
            phStart = new Point(nLeft, (nCount * 0x37) + nTop);
            phEnd = new Point(640 + nLeft, (nCount * 0x37) + nTop);
            objGraph.DrawLine(new Pen(Color.Black), phStart, phEnd);
            pvStart = new Point((nCount * 40) + nLeft, nTop);
            pvEnd = new Point((nCount * 40) + nLeft, 880 + nTop);
            objGraph.DrawLine(new Pen(Color.Black), pvStart, pvEnd);
        }

    }

    private void drawFont(Graphics objGraph)
    {
        //fonts
        PrivateFontCollection pFont = new PrivateFontCollection();
        pFont.AddFontFile(Session["FontPath"].ToString());
        System.Drawing.Font fntForChar = new Font(pFont.Families[0], 16);
        Font objFontforNum = new Font("verdana", 7f);

        //color
        Color clrForNum = Color.Black;
        Color clrForChar = Color.Black;
        Color clrSampleText = Color.Black;
        string strOneChar = "سارۋان";

        int nCharIndex = Convert.ToInt32(Session["Region"].ToString())*256;
        for (int nX = 0; nX < 0x10; nX++)
        {
            for (int nY = 0; nY < 0x10; nY++)
            {
                objGraph.DrawString(nCharIndex.ToString("X"), objFontforNum, new SolidBrush(clrForNum), (float)((nX * 40) + nLeft), (float)(((nY * 0x37) + 40) + nTop));
                strOneChar = Convert.ToString((char)nCharIndex);
                objGraph.SmoothingMode = SmoothingMode.AntiAlias;
                objGraph.DrawString(strOneChar, fntForChar, new SolidBrush(clrForChar), (float)((nX * 40) + nLeft), (float)((nY * 0x37) + nTop));
                nCharIndex++;
            }
        }
        StringFormat sfMainText = new StringFormat();
        sfMainText.FormatFlags = StringFormatFlags.DirectionRightToLeft;
        Rectangle recSampleText = new Rectangle(nLeft, 80, 640, 100);
        //objGraph.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), recSampleText);
        objGraph.DrawString(Session["SampleText"].ToString(), fntForChar, new SolidBrush(clrSampleText), recSampleText, sfMainText);



    }

    private void drawHeaderAndFooter(Graphics objGraph)
    {

        int nLeft = 77;
        int nRight = 77;
        int nTop = 80;
        int nButtom = 50;
        System.Drawing.Size szPageSize = new Size(794, 1123);
        Rectangle recTextArea = new Rectangle(nLeft, nTop, 640, 1000);
        Size szTextArea = new Size(640, 1000);


        //point
        Point pntHeaderLineLeft = new Point(nLeft, 50);
        Point pntHeaderLineRight = new Point(nLeft + recTextArea.Width, 50);

        Point pntFooterLineLeft = new Point(nLeft, nTop + recTextArea.Height);
        Point pntFooterLineRight = new Point(nLeft + recTextArea.Width, nTop + recTextArea.Height);


        //fonts
        Font fntWebSite = new Font("Segoe UI", 9);
        Font fntHeader = new Font("ALKATIP Tor", 12);
        Font fntFooter = new Font("ALKATIP Tor", 9);
        string strMFontName = "";
        int nMFontSize = 9;


        //color
        Color clrMaintText = Color.Black;
        Color clrWebSite = Color.Black;
        Color clrLine = Color.FromArgb(39, 173, 233);
        Color clrHeaderText = Color.Black;
        Color clrFooterText = Color.Black;

        //format
        StringFormat sfMainText = new StringFormat();
        sfMainText.FormatFlags = StringFormatFlags.DirectionRightToLeft;


        //Draw line
        Pen pnLine = new Pen(clrLine, 5);
        objGraph.DrawLine(pnLine, pntHeaderLineLeft, pntHeaderLineRight);
        objGraph.DrawLine(pnLine, pntFooterLineLeft, pntFooterLineRight);


        //draw string
        objGraph.TextRenderingHint = TextRenderingHint.AntiAlias;
        objGraph.DrawString("ئۇيغۇر يۇمشاق دېتال ئىجادىيەت تورى", fntHeader, new SolidBrush(clrHeaderText), nLeft + recTextArea.Width, 25, sfMainText);
        objGraph.DrawString("http://lab.UyghurDev.net", fntWebSite, new SolidBrush(clrWebSite), 220, szPageSize.Height - 40, sfMainText);
        objGraph.DrawString("خەت نۇسخىسى كۆرگۈچ", fntFooter, new SolidBrush(clrHeaderText), nLeft + recTextArea.Width, szPageSize.Height - 40, sfMainText);

        objGraph.DrawString("خەت نۇسخىسى نامى:" + Session["FontName"].ToString() +"          "+ "رايۇن:" + Session["Region"].ToString()+"-رايۇن", fntHeader, new SolidBrush(clrHeaderText), nLeft + recTextArea.Width, nTop - 20, sfMainText);
        //objGraph.DrawString("رايۇن:"+Session["Region"].ToString(), fntHeader, new SolidBrush(clrHeaderText), nLeft + recTextArea.Width, nTop, sfMainText);



    }



}
