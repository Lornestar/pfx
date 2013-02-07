<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Payment.aspx.cs" Inherits="Peerfx.Admin.Admin_Payment" MasterPageFile="~/Admin/Admin.Master" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>


<telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound" OnItemCommand="RadGrid1_ItemCommand" AllowSorting="true"
OnDetailTableDataBind="RadGrid1_DetailTableDataBind">
                             <MasterTableView Width="100%" DataKeyNames="payments_key" AutoGenerateColumns="False" Name="Payments" >                                                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="tx_key" Name="Transactions" Width="100%"  AutoGenerateColumns="False">
                                        <Columns>       
                                            <telerik:GridBoundColumn DataField="tx_key" HeaderText="Key" UniqueName="tx_key" >
                                            </telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="tx_status_text" HeaderText="Status" UniqueName="tx_status_text" >
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="amount" HeaderText="Amount" UniqueName="amount" >
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="currency_text" HeaderText="Currency" UniqueName="currency_text" >
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="payment_object_sender" HeaderText="From" UniqueName="payment_object_sender" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="payment_object_receiver" HeaderText="To" UniqueName="payment_object_receiver" Visible=false>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="" HeaderText="From" UniqueName="">
                                                <ItemTemplate>
                                                    <asp:Label ID=lblfrom runat=server></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="" HeaderText="To" UniqueName="">
                                                <ItemTemplate>
                                                    <asp:Label ID=lblto runat=server></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="date_processed" HeaderText="Date Processed" UniqueName="date_processed" >
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>                                         
                                    <telerik:GridBoundColumn DataField="payments_key" HeaderText="Key" UniqueName="payments_key" >
                                     </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="sell_currency_text" HeaderText="Sell Currency" UniqueName="sell_currency_text">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="sell_amount" HeaderText="Sell Amount" UniqueName="sell_amount">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="buy_currency_text" HeaderText="Buy Currency" UniqueName="buy_currency_text">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="buy_amount" HeaderText="Buy Amount" UniqueName="buy_amount">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="payment_status_text" HeaderText="Status" UniqueName="payment_status_text">
                                    </telerik:GridBoundColumn>        
                                    <telerik:GridBoundColumn DataField="payment_object_receiver" HeaderText="Receiver payment object key" UniqueName="payment_object_receiver" Visible=false>
                                    </telerik:GridBoundColumn>        
                                                                

                                     <telerik:GridTemplateColumn HeaderText="Actions">
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td >
                                                        <telerik:RadComboBox ID=ddlupdatestatus runat=server EmptyMessage="Update Status" >
                                                        </telerik:RadComboBox>
                                                        <telerik:RadButton ID=btnupdatestatus runat=server Text="Change Status" CommandName="btnupdatestatus"></telerik:RadButton>
                                                    </td>                                                    
                                                </tr>                                                
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID=pnlmoneysent runat=server Visible=false>
                                                        Is this the bank account the money was sent to?
                                                        <br />
                                                        <asp:Label ID=lblbankaccountsent runat=server ></asp:Label>
                                                        <br />
                                                        <telerik:RadNumericTextBox ID=txtamount Value="0" EmptyMessage="Amount Transferred" runat=server></telerik:RadNumericTextBox>
                                                        <br />
                                                        <telerik:RadButton ID=btnconfirmmoneysent runat=server Text="Confirm" CommandName="btnconfirmmoneysent">
                                                        </telerik:RadButton>
                                                        <telerik:RadButton ID=btncancelmoneysent runat=server Text="No" CommandName="btncancelmoneysent">
                                                        </telerik:RadButton>
                                                        </asp:Panel>
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


</asp:Content>