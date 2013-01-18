﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExchangeCurrency.ascx.cs" Inherits="Peerfx.User_Controls.ExchangeCurrency" %>

<asp:HiddenField ID="hdbuyrate" runat=server value="0"/>
<asp:HiddenField ID="hdsellcurrencysymbol" runat=server Value="$" />
<asp:HiddenField ID="hdbuycurrencysymbol" runat=server Value="$" />
<asp:HiddenField ID="hdservicefee" runat=server Value="0" />
<asp:HiddenField ID="hdbuyamount" runat=server Value="0" />

<script language=javascript>

function updatetable() {
    var sellrate = document.getElementById('ctl00_Main_ucExchangeCurrency_hdsellrate');
    var buyrate = document.getElementById('ctl00_Main_ucExchangeCurrency_hdbuyrate');
    var currencysymbol = document.getElementById('ctl00_Main_ucExchangeCurrency_hdcurrencysymbol');
    var lblservicefee = document.getElementById('ctl00_Main_ucExchangeCurrency_lblservicefee');
    var lblrate = document.getElementById('ctl00_Main_ucExchangeCurrency_lblrate');
    alert(lblservicefee);

    lblrate.innerHTML = sellrate;
    lblservicefee.innerHTML = currencysymbol + '5';
}

</script>
<telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanelExchangeCurrency">
        </telerik:RadAjaxLoadingPanel>
<telerik:RadAjaxPanel runat="server" ID="RadAjaxPanelExchangeCurrency" LoadingPanelID="LoadingPanelExchangeCurrency"
            Height="100%">
<table style="border:1px solid black;">
    <tr>
        <td>
            Exchange Currency
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td>
                        You Pay
                        <br />
                        <telerik:RadNumericTextBox ID=txtsell runat=server Value="300.00" OnTextChanged="txtsell_TextChanged" AutoPostBack=true>
                        </telerik:RadNumericTextBox>
                        <telerik:RadComboBox ID=ddlsellcurrency runat=server OnSelectedIndexChanged="ddlsellcurrency_changed" AutoPostBack=true></telerik:RadComboBox>
                    </td>
                    <td>
                    ->
                    </td>
                    <td>
                        You Get
                        <br />
                        <telerik:RadNumericTextBox ID=txtbuy runat=server Enabled=false></telerik:RadNumericTextBox>
                        <telerik:RadComboBox ID=ddlbuycurrency runat=server OnSelectedIndexChanged="ddlbuycurrency_changed" AutoPostBack=true></telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>    
    <tr>
        <td>
            <table>
                <tr>
                    <td>Service Fee</td>
                    <td><asp:Label ID=lblservicefee runat=server>0.00</asp:Label> </td>
                </tr>
                <tr>
                    <td>You Get</td>
                    <td><asp:Label ID="lblyouget" runat=server>0.00</asp:Label></td>
                </tr>
                <tr>
                    <td>Exchange Rate</td>
                    <td><asp:Label ID="lblrate" runat=server>0.00</asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>    
    <tr>
        <td style="text-align:right;">        
            <telerik:RadButton ID=btnExchange runat=server Text="Exchange Currency" 
                onclick="btnExchange_Click"></telerik:RadButton>
        </td>
    </tr>
</table>
</telerik:RadAjaxPanel>