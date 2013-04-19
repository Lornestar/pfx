<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_CurrencyCloud.aspx.cs" Inherits="Peerfx.Admin.Admin_CurrencyCloud" MasterPageFile="~/Admin/Admin.Master"%>

<%@ Register Src="~/User_Controls/Admin_CurrencyCloud_Deposits.ascx" tagname="CC" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<uc1:CC id="CurrencyCloud1" runat=server></uc1:CC>

</asp:Content>