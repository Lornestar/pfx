<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipients.aspx.cs" Inherits="Peerfx.User.Recipients" MasterPageFile="~/Site.Master"%>

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
                        <td>
                            Recipient Name:<br />                        
                            <telerik:RadTextBox ID=txtfirstname EmptyMessage="First Name" runat=server></telerik:RadTextBox>
                            <telerik:RadTextBox ID=txtlastname EmptyMessage="Last Name" runat=server></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Currency:<br />
                            <telerik:RadComboBox ID=ddlcurrency runat=server OnSelectedIndexChanged="ddlcurrency_changed" AutoPostBack=true></telerik:RadComboBox>
                        </td>
                    </tr>
                                <tr>
                                    <td><asp:Panel runat=server ID="pnlIBAN">
                                        IBAN account number
                                        <br />
                                        <telerik:RadTextBox ID="txtIbanAccount" runat=server></telerik:RadTextBox>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Panel ID=pnlBankCode runat=server>
                                        Bank Code (BIC)
                                        <br />
                                        <telerik:RadTextBox ID="txtBankCode" runat=server></telerik:RadTextBox>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Panel ID="pnlABArouting" runat=server Visible=false>
                                        ABA routing transit number
                                        <br />
                                        <telerik:RadMaskedTextBox ID="txtABArouting" runat=server EmptyMessage="123456789" HideOnBlur=true Mask="#########"></telerik:RadMaskedTextBox>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlAccountNumber" runat=server Visible=false>
                                        Account Number
                                        <br />
                                        <telerik:RadTextBox ID="txtaccountnumber" runat=server EmptyMessage="12345678"></telerik:RadTextBox>
                                        </asp:Panel>
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