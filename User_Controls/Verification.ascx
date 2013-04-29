<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Verification.ascx.cs" Inherits="Peerfx.User_Controls.Verification" %>

<%@ Register Src="~/User_Controls/ViewUploadedPics.ascx" tagname="ViewUploadedPics" tagprefix="uc1" %>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnphonesendverification">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>            
            <telerik:AjaxSetting AjaxControlID="btnemail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnphone">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnpassportopen">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnopenaddress">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPassportNext">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnaddresssnext">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlverifications" LoadingPanelID="RadAjaxLoadingPanel1"/>                    
                </UpdatedControls>
            </telerik:AjaxSetting>                        
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <script type="text/javascript">
        function fileUploaded(sender, args) {            
            $find('ctl00_Main_ucVerification_RadAjaxManager1').ajaxRequest();            
            $telerik.$(".invalid").html("");
            setTimeout(function () {
                sender.deleteFileInputAt(0);
            }, 10);
        }

        function validationFailed(sender, args) {
            alert("Please select an image smaller than 4MB, and of type jpg/jpeg/gif/png");
        }

    </script>


<div class="Page_Header">
Verifications
</div>


<center>
<asp:Panel ID=pnlverifications runat=server>

<telerik:RadNotification ID="RadNotification1" runat="server" VisibleOnPageLoad="false" AnimationDuration=750 AutoCloseDelay=3000 Position=Center
            Width="330" Height="130" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
            Title="Passport Notification" Text=""
            Style="z-index: 35000">
        </telerik:RadNotification>

<asp:HiddenField ID=hduserkey runat=server Value="0"/>

<table style="vertical-align:top; width:700px; border:1px solid gray;">
    <tr>
        <td colspan=3 class="Verification_Sections">
            <span class="Exchange_Header">Required to complete payments</span>
        </td>
    </tr>
    <tr>
        <td colspan=3 class="Verification_Sections">
            <table width=100%>
                <tr>
                    <td>
                        <telerik:RadBinaryImage ID=imgvalid1 runat=server ImageUrl="/images/x.png"/>
                    </td>
                    <td>
                        <div class="Verification_Name">Email Verification</div>            
                        <div class="Verification_Description">
                            An email was sent to you with a unique link to verify your account
                        </div>
                    </td>
                    <td style=" text-align:right;">
                        <telerik:RadButton ID=btnemail runat=server Text="Resend Email" 
                            onclick="btnemail_Click"></telerik:RadButton>
                    </td>
                </tr>
            </table>
        </td>        
    </tr>
    <tr>
        <td colspan=3 class="Verification_Sections">
            <table width=100%>
                <tr>
                    <td>
                        <telerik:RadBinaryImage ID=imgvalid2 runat=server ImageUrl="/images/x.png"/>
                    </td>
                    <td>
                        <div class="Verification_Name">ID Verification</div>            
                        <div class="Verification_Description">
                            Verification of your passport number and an uploaded image of your Passport photo page.
                        </div>
                    </td>
                    <td style="text-align:right;">           
                        <telerik:RadButton ID=btnpassportopen runat=server onclick="btnpassportopen_Click" Text="Verify Passport"></telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td colspan=3>
                        <asp:Panel ID=pnlpassport runat=server Visible=false>
                        <table width=100%>
                            <tr>
                                <td>
                                    Passport Code
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadMaskedTextBox ID=txtPassport1 runat=server Width=80 MaxLength="9" HideOnBlur=true Mask="#########"/>
                                                <br />
                                                123456789
                                            </td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID=txtPassport2 runat=server Width=18 MaxLength="1" HideOnBlur=true Mask="#"/>
                                                <br />
                                                1
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport3 runat=server Width=50 MaxLength="3" />
                                                <br />
                                                GBR
                                            </td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID=txtPassport4 runat=server Width=70 MaxLength="7" HideOnBlur=true Mask="#######"/>
                                                <br />
                                                1234567
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport5 runat=server Width=25 MaxLength="1"></telerik:RadTextBox>
                                                <br />
                                                F
                                            </td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID=txtPassport6 runat=server Width=70 MaxLength="7" HideOnBlur=true Mask="#######"/>
                                                <br />
                                                1234567
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport7 runat=server Width=150 MaxLength="14" Enabled=false Text="<<<<<<<<<<<<<<"></telerik:RadTextBox>
                                                <br />
                                                <<<<<<<<<<<<<<
                                            </td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID=txtPassport8 runat=server Width=18 MaxLength="1" HideOnBlur=true Mask="#"/>
                                                <br />
                                                1
                                            </td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID=txtPassport9 runat=server Width=18 MaxLength="1" HideOnBlur=true Mask="#"/>
                                                <br />
                                                1
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div style="float:right;">
                        <asp:Label ID=lblpassporterror runat=server ForeColor=Red></asp:Label>
                        <telerik:RadButton ID=btnPassportNext runat=server Text="Upload Image" OnClick="btnpassportnext_Click"></telerik:RadButton> </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan=3>
                        <asp:Panel ID=pnlPassportPhoto runat=server Visible=false>
                        Upload an image of your Passport Photo (jpeg,jpg,gif,png)
                        <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" OnFileUploaded="AsyncUpload1_FileUploaded" AllowedFileExtensions="jpeg,jpg,gif,png" 
                                       OnClientFileUploaded="fileUploaded" OnClientValidationFailed="validationFailed" MultipleFileSelection="Automatic"  MaxFileSize="4024288">                                       <Localization Select="" />
                                                                                             </telerik:RadAsyncUpload>            
                                                                                             <telerik:RadProgressManager runat="server" ID="RadProgressManager1" />
                            <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
                            <br />
                            <uc1:ViewUploadedPics id="ViewUploadedPics1" runat=server></uc1:ViewUploadedPics>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>        
    </tr>
    <tr>
        <td colspan=3 class="Verification_Sections">
            <table>
                <tr>
                    <td>
                        <telerik:RadBinaryImage ID=imgvalid3 runat=server ImageUrl="/images/x.png"/>
                    </td>
                    <td>
                        <div class="Verification_Name">Address Verification</div>            
                        <div class="Verification_Description">
                            A scanned image of a recent bank statement or utility bill (no more than 3 months old) showing name and residential address (PO Box address will not be accepted)
                        </div>
                    </td>
                    <td style="text-align:right;">
                        <telerik:RadButton ID=btnopenaddress runat=server Text="Verify Address" OnClick="btnaddressnext_Click"></telerik:RadButton>
                    </td>                    
                </tr>
                <tr>
                    <td colspan=3>
                        <asp:Panel ID=pnladdress runat=server Visible=false>
                        <table>
                            <tr>
                                <td class="Signup_Left_Columns">
                                    *Residential Address
                                    <br />P.O. Box not accepted
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtAddress1 runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <telerik:RadTextBox ID=txtAddress2 runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    *City / Town
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtCity runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    *State / Province
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtState runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    *Country
                                </td>
                                <td>
                                    <telerik:RadComboBox ID=ddlCountryAddress runat=server EmptyMessage="Select Country">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>                            
                            <tr>
                                <td>
                                    *Postal / Zip Code
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtpostalzipcode runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>    
                         <br />
                         <div style="float:right;">
                         <asp:Label ID=lbladdresserror runat=server ForeColor=Red></asp:Label>
                         <telerik:RadButton ID=btnaddresssnext runat=server Text="Upload Image" OnClick="btnaddressnext2_Click"></telerik:RadButton>                                 
                         </div>                                
                        </asp:Panel>
                        <br />
                        <table width=100%>
                            <tr>
                                <td>
                                <asp:Panel ID=pnladdressimage runat=server Visible=false>
                               Upload images of a Utility bill with your address (jpeg,jpg,gif,png)
                                <telerik:RadAsyncUpload runat="server" ID="RadAsyncUpload2" OnFileUploaded="AsyncUpload2_FileUploaded" AllowedFileExtensions="jpeg,jpg,gif,png" 
                                                   OnClientFileUploaded="fileUploaded" OnClientValidationFailed="validationFailed" MultipleFileSelection="Automatic"  MaxFileSize="4024288">
                                                   
                                                                                                         <Localization Select="" />
                                                                                                         </telerik:RadAsyncUpload>        
                                                                                                         <telerik:RadProgressManager runat="server" ID="RadProgressManager2" />
                            <telerik:RadProgressArea runat="server" ID="RadProgressArea2" />
<br />
<uc1:ViewUploadedPics id="ViewUploadedPics2" runat=server></uc1:ViewUploadedPics>                                                                                                        </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
            </table>
        </td>        
    </tr>
    <tr>
        <td colspan=3 >
            <div class="Exchange_Header">Additional Security</div>
        </td>
    </tr>
    <tr>
        <td colspan=3>
            <table width=100%>
                <tr>
                    <td>
                        <telerik:RadBinaryImage ID=imgvalid4 runat=server ImageUrl="/images/x.png"/>
                    </td>
                    <td>
                        <div class="Verification_Name">Phone Verification</div>            
                        <div class="Verification_Description">
                            An sms with a unique code is sent to your phone
                        </div>
                    </td>
                    <td style="text-align:right;">
                        <telerik:RadButton ID=btnphone runat=server Text="Verify Phone" 
                            onclick="btnphone_Click"></telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td colspan=3>
                        <asp:Panel ID=pnlphonesendverification runat=server Visible=false>                        
                            <telerik:RadComboBox ID=ddlcountryphone runat=server EmptyMessage="Country">
                            </telerik:RadComboBox>
                            <telerik:RadTextBox ID=txtphonesendverfication runat=server EmptyMessage="Phone Number"></telerik:RadTextBox>
                            <span style="font-size:smaller;">(do not start # with a 0)</span>
                            <telerik:RadButton ID=btnphonesendverification runat=server OnClick=btnphonesendverification_Click Text="Send Phone Code"></telerik:RadButton>
                            <br />
                            <asp:Label ID=lblphoneerror runat=server ForeColor=Red></asp:Label>
                        </asp:Panel>                        
                    </td>
                </tr>
                <tr>
                    <td colspan=3>
                        <asp:Panel ID=pnlphoneverification runat=server Visible=false>
                            <telerik:RadTextBox ID=txtphonecode runat=server EmptyMessage="Enter the code sent to your phone" Width=280px></telerik:RadTextBox>
                            <telerik:RadButton ID=btnphonecode runat=server OnClick=btnphonecode_Click Text="Enter Phone Code"></telerik:RadButton>
                            <br />
                            <asp:Label ID=lblphoneerror2 runat=server ForeColor=Red></asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>        
    </tr>
    <tr>
        <td>
            <telerik:RadBinaryImage ID=imgvalid5 runat=server ImageUrl="/images/x.png"/>
        </td>
        <td>
            <div class="Verification_Name">Connect Facebook</div>            
            <div class="Verification_Description">
                Sign in with Facebook and receive a $5 credit
            </div>
        </td>
        <td style="text-align:right;">        
            <a href="http://www.facebook.com/dialog/oauth/?client_id=223254254482336&redirect_uri=http://www.tradepfx.com/Facebook/fblogin.aspx&scope=email&user_birthday&user_location">
            <asp:Image ImageUrl="/images/btnfbconnect.png" ID=imgfbbutton runat=server />
            </a>

            <telerik:RadButton ID=btnFacebook runat=server Visible=false></telerik:RadButton>
        </td>
    </tr>
</table>
</asp:Panel>

</center>