<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Users.aspx.cs" Inherits="Peerfx.Admin.Admin_Users" MasterPageFile="~/Admin/Admin.Master"%>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False"  OnNeedDataSource="RadGrid1_NeedDataSource" AllowSorting="true">
                     <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="account_number" AutoGenerateColumns="False">
                        <Columns>
                            <telerik:GridBoundColumn DataField="account_number" HeaderText="Account Number" UniqueName="account_number">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="first_name" HeaderText="First Name" UniqueName="first_name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="last_name" HeaderText="Last Name" UniqueName="last_name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="user_balance" HeaderText="Current Balance" UniqueName="user_balance">
                            </telerik:GridBoundColumn>                
                            <telerik:GridBoundColumn DataField="user_status_text" HeaderText="Status" UniqueName="user_status_text">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="last_changed" HeaderText="Last Online" UniqueName="last_changed">
                            </telerik:GridBoundColumn>  
                        </Columns>
                        <CommandItemSettings ShowAddNewRecordButton=false />
                    </MasterTableView>
                </telerik:RadGrid>

</telerik:RadAjaxPanel>

</asp:Content>