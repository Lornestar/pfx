<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="Peerfx.User.Withdraw" MasterPageFile="~/Site.Master" %>
<%@ Register Src="~/User_Controls/BankAccountEntry.ascx" tagname="BankAccountEntry" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<div class="Page_Header">
Withdraw Funds
</div>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
<asp:Panel ID=pnlhavebalance runat=server Visible=false>

<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" Width=100%>
                    <Tabs>
                        <telerik:RadTab Text="Order Withdrawl">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Confirm Withdrawl" Enabled=false>
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" BorderWidth=1>                
                <!--*************Tab1************-->
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="corporatePageView">
<table>
    <tr>
        <td>From this balance</td>
        <td> <telerik:RadComboBox ID=ddlcurrency runat=server 
                onselectedindexchanged="ddlcurrency_SelectedIndexChanged" AutoPostBack=true></telerik:RadComboBox> </td>
    </tr>
    <tr>
        <td>Amount</td>
        <td> 
            <telerik:RadNumericTextBox ID=txtamount runat=server Value="0.00" ></telerik:RadNumericTextBox>
        </td>
    </tr>
    <tr>
        <td>To</td>
        <td> <telerik:RadListBox ID=ddlReceivers runat=server 
                onselectedindexchanged="ddlReceivers_SelectedIndexChanged" AutoPostBack=true></telerik:RadListBox> </td>
    </tr>
    <tr>
        <td colspan=2>
            <uc1:BankAccountEntry id=BankAccountEntry1 runat=server Visible=false></uc1:BankAccountEntry>
        </td>
    </tr>
    <tr>
        <td colspan=2>
            <telerik:RadButton ID=btncontinue1 runat=server Text="Continue" 
                onclick="btncontinue1_Click"></telerik:RadButton>
                <asp:Label ID=lblerror runat=server ForeColor=Red Visible=false>Please enter an amount</asp:Label>
        </td>
    </tr>
</table>
</telerik:RadPageView>
<telerik:RadPageView runat="server" ID="RadPageView2" CssClass="corporatePageView">

<table>
    <tr>
        <td>
            From this balance
        </td>
        <td><asp:Label ID=lblcurrency runat=server></asp:Label></td>
    </tr>
    <tr>
        <td>Amount</td>
        <td><asp:Label ID=lblamount runat=server></asp:Label> </td>
    </tr>
    <tr>
        <td colspan=2>To:</td>
    </tr>
    <tr>
        <td colspan=2>
            <uc1:BankAccountEntry ID=BankAccountEntry2 runat=server />
        </td>
    </tr>
    <tr>
        <td colspan=2>
            <telerik:RadButton ID=btnback runat=server Text="Back" onclick="btnback_Click"></telerik:RadButton>
            &nbsp;&nbsp;&nbsp;
            <telerik:RadButton ID=btncontinue2 runat=server Text="Confirm" 
                onclick="btncontinue2_Click"></telerik:RadButton>
        </td>
    </tr>
</table>

</telerik:RadPageView>

</telerik:RadMultiPage>

</asp:Panel>

<asp:Panel ID=pnldonthavebalance runat=server>
You currently have no balance to withdraw from
</asp:Panel>

</telerik:RadAjaxPanel>
</asp:Content>