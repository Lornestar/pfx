<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Admin_ScheduledTask_CurrencyCloud.ascx.cs" Inherits="Peerfx.User_Controls.Admin_ScheduledTask_CurrencyCloud" %>

<%@ Register Src="~/User_Controls/Payment_Details.ascx" tagname="PaymentDetails" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/CurrencyCloud_TradeDetails.ascx" tagname="CCTradeDetails" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/CurrencyCloud_PaymentDetails.ascx" tagname="CCPaymentDetails" tagprefix="uc1" %>

<center>
<table width=100%>
    <tr>
        <td>
            Daily run 1:
            <br />
            Cutoff time 1:30pm UK time
            <br />
            Currencies (Buying) - EUR, GBP, CAD, AUD, HKD, JPY, NZD, AED, ILS
            <br />
            Last Run <asp:Label ID=lblrun1lasttime runat=server></asp:Label> UK time
            <br />
            # of trades in queue - <asp:Label ID=lblpendingtrades1 runat=server></asp:Label>
            <br />
            <telerik:RadButton ID=btndorun1 runat=server Text="Do Run 1" 
                onclick="btndorun1_Click"></telerik:RadButton>
        </td>
        <td>
            Daily run 2:
            <br />
            Cutoff time 4:30pm UK time
            <br />
            Currencies (Buying) - USD, NOK, DKK, SEK, CHF, CZK, PLN, TRY, ZAR, SGD, THB
            <br />
            Last Run <asp:Label ID=lblrun2lasttime runat=server></asp:Label> UK time
            <br />
            # of trades in queue - <asp:Label ID=lblpendingtrades2 runat=server></asp:Label>
            <br />
            <telerik:RadButton ID=btndorun2 runat=server Text="Do Run 2" 
                onclick="btndorun2_Click"></telerik:RadButton>
        </td>
    </tr>
    <tr>
        <td colspan=2>
            <hr />
        </td>
    </tr>
    <tr>
        <td colspan=2>
            <div class="Exchange_Header">Trades Awaiting Settlement</div>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize=50 AllowAutomaticInserts="False" AllowAutomaticUpdates="False" OnNeedDataSource="RadGrid1_NeedDataSource"                                 OnItemDataBound="RadGrid1_ItemDataBound" OnItemCommand="RadGrid1_ItemCommand" AllowSorting="true" ShowFooter=true>
                            <MasterTableView Width="100%" DataKeyNames="currencycloud_trade_key" AutoGenerateColumns="False" Name="CurrencyCloud" ShowGroupFooter=true>
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
                                            <telerik:GridBoundColumn DataField="txt_Sell_full" HeaderText="Selling" SortExpression="txt_Sell_full" >
                                            </telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="txt_Buy_full" HeaderText="Buying" SortExpression="txt_Buy_full">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="cc_cutoff" HeaderText="Run" SortExpression="cc_cutoff">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="initiated_date" HeaderText="Initiated Date" SortExpression="initiated_date">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Actions">
                                                        <ItemTemplate>
                                                            <telerik:RadButton ID=btnDetails runat=server Text="View Details" CommandName="btntradedetails" ButtonType=LinkButton BorderStyle=None></telerik:RadButton>
                                                        </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                            </MasterTableView>
                            </telerik:RadGrid>
        </td>
    </tr>
    <tr>
        <td colspan=2>
        <div class="Exchange_Header">Trades that didn't initiate due to error</div>
        <telerik:RadButton ID=btnretryTrades runat=server Text="Retry Trades" 
                onclick="btnretryTrades_Click"></telerik:RadButton>
        <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize=50 AllowAutomaticInserts="False" AllowAutomaticUpdates="False" OnNeedDataSource="RadGrid2_NeedDataSource"                                 OnItemDataBound="RadGrid2_ItemDataBound" OnItemCommand="RadGrid1_ItemCommand" AllowSorting="true" >
                            <MasterTableView Width="100%" DataKeyNames="payments_key" AutoGenerateColumns="False" Name="CurrencyCloud" ShowGroupFooter=true>
                                <Columns>
                                            <telerik:GridBoundColumn DataField="payments_key" HeaderText="Payments Key" SortExpression="payments_key" Aggregate=Count FooterText="Total Trades: ">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="request" HeaderText="Request" SortExpression="request" >
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="response" HeaderText="Response" SortExpression="response">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="dateoccured" HeaderText="Date Occured" SortExpression="dateoccured">
                                            </telerik:GridBoundColumn>                                            
                                            <telerik:GridTemplateColumn HeaderText="Actions">
                                                        <ItemTemplate>
                                                            <telerik:RadButton ID=btnDetails runat=server Text="View Details" CommandName="btntradedetails" ButtonType=LinkButton BorderStyle=None Width=70></telerik:RadButton>
                                                        </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                            </MasterTableView>
                            </telerik:RadGrid>

        </td>
    </tr>
    <tr>
        <td>
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
        </td>
    </tr>
</table>
</center>