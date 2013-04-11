<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Peerfx.User_Controls.Footer" %>

<%@ Register Src="~/User_Controls/Login.ascx" tagname="Login" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/NavigationLinks.ascx" tagname="NavigationLinks" tagprefix="uc4" %>
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
        <uc4:NavigationLinks id="NavigationLinks" runat=server></uc4:NavigationLinks>
        <uc1:Login id="ucLogin" runat="Server"></uc1:Login>
        </td>
    </tr>
</table>
</center>
</div>

<div class="footer2">

<center>
    <table width="80%" cellpadding=10px>
        <tr>
            <td>
            Banks charge a lot for foreign-currency transfers. we don’t. we use real exchange rates to help expats, foreign students and businesses wire money securely, conveniently, and at a verylows cost. finally, a financial service built for people, not banks
            </td>
            <td width=280px>
                COPYRIGHT 2013 / 2014 UBNZ MARKETS
            </td>
        </tr>
    </table>    
</center>

</div>