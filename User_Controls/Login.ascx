<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Peerfx.User_Controls.Login" %>


<table>
    <tr>
        <td>
            <asp:Panel ID=pnlLoginSignup runat=server>
            <table width=150px>
                <tr>
                    <td>
                    <img src="/images/Icons/Login_Arrow.png" />
               <a href="../Login.aspx" class="Navigation_text">Login</a>
                    </td>
                    <td>
                    <img src="/images/Icons/Login_Arrow.png" />
                        <a onclick="openSignup('0')" href="#" class="Navigation_text">Signup</a>
                    </td>
                </tr>
            </table>             
            </asp:Panel>
            <asp:Panel ID=pnlSignedIn runat=server Visible=false>            
            <div style=" position:absolute; top:0px; right:200px;">                          
                <div class="Loggedin">
                    <a href="/User/dashboard.aspx">
                            <div style="background-image:url('/Images/Buttons/Loggedin_left.png'); width:50px;">&nbsp;</div>
                            <div style="background-image:url('/Images/Buttons/Loggedin_middle.png'); background-repeat:repeat-x;  text-indent:4px;">
                            <asp:Label ID=lblusername runat=server>Email Address</asp:Label>
                            </div>
                            <div style="background-image:url('/Images/Buttons/Loggedin_middle.png'); width:10px; background-repeat:repeat-x;">
                            </div>            
                            </a>                
                            <div style="background-image:url('/Images/Buttons/Loggedin_right.png');  width:92px; text-indent:5px;"> 
                            <telerik:RadButton ID=btnlogout runat=server Text="Logout" 
                        onclick="btnlogout_Click" Width=80px ForeColor=White>
                        <Image IsBackgroundImage=true ImageUrl="/Images/Buttons/Loggedin_Invisiblebutton.png" />
                        </telerik:RadButton>
                            </div>
                            </div>
                        </div>
                
                
                            <asp:HyperLink ID=hypAdmin runat=server Text="Admin Stuff" runat=server Visible=false NavigateUrl="~/Admin/Admin_Default.aspx"></asp:HyperLink>
                        
                
                
            </asp:Panel>
        </td>
    </tr>
</table>
