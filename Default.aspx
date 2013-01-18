<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Peerfx._Default" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

Home page

<br />

<uc1:ExchangeCurrency ID="ucExchangeCurrency" runat=server />

        
</asp:Content>