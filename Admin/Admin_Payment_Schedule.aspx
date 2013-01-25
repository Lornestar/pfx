<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Payment_Schedule.aspx.cs" Inherits="Peerfx.Admin.Admin_Payment_Schedule" MasterPageFile="~/Admin/Admin.Master"%>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

Payment Schedule

<telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" OnNeedDataSource="RadGrid1_NeedDataSource" OnInsertCommand="RadGrid1_InsertCommand" OnItemDataBound="RadGrid1_ItemDataBound" OnItemCommand="RadGrid1_ItemCommand" AllowSorting="true"
                          OnItemUpdated="RadGrid1_ItemUpdated"  AllowMultiRowEdit="True"
                         AllowAutomaticDeletes="True">
                             <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="payment_schedule_key" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnCurrentPage" Name="Schedule" >
                             <Columns>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridEditCommandColumn>                                                           
                                <telerik:GridTemplateColumn DataField="payment_schedule_key" HeaderText="Key" UniqueName="payment_schedule_key" SortExpression="payment_schedule_key">
                                    <InsertItemTemplate>                                            
                                    </InsertItemTemplate>
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="currency_code_sender" HeaderText="Currency1" UniqueName="currency_code_sender" >
                                    <InsertItemTemplate>
                                        <telerik:RadComboBox ID="ddlcurrency1" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </InsertItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadComboBox ID="ddlcurrency1" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="currency_code_receiver" HeaderText="Currency2" UniqueName="currency_code_receiver" >
                                    <InsertItemTemplate>
                                        <telerik:RadComboBox ID="ddlcurrency2" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </InsertItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadComboBox ID="ddlcurrency2" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="currency_sender" HeaderText="currency_sender" UniqueName="currency_sender" SortExpression="currency_sender" Visible=false>
                                     </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="currency_receiver" HeaderText="currency_receiver" UniqueName="currency_receiver" SortExpression="currency_receiver" Visible=false>
                                     </telerik:GridBoundColumn>

                             </Columns>

                             </MasterTableView>
                             </telerik:RadGrid>

</asp:Content>