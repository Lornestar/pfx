<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrencyCloud_TradeDetails.ascx.cs" Inherits="Peerfx.User_Controls.CurrencyCloud_TradeDetails" %>

<table>
    <tr>
        <td>TradeID</td>
        <td><asp:Label ID=lbltradeid runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td>Selling</td>
        <td><asp:Label ID=lblsellamount runat=server></asp:Label> 
        <asp:Label ID=lblsellcurrency runat=server></asp:Label>
        </td>
    </tr>
    <tr>
        <td>Buying</td>
        <td><asp:Label ID=lblbuyamount runat=server></asp:Label> 
        <asp:Label ID=lblbuycurrency runat=server></asp:Label>
        </td>
    </tr>
    <tr>
        <td>Market Rate</td>
        <td><asp:Label ID=lblmarketrate runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td>Client Rate</td>
        <td><asp:Label ID=lblclientrate runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td>Traded Date</td>
        <td><asp:Label ID=lbltradeddate runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td>Settlement Date</td>
        <td><asp:Label ID=lblsettlementdate runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td>Delivery Date</td>
        <td><asp:Label ID=lbldeliverydate runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td>Status</td>
        <td><asp:Label ID=lblstatus runat=server></asp:Label> </td>
    </tr>    
</table>
