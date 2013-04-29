<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Withdrawl.aspx.cs" Inherits="Peerfx.Admin.Admin_Withdrawl" MasterPageFile="~/Admin/Admin.Master"%>

<%@ Register Src="~/User_Controls/Payment_Details.ascx" tagname="PaymentDetails" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/CurrencyCloud_TradeDetails.ascx" tagname="CCTradeDetails" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/CurrencyCloud_PaymentDetails.ascx" tagname="CCPaymentDetails" tagprefix="uc1" %>


<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" OnTabClick="RadTabStrip1_TabClick">
                    <Tabs>
                        <telerik:RadTab Text="Pending Withdrawls">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Processed Withdrawls">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <!--*******************PENDING DEPOSITS************************-->
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="Admin_Tabs">

                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False"  OnNeedDataSource="RadGrid1_NeedDataSource" AllowSorting="true"
                    OnItemCommand="RadGrid1_ItemCommand" PageSize=50 OnItemDataBound=RadGrid1_ItemDataBound >
                         <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="payments_key" AutoGenerateColumns="False">
                            <Columns>
                                <telerik:GridBoundColumn DataField="payments_key" HeaderText="Key" UniqueName="payments_key" SortExpression="payments_key">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="txt_Sell_full" HeaderText="Sell" UniqueName="txt_Sell_full" SortExpression="txt_Sell_full">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="txt_Buy_full" HeaderText="Buy" UniqueName="txt_Buy_full" SortExpression="txt_Buy_full">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sender_name" HeaderText="Sender" UniqueName="sender_name" SortExpression="sender_name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="receiver_name" HeaderText="Receiver" UniqueName="receiver_name" SortExpression="receiver_name">
                                </telerik:GridBoundColumn>                                                
                                <telerik:GridBoundColumn HeaderText="Bank Account" UniqueName="bank_account_description" SortExpression="bank_account_description">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="date_created" HeaderText="Date Requested" SortExpression="date_created">
                                </telerik:GridBoundColumn>  
                                <telerik:GridTemplateColumn HeaderText="Actions">
                                    <ItemTemplate>
                                        <telerik:RadButton ID=btnDetails runat=server Text="View Details" CommandName="btntradedetails" ButtonType=LinkButton BorderStyle=None></telerik:RadButton>
                                        <telerik:RadButton ID=btnWithdraw runat=server Text="Process Withdrawl" CommandName="btnWithdraw"></telerik:RadButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <CommandItemSettings ShowAddNewRecordButton=false />
                        </MasterTableView>
                    </telerik:RadGrid>

                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="Admin_Tabs">
                    </telerik:RadPageView>
                </telerik:RadMultiPage>

                <asp:Panel ID=pnltradedetails runat=server Visible=false>
            <div class="Exchange_Header">Payment Details</div>            
                    <uc1:PaymentDetails id="Paymentdetails1" runat="server"></uc1:PaymentDetails>
                    <hr />
                    <table width=100%>
                        <tr valign=top>
                            <td>
                                <div class="Exchange_Header">Trade details (from CC)</div>
                                <uc1:CCTradeDetails id="CCTradeDetails1" runat="server"></uc1:CCTradeDetails>
                            </td>
                            <td>
                                <div class="Exchange_Header">CC Payment details (from CC)</div>                                
                                <uc1:CCPaymentDetails ID="CCPaymentDetails1" runat=server ></uc1:CCPaymentDetails>
                            </td>
                        </tr>
                    </table>                    
                </asp:Panel>

</telerik:RadAjaxPanel>
</asp:Content>