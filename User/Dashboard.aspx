<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Peerfx.User.Dashboard" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/UserBalances.ascx" tagname="UserBalances" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/UserRecentPayments.ascx" tagname="UserRecentPayments" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<telerik:RadNotification ID="RadNotification1" runat="server" VisibleOnPageLoad="false" AnimationDuration=750 AutoCloseDelay=5000 Position=Center
            Width="330" Height="130" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
            Title="Notification Title" Text="Your Payment went through.<br/><br/>You should receive an email with information about your Request."
            Style="z-index: 35000">
        </telerik:RadNotification>

        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnluserpic" LoadingPanelID="LoadingPanelExchangeCurrency"/>                    
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
                    <td>
                    <asp:Panel ID=pnluserpic runat=server>
                    <table style="border:1px solid gray; text-align:center;">
                        <tr>
                            <td align=center>
                                <asp:Image ID=imgNopic runat=server Width=250px ImageUrl="/Images/empty_profile.jpg"/>
                                <telerik:RadBinaryImage ID=imguser runat=server ResizeMode=Fit Width=250px Visible=false/>
                                <br />             
                                 <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MultipleFileSelection=Disabled OnClientFileUploaded="fileUploaded" OnClientValidationFailed="validationFailed"
                                                                                OnFileUploaded="AsyncUpload1_FileUploaded" AllowedFileExtensions="jpeg,jpg" 
                                                                                 MaxFileSize="524288" Width=250>
                                                                                 <Localization Select="New Image" />
                                                                                 </telerik:RadAsyncUpload>
                                                                                 <telerik:RadProgressManager runat="server" ID="RadProgressManager2" />
                            <telerik:RadProgressManager runat="server" ID="RadProgressManager1" />
                            <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
                            <br />
                            
                            </td>
                        </tr>                
                        <tr>
                            <td> <span class="User_Name">
                                <asp:Label ID=lblusername runat=server></asp:Label>
                                </span>
                                 (<asp:Label ID=lbluseremail runat=server></asp:Label>)
                            </td>
                        </tr>
                        <tr>                    
                            <td>
                                Account Status : <asp:Label ID=lblaccountstatus runat=server></asp:Label>
                            </td>
                        </tr>            
                    </table>
                    </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width=100% style="border:1px solid gray;">
                            <tr >
                                <td >
                                    Verifications
                                </td>
                                <td style="text-align:right;">
                                    <a href="Verification.aspx">See all</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan=2>
                                    <table style="background:#DDDDDD;" width=100%>
                                        <tr>
                                            <td>
                                                Email Verification:
                                            </td>
                                            <td>
                                                <telerik:RadBinaryImage runat=server ImageUrl="/images/checkmark.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Passport Verification:
                                            </td>
                                            <td>
                                                <telerik:RadBinaryImage ID="RadBinaryImage1" runat=server ImageUrl="/images/x.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Address Verification:
                                            </td>
                                            <td>
                                                <telerik:RadBinaryImage ID="RadBinaryImage2" runat=server ImageUrl="/images/x.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size:smaller; text-align:right;" colspan=2>
                                                *Required to Send Payments
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                        </tr>
                                    </table>                                                                        
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