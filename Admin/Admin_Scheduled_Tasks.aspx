<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Scheduled_Tasks.aspx.cs" Inherits="Peerfx.Admin.Admin_Scheduled_Tasks" MasterPageFile="~/Admin/Admin.Master"%>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

<table>
    <tr>
        <td>
            Embee Catalog
        </td>
        <td>
            <asp:Button ID=btnEmbeeCatalog runat=server Text="Update Embee Catalog" 
                onclick="btnEmbeeCatalog_Click" />
        </td>
        <td>
            Last Updated: <asp:Label ID=lblEmbeeCatalogUpdated runat=server></asp:Label> UK Time
        </td>
    </tr>
</table>

</asp:Content>