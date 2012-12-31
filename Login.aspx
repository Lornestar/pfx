<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Peerfx.Login" MasterPageFile="~/Site.Master"%>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

<center>
    <table style="border:1px solid black; padding:20px 20px 20px 20px; background-color:#EEEEEE; padding:5 5 5 5;">
        <tr>
            <td class="Login_Header">
                <center>
                Login
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTextBox ID=txtemail runat=server EmptyMessage="Email Address" Width=300></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTextBox ID=txtpassword runat=server EmptyMessage="Password" TextMode=Password Width=300></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                <telerik:RadButton ID=btnLogin runat=server Text="Login" 
                    onclick="btnLogin_Click"></telerik:RadButton>                
                </center>
            </td>
        </tr>
        <tr>
            <td >
                <center>
                <asp:Label runat=server ID=lblerror ForeColor=Blue Visible=false>Incorrect email/password combination.</asp:Label>
                </center>
            </td>
        </tr>
    </table>
</center>

</telerik:RadAjaxPanel>
</asp:Content>