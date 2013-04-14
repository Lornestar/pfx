<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankAccountEntry.ascx.cs" Inherits="Peerfx.User_Controls.BankAccountEntry" %>

<table>
    <tr>
                        <td>
                            Name:<br />                        
                            <telerik:RadTextBox ID=txtfirstname EmptyMessage="First Name" runat=server></telerik:RadTextBox>
                            <telerik:RadTextBox ID=txtlastname EmptyMessage="Last Name" runat=server></telerik:RadTextBox>
                            <asp:Label ID=lblfullname runat=server Visible=false></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID=lblcurrency runat=server>Currency:<br /></asp:Label>
                            <asp:Label ID=lblcurrencylabels runat=server Visible=false>Currency: </asp:Label>
                            <telerik:RadComboBox ID=ddlcurrency runat=server OnSelectedIndexChanged="ddlcurrency_changed" AutoPostBack=true></telerik:RadComboBox>
                        </td>
                    </tr>                    
                                <tr>
                                    <td><asp:Panel runat=server ID="pnlIBAN">
                                        IBAN account number
                                        <br />
                                        <telerik:RadTextBox ID="txtIbanAccount" runat=server></telerik:RadTextBox>
                                        <asp:Label ID=lblIbanAccount runat=server Visible=false></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Panel ID=pnlBankCode runat=server>
                                        Bank Code / Swift Code (BIC)
                                        <br />
                                        <telerik:RadTextBox ID="txtBankCode" runat=server></telerik:RadTextBox>
                                        <asp:Label ID=lblBankCode runat=server Visible=false></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Panel ID="pnlABArouting" runat=server Visible=false>
                                        ABA routing transit number
                                        <br />
                                        <telerik:RadMaskedTextBox ID="txtABArouting" runat=server EmptyMessage="123456789" HideOnBlur=true Mask="#########"></telerik:RadMaskedTextBox>
                                        <asp:Label ID=lblABArouting runat=server Visible=false></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID=pnlbsb runat=server Visible=false>
                                            BSB
                                            <br />
                                            <telerik:RadMaskedTextBox ID=txtbsb runat=server Mask="###-###" EmptyMessage="123-456" HideOnBlur=true></telerik:RadMaskedTextBox>
                                            <asp:Label ID=lblbsb runat=server Visible=false></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlAccountNumber" runat=server Visible=false>
                                        Account Number
                                        <br />
                                        <telerik:RadTextBox ID="txtaccountnumber" runat=server EmptyMessage="12345678"></telerik:RadTextBox>
                                        <asp:Label ID=lblaccountnumber runat=server Visible=false></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlSortCode" runat=server Visible=false>
                                        Sort Code
                                        <br />
                                        <table>
                                            <tr>
                                                <td>
                                                <telerik:RadMaskedTextBox ID=txtsortcode1 runat=server Mask="##" Width="30" HideOnBlur=true EmptyMessage="12"></telerik:RadMaskedTextBox>
                                                </td>
                                                <td>
                                                <telerik:RadMaskedTextBox ID=txtsortcode2 runat=server Mask="##" Width="30" HideOnBlur=true EmptyMessage="34"></telerik:RadMaskedTextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadMaskedTextBox ID=txtsortcode3 runat=server Mask="##" Width="30" HideOnBlur=true EmptyMessage="56"></telerik:RadMaskedTextBox>
                                                </td>
                                            </tr>                                            
                                        </table>
                                        <asp:Label ID=lblsortcode runat=server Visible=false></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID=pnlnzdaccount runat=server Visible=false>
                                        Account Number
                                        <br />
                                        <telerik:RadMaskedTextBox ID=txtnzdaccount1 runat=server Mask=## HideOnBlur=true EmptyMessage="12" Width="30"></telerik:RadMaskedTextBox>
                                        <telerik:RadMaskedTextBox ID=txtnzdaccount2 runat=server Mask="####" HideOnBlur=true EmptyMessage="1234" Width="60"></telerik:RadMaskedTextBox>
                                        <telerik:RadMaskedTextBox ID=txtnzdaccount3 runat=server Mask="0######" HideOnBlur=true EmptyMessage="0123456" Width="80"></telerik:RadMaskedTextBox>
                                        <telerik:RadMaskedTextBox ID=txtnzdaccount4 runat=server Mask="0##" HideOnBlur=true EmptyMessage="012" Width="45"></telerik:RadMaskedTextBox>
                                        </asp:Panel>
                                        <asp:Label ID=lblnzdaccount runat=server Visible=false></asp:Label>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>
                                        Email
                                                                                    <br />
                                                                                    <telerik:RadTextBox ID="txtemailreceiver" runat=server></telerik:RadTextBox>
                                                                                    <asp:Label ID=lblemailreceiver runat=server Visible=false></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID=lblerror runat=server ForeColor=Blue Visible=false></asp:Label>
                                    </td>
                                </tr>
</table>
