﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewUploadedPics.ascx.cs" Inherits="Peerfx.User_Controls.ViewUploadedPics" %>

<telerik:RadListView ID="RadListView1" runat="server" Width=100% ItemPlaceholderID="ListViewContainer" >                                
                                                              <LayoutTemplate>   
                                                              <fieldset style="width:450px;">
                                                                <legend>Pics</legend>
                                                                    <asp:PlaceHolder id="ListViewContainer" runat="server" />
                                                               </fieldset>                         
                                                            </LayoutTemplate>                            
                                                                <ItemTemplate>                            
                                                                    <span><a href="<%# Eval("imgurl")%>" target=_blank>
                                                                                <img src="<%# Eval("imgurl")%>" />
                                                                            </a>
                                                                          </span>
                                                                </ItemTemplate>
                                                                <EmptyDataTemplate>
                                                                    No Images Uploaded
                                                                </EmptyDataTemplate>
                                                            </telerik:RadListView>
