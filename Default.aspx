<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Peerfx._Default" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>



<table style="width:99%; margin-top:-30px;">
    <tr>
        <td style="height:40px;">&nbsp;</td>
    </tr>
    <tr valign=top>
        <td width=60% class="Default_Page">
            Send Money abroad           
            without the pain
        </td>
        <td style="float:right;">
            <uc1:ExchangeCurrency ID="ucExchangeCurrency" runat=server />
        </td>
    </tr>
</table>

        
</asp:Content>