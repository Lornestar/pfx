<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Admin_ScheduledTask_Embee.ascx.cs" Inherits="Peerfx.User_Controls.Admin_ScheduledTask_Embee" %>

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
