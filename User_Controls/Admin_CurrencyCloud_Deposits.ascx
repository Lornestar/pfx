<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Admin_CurrencyCloud_Deposits.ascx.cs" Inherits="Peerfx.User_Controls.Admin_CurrencyCloud_Deposits" %>

<%@ Register Src="~/User_Controls/Payment_Details.ascx" tagname="PaymentDetails" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/CurrencyCloud_TradeDetails.ascx" tagname="CCTradeDetails" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/CurrencyCloud_PaymentDetails.ascx" tagname="CCPaymentDetails" tagprefix="uc1" %>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

<div class="Page_Header">CurrencyCloud Withdrawls/Deposits</div>

<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" OnTabClick="RadTabStrip1_TabClick">
                    <Tabs>
                        <telerik:RadTab Text="Withdrawls">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Deposits">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Direct from CC">
                        </telerik:RadTab>                        
                        <telerik:RadTab Text="Completed Trades" >
                        </telerik:RadTab>                        
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="Admin_Tabs">
                    <div class="Exchange_Header">Trades</div>
                     <asp:Panel ID=pnlcheckdirectpayment runat=server Visible=false>
                        Last Check: <asp:Label ID=lbldirectpayment runat=server></asp:Label>
                        <br />
                        <telerik:RadButton ID=btndirectpayment runat=server Text="Run Check Trades Direct Payment"
                            onclick="btndirectpayment_Click"></telerik:RadButton>
                     </asp:Panel>   

                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" OnNeedDataSource="RadGrid1_NeedDataSource"                                 OnItemDataBound="RadGrid1_ItemDataBound" OnItemCommand="RadGrid1_ItemCommand" AllowSorting="true" OnDetailTableDataBind="RadGrid1_DetailTableDataBind" PageSize=100>
                            <MasterTableView Width="100%" DataKeyNames="currencycloud_trade_key" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnCurrentPage" Name="CurrencyCloud"  ShowGroupFooter=true>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="cc_tradeid" HeaderText="CurrencyCloud Trade ID" SortExpression="cc_tradeid" Aggregate=Count FooterText="Total Trades: ">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="currencycloud_trade_key" HeaderText="Key" SortExpression="currencycloud_trade_key" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="payments_key" HeaderText="paymentskey" SortExpression="payments_key" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="sell_currency" HeaderText="Sell Currency" SortExpression="sell_currency" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="buy_currency" HeaderText="Buy Currency" SortExpression="buy_currency" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="sell_amount" HeaderText="Sell Amount" SortExpression="sell_amount" Aggregate=Sum FooterText="Currency Total: ">
                                            </telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="txt_Sell_full" HeaderText="Selling" SortExpression="txt_Sell_full" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="buy_amount" HeaderText="Buy Amount" SortExpression="buy_amount" Aggregate=Sum FooterText="Currency Total: ">
                                            </telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="txt_Buy_full" HeaderText="Buying" SortExpression="txt_Buy_full">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="initiated_date" HeaderText="Initiated Date" SortExpression="initiated_date">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="directlyfromcurrencycloud" HeaderText="CC sends directly to bankaccount (1=YES)" SortExpression="directlyfromcurrencycloud">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="cctrade_status" HeaderText="Status" SortExpression="cctrade_status" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="cc_settlementid" HeaderText="Settlementid" SortExpression="cc_settlementid">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Actions" UniqueName="Actions">
                                                        <ItemTemplate>
                                                            <telerik:RadButton ID=btnDetails runat=server Text="View Payment Details" CommandName="btntradedetails" ButtonType=LinkButton BorderStyle=None></telerik:RadButton>
                                                            <telerik:RadButton ID=btnProcessTrade runat=server Text="Process Trade" CommandName="btnProcessTrade"></telerik:RadButton>
                                                        </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <GroupByExpressions>
                                            <telerik:GridGroupByExpression>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="sell_currency_text"></telerik:GridGroupByField>
                                                </GroupByFields>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldName="sell_currency_text" HeaderText="Sell Currency"></telerik:GridGroupByField>
                                                </SelectFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>                                
                            </MasterTableView>
                         </telerik:RadGrid>


                    </telerik:RadPageView>                    
                    </telerik:RadMultiPage>
                    <asp:panel ID=pnlpaymentdetails runat=server Visible=false>
                    <div class="Exchange_Header">Payment Details</div>
                    <uc1:PaymentDetails id="Paymentdetails1" runat="server"></uc1:PaymentDetails>
                    <hr />
                    <table width=100%>
                        <tr valign=top>
                            <td>
                                <div class="Exchange_Header">CC Trade details (from CC)</div>
                                <uc1:CCTradeDetails id="CCTradeDetails1" runat="server"></uc1:CCTradeDetails>                    
                            </td>
                            <td>
                                <div class="Exchange_Header">CC Payment details (from CC)</div>
                                <uc1:CCPaymentDetails ID="CCPaymentDetails1" runat=server />
                            </td>
                        </tr>
                    </table>                    
                    
                    </asp:panel>
                

</telerik:RadAjaxPanel>
