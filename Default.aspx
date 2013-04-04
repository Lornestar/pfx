<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Peerfx._Default" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<table style="width:99%;">
    <tr>
        <td style="height:100px;">&nbsp;</td>
    </tr>
    <tr valign=top>
        <td style="text-align:center;" width=60%>
            
            
        </td>
        <td style="float:right;">
            <uc1:ExchangeCurrency ID="ucExchangeCurrency" runat=server />
        </td>
    </tr>
</table>

        
</asp:Content>