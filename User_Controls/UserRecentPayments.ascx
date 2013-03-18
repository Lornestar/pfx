<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserRecentPayments.ascx.cs" Inherits="Peerfx.User_Controls.UserRecentPayments" %>


<telerik:RadListView ID="RadListView2" runat="server" Width=100% ItemPlaceholderID="ListViewContainer" AllowPaging=true PageSize=5
                          Skin="Vista">
                          <LayoutTemplate>                                                              
                                <table id="products" width=100% class="RadListview_Table">
                                    </tr>
                                        <tr class="RadListview_Header">
                                            <td >
                                                Date
                                            </td>
                                            <td>
                                                Description
                                            </td>
                                            <td style="text-align:right;">
                                                Status
                                            </td>     
                                            <td>
                                                
                                            </td>                                       
                                        </tr>
                                    <tr id="ListViewContainer" runat="server">
                                    </tr>                                    
                                    <tr>
                                        <td colspan=4 style="text-align:right;">
                                            <a href="History.aspx">See All Payments</a>
                                        </td>
                                    </tr>
                                </table>
                        </LayoutTemplate>
                            <ItemTemplate>
                            
                                    <tr >
                                        <td >
                                        
                                            <%# Eval("date_created") %>                               
                                        
                                        </td>
                                        <td>
                                        
                                            <%# Eval("payment_description") %>
                                            
                                        </td>
                                        <td style="float:right;">
                                        
                                            <%# Eval("payment_status_info")%>
                                        
                                        </td>                                        
                                        <td align=right>
                                            <a href="Payment.aspx?paymentkey=<%# Eval("payments_key") %>">
                                            Details
                                            </a>
                                        </td>
                                    </tr>                        
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class=RadListview_Alternating>
                                        <td >
                                        
                                            <%# Eval("date_created")%>                               
                                        
                                        </td>
                                        <td>
                                        
                                            <%# Eval("payment_description") %>
                                        
                                        </td>
                                        <td style="float:right;">
                                        
                                            <%# Eval("payment_status_info")%>
                                        
                                        </td>                                        
                                        <td align=right>
                                            <a href="Payment.aspx?paymentkey=<%# Eval("payments_key") %>">
                                            Details
                                            </a>
                                        </td>
                                    </tr>
                            </AlternatingItemTemplate>
                        </telerik:RadListView>