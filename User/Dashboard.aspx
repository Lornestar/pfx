<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Peerfx.User.Dashboard" MasterPageFile="~/Site.Master" %>
<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

User Dashboard

<table width=100%>
    <tr valign=top>
        <td>
            <table width=500>
                <tr>
                    <td>
                        
                        <telerik:RadListView ID="RadListView1" runat="server" Width=100% ItemPlaceholderID="ListViewContainer">                                
                          <LayoutTemplate>                            
                                <table id="products" width=100% style="border:1px solid black;">
                                        <tr style="background-color:#DDDDDD;">
                                            <td style="width:40%">
                                                Currency
                                            </td>
                                            <td style="float:right;">
                                                Balance
                                            </td>                                            
                                        </tr>
                                    <tr id="ListViewContainer" runat="server">
                                    </tr>
                                </table>                            
                        </LayoutTemplate>
                            <ItemTemplate>
                                    <tr style="border-bottom:1px solid black;">
                                        <td >
                                                <%# Eval("info_currency_description") %>                                                
                                        </td>
                                        <td style="float:right;">
                                            <%# Eval("user_balance")%>
                                        </td>                                        
                                    </tr>                        
                            </ItemTemplate>
                        </telerik:RadListView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadListView ID="RadListView2" runat="server" Width=100% ItemPlaceholderID="ListViewContainer">                                
                          <LayoutTemplate>                                                            
                                <table id="products" width=100% style="border:1px solid black;">
                                    <tr>
                                        <td colspan=3>
                                            Payments Ordered
                                        </td>
                                    </tr>
                                        <tr style="background-color:#DDDDDD;">
                                            <td >
                                                Payment id
                                            </td>
                                            <td>
                                                Description
                                            </td>
                                            <td style="float:right;">
                                                Status
                                            </td>                                            
                                        </tr>
                                    <tr id="ListViewContainer" runat="server">
                                    </tr>
                                </table>                            
                        </LayoutTemplate>
                            <ItemTemplate>
                                    <tr style="border-bottom:1px solid black;">
                                        <td >
                                            <%# Eval("payments_key") %>                                                
                                        </td>
                                        <td>
                                        <a href="Payment.aspx?paymentkey=<%# Eval("payments_key") %>">
                                            <%# Eval("payment_description") %>
                                            </a>
                                        </td>
                                        <td style="float:right;">
                                            <%# Eval("payment_status_info")%>
                                        </td>                                        
                                    </tr>                        
                            </ItemTemplate>
                        </telerik:RadListView>
                    </td>
                </tr>
            </table>
        </td>
        <td style="float:right;">
            <uc1:ExchangeCurrency ID="ucExchangeCurrency" runat=server />
        </td>
    </tr>
</table>


</asp:Content>