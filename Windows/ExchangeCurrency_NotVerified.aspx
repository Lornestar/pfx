<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExchangeCurrency_NotVerified.aspx.cs" Inherits="Peerfx.Windows.ExchangeCurrency_NotVerified" MasterPageFile="~/Windows/Site_Windows.Master"%>

<asp:Content ContentPlaceHolderID=Main ID=content1 runat=server>

You can complete a Payment Request when all the Required Verifications have been completed.
<br />
<br />
Go to <a href="#" onclick="gotoverification();">Verification Page</a>

<script language=javascript>

    function gotoverification() {
        GetRadWindow().close('1');
    }
</script>

</asp:Content>