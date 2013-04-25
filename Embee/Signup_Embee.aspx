<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup_Embee.aspx.cs" Inherits="Peerfx.Embee.Signup_Embee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Peerfx.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-image:url('../images/homepage/background.jpg');
     background-repeat:no-repeat;
     background-position:center top;">
    <form id="form1" runat="server">
    <div style="min-height:800px; margin-top:50px; ">
     <center>
     <div class="Login_Page">
<telerik:RadScriptManager ID="ScriptManager" runat="server" />       
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <table >
        <tr>
            <td  colspan=2>
                <center>                
                <span class="Login_Header">Sign Up</span>
                </center>
            </td>
        </tr>
        <tr>
            <td>
            First Name
            </td>
            <td>
                <telerik:RadTextBox ID=txtfirstname runat=server Width=200 AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
            Last Name
            </td>
            <td>
                <telerik:RadTextBox ID=txtlastname runat=server Width=200 AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <telerik:RadTextBox ID=txtemail runat=server Width=200 AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <telerik:RadTextBox ID=txtpassword runat=server Width=200 TextMode=Password AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan=2> <center>
                <telerik:RadButton ID=btnsignup runat=server Text="Sign Up" 
                    onclick="btnsignup_Click"></telerik:RadButton>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan=2>
                <center>
                    <asp:Label ID=lblerror runat=server ForeColor=Red></asp:Label>
                </center>
            </td>
        </tr>
    </table>    

    </telerik:RadAjaxPanel>
    </div>
    </center>
    
    </div>
    </form>
</body>
</html>
