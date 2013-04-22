<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrencyCloud_PaymentDetails.ascx.cs" Inherits="Peerfx.User_Controls.CurrencyCloud_PaymentDetails" %>

<table>
    <tr>
        <td>CCPaymentID</td>
        <td><asp:Label ID=lblpaymentid runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td>Currency</td>
        <td><asp:Label ID="lblcurrency" runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Client cost</td>
        <td><asp:Label ID="lblclientcost" runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Payment Reference</td>
        <td><asp:Label ID="lblpaymentreference" runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Reason</td>
        <td><asp:Label ID="lblreason" runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Status</td>
        <td><asp:Label ID="lblstatus" runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Transfered Date</td>
        <td><asp:Label ID="lbltransfereddate" runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Deal Reference</td>
        <td><asp:Label ID="lbldealref" runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Payment Type</td>
        <td><asp:Label ID="lblpaymenttype" runat=server></asp:Label></td>
    </tr>    
</table>

