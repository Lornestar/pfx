<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="Peerfx.User.Verification" MasterPageFile="~/Site.Master"%>

<%@ Register Src="~/User_Controls/Verification.ascx" tagname="Verification" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>


<uc1:Verification ID="ucVerification" runat=server />

</asp:Content>