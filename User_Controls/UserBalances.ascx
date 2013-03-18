<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserBalances.ascx.cs" Inherits="Peerfx.User_Controls.UserBalances" %>


                        <telerik:RadListView ID="RadListView1" runat="server" Width=100% ItemPlaceholderID="ListViewContainer" >                                
                          <LayoutTemplate>                            
                                <table id="products" width=100%  class="RadListview_Table">
                                        <tr class="RadListview_Header">
                                            <td style="width:40%">
                                                Currency
                                            </td>
                                            <td style="text-align:right;">
                                                Balance
                                            </td>                                            
                                        </tr>
                                    <tr id="ListViewContainer" runat="server" >
                                    </tr>
                                </table>                            
                        </LayoutTemplate>                            
                            <ItemTemplate>                            
                                    <tr>
                                        <td >
                                                <%# Eval("info_currency_description") %>                                                
                                        </td>
                                        <td style="float:right; text-align:right;">
                                            <%# Eval("user_balance")%>
                                        </td>                                        
                                    </tr>                        
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class=RadListview_Alternating>
                                        <td >
                                                <%# Eval("info_currency_description") %>                                                
                                        </td>
                                        <td style="float:right; text-align:right;">
                                            <%# Eval("user_balance")%>
                                        </td>                                        
                                    </tr>
                            </AlternatingItemTemplate>
                        </telerik:RadListView>
