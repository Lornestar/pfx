<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCurrencyCloud_RequiredFields.aspx.cs" Inherits="Peerfx.Testing.TestCurrencyCloud_RequiredFields" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Ping Currency Cloud to see what required fields for each currency/country
    <br />
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />       

    <telerik:RadComboBox ID=ddlcountry runat=server 
            onselectedindexchanged="ddlcountry_SelectedIndexChanged" AutoPostBack=true></telerik:RadComboBox>
    <telerik:RadComboBox ID=ddlcurrency runat=server 
            onselectedindexchanged="ddlcurrency_SelectedIndexChanged" style="height: 22px" AutoPostBack=true></telerik:RadComboBox>
    
    <br />
    <asp:Label ID=lblccresult runat=server></asp:Label>

    </div>
    </form>
</body>
</html>
