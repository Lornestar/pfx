<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Peerfx.Login" MasterPageFile="~/Site.Master"%>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>
<center>
    <table>
        <tr>
            <td>
                <telerik:RadTextBox ID=txtemail runat=server EmptyMessage="Email Address"></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTextBox ID=txtpassword runat=server EmptyMessage="Password" TextMode=Password></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadButton ID=btnLogin runat=server Text="Login" 
                    onclick="btnLogin_Click"></telerik:RadButton>                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat=server ID=lblerror ForeColor=Blue Visible=false>Incorrect email/password combination.</asp:Label>
            </td>
        </tr>
    </table>
</center>
</asp:Content>