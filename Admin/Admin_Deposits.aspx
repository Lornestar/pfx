﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Deposits.aspx.cs" Inherits="Peerfx.Admin.Admin_Deposits" MasterPageFile="~/Admin/Admin.Master"%>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" OnTabClick="RadTabStrip1_TabClick">
                    <Tabs>
                        <telerik:RadTab Text="Pending Deposits">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Processed Deposits">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Duplicate Deposits" >
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <!--*******************PENDING DEPOSITS************************-->
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="Admin_Tabs">
                        
                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" OnNeedDataSource="RadGrid1_NeedDataSource" OnInsertCommand="RadGrid1_InsertCommand" OnItemDataBound="RadGrid1_ItemDataBound" OnItemCommand="RadGrid1_ItemCommand" AllowSorting="true"
                         OnDetailTableDataBind="RadGrid1_DetailTableDataBind" OnItemUpdated="RadGrid1_ItemUpdated"  AllowMultiRowEdit="True"
                         AllowAutomaticDeletes="True">
                             <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="tx_external_key" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnCurrentPage" Name="Deposits" >
                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="tx_fees_key" Name="Fees" Width="100%" CommandItemDisplay="Top" AllowAutomaticInserts="False" AutoGenerateColumns="False" AllowAutomaticUpdates="False">
                                        <Columns>       
                                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridEditCommandColumn>                                                           
                                            <telerik:GridTemplateColumn DataField="tx_fees_key" HeaderText="Key" UniqueName="tx_fees_key" SortExpression="tx_fees_key">
                                                <InsertItemTemplate>                                            
                                                </InsertItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID=lbltxfeeskey runat=server Visible=false></asp:Label>
                                                </EditItemTemplate>
                                             </telerik:GridTemplateColumn>
                                             <telerik:GridTemplateColumn DataField="amount" HeaderText="Amount" UniqueName="amount" >
                                                <InsertItemTemplate>
                                                    <telerik:radnumerictextbox ID=txtamount runat=server Type=Currency >
                                                    </telerik:radnumerictextbox>
                                                </InsertItemTemplate>                                                                                        
                                                <EditItemTemplate>
                                                    <telerik:radnumerictextbox ID=txtamount runat=server Type=Currency >
                                                    </telerik:radnumerictextbox>
                                                </EditItemTemplate>
                                             </telerik:GridTemplateColumn>                                         
                                         <telerik:GridTemplateColumn DataField="info_currency_code" HeaderText="Currency" UniqueName="info_currency_code" >
                                            <InsertItemTemplate>
                                                <telerik:RadComboBox ID="ddlcurrency" runat="server" Width="150px">
                                                </telerik:RadComboBox>
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                                <telerik:RadComboBox ID="ddlcurrency" runat="server" Width="150px">
                                                </telerik:RadComboBox>
                                            </EditItemTemplate>
                                         </telerik:GridTemplateColumn>
                                         <telerik:GridBoundColumn DataField="description" HeaderText="Description" SortExpression="description"
                                            UniqueName="description" >                                        
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="date_created" HeaderText="Date" UniqueName="date_created">
                                            <InsertItemTemplate>                                            
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                         </telerik:GridTemplateColumn>
                                        </Columns>
                                        <AlternatingItemStyle BackColor="#EEEEEE" />                                                                                
                                        <CommandItemSettings ShowAddNewRecordButton="true" AddNewRecordText="Add New Fee" />                                        
                                        <EditFormSettings ColumnNumber="2" CaptionDataField="tx_fees_key" InsertCaption="New Fee">
                                            <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                            <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                            <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3"
                                                Width="100%"></FormMainTableStyle>
                                            <FormTableStyle CellSpacing="0" CellPadding="2" Height="110px">
                                            </FormTableStyle>
                                            <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                            <EditColumn ButtonType=PushButton InsertText="Insert Deposit" UniqueName="EditCommandColumn1" CancelText="Cancel">                                                                                  </EditColumn>
                                            <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>                                    
                                        </EditFormSettings>
                                        
                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>                                         
                                    <telerik:GridTemplateColumn DataField="tx_external_key" HeaderText="Key" UniqueName="tx_external_key" SortExpression="tx_external_key">
                                        <InsertItemTemplate>                                            
                                        </InsertItemTemplate>
                                     </telerik:GridTemplateColumn>
                                     <telerik:GridDropDownColumn DataField="sender_bank_name1" HeaderText="User Bank" DropDownControlType=RadComboBox 
                                        UniqueName="sender_bank_name">
                                    </telerik:GridDropDownColumn>
                                    <telerik:GridBoundColumn DataField="sender_bank_account1" HeaderText="User Bank Account" 
                                        UniqueName="sender_bank_account">                                        
                                    </telerik:GridBoundColumn>
                                    <telerik:GridDropDownColumn DataField="receiver_bank_name1" HeaderText="System Bank Account" SortExpression="bank_name" DropDownControlType=RadComboBox 
                                        UniqueName="receiver_bank_name">
                                    </telerik:GridDropDownColumn>                                    
                                    <telerik:GridTemplateColumn DataField="info_currency_code" HeaderText="Currency" UniqueName="info_currency_code" >
                                        <InsertItemTemplate>
                                            <telerik:RadComboBox ID="ddlcurrency" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </InsertItemTemplate>
                                     </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="tx_external_description" HeaderText="Description" SortExpression="tx_external_description"
                                        UniqueName="tx_external_description" >                                        
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="bank_reference" HeaderText="Bank Reference" SortExpression="bank_reference"
                                        UniqueName="bank_reference">
                                    </telerik:GridBoundColumn>                                     
                                     <telerik:GridTemplateColumn DataField="amount" HeaderText="Amount" UniqueName="amount" >
                                        <InsertItemTemplate>
                                            <telerik:radnumerictextbox ID=txtamount runat=server Type=Currency >
                                            </telerik:radnumerictextbox>
                                        </InsertItemTemplate>
                                     </telerik:GridTemplateColumn>                                     
                                     <telerik:GridTemplateColumn DataField="proceeds" HeaderText="Proceeds" UniqueName="proceeds" SortExpression="proceeds">
                                                <InsertItemTemplate>                                            
                                                </InsertItemTemplate>
                                             </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="last_changed" HeaderText="Date" UniqueName="last_changed">
                                        <InsertItemTemplate>                                            
                                        </InsertItemTemplate>
                                     </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn HeaderText="Actions">
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadButton ID=btnconnectuser runat=server Text="Connect" CommandName="btnconnectuser"></telerik:RadButton>
                                                    </td>
                                                    <td>
                                                        <telerik:RadButton ID=btnremovedeposit runat=server Text="Remove" CommandName="btnremovedeposit"></telerik:RadButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan=2>
                                                        <telerik:RadComboBox ID=ddlconnectuser runat=server EmptyMessage="Choose User" >
                                                        </telerik:RadComboBox>
                                                    </td>                                                    
                                                </tr>
                                            </table>                                                                                        
                                        </ItemTemplate>
                                     </telerik:GridTemplateColumn>                                     
                                </Columns>
                                <CommandItemSettings ShowAddNewRecordButton="true" AddNewRecordText="Add New Deposit"/>
                                <AlternatingItemStyle BackColor="#EEEEEE" />
                                 <EditFormSettings ColumnNumber="2" CaptionDataField="tx_external_key" InsertCaption="New Deposit">
                                    <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                    <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                    <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3"
                                        Width="100%"></FormMainTableStyle>
                                    <FormTableStyle CellSpacing="0" CellPadding="2" Height="110px">
                                    </FormTableStyle>
                                    <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                    <EditColumn ButtonType=PushButton InsertText="Insert Deposit" UniqueName="EditCommandColumn1" CancelText="Cancel">                                        
                                    </EditColumn>
                                    <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>                                    
                                </EditFormSettings>
                            </MasterTableView>                                                        
                        </telerik:RadGrid>
                        

                    </telerik:RadPageView>                
                <!--*******************PENDING DEPOSITS************************-->
                <!--*******************PROCESSED DEPOSITS************************-->
                    <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="Admin_Tabs">


                    <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" AllowAutomaticInserts="False"  OnNeedDataSource="RadGrid2_NeedDataSource"
                         OnItemDataBound="RadGrid2_ItemDataBound" OnItemCommand="RadGrid2_ItemCommand" AllowSorting="true">
                             <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="tx_external_key" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnCurrentPage" >
                                <Columns>                                                                        
                                    <telerik:GridBoundColumn DataField="tx_external_key" HeaderText="Key" UniqueName="tx_external_key" SortExpression="tx_external_key">
                                     </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="sender_bank_name1" HeaderText="User Bank" UniqueName="sender_bank_name">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="sender_bank_account1" HeaderText="User Bank Account" 
                                        UniqueName="sender_bank_account">                                        
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="receiver_bank_name1" HeaderText="System Bank Account" SortExpression="bank_name" UniqueName="receiver_bank_name">
                                    </telerik:GridBoundColumn>                                    
                                    <telerik:GridBoundColumn DataField="info_currency_code" HeaderText="Currency" UniqueName="info_currency_code" >                                        
                                     </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="tx_external_description" HeaderText="Description" SortExpression="tx_external_description"
                                        UniqueName="tx_external_description" >                                        
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="bank_reference" HeaderText="Bank Reference" SortExpression="bank_reference"
                                        UniqueName="bank_reference">
                                    </telerik:GridBoundColumn>                                     
                                     <telerik:GridBoundColumn DataField="amount" HeaderText="Amount" UniqueName="amount" SortExpression="amount">
                                     </telerik:GridBoundColumn>                                     
                                    <telerik:GridBoundColumn DataField="date_processed" HeaderText="Date Processed" UniqueName="date_processed" SortExpression="date_processed">            
                                     </telerik:GridBoundColumn>                                     
                                     <telerik:GridBoundColumn DataField="user_account_number" HeaderText="User Account Number" SortExpression="user_account_number"
                                        UniqueName="user_account_number">
                                    </telerik:GridBoundColumn>    
                                </Columns>
                                <CommandItemSettings ShowAddNewRecordButton=false />
                                <AlternatingItemStyle BackColor="#EEEEEE" />
                                 <EditFormSettings ColumnNumber="2" CaptionDataField="tx_external_key" InsertCaption="New Deposit">
                                    <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                    <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                    <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3"
                                        Width="100%"></FormMainTableStyle>
                                    <FormTableStyle CellSpacing="0" CellPadding="2" Height="110px">
                                    </FormTableStyle>
                                    <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                    <EditColumn ButtonType=PushButton InsertText="Insert Deposit" UniqueName="EditCommandColumn1" CancelText="Cancel">                                        
                                    </EditColumn>
                                    <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>                                    
                                </EditFormSettings>
                            </MasterTableView>                                                        
                        </telerik:RadGrid>

                    </telerik:RadPageView>
                <!--*******************PROCESSED DEPOSITS************************-->
                <!--*******************DUPLICATE DEPOSITS************************-->
                    <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="Admin_Tabs">
                    </telerik:RadPageView>
                <!--*******************DUPLICATE DEPOSITS************************-->
                </telerik:RadMultiPage>
        </telerik:RadAjaxPanel>
</asp:Content>