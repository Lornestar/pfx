<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExchangeCurrency.aspx.cs" Inherits="Peerfx.ExchangeCurrency" MasterPageFile="~/Site.Master"%>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<asp:HiddenField ID="hdbuyrate" runat=server value="0"/>
<asp:HiddenField ID="hdsellcurrencysymbol" runat=server Value="$" />
<asp:HiddenField ID="hdbuycurrencysymbol" runat=server Value="$" />
<asp:HiddenField ID="hdservicefee" runat=server Value="0" />
<asp:HiddenField ID="hdbuyamount" runat=server Value="0" />

<telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanelExchangeCurrency">
        </telerik:RadAjaxLoadingPanel>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">        
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtsell">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlQuote" LoadingPanelID="LoadingPanelExchangeCurrency"></telerik:AjaxUpdatedControl>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlsellcurrency">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlQuote" LoadingPanelID="LoadingPanelExchangeCurrency"></telerik:AjaxUpdatedControl>                                        
                </UpdatedControls>
            </telerik:AjaxSetting>            
            <telerik:AjaxSetting AjaxControlID="ddlbuycurrency">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlQuote" LoadingPanelID="LoadingPanelExchangeCurrency"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="pnlIBAN"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="pnlBankCode"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="pnlABArouting"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="pnlAccountNumber"></telerik:AjaxUpdatedControl>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnContinue1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlCreatePayment" LoadingPanelID="LoadingPanelExchangeCurrency"></telerik:AjaxUpdatedControl>                                        
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnContinue2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlConfirmPayment" LoadingPanelID="LoadingPanelExchangeCurrency"></telerik:AjaxUpdatedControl>                                        
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnBack2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlConfirmPayment" LoadingPanelID="LoadingPanelExchangeCurrency"></telerik:AjaxUpdatedControl>                                        
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" Width=100%>
                    <Tabs>
                        <telerik:RadTab Text="Create Payment">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Confirm Payment" Enabled=false>
                        </telerik:RadTab>
                        <telerik:RadTab Text="Make Bank Transfer" Enabled=false>
                        </telerik:RadTab>
                        <telerik:RadTab Text="Payment Delivered" Enabled=false>
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" BorderWidth=1>                
                <!--*************Tab1************-->
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="corporatePageView">

                    <table>
                        <tr valign=top>
                            <td>
                                <asp:Panel ID=pnlQuote runat=server>
                                <table>
                                    <tr>
                                        <td colspan=2 class="Exchange_Header">Quote</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>You Pay</td>
                                                    <td><telerik:RadNumericTextBox ID=txtsell runat=server Value="300.00" OnTextChanged="txtsell_TextChanged" AutoPostBack=true Width=100></telerik:RadNumericTextBox>
                                                        <telerik:RadComboBox ID=ddlsellcurrency runat=server OnSelectedIndexChanged="ddlsellcurrency_changed" AutoPostBack=true Width=50></telerik:RadComboBox></td>
                                                </tr>
                                                <tr>
                                                    <td>You Get</td>
                                                    <td><telerik:RadNumericTextBox ID=txtbuy runat=server Enabled=false Width=100></telerik:RadNumericTextBox>
                                                        <telerik:RadComboBox ID=ddlbuycurrency runat=server OnSelectedIndexChanged="ddlbuycurrency_changed" AutoPostBack=true Width=50></telerik:RadComboBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:100px;"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                        Payment received no later than:
                                        <br />
                                        <asp:Label ID=lbldelivery runat=server></asp:Label>
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
                                </table>    
                                </asp:Panel>                       
                            </td>
                            <td style="width:60%;">
                                <asp:Panel ID="pnlCreatePayment" runat=server>
                                <table width=100%>
                                    <tr>
                                        <td class="Exchange_Header">Sender</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID=pnlloggedinsender runat=server Visible=false></asp:Panel>
                                            <asp:Panel ID=pnlnewsender runat=server>
                                                <table>
                                                    <tr>                                                        
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadTextBox ID=txtfirstnamesender runat=server EmptyMessage="First Name" Width=200></telerik:RadTextBox>
                                                                    </td>                                            
                                                                    <td>
                                                                        <telerik:RadTextBox ID=txtlastnamesender runat=server EmptyMessage="Last Name" Width=200></telerik:RadTextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>                                                                                                                
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td colspan=3>Date of Birth</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <telerik:RadNumericTextBox ID="txtbirthday" runat=server EmptyMessage="DD" Width=50 MaxValue="31" MinValue="1">
                                                                                        <NumberFormat AllowRounding="False" DecimalDigits="0"/>
                                                                                    </telerik:RadNumericTextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <telerik:RadNumericTextBox ID="txtbirthmonth" runat=server EmptyMessage="MM" Width=50 MaxValue="12" MinValue="1">
                                                                                        <NumberFormat AllowRounding="False" DecimalDigits="0"/>
                                                                                    </telerik:RadNumericTextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <telerik:RadNumericTextBox ID="txtbirthyear" runat=server EmptyMessage="YYYY" Width=50 MinValue="1912" MaxValue="1994">
                                                                                        <NumberFormat AllowRounding="False" DecimalDigits="0" GroupSeparator=""/>
                                                                                    </telerik:RadNumericTextBox>
                                                                                </td>
                                                                            </tr>                                        
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        Country<br />
                                                                        <telerik:RadComboBox ID=ddlcountryresidence runat=server >
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>                                                                    
                                                                    <td>Address<br /><telerik:RadTextBox ID=txtAddress1 runat=server ></telerik:RadTextBox></td>
                                                                    <td>City<br /><telerik:RadTextBox ID=txtCity runat=server></telerik:RadTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>State<br /><telerik:RadTextBox ID=txtState runat=server></telerik:RadTextBox></td>
                                                                    <td>Postal/Zip Code<br /><telerik:RadTextBox ID=txtpostalzipcode runat=server></telerik:RadTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Phone
                                                                        <br />
                                                                        <telerik:RadMaskedTextBox ID="txtphone" runat="server"
                                                                            Width="150px"                                                      
                                                                            Mask="(###) ###-####"  
                                                                            DisplayMask="(###) ###-####"  
                                                                            NumericRangeAlign="Left"> 
                                                                        </telerik:RadMaskedTextBox> 
                                                                    </td>                     
                                                                    <td>
                                                                        Email<br />
                                                                        <telerik:RadTextBox ID="txtemailsender" runat="server" EmptyMessage="Email"></telerik:RadTextBox>                                                               
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>                                                                                                                
                                                </table>                                                
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Exchange_Header">Receiver</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID=pnlexistingreceiver runat=server Visible=false>
                                                <telerik:RadComboBox ID=ddlReceivers runat=server></telerik:RadComboBox>
                                            </asp:Panel>
                                            <asp:Panel ID=pnlnewreceiver runat=server>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadTextBox ID=txtfirstnamereceiver runat=server EmptyMessage="First Name" Width=200></telerik:RadTextBox>
                                                                    </td>                                            
                                                                    <td>
                                                                        <telerik:RadTextBox ID=txtlastnamereceiver runat=server EmptyMessage="Last Name" Width=200></telerik:RadTextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr valign=top>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td><asp:Panel runat=server ID="pnlIBAN">
                                                                                    IBAN account number
                                                                                    <br />
                                                                                    <telerik:RadTextBox ID="txtIbanAccount" runat=server></telerik:RadTextBox>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td><asp:Panel ID=pnlBankCode runat=server>
                                                                                    Bank Code (BIC)
                                                                                    <br />
                                                                                    <telerik:RadTextBox ID="txtBankCode" runat=server></telerik:RadTextBox>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td><asp:Panel ID="pnlABArouting" runat=server Visible=false>
                                                                                    ABA routing transit number
                                                                                    <br />
                                                                                    <telerik:RadTextBox ID="txtABArouting" runat=server EmptyMessage="123456789"></telerik:RadTextBox>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="pnlAccountNumber" runat=server Visible=false>
                                                                                    Account Number
                                                                                    <br />
                                                                                    <telerik:RadTextBox ID="txtaccountnumber" runat=server EmptyMessage="12345678"></telerik:RadTextBox>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    Exchange Description
                                                                                    <br />
                                                                                    <telerik:RadTextBox ID="txtdescription" runat=server EmptyMessage="eg. payroll"></telerik:RadTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Email
                                                                                    <br />
                                                                                    <telerik:RadTextBox ID="txtemailreceiver" runat=server></telerik:RadTextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td style="text-align:right;">
                                            <telerik:RadButton ID="btnContinue1" runat="server" Text="Exchange Currency" 
                                                onclick="btnContinue1_Click"></telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>

                    </telerik:RadPageView>
                    <!--**********************Tab1*****************************************************-->
                    <!--**********************Tab2*****************************************************-->
                    <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="corporatePageView">
                    <asp:Panel ID="pnlConfirmPayment" runat=server>
                    <table>
                        <tr valign=top>
                            <td>                                
                                <table>
                                    <tr>
                                        <td colspan=2 class="Exchange_Header">Quote</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>You Pay</td>
                                                    <td><asp:Label ID="lblconfirmquotesendamount" runat=server>Send Amount</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>You Get</td>
                                                    <td><asp:Label ID="lblconfirmquotereceiveamount" runat=server>Get Amount</asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:100px;"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                        Payment received no later than:
                                        <br />
                                        <asp:Label ID=lblconfirmquotearrivaldate runat=server></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>Service Fee</td>
                                                    <td><asp:Label ID=lblconfirmquoteservicefee runat=server>0.00</asp:Label> </td>
                                                </tr>
                                                <tr>
                                                    <td>You Get</td>
                                                    <td><asp:Label ID="lblconfirmquoteyouget" runat=server>0.00</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>Exchange Rate</td>
                                                    <td><asp:Label ID="lblconfirmquoteexchangerate" runat=server>0.00</asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>    
                                                       
                            </td>
                            <td style="width:60%;">
                                <table width=100%>
                                    <tr>
                                        <td class="Exchange_Header">Sender</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID=Panel2 runat=server Visible=false></asp:Panel>
                                            <asp:Panel ID=Panel3 runat=server>
                                                <table>
                                                    <tr>                                                        
                                                        <td>
                                                            <asp:Label ID=lblconfirmsenderfullname runat=server>Full Name</asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Date of Birth<br />
                                                            <asp:Label ID="lblconfirmsenderdob" runat=server>dob</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Address<br />
                                                            <asp:Label ID="lblconfirmsenderaddress" runat=server>address</asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblconfirmsendercity" runat=server>City</asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblconfirmsenderstate" runat=server>State</asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblconfirmsenderpostalcode" runat=server>Postal Code</asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblconfirmsendercountry" runat=server>Country</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Phone<br />
                                                            <asp:Label ID="lblconfirmsenderphone" runat=server>phone</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Email<br />
                                                            <asp:Label ID="lblconfirmsenderemail" runat=server>email</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>                                                
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Exchange_Header">Receiver</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID=Panel4 runat=server Visible=false>
                                                <telerik:RadComboBox ID=RadComboBox4 runat=server></telerik:RadComboBox>
                                            </asp:Panel>
                                            <asp:Panel ID=Panel5 runat=server>
                                                <table>
                                                    <tr>                                                        
                                                        <td>
                                                            <asp:Label ID=lblconfirmreceiverfullname runat=server>Full Name</asp:Label>
                                                        </td>                                                        
                                                    </tr>                                                    
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td><asp:Panel runat=server ID="pnlconfirmreceiverIBAN">
                                                                        IBAN account number
                                                                        <br />
                                                                        <asp:Label ID="lblconfirmreceiverIBAN" runat=server></asp:Label>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Panel ID=pnlconfirmreceiverBankCode runat=server>
                                                                        Bank Code (BIC)
                                                                        <br />
                                                                        <asp:Label ID=lblconfirmreceiverBankCode runat=server></asp:Label>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Panel ID="pnlconfirmreceiverABArouting" runat=server Visible=false>
                                                                        ABA routing transit number
                                                                        <br />
                                                                        <asp:Label ID="lblconfirmreceiverABArouting" runat=server></asp:Label>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Panel ID="pnlconfirmreceiverAccount" runat=server Visible=false>
                                                                        Account Number
                                                                        <br />
                                                                        <asp:Label ID=lblconfirmreceiverAccount runat=server></asp:Label>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Description<br />
                                                            <asp:Label ID="lblconfirmreceiverdescription" runat=server>phone</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Email<br />
                                                            <asp:Label ID="lblconfirmreceiveremail" runat=server>email</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table> 
                                            </asp:Panel>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width=100%>
                                                <tr>
                                                    <td>
                                                        <telerik:RadButton ID=btnBack2 runat="server" Text="Back" 
                                                            onclick="btnBack2_Click"></telerik:RadButton>
                                                     </td>
                                                    <td style="text-align:right;">
                                                        <telerik:RadButton ID=btnContinue2 runat="server" Text="Confirm Currency Exchange" 
                                                            onclick="btnContinue2_Click"></telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                    </telerik:RadPageView>
                    <!--**********************Tab2*****************************************************-->
                    <!--**********************Tab3*****************************************************-->
                    <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="corporatePageView">
                        <asp:Panel ID="Panel1" runat=server>
                    <table>
                        <tr valign=top>
                            <td>                                
                                <table>
                                    <tr>
                                        <td colspan=2 class="Exchange_Header">Transaction #<asp:Label ID=lbltxnum runat=server></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Amount:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblalreadyconfirmedamount" runat=server>amount</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        From:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblalreadyconfirmedfrom" runat=server>from</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            To:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblalreadyconfirmedto" runat=server>to</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel runat=server ID="pnlalreadyconfirmedIBAN">
                                            IBAN account number
                                            </asp:Panel>
                                            <asp:Panel runat=server ID="pnlalreadyconfirmedABArouting">
                                            ABA routing transit number
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <asp:Panel ID="pnlalreadyconfirmedIBAN2" runat=server>
                                                <asp:Label ID="lblalreadyconfirmedIBAN2" runat=server></asp:Label>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlalreadyconfirmedABArouting2" runat=server>
                                                <asp:Label ID="lblalreadyconfirmedABArouting2" runat=server></asp:Label>
                                            </asp:Panel>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlalreadyconfirmedBankCode" runat=server>
                                            Bank Code (BIC)
                                            </asp:Panel>
                                            <asp:Panel ID="pnlalreadyconfirmedAccountNumber" runat=server>
                                            Account Number
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <asp:Panel ID="pnlalreadyconfirmedBankCode2" runat=server>
                                                <asp:Label ID="lblalreadyconfirmedBankCode2" runat=server></asp:Label>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlalreadyconfirmedAccountNumber2" runat=server>
                                                <asp:Label ID="lblalreadyconfirmedAccountNumber2" runat=server></asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>    
                                                       
                            </td>
                            <td style="width:60%;">
                                <table width=100%>
                                    <tr>
                                        <td>
                                            INSTRUCTIONS
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>                                
                    </telerik:RadPageView>
                    <!--**********************Tab3*****************************************************-->
                    <!--**********************Tab4*****************************************************-->
                    <telerik:RadPageView runat="server" ID="RadPageView4" CssClass="corporatePageView">
                        Payment delivered
                    </telerik:RadPageView>
                    <!--**********************Tab4*****************************************************-->
                </telerik:RadMultiPage>
                                


</asp:Content>