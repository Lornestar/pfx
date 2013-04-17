<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Scheduled_Tasks.aspx.cs" Inherits="Peerfx.Admin.Admin_Scheduled_Tasks" MasterPageFile="~/Admin/Admin.Master"%>

<%@ Register Src="~/User_Controls/Admin_ScheduledTask_Embee.ascx" tagname="Embee" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/Admin_ScheduledTask_CurrencyCloud.ascx" tagname="CurrencyCloud" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">


<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" OnTabClick="RadTabStrip1_TabClick">
                    <Tabs>
                        <telerik:RadTab Text="Currency Cloud">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Embee Catalog Updates">
                        </telerik:RadTab>                        
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="Admin_Tabs">
                        <uc1:CurrencyCloud id="ucCurrencyCloud1" runat=server></uc1:CurrencyCloud>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat=server ID=RadPageView2 CssClass="Admin_Tabs">
                        <uc1:Embee runat=server id=ucEmbee1 ></uc1:Embee>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                
                
</telerik:RadAjaxPanel>


</asp:Content>