<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Peerfx.User_Controls.Footer" %>

<%@ Register Src="~/User_Controls/Login.ascx" tagname="Login" tagprefix="uc1" %>
<div class="footer">
<center>
<table width="75%" cellpadding=10px >
    <tr>
        <td>
            <a href="/default.aspx">
            <img src="/images/footer_logo.png" />
            </a>
        </td>
        <td align=right>
        <uc1:Login id="ucLogin" runat="Server"></uc1:Login>
        </td>
    </tr>
</table>
</center>
</div>