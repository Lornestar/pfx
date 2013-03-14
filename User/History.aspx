<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Peerfx.User.History" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<div class="Page_Header">
Payments History
</div>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False"  OnNeedDataSource="RadGrid1_NeedDataSource" AllowSorting="true" PageSize=20
                 OnItemDataBound="RadGrid1_ItemDataBound">
                     <MasterTableView Width="100%" DataKeyNames="date_created" AutoGenerateColumns="False">
                        <Columns>
                            <telerik:GridBoundColumn DataField="payments_key" HeaderText="Payments Key" UniqueName="payments_key" Visible=false>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="date_created" HeaderText="Date" UniqueName="date_created">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="payment_type" HeaderText="Type" UniqueName="payment_type">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="name" HeaderText="Name" UniqueName="name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="payment_status_text" HeaderText="Payment Status" UniqueName="payment_status_text">
                            </telerik:GridBoundColumn>                
                            <telerik:GridBoundColumn DataField="txt_Sell_full" HeaderText="Amount Sent" UniqueName="txt_Sell_full">
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn DataField="rate" HeaderText="Quoted Rate" UniqueName="rate">
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn DataField="service_fee" HeaderText="Fee" UniqueName="service_fee">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="txt_Buy_full" HeaderText="Amount Received" UniqueName="txt_Buy_full">
                            </telerik:GridBoundColumn>                                                                                    
                            <telerik:GridTemplateColumn HeaderText="Actions">
                                        <ItemTemplate>
                                            <asp:HyperLink ID=hyppayment runat=server Text="Details"></asp:HyperLink>
                                        </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <AlternatingItemStyle CssClass="RadListview_Alternating"/>
                        <HeaderStyle CssClass="RadListview_Header" />                        
                        <CommandItemSettings ShowAddNewRecordButton=false />
                    </MasterTableView>
                </telerik:RadGrid>

</telerik:RadAjaxPanel>


</asp:Content>