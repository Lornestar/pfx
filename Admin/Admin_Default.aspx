<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Default.aspx.cs" Inherits="Peerfx.Admin.Admin_Default" MasterPageFile="~/Admin/Admin.Master" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>


<table>
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
                                                Treasury Balance
                                            </td>        
                                            <td>
                                                Overall Balance
                                            </td>                               
                                            <td>
                                                In Bank Account Balance
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
                                        <td>
                                            <%# Eval("overall_balance")%>
                                        </td>          
                                        <td>
                                            <%# Eval("system_account_info_text") %>
                                        </td>            
                                    </tr>                        
                            </ItemTemplate>
                        </telerik:RadListView>


        </td>
    </tr>
</table>

</asp:Content>