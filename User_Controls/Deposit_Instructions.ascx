<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Deposit_Instructions.ascx.cs" Inherits="Peerfx.User_Controls.Deposit_Instructions" %>

<%@ Register Src="~/User_Controls/ExchangeCurrency_NextSteps.ascx" tagname="ExchangeCurrency_NextSteps" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/BankAccountEntry.ascx" tagname="BankAccountEntry" tagprefix="uc1" %>

<table width=100%>
                                    <tr valign=top>
                                        <td style="border:1px solid black; width:50%">
                                            <table>
                                                <tr>
                                                    <td><b>PassportFX Deposit Account</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Send To:
                                                        <br />                                                        
                                                        <uc1:BankAccountEntry id=BankAccountEntry1 runat=server></uc1:BankAccountEntry>
                                                    </td>
                                                </tr>  
                                                <tr>
                                                    <td style="font-weight:bold;">
                                                        <asp:Panel ID=pnlreference runat=server Visible=false>
                                                        Be sure to add the following reference to your deposit:                                                        
                                                        <asp:Label ID=lblreference runat=server></asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>                                              
                                            </table>
                                            We will notify you when your funds have been deposited
                                        </td>                                        
                                    </tr>
                                </table>
