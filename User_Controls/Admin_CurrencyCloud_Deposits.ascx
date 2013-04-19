<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Admin_CurrencyCloud_Deposits.ascx.cs" Inherits="Peerfx.User_Controls.Admin_CurrencyCloud_Deposits" %>

<%@ Register Src="~/User_Controls/Payment_Details.ascx" tagname="PaymentDetails" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/CurrencyCloud_TradeDetails.ascx" tagname="CCTradeDetails" tagprefix="uc1" %>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

<div class="Page_Header">CurrencyCloud Withdrawls/Deposits</div>

<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" OnTabClick="RadTabStrip1_TabClick">
                    <Tabs>
                        <telerik:RadTab Text="Withdrawls">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Deposits">
                        </telerik:RadTab>                        
                        <telerik:RadTab Text="Completed Settlements" >
                        </telerik:RadTab>                        
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="Admin_Tabs">
                    <div class="Exchange_Header">Settlements</div>
                        

                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" OnNeedDataSource="RadGrid1_NeedDataSource"                                 OnItemDataBound="RadGrid1_ItemDataBound" OnItemCommand="RadGrid1_ItemCommand" AllowSorting="true" OnDetailTableDataBind="RadGrid1_DetailTableDataBind" ShowFooter=false>
                            <MasterTableView Width="100%" DataKeyNames="currencycloud_settlement_key" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnCurrentPage" Name="CurrencyCloud" >
                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="currencycloud_trade_key" Name="Trades" Width="100%" AutoGenerateColumns="False" ShowGroupFooter=true>
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
                                            <telerik:GridBoundColumn DataField="txt_Buy_full" HeaderText="Buying" SortExpression="txt_Buy_full">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="initiated_date" HeaderText="Initiated Date" SortExpression="initiated_date">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Actions">
                                                        <ItemTemplate>
                                                            <telerik:RadButton ID=btnDetails runat=server Text="View Payment Details" CommandName="btntradedetails" ButtonType=LinkButton BorderStyle=None></telerik:RadButton>
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
                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="currencycloud_settlement_key" HeaderText="Key" SortExpression="currencycloud_settlement_key">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_settlementid" HeaderText="CC SettlementID" SortExpression="cc_settlementid">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="releasedate" HeaderText="Release Date" SortExpression="releasedate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="number_of_trades" HeaderText="# of Trades" SortExpression="number_of_trades">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="status" HeaderText="Status" SortExpression="status" Visible=false>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Actions">
                                                <ItemTemplate>
                                                    <telerik:RadButton ID=btnProcessSettlement runat=server Text="Process Settlement" CommandName="btnProcessSettlement"></telerik:RadButton>
                                                </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                         </telerik:RadGrid>


                    </telerik:RadPageView>                    
                    </telerik:RadMultiPage>
                    <asp:panel ID=pnlpaymentdetails runat=server Visible=false>
                    <div class="Exchange_Header">Payment Details</div>
                    <uc1:PaymentDetails id="Paymentdetails1" runat="server"></uc1:PaymentDetails>
                    <hr />
                    <div class="Exchange_Header">CC Trade details (from CC)</div>
                    <uc1:CCTradeDetails id="CCTradeDetails1" runat="server"></uc1:CCTradeDetails>                    
                    </div>
                    </asp:panel>
                

</telerik:RadAjaxPanel>
