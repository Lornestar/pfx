<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Users.aspx.cs" Inherits="Peerfx.Admin.Admin_Users" MasterPageFile="~/Admin/Admin.Master"%>

<%@ Register Src="~/User_Controls/UserBalances.ascx" tagname="UserBalances" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/UserRecentPayments.ascx" tagname="UserRecentPayments" tagprefix="uc1" %>
<%@ Register Src="~/User_Controls/ViewUploadedPics.ascx" tagname="ViewUploadedPics" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
<asp:HiddenField ID=hduserkey runat=server Value="0" />
<telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="0" runat="server" MultiPageID="RadMultiPage1" AutoPostBack=true>
                    <Tabs>
                        <telerik:RadTab Text="Users">
                        </telerik:RadTab>
                        <telerik:RadTab Text="User Details">
                        </telerik:RadTab>                        
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" RenderSelectedPageOnly=true>
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="Admin_Tabs">

                    <telerik:RadButton ID=btnawaitingverification runat=server 
                            Text="View Users Awaiting Verification" onclick="btnawaitingverification_Click"></telerik:RadButton>

                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowAutomaticInserts="False"  OnNeedDataSource="RadGrid1_NeedDataSource" AllowSorting="true"
                OnItemCommand="RadGrid1_ItemCommand" PageSize=25 AllowFilteringByColumn=true OnItemDataBound="RadGrid1_ItemDataBound">
                <groupingsettings casesensitive="false"></groupingsettings>
                     <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="account_number" AutoGenerateColumns="False" >
                        <Columns>
                            <telerik:GridBoundColumn DataField="account_number" HeaderText="Account Number" UniqueName="account_number" SortExpression="account_number" CurrentFilterFunction=Contains FilterDelay=1500>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="user_key" HeaderText="user_key" UniqueName="user_key" Visible=false>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="first_name" HeaderText="First Name" UniqueName="first_name" SortExpression="first_name" CurrentFilterFunction=Contains FilterDelay=1500>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="last_name" HeaderText="Last Name" UniqueName="last_name" SortExpression="last_name" CurrentFilterFunction=Contains FilterDelay=1500>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="email" HeaderText="Email" UniqueName="email" SortExpression="email" CurrentFilterFunction=Contains FilterDelay=1500>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="user_balance" HeaderText="Current Balance" UniqueName="user_balance" SortExpression="user_balance" AllowFiltering=false>
                            </telerik:GridBoundColumn>                
                            <telerik:GridBoundColumn DataField="user_status_text" HeaderText="Status" UniqueName="user_status_text" SortExpression="user_status_text" AllowFiltering=false>
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn DataField="last_online" HeaderText="Last Online" UniqueName="last_online" SortExpression="last_online" PickerType="DatePicker"
                    EnableRangeFiltering="true">
                            </telerik:GridDateTimeColumn>  
                            <telerik:GridButtonColumn DataTextFormatString="Details" DataTextField="user_key" Text="Details" CommandName="Details"></telerik:GridButtonColumn>                            
                        </Columns>
                        <CommandItemSettings ShowAddNewRecordButton=false />
                    </MasterTableView>
                </telerik:RadGrid>

                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="Admin_Tabs">
                        <table >
                            <tr valign=top>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td><telerik:RadBinaryImage ID=imguser runat=server ResizeMode=Fit Width=250px /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label ID=lblname runat=server></asp:Label>
                                                            <br />
                                                            (<asp:Label ID=lblemail runat=server></asp:Label>)
                                                        </td>
                                                    </tr>
                                                </table>                                    

                                            </td>
                                        </tr>
                                        <tr>                    
                                            <td>
                                                Account Status : <asp:Label ID=lblaccountstatus runat=server></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Date Created : <asp:Label ID=lblaccountcreated runat=server></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Last Login : <asp:Label ID=lblaccountlastlogin runat=server></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Verifications
                                                <br />
                                                Points: <asp:Label ID=lblpoints runat=server>
                                                </asp:Label>
                                                <br />
                                                <telerik:RadListView ID="RadListView1" runat="server" Width=100% ItemPlaceholderID="ListViewContainer" OnItemDataBound="RadListView1_Databound"
                                                 OnItemCommand="RadListView1_ItemCommand">
                                                  <LayoutTemplate>                            
                                                        <table id="products" width=100%  class="RadListview_Table">
                                                                <tr class="RadListview_Header">
                                                                    <td >
                                                                        Method
                                                                    </td>
                                                                    <td >
                                                                        Points
                                                                    </td>     
                                                                    <td>
                                                                        Status
                                                                    </td>                                                                                                                                                                                                       <td>
                                                                        Actions
                                                                    </td>
                                                                </tr>
                                                            <tr id="ListViewContainer" runat="server" >
                                                            </tr>
                                                        </table>                            
                                                </LayoutTemplate>                            
                                                    <ItemTemplate>                            
                                                            <tr>
                                                                <td >                                                                
                                                                        <%# Eval("verification_method_name") %>                                                
                                                                </td>
                                                                <td >
                                                                    <%# Eval("points")%>
                                                                </td>               
                                                                <td>
                                                                    
                                                                        <telerik:RadBinaryImage ID=imgstatus runat=server ImageUrl="/images/x.png" />
                                                                </td>                         
                                                                <td>
                                                                    <telerik:RadButton ID=btnvalid runat=server CommandName="Validate" Text="Validate"></telerik:RadButton>
                                                                    <telerik:RadButton ID=btnreject runat=server CommandName="Reject" Text="Reject"></telerik:RadButton>
                                                                </td>
                                                            </tr>                        
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <tr style="background-color:#EEEEEE;">
                                                                <td >                                                                
                                                                        <%# Eval("verification_method_name") %>                                                
                                                                </td>
                                                                <td >
                                                                    <%# Eval("points")%>
                                                                </td>               
                                                                <td>
                                                                    
                                                                        <telerik:RadBinaryImage ID=imgstatus runat=server ImageUrl="/images/x.png" />
                                                                </td>                         
                                                                <td>
                                                                    <telerik:RadButton ID=btnvalid runat=server CommandName="Validate" Text="Validate"></telerik:RadButton>
                                                                    <telerik:RadButton ID=btnreject runat=server CommandName="Reject" Text="Reject"></telerik:RadButton>
                                                                </td>
                                                            </tr>  
                                                    </AlternatingItemTemplate>
                                                </telerik:RadListView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align=right>
                                    <table width=650 >                 
                                        <tr>
                                            <td>
                                                <table style="vertical-align:top;">
                                                    <tr>
                                                        <td colspan=2 class="Exchange_Header">
                                                            ID Verification
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Passport Number</td>
                                                        <td><asp:Label ID=lblpassportnumber runat=server></asp:Label> </td>
                                                    </tr>
                                                    <tr valign=top>
                                                        <td >Passport Images</td>
                                                        <td>
                                                            <uc1:ViewUploadedPics id="ViewUploadedPics1" runat=server></uc1:ViewUploadedPics>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan=2><hr /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan=2 class="Exchange_Header">
                                                            Address Verification
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Address:</td>
                                                        <td><asp:Label ID=lbladdress1 runat=server></asp:Label> <asp:Label  ID=lbladdress2 runat=server></asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td>City:</td>
                                                        <td><asp:Label ID=lblcity runat=server></asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Country:</td>
                                                        <td><asp:Label ID=lblcountry runat=server></asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td>State/Province:</td>
                                                        <td><asp:Label ID=lblstate runat=server></asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Zip/Postal Code:</td>
                                                        <td><asp:Label ID=lblpostalcode runat=server></asp:Label> </td>
                                                    </tr>
                                                    <tr valign=top>
                                                        <td >Address Images</td>
                                                        <td>
                                                            <uc1:ViewUploadedPics id="ViewUploadedPics2" runat=server></uc1:ViewUploadedPics>
                                                        </td>
                                                    </tr>            
                                                    <tr>
                                                        <td colspan=2><hr /></td>
                                                    </tr>
                                                    <tr>                                                        
                                                        <td colspan=2 class="Exchange_Header">Facebook Validation:</td>
                                                    </tr>                
                                                    <tr>
                                                        <td colspan=2>
                                                            <table width=100%>
                                                                <tr valign=top>
                                                                    <td>
                                                                    <table>
                                                                <tr>
                                                                    <td colspan=2>
                                                                        <asp:HyperLink ID=hypfb runat=server Target=_blank NavigateUrl="http://www.facebook.com/profile.php?id=" Text="Link to user's Facebook Account"></asp:HyperLink>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        fb location:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID=lblfblocation runat=server></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        fb email:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID=lblfbemail runat=server></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        fb friends count:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID=lblfbfriendscount runat=server></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        fb gender:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID=lblfbgender runat=server></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        fb full name:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID=lblfbfullname runat=server></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        fb is verified:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID=lblfbverified runat=server></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                                    </td>
                                                                    <td>
                                                                    <asp:HyperLink ID=hypfb2 runat=server>
                                                            <telerik:RadBinaryImage ID=imgfb runat=server Width=200 /></asp:HyperLink>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            
                                                        </td>            
                                                    </tr>               
                                                </table>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td align=right>
                                                <div class="Exchange_Header">Your Balances</div>
                                                <uc1:UserBalances id=userbalances1 runat=server></uc1:UserBalances>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td align=right>
                                                <div class="Exchange_Header">Recent Payments</div>
                                                <uc1:UserRecentPayments ID=ucUserRecentPayment1 runat=server />
                                            </td>
                                        </tr>                                        
                                    </table>
                                </td>
                            </tr>
                        </table>                        
                    </telerik:RadPageView>

                </telerik:RadMultiPage>
                

</telerik:RadAjaxPanel>

</asp:Content>