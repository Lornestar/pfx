<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Peerfx._Default" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

Home page

<br />

<telerik:RadButton ID=btnsignup runat=server Text="Sign Up" 
        onclick="btnsignup_Click"></telerik:RadButton>

</asp:Content>