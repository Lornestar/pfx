<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rob.aspx.cs" Inherits="Peerfx.Rob" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<telerik:RadScriptManager ID="ScriptManager" runat="server" />       
<center>

<table style="text-align:center; border:1px solid black; padding:3px 3px 3px 3px;" cellspacing="10">
    <tr>
        <td><img src="/Images/Peerfx_logo.png" /></td>
    </tr>
    <tr>
        <td>Rob's Top Up Tool</td>
    </tr>
    <tr>
        <td><telerik:RadTextBox ID=txtpin runat=server EmptyMessage="PIN"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td>
        <telerik:RadComboBox ID="ddlembeecountry" runat=server EmptyMessage="Select Country To send Top Up"
                                                OnSelectedIndexChanged="ddlembeecountry_changed" AutoPostBack=true Width="300">
                                                </telerik:RadComboBox>
                                                </td>
                                                </tr>
                                                <tr>
                                                <td>
                                                <telerik:RadComboBox ID=ddlembeecatalog runat=server EmptyMessage="Select Top up plan" Width="300" HighlightTemplatedItems="true"
                                                AutoPostBack=true>
                                                <HeaderTemplate>
                                                <table width=100%>
                                                    <tr>
                                                        <td style="width:75%; text-align:center;">
                                                            Top Up Plan
                                                        </td>
                                                        <td style="width:50%; text-align:center;">
                                                            Price in USD
                                                        </td>
                                                    </tr>                                                                                                               
                                                </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width=100%>
                                                    <tr>
                                                        <td style="width:75%; text-align:left;">
                                                            <%# DataBinder.Eval(Container.DataItem, "product_name") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID=lblprice runat=server><%# DataBinder.Eval(Container.DataItem, "price_in_dollars", "{0:c}") %></asp:Label>
                                                        </td>
                                                    </tr>
                                                    </table>
                                                </ItemTemplate>
                                                </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
        <telerik:RadTextBox ID=txtembeephone runat=server EmptyMessage="Phone Number to top up" >
                                                </telerik:RadTextBox><span style="font-size:smaller;"><br />(Do not enter country code & do not start # with a 0)</span>
        </td>
    </tr>
    <tr>
        <td>
            <br />
            <telerik:RadButton ID=btnsubmit runat=server Text="Submit" 
                onclick="btnsubmit_Click" ></telerik:RadButton>
        </td>
    </tr>
    <tr>
        <td><asp:Label ID=lblresult runat=server ForeColor=Blue></asp:Label></td>
    </tr>
</table>

</center>
    
    </div>
    </form>
</body>
</html>
