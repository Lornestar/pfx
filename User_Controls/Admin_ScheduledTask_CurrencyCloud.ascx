<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Admin_ScheduledTask_CurrencyCloud.ascx.cs" Inherits="Peerfx.User_Controls.Admin_ScheduledTask_CurrencyCloud" %>

<center>
<table width=80%>
    <tr>
        <td>
            Daily run 1:
            <br />
            Cutoff time 1:30pm UK time
            <br />
            Currencies - EUR, GBP, CAD, AUD, HKD, JPY, NZD, AED, ILS
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
            Currencies - USD, NOK, DKK, SEK, CHF, CZK, PLN, TRY, ZAR, SGD, THB
            <br />
            Last Run <asp:Label ID=lblrun2lasttime runat=server></asp:Label> UK time
            <br />
            # of trades in queue - <asp:Label ID=lblpendingtrades2 runat=server></asp:Label>
            <br />
            <telerik:RadButton ID=btndorun2 runat=server Text="Do Run 2" 
                onclick="btndorun2_Click"></telerik:RadButton>
        </td>
    </tr>
</table>
</center>