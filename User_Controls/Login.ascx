<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Peerfx.User_Controls.Login" %>

<table>
    <tr>
        <td>
            <asp:Panel ID=pnlLoginSignup runat=server>
               <a href="../Login.aspx">Login</a> | <a href="../Signup.aspx">Signup</a>
            </asp:Panel>
            <asp:Panel ID=pnlSignedIn runat=server Visible=false>
                <div style="float:right;">
                <asp:Label ID=lblusername runat=server>Email Address</asp:Label>
                <br />
                <asp:HyperLink ID=hypAdmin runat=server Text="Admin Stuff" runat=server NavigateUrl="~/Admin/Admin_Default.aspx"></asp:HyperLink>
                <br />                
                <telerik:RadButton ID=btnlogout runat=server Text="Logout" 
                        onclick="btnlogout_Click"></telerik:RadButton>
                </div>
            </asp:Panel>
        </td>
    </tr>
</table>
