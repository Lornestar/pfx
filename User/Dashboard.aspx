<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Peerfx.User.Dashboard" MasterPageFile="~/User/User.Master" %>
<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

User Dashboard

<br />

<uc1:ExchangeCurrency ID="ucExchangeCurrency" runat=server />

</asp:Content>