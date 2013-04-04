<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExchangeCurrency.ascx.cs" Inherits="Peerfx.User_Controls.ExchangeCurrency" %>

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
<div class="SendPayment_Box_Header">
 <span style="position:relative;top:4px; left:10px;"> Send Payment</span>
</div>
<div class="SendPayment_Box">
<div class="SendPayment_Box_Main">
    <center>
<table cellpadding=5>
    <tr>
        <td>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="width:80px;">
                                    You Pay
                                </td>
                                <td style="width:105px;">
                                    <telerik:RadNumericTextBox ID=txtsell runat=server Value="300.00" OnTextChanged="txtsell_TextChanged" MinValue="0.01" AutoPostBack=true Width=100   CssClass="SendPayment_Box_Inputs">                 
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>                    
                                    <telerik:RadComboBox ID=ddlsellcurrency runat=server OnSelectedIndexChanged="ddlsellcurrency_changed" AutoPostBack=true Width=60 Font-Bold=true Font-Size=Medium ></telerik:RadComboBox>                                </td>                    
                            </tr>
                            <tr>
                                <td>
                                    You Get
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID=txtbuy runat=server Enabled=false Width=100 CssClass="SendPayment_Box_Inputs"></telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID=ddlbuycurrency runat=server OnSelectedIndexChanged="ddlbuycurrency_changed" AutoPostBack=true Width=60 Font-Bold=true Font-Size=Medium></telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>                    
                    </td>                                       
                </tr>
            </table>
        </td>
    </tr>    
    <tr>
        <td style="text-align:right;">
            <asp:Panel ID=pnlworking runat=server>
            <table width=100%>
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
            </asp:Panel>
            <span style="text-align:center;">
            <asp:Label ID=lblerror runat=server Visible=false>Payment Request Service currency unavailable</asp:Label>
            </span>
        </td>
    </tr>    
    <tr>
        <td style="text-align:right;">                
            <telerik:RadButton ID=btnExchange runat=server Text="Send Payment" cssclass="SendPayment_Box_Button" onclick="btnExchange_Click">                 
            <Image EnableImageButton=true />
                </telerik:RadButton>                
            <telerik:RadButton ID=btnNotLoggedIn runat=server Text="Send Payment" cssclass="SendPayment_Box_Button" OnClientClicked="opensign" Visible=false AutoPostBack=false>                           <Image EnableImageButton=true />
            </telerik:RadButton>
        </td>
    </tr>
</table>
</center>
</div>
</div>
<div class=SendPayment_Footer>
&nbsp;
</div>
<script language=javascript>
    function opensign() {
        openSignup('1');
    }
</script>
</telerik:RadAjaxPanel>