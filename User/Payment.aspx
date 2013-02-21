<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Peerfx.User.Payment" MasterPageFile="~/Site.Master"%>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<center>
<table>
    <tr valign=top>
        <td style="width:290px;">
            <table>
                                    <tr>
                                        <td colspan=2 class="Exchange_Header">Payment #<asp:Label ID=lblpaymentnum runat=server></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan=2>                                            
                                            <asp:Label ID="lblsenderamount" runat=server>sellamount</asp:Label> -> <asp:Label ID=lblreceiveramount runat=server>buyamount</asp:Label>
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td>
                                        From:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblfrom" runat=server>from</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            To:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblto" runat=server>to</asp:Label>
                                        </td>
                                    </tr>                                    
                                    <tr valign=top>
                                        <td>
                                            Receiver Bank Account
                                        </td>
                                        <td>
                                            <asp:Label ID=lblreceiveraccount runat=server></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Description:
                                        </td>
                                        <td>
                                            <asp:Label ID=lblalreadyconfirmeddescription runat=server></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Status:
                                        </td>
                                        <td>
                                            <asp:Label ID=lblstatus runat=server></asp:Label>
                                        </td>
                                    </tr>
                                </table>  

        </td>
        <td>
            <asp:Panel ID=pnlinstructions runat=server Visible=false>
                <table width=100%>
                                    <tr valign=top>
                                        <td>
                                            <b>NEXT STEPS:</b>
                                            <ol>
                                                <li>
                                                    Activate your payment by transferring the required deposit to the Peerfx deposit account.
                                                </li>
                                                <li>
                                                    We will confirm the receipt of your deposit within 4 working hours after it reaches our bank account.
                                                </li>
                                            </ol>
                                            <div class="FinePrint">
                                                Note that the deposit payment will have to originate from a bank account in the name of "<asp:Label ID="lblalreadyconfirmedfrom2" runat=server></asp:Label>", otherwise the payment will not be activated.
                                            </div>
                                        </td>
                                        <td style="border:1px solid black; width:50%">
                                            <table>
                                                <tr>
                                                    <td><b>Peerfx Deposit Account</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    Amount:
                                                    <br />
                                                    <asp:Label ID=lblalreadyconfirmedquotesenderamount2 runat=server>amount</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        To:
                                                        <br />
                                                        <asp:Label ID=lblalreadyconfirmedpeerfxname runat=server>Peerfx</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Bank Account:
                                                        <br />
                                                        <asp:Label ID=lblalreadyconfirmedpeerfxbankaccount runat=server></asp:Label>
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
                                  
                                                       
              </center>              

</asp:Content>