<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipients.aspx.cs" Inherits="Peerfx.User.Recipients" MasterPageFile="~/Site.Master"%>

<%@ Register Src="~/User_Controls/BankAccountEntry.ascx" tagname="BankAccountEntry" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>


<telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanelExchangeCurrency">
        </telerik:RadAjaxLoadingPanel>

         <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

         <asp:HiddenField ID=hdcurrentbankaccountkey runat=server value=0/>
<center>
<table width=400px>
    <tr>
        <td>
            <table width=100%>
                <tr>
                    <td style="float:left;"> 
                    <div class="Page_Header">Recipients</div>
                    </td>
                    <td style="float:right;">

                    <telerik:RadButton ID=btnaddrecipient runat=server Text="Add Recipient" 
                            onclick="btnaddrecipient_Click"></telerik:RadButton>

                    </td>
                </tr>
            </table>        
        </td>
    </tr>
    <tr>
        <td>
        <telerik:RadListView ID="RadListView1" runat="server" Width=100% 
                ItemPlaceholderID="ListViewContainer"  EnableEmbeddedSkins=true
                OnSelectedIndexChanged="RadListView1_SelectedIndexChanged" >
                          <LayoutTemplate>                            
                                <table id="products" width=100% style="border:1px solid black;">
                                        <tr class="RadListview_Header">
                                            <td style="width:40%">
                                                Name
                                            </td>                                            
                                            <td style=" text-align:right;">
                                                Currency
                                            </td>                                            
                                            <td>
                                            &nbsp;
                                            </td>
                                        </tr>
                                    <tr id="ListViewContainer" runat="server" class="rlvI">
                                    </tr>
                                </table>                            
                        </LayoutTemplate>
                            <ItemTemplate>
                                    <tr style="border-bottom:1px solid black;">
                                        <td >
                                            <span style="display:none;"></span>
                                            <%# Eval("first_name")%> <%# Eval("last_name")%>
                                        </td>                                        
                                        <td style="text-align:right;">
                                                <%# Eval("currency_text")%>
                                        </td>   
                                        <td style=" text-align:right;">
                                        <asp:LinkButton ID="LinkButton1" Text="Edit" runat="server" CommandName="Select" >
                                            <asp:Label ID=lblcurrency runat=server Text='<%# Bind("bank_account_key")%>' Visible=false></asp:Label>
                                        </asp:LinkButton>
                                        </td>                                     
                                    </tr>                        
                            </ItemTemplate>                      
                            <AlternatingItemTemplate>
                                <tr class="RadListview_Alternating">
                                        <td >
                                            <span style="display:none;"></span>
                                            <%# Eval("first_name")%> <%# Eval("last_name")%>
                                        </td>                                        
                                        <td style="text-align:right;">
                                                <%# Eval("currency_text")%>
                                        </td>   
                                        <td style=" text-align:right;">
                                        <asp:LinkButton ID="LinkButton1" Text="Edit" runat="server" CommandName="Select" >
                                            <asp:Label ID=lblcurrency runat=server Text='<%# Bind("bank_account_key")%>' Visible=false></asp:Label>
                                        </asp:LinkButton>
                                        </td>                                     
                                    </tr>                        
                            </AlternatingItemTemplate>      
                        </telerik:RadListView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID=pnladdnew runat=server Visible=false>
                <table>
                    <tr>
                        <td class="Exchange_Header">
                            Recipient's Bank Account Details
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:BankAccountEntry id=BankAccountEntry1 runat=server></uc1:BankAccountEntry>
                        </td>
                    </tr>
                    <tr>
                                    <td>
                                        <telerik:RadButton ID=btnsavechange runat=server Text="Save Changes" 
                                            onclick="btnsavechange_Click"></telerik:RadButton>
                                            
                                    </td>
                                </tr>     
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
</center>

</telerik:RadAjaxPanel>
</asp:Content>