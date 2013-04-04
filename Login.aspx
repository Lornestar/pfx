<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Peerfx.Login" MasterPageFile="~/Site.Master"%>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>



<center>
<div class="Login_Page">
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <table cellpadding=3 >
        <tr>
            <td class="Login_Header" colspan=2>
                <center>
                Login
                </center>
            </td>
        </tr>
        <tr>
            <td>
            Email:
            </td>
            <td>
                 <telerik:RadTextBox ID=txtemail runat=server Width=250></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
            Password:
            </td>
            <td>
                <telerik:RadTextBox ID=txtpassword runat=server TextMode=Password Width=250></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan=2>
                <center>
                <telerik:RadButton ID=btnLogin runat=server Text="Login"
                    onclick="btnLogin_Click" CssClass="Buttons">
                    <Image IsBackgroundImage=true ImageUrl="/images/buttons/button_background.png" />                    
                    </telerik:RadButton>                
                </center>
            </td>
        </tr>
        <tr>
            <td colspan=2>
                <center>
                <asp:Label runat=server ID=lblerror CssClass="lblerror" Visible=false>Incorrect email/password combination.</asp:Label>
                </center>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>    
    </div>
</center>


</asp:Content>