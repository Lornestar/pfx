<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRadgrid.aspx.cs" Inherits="Peerfx.TestRadgrid" MasterPageFile="~/Site.Master" %>

<asp:Content runat=server ContentPlaceHolderID=Main>

<telerik:RadGrid ID=RadGrid1 runat=server AllowAutomaticDeletes=true AllowAutomaticInserts=true AllowAutomaticUpdates=true OnNeedDataSource="RadGrid1_NeedDataSource">
<MasterTableView Width="100%" CommandItemDisplay="Top" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnCurrentPage" Name="Deposits" >
<Columns>
<telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridEditCommandColumn>

                                        <telerik:GridBoundColumn DataField="bank_reference" HeaderText="Bank Reference" SortExpression="bank_reference"
                                        UniqueName="bank_reference">
                                    </telerik:GridBoundColumn>                                     
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
                                        </Columns>
                                        </MasterTableView>
</telerik:RadGrid>


</asp:Content>