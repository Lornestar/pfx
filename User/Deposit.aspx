<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="Peerfx.User.Deposit" MasterPageFile="~/Site.Master"%>

<%@ Register Src="~/User_Controls/Deposit_Instructions.ascx" tagname="DepositInstructions" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<div class="Page_Header">
            Deposit
        </div>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
<table>
    <tr>        
        <td>
        What currency do you want to make a deposit in?
        <telerik:RadComboBox ID=ddlcurrency runat=server 
                onselectedindexchanged="ddlcurrency_SelectedIndexChanged" AutoPostBack=true EmptyMessage="select currency" ></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID=pnlinstructions runat=server Visible=false>
            <uc1:DepositInstructions id="DepositInstructions1" runat=server></uc1:DepositInstructions>
            </asp:Panel>
        </td>
    </tr>
</table>
</telerik:RadAjaxPanel>


</asp:Content>