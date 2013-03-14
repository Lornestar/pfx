<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Peerfx.User.Payment" MasterPageFile="~/Site.Master"%>
<%@ Register Src="~/User_Controls/Payment_Details.ascx" tagname="PaymentDetails" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<div class="Page_Header">
Payment Details
</div>

<uc1:PaymentDetails id="Paymentdetails" runat="server"></uc1:PaymentDetails>

</asp:Content>