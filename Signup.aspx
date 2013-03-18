<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Peerfx.Signup" MasterPageFile="~/Site.Master"%>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

Sign up
<br />

<telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="LoadingPanel1"
            Height="100%">

            <asp:HiddenField ID=hduserkey runat=server Value="0" />
            <div style="float: left; width: 100%">
                <telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1">
                    <Tabs>
                        <telerik:RadTab Text="Personal Details">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Contact Information" >
                        </telerik:RadTab>
                        <telerik:RadTab Text="Account Security" >
                        </telerik:RadTab>
                        <telerik:RadTab Text="Confirmation" >
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" BorderWidth=1>                
                <!--*************Tab1************-->
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="corporatePageView">
                        <table>
                            <tr>
                                <td colspan=2>
                                    *Required Fields
                                </td>
                            </tr>
                            <tr>
                                <td class="Signup_Left_Columns">
                                    *Name
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadComboBox ID=ddlTitle runat=server EmptyMessage="Title" Width=50>
                                                    <Items>
                                                         <telerik:RadComboBoxItem Text="Mr" Value="Mr"/>
                                                         <telerik:RadComboBoxItem Text="Mrs" Value="Mrs"/>
                                                         <telerik:RadComboBoxItem Text="Miss" Value="Miss"/>
                                                         <telerik:RadComboBoxItem Text="Ms" Value="Ms"/>
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtfirstname runat=server EmptyMessage="First Name" Width=200></telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtmiddlename runat=server EmptyMessage="Middle Name" Width=200></telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtlastname runat=server EmptyMessage="Last Name" Width=200></telerik:RadTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    *Date of Birth
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadComboBox ID=ddlbirthday runat=server EmptyMessage="Day">                                                    
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID=ddlbirthmonth runat=server EmptyMessage="Month">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="January" Value="1" />
                                                        <telerik:RadComboBoxItem Text="February" Value="2" />
                                                        <telerik:RadComboBoxItem Text="March" Value="3" />
                                                        <telerik:RadComboBoxItem Text="April" Value="4" />
                                                        <telerik:RadComboBoxItem Text="May" Value="5" />
                                                        <telerik:RadComboBoxItem Text="June" Value="6" />
                                                        <telerik:RadComboBoxItem Text="July" Value="7" />
                                                        <telerik:RadComboBoxItem Text="August" Value="8" />
                                                        <telerik:RadComboBoxItem Text="September" Value="9" />
                                                        <telerik:RadComboBoxItem Text="October" Value="10" />
                                                        <telerik:RadComboBoxItem Text="November" Value="11" />
                                                        <telerik:RadComboBoxItem Text="December" Value="12" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID=ddlbirthyear runat=server EmptyMessage="Year">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>                                        
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>*Country of Residence</td>
                                <td>
                                    <telerik:RadComboBox ID=ddlcountryresidence runat=server >
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>*Email Address</td>
                                <td>
                                    <telerik:RadTextBox ID="txtemail" runat="server"></telerik:RadTextBox>
                                    <asp:RegularExpressionValidator ID="regemail" runat="server" Display="Dynamic"
                                    ErrorMessage="Please, enter valid e-mail address." ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                    ControlToValidate="txtemail"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rqvemail" runat="server" Display="Dynamic"
                                    ControlToValidate="txtemail" ErrorMessage="Please, enter an e-mail address"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>*Confirm Email</td>
                                <td>
                                    <telerik:RadTextBox ID="txtemailconfirm" runat="server"></telerik:RadTextBox>                                    
                                    <asp:CompareValidator id="rqvemailconfirm"  runat=server Display="dynamic"
                                    ControlToValidate="txtemailconfirm" ControlToCompare="txtemail" ErrorMessage="The 2 email addresses are not the same">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan=2 style="text-align:right;">
                                    <telerik:RadButton ID=btnContinue1 runat=server Text="Continue" onclick="btnContinue1_Click"></telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <!--*************Tab1************-->
                    <!--*************Tab2************-->

                    <telerik:RadPageView ID="RadPageView2" runat="server" BorderWidth=1>
                        <table>
                            <tr>
                                <td colspan=2>
                                    *Required Fields
                                </td>
                            </tr>
                            <tr>
                                <td colspan=2 class="Signup_Header">
                                    Contact Details
                                </td>
                            </tr>
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
                                    <telerik:RadComboBox ID=ddlCountrytab2 runat=server >
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
                            <tr>
                                <td>
                                    *Primary Phone
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadComboBox ID=ddlPhoneCountryCode1 runat=server EmptyMessage="Country Code"></telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID=ddlPhoneType1 runat=server EmptyMessage="Type"></telerik:RadComboBox>
                                            </td>
                                            <td>
                                            <telerik:RadTextBox id="txtPhone1" runat="server" EmptyMessage="Number"></telerik:RadTextBox>
                                            </td>
                                        </tr>
                                    </table>                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Secondary Phone
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadComboBox ID=ddlPhoneCountryCode2 runat=server EmptyMessage="Country Code"></telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID=ddlPhoneType2 runat=server EmptyMessage="Type"></telerik:RadComboBox>
                                            </td>
                                            <td>
                                            <telerik:RadTextBox id="txtPhone2" runat="server" EmptyMessage="Number"></telerik:RadTextBox>
                                            </td>
                                        </tr>
                                    </table>                                    
                                </td>
                            </tr>
                            <tr>
                                <td colspan=2 style="font-weight:bolder;">
                                    Identity Verification
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    *Nationality
                                </td>
                                <td>
                                    <telerik:RadComboBox ID=ddlIdentityNationality runat=server AutoPostBack=true OnSelectedIndexChanged="ddlIdentityNationality_changed">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID=lblssnrequired runat=server Visible=false>*</asp:Label>US Social Security Number
                                </td>
                                <td>
                                
                                <telerik:RadMaskedTextBox ID=txtssn runat=server Mask="###-##-####">
                                    </telerik:RadMaskedTextBox>(SSN allows us to transfer USD much faster for you)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    *Occupation
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID=txtOccupation runat=server ></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Passport Code
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport1 runat=server Width=70 MaxLength="9"></telerik:RadTextBox>
                                                <br />
                                                123456789
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport2 runat=server Width=18 MaxLength="1"></telerik:RadTextBox>
                                                <br />
                                                1
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport3 runat=server Width=50 MaxLength="3"></telerik:RadTextBox>
                                                <br />
                                                GBR
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport4 runat=server Width=70 MaxLength="7"></telerik:RadTextBox>
                                                <br />
                                                1234567
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport5 runat=server Width=18 MaxLength="1"></telerik:RadTextBox>
                                                <br />
                                                F
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport6 runat=server Width=70 MaxLength="7"></telerik:RadTextBox>
                                                <br />
                                                1234567
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport7 runat=server Width=150 MaxLength="14"></telerik:RadTextBox>
                                                <br />
                                                <<<<<<<<<<<<<<
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport8 runat=server Width=18 MaxLength="1"></telerik:RadTextBox>
                                                <br />
                                                1
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID=txtPassport9 runat=server Width=18 MaxLength="1"></telerik:RadTextBox>
                                                <br />
                                                1
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadButton ID=btnBack2 Text="Back" runat=server 
                                        OnClick="btnBack2_Click"></telerik:RadButton>
                                </td>
                                <td style="text-align:right;">
                                    <telerik:RadButton ID=btnContinue2 runat=server Text="Continue" OnClick="btnContinue2_Click"></telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <!--*************Tab3************-->

                    <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="productsPageView" BorderWidth=1>
                        <table>
                            <tr>
                                <td colspan=2>
                                    *Required Fields
                                </td>
                            </tr>
                            <tr>
                                <td colspan=2  class="Signup_Header">
                                    Secure Your Account
                                </td>
                            </tr>
                            <tr>
                                <td class="Signup_Left_Columns">
                                    *Username
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtUsername runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Password
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtPassword runat=server></telerik:RadTextBox>
                                    <div class="FinePrint">
                                    (8 to 20 characters with at least 1 number, 1 upper case and 1 lower case letter)
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Confirm Password
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtConfirmPassword runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Security Question 1
                                </td>
                                <td>
                                    <telerik:RadComboBox ID=ddlSecurityQuestion1 runat=server EmptyMessage="Select"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Security Answer 1
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtSecurityAnswer1 runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Security Question 2
                                </td>
                                <td>
                                    <telerik:RadComboBox ID=ddlSecurityQuestion2 runat=server EmptyMessage="Select"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Security Answer 2
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtSecurityAnswer2 runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Security Question 3
                                </td>
                                <td>
                                    <telerik:RadComboBox ID=ddlSecurityQuestion3 runat=server EmptyMessage="Select"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    *Security Answer 3
                                </td>
                                <td>
                                    <telerik:RadTextBox ID=txtSecurityAnswer3 runat=server></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan=2>
                                    <asp:CheckBox runat=server Checked=false ID=chkterms runat=server />
                                    I confirm that I am at least 18 yeras old and that I agree to Peerfx's Terms & Services
                                </td>
                            </tr>                                     
                            <tr>
                                <td colspan=2>                                    
                                    <telerik:RadCaptcha ID="RadCaptcha1" runat="server" ErrorMessage="The code you entered is not valid."
                                        ValidationGroup="Group" CaptchaTextBoxLabel="Please type code from image">
                                    </telerik:RadCaptcha>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadButton ID=btnBack3 Text="Back" runat=server 
                                        OnClick="btnBack3_Click"></telerik:RadButton>
                                </td>
                                <td style="text-align:right;">
                                    <telerik:RadButton ID=btnContinue3 runat=server Text="Register" OnClick="btnContinue3_Click"></telerik:RadButton>
                                </td>
                            </tr>                            
                        </table>
                    </telerik:RadPageView>

                    <!--*************Tab4************-->
                    <telerik:RadPageView runat="server" ID="RadPageView4" CssClass="productsPageView" BorderWidth=1>
                        <table>
                            <tr>
                                <td class="Signup_Header">
                                    Online Registration - Complete
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Congratulations on completing registration:
                                   <table>
                                    <tr>
                                        <td>Client Number - <asp:Label ID=lblclientnumber runat=server></asp:Label> </td>
                                    </tr>
                                    <tr>
                                        <td>Username - <asp:Label ID=lblusername runat=server></asp:Label> </td>
                                    </tr>
                                    <tr>
                                        <td>Email Address - <asp:Label ID=lblemailaddress runat=server></asp:Label> </td>
                                    </tr>
                                   </table> 
                                </td>                                
                            </tr>
                            <tr>
                                <td class="Signup_Header">
                                    Next steps
                                </td>
                            </tr>
                            <tr>
                                <td>
                                We have sent you an email. Please click on it to verify your are the owner of that email address. We will use this email address for notifications. If you didn't get it click here to resend .
                                    We have sent an email to <asp:Label ID=lblemailaddress2 runat=server></asp:Label>.  Please verify your email account by following the instructions in that email.  If for some reason you do not receive an email from us in the next 5 minutes, please call us at 1-800-xxxxxxx
                                </td>
                            </tr>                            
                        </table>
                    </telerik:RadPageView>
                    <!--*************Tab3************-->
                    <!--*************Tab4************-->

                </telerik:RadMultiPage>
            </div>            
 </telerik:RadAjaxPanel>

</asp:Content>