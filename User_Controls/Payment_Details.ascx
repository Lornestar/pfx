<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Payment_Details.ascx.cs" Inherits="Peerfx.User_Controls.Payment_Details" %>
<%@ Register Src="~/User_Controls/UserInfo.ascx" tagname="UserInfo" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/ExchangeCurrency_FinePrint.ascx" tagname="ExchangeCurrency_FinePrint" tagprefix="uc1" %>
<table>
<tr>
    <td colspan=2>
        <table>
            <tr>
                <td>Type: <asp:Label ID=lblType runat=server></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Status: <asp:Label ID=lblStatus runat=server></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                    Created Date: <asp:Label ID=lblCreatedDate runat=server></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Description: <asp:Label ID="lblconfirmreceiverdescription" runat=server>description</asp:Label>
                </td>
            </tr>
        </table>
    </td>
</tr>
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
                                                    <td>Sender Pays</td>
                                                    <td><asp:Label ID="lblconfirmquotesendamount" runat=server>Send Amount</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>Receiver Gets</td>
                                                    <td><asp:Label ID="lblconfirmquotereceiveamount" runat=server>Get Amount</asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:100px;"></td>
                                    </tr>
                                    <tr>
                                        <td>
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
                                                    <td>Receiver Gets</td>
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
                                                <asp:Label ID=lblsenderfullname runat=server></asp:Label>
                                                <br />
                                                <br />
                                                Funding Source:<br /> <asp:Label ID=lblFundingSource runat=server></asp:Label>                                            
                                                <asp:Label ID=lblBankDetails runat=server></asp:Label>
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
                                            <asp:Panel ID=pnlreceivinguserbalance runat=server Visible=false>
                                                <asp:Label ID=lblreceivinguserbalance runat=server></asp:Label>
                                            </asp:Panel>
                                            <asp:Panel ID=pnlreceivingbankaccount runat=server>
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
                                                </table> 
                                            </asp:Panel>                                            
                                        </td>                                        
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                    </table>