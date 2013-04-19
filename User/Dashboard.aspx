<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Peerfx.User.Dashboard" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/UserBalances.ascx" tagname="UserBalances" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/UserRecentPayments.ascx" tagname="UserRecentPayments" tagprefix="uc1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>


        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnluserpic" LoadingPanelID="LoadingPanelExchangeCurrency"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlcurrencyview">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlnetbalance" LoadingPanelID="LoadingPanelExchangeCurrency"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <script type="text/javascript">
        function fileUploaded(sender, args) {
            $find('ctl00_Main_RadAjaxManager1').ajaxRequest();
            $telerik.$(".invalid").html("");
            setTimeout(function () {
                sender.deleteFileInputAt(0);
            }, 10);
        }

        function validationFailed(sender, args) {
            $telerik.$(".invalid")
                .html("Invalid extension, please choose a jpg image file");
            sender.deleteFileInputAt(0);
        }

    </script>

<table width=100%>
    <tr valign=top>
        <td>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td >
                    <!--Passport Book-->
                    <table class="Dashboard_Book">
                        <tr>
                            <td style="border-right:1px dashed Gray; width:50%;">
                                <asp:Panel ID=pnluserpic runat=server>
                                    <table style="text-align:center;">
                                        <tr>
                                            <td class="Exchange_Header">
                                                :: Welcome ::
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="User_Name">
                                                <asp:Label ID=lblusername runat=server></asp:Label>
                                                <asp:Label ID=lbluseremail Visible=false runat=server></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Image ID=imgNopic runat=server Width=250px ImageUrl="/Images/empty_profile.jpg"/>
                                                <telerik:RadBinaryImage ID=imguser runat=server ResizeMode=Fit Width=250px Visible=false/>
                                                <br />             
                                                <br />
                                                <center>
                                                <table>
                                                    <tr>
                                                        <td class="Dashboard_Netbalance_words">
                                                        Change Image
                                                        </td>
                                                        <td>
                                                            <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MultipleFileSelection=Disabled OnClientFileUploaded="fileUploaded" OnClientValidationFailed="validationFailed" 
                                                                                                OnFileUploaded="AsyncUpload1_FileUploaded" AllowedFileExtensions="jpeg,jpg" 
                                                                                                 MaxFileSize="524288"><Localization Select="" />                                                                                                 </telerik:RadAsyncUpload>                                
                                                        </td>
                                                    </tr>
                                                </table>                                                                                                         </center>                                        
                                            <telerik:RadProgressManager runat="server" ID="RadProgressManager1" />
                                            <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />

                       
                                            <br />
                            <br />
                                            </td>
                                        </tr>                                                                                      
                                    </table>
                                    </asp:Panel>
                            </td>
                            <td style="vertical-align:top;">
                                <asp:Panel ID=pnlnetbalance runat=server>
                                <table width=100% style="text-align:center;">
                                    <tr>
                                        <td>
                                            <div class="Dashboard_Netbalance_words">
                                                Net Available Balances
                                            </div>                                   
                                            <div class="Dashboard_Netbalance">                                            
                                            <asp:Label ID=lblnetbalance runat=server></asp:Label>
                                            </div>
                                            
                                            <div class="hr_dotted">
                                            &nbsp;
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Dashboard_Netbalance_additiontext">
                                            <asp:Label ID=lblnetfrozenbalance runat=server></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Dashboard_Netbalance_additiontext">
                                            <asp:Label ID=lblnetpendingpayment runat=server></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Dashboard_Netbalance_additiontext">
                                            <span class="Dashboard_Netbalance_words">Default Currency</span>
                                            <telerik:RadComboBox ID=ddlcurrencyview runat=server Width=50 
                                                onselectedindexchanged="ddlcurrencyview_SelectedIndexChanged" AutoPostBack=true ></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <table style="padding-top:20px; width:100%; position:relative; left:5px;">
                                    <tr>
                                        <td>
                                            <div class="Dashboard_Netbalance_words">
                                                Common Actions
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="Dashboard_Buttons">
                                                <tr>
                                                    <td>
                                                        <a href="/User/Verification.aspx">
                                                            <div><img src="/images/icons/verification.png"> Verifications</div>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="/ExchangeCurrency.aspx">
                                                            <div>
                                                              <img src="/images/icons/sendmoney.png" /> Send Money
                                                            </div>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="/user/Deposit.aspx">
                                                            <div>
                                                              <img src="/images/icons/sendmoney.png" /> Deposit Money
                                                            </div>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="/user/Withdrawl.aspx">
                                                            <div>
                                                              <img src="/images/icons/sendmoney.png" /> Withdraw Money
                                                            </div>
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <img src="/images/PassportBook_Footer.png" />
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width=100% >
                            <tr >
                                <td >
                                    <a href="Verification.aspx"><telerik:RadBinaryImage ID=imgverificationheader runat=server ImageUrl="/images/buttons/Verified_no.png" />
                                    </a>
                                </td>
                                <td style="text-align:right; font-size:smaller;">
                                    Email, Passport and Address Verification are required in order to send a payment.
                                </td>
                            </tr>
                            <tr>
                                <td colspan=2 class="Dashboard_VerificationTable">
                                    <br />                                    
                                    <table>
                                        <tr>
                                            <td>Email Verification</td>
                                            <td>Passport Verification</td>
                                            <td>Address Verification</td>
                                        </tr>
                                        <tr>
                                            <td><img src="/images/icons/pointer_down.png" /> </td>
                                            <td><img src="/images/icons/pointer_down.png" /> </td>
                                            <td><img src="/images/icons/pointer_down.png" /> </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div style="background-image:url('/images/buttons/VerificationLinear_Background.png'); width:500px; height:14px;">
                                    
                                    <table>
                                        <tr>
                                            <td width=166>
                                            <telerik:RadBinaryImage ID=imgVerificationEmail runat=server  ImageUrl="/images/buttons/VerificationLinear_Yes.png" Visible=false/>
                                            </td>                                        
                                            <td>
                                                <telerik:RadBinaryImage ID=imgVerificationPassport runat=server  ImageUrl="/images/buttons/VerificationLinear_Yes.png" Visible=false/>
                                            </td>                                        
                                            <td>
                                            <telerik:RadBinaryImage ID=imgVerificationAddress runat=server  ImageUrl="/images/buttons/VerificationLinear_Yes.png" Visible=false/>
                                            </td> 
                                         </tr>                                       
                                    </table>

                                    </div>
                                               
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>            
        </td>        
        <td align=right>
            <table width=650>                
                <tr>
                    <td align=right>
                        <div class="Exchange_Header">Your Balances</div>
                        <uc1:UserBalances id=userbalances1 runat=server></uc1:UserBalances>
                    </td>
                </tr>
                <tr>
                    <td align=right>
                        <div class="Exchange_Header">Recent Payments</div>
                        <uc1:UserRecentPayments ID=ucUserRecentPayment1 runat=server />
                    </td>
                </tr>
                <tr>
                    <td align=right><uc1:ExchangeCurrency ID="ucExchangeCurrency" runat=server /></td>
                </tr>
            </table>
        </td>
    </tr>        
</table>


</asp:Content>