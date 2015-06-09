<%@ Page Language="C#" MasterPageFile="~/Common/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="FontViewer_Default" Title="خەت نۇسخىسى كۆرگۈچ(Online Font Viewer)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="text-align: center">
                <br />
                خەت نۇسخىسى كۆرگۈچ<br />
                Online Font Viewer<br />
                <hr class="HorzentalLineHeader" dir="rtl" />
            </td>
        </tr>
        <tr>
            <td>
            
            
                <table cellpadding="0" dir="rtl" 
                    style="border-collapse: collapse; width: 800px; border: 1px solid #d5ddf3" 
                    align="center">
                    <tr>
                        <td dir="rtl" width="150">
                            خەت نۇسخىسى:</td>
                        <td align="center" style="height: 32px">
                            <asp:FileUpload ID="fuFont" runat="server" Width="400px" />
                            <asp:RegularExpressionValidator ID="revFontFile" runat="server" 
                                ControlToValidate="fuFont" Enabled="False" 
                                ErrorMessage="تاللانغىنى خەت نۇسخىسى ھۆججىتى ئەمەس!" 
                                
                                ValidationExpression="\b[a-zA-Z]:\\[^/:*?&lt;&gt;|\r\n]*(\.[t|T][t|T][f|F])">*</asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="cvFont" runat="server" ControlToValidate="fuFont" 
                                ErrorMessage="تاللانغىنى خەت نۇسخىسى ھۆججىتى ئەمەس!" 
                                onservervalidate="cvFont_ServerValidate">*</asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfvFont" runat="server" 
                                ControlToValidate="fuFont" ErrorMessage="خەت نۇسخىسى تاللانمىغان!">*</asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblFont" runat="server"></asp:Label>
                        </td>
                        <td dir="rtl" align="center" width="150">
                            <asp:Button ID="btnUpload" runat="server" Text="يۈكلەش" 
                                onclick="btnUpload_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right"  dir="rtl">
                            سىناق تېكىست:</td>
                        <td style="text-align: center">
                            <asp:TextBox ID="txtSampleText" runat="server" Width="400px">ئۇيغۇر يۇمشاق دېتال ئىجادىيەت تورى</asp:TextBox>
                                            </td>
                        <td style="text-align: right">
                            &nbsp;</td>
                                        </tr>
                    <tr>
                        <td style="text-align: Right">
                            رايۇن:</td>
                        <td style="text-align: center">
                            <asp:DropDownList ID="ddlRegion" runat="server">
                            </asp:DropDownList>
                                            </td>
                        <td style="text-align: center">
                            <asp:Button ID="btnView" runat="server" Text="كۆرۈش" CausesValidation="False" 
                                onclick="btnView_Click" />
                        </td>
                                        </tr>
                    <tr>
                        <td style="text-align: center" colspan="3">
                            <asp:Image ID="imgFont" runat="server" BorderWidth="1px" Height="1123px" 
                                Width="794px" />
                        </td>
                                        </tr>
                                        </table>
                <br />
                <br />
                <br />
                مۇناسىۋەتلىك ئۇلىنىشلار<hr align="right" class="HorzentalLineLinks" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

