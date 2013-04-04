<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup2.aspx.cs" Inherits="Peerfx.Signup2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/Scripts.js" type="text/javascript"></script>
    <link href="Peerfx.css" rel="stylesheet" type="text/css" />
</head>
<body>
<script language=javascript>
    function CloseWindow() {
        GetRadWindow().close('0');
    }
    function Loginuser() {
        GetRadWindow().close('1');
    }

</script>

    <form id="form1" runat="server">
    <div style="background-color:#EEEEEE; height:100%">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />       
    <center>
    <table >
        <tr>
            <td  colspan=2>
                <center>
                <asp:Panel ID=pnlinfo runat=server Visible=false >
                    Please sign up before requesting a payment
                </asp:Panel>
                <span class="Login_Header">Sign Up</span>
                </center>
            </td>
        </tr>
        <tr>
            <td>
            First Name
            </td>
            <td>
                <telerik:RadTextBox ID=txtfirstname runat=server Width=200></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
            Last Name
            </td>
            <td>
                <telerik:RadTextBox ID=txtlastname runat=server Width=200></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <telerik:RadTextBox ID=txtemail runat=server Width=200></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <telerik:RadTextBox ID=txtpassword runat=server Width=200 TextMode=Password></telerik:RadTextBox>
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
    </center>

    </div>
    </form>
</body>
</html>
