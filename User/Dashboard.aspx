<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Peerfx.User.Dashboard" MasterPageFile="~/Site.Master" %>
<%@ Register Src="~/User_Controls/ExchangeCurrency.ascx" tagname="ExchangeCurrency" tagprefix="uc1" %>

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
                .html("Invalid extension, please choose an image file");
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
                            <td> <span style="font-weight:bolder; font-size:medium;">
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
                        <telerik:RadListView ID="RadListView1" runat="server" Width=100% ItemPlaceholderID="ListViewContainer" >                                
                          <LayoutTemplate>                            
                                <table id="products" width=100%  class="RadListview_Table">
                                        <tr class="RadListview_Header">
                                            <td style="width:40%">
                                                Currency
                                            </td>
                                            <td style="text-align:right;">
                                                Balance
                                            </td>                                            
                                        </tr>
                                    <tr id="ListViewContainer" runat="server" >
                                    </tr>
                                </table>                            
                        </LayoutTemplate>                            
                            <ItemTemplate>                            
                                    <tr>
                                        <td >
                                                <%# Eval("info_currency_description") %>                                                
                                        </td>
                                        <td style="float:right; text-align:right;">
                                            <%# Eval("user_balance")%>
                                        </td>                                        
                                    </tr>                        
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class=RadListview_Alternating>
                                        <td >
                                                <%# Eval("info_currency_description") %>                                                
                                        </td>
                                        <td style="float:right; text-align:right;">
                                            <%# Eval("user_balance")%>
                                        </td>                                        
                                    </tr>
                            </AlternatingItemTemplate>
                        </telerik:RadListView>
                    </td>
                </tr>
                <tr>
                    <td align=right>
                        
                        <telerik:RadListView ID="RadListView2" runat="server" Width=100% ItemPlaceholderID="ListViewContainer" AllowPaging=true PageSize=5
                          Skin="Vista">
                          <LayoutTemplate>                             
                                 <div class="Exchange_Header">Recent Payments</div>
                                <table id="products" width=100% class="RadListview_Table">
                                    </tr>
                                        <tr class="RadListview_Header">
                                            <td >
                                                Date
                                            </td>
                                            <td>
                                                Description
                                            </td>
                                            <td style="text-align:right;">
                                                Status
                                            </td>     
                                            <td>
                                                
                                            </td>                                       
                                        </tr>
                                    <tr id="ListViewContainer" runat="server">
                                    </tr>                                    
                                    <tr>
                                        <td colspan=4 style="text-align:right;">
                                            <a href="History.aspx">See All Payments</a>
                                        </td>
                                    </tr>
                                </table>
                        </LayoutTemplate>
                            <ItemTemplate>
                            
                                    <tr >
                                        <td >
                                        
                                            <%# Eval("date_created") %>                               
                                        
                                        </td>
                                        <td>
                                        
                                            <%# Eval("payment_description") %>
                                            
                                        </td>
                                        <td style="float:right;">
                                        
                                            <%# Eval("payment_status_info")%>
                                        
                                        </td>                                        
                                        <td align=right>
                                            <a href="Payment.aspx?paymentkey=<%# Eval("payments_key") %>">
                                            Details
                                            </a>
                                        </td>
                                    </tr>                        
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class=RadListview_Alternating>
                                        <td >
                                        
                                            <%# Eval("date_created")%>                               
                                        
                                        </td>
                                        <td>
                                        
                                            <%# Eval("payment_description") %>
                                        
                                        </td>
                                        <td style="float:right;">
                                        
                                            <%# Eval("payment_status_info")%>
                                        
                                        </td>                                        
                                        <td align=right>
                                            <a href="Payment.aspx?paymentkey=<%# Eval("payments_key") %>">
                                            Details
                                            </a>
                                        </td>
                                    </tr>
                            </AlternatingItemTemplate>
                        </telerik:RadListView>
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