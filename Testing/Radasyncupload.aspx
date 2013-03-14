<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Radasyncupload.aspx.cs" Inherits="Peerfx.Testing.Radasyncupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
 <telerik:RadScriptManager ID="ScriptManager1" runat="server" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Thumbnail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <script type="text/javascript">
        function fileUploaded(sender, args) {
            $find('RadAjaxManager1').ajaxRequest();
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

        function OnClientClicked(sender, args) {
            $telerik.$(".binary-image").attr("src", "blank.png");
        }
    </script>

    <div class="upload-panel">
        <%-- For the purpose of this demo the files are discarded.
			 In order to store the uploaded files permanently set the TargetFolder property to a valid location. --%>
        <telerik:RadBinaryImage runat="server" Width="200px" Height="150px" ResizeMode="Fit"
            ID="Thumbnail" ImageUrl="blank.png" AlternateText="Thumbnail" CssClass="binary-image" />

        <span class="invalid"></span>
        <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MaxFileInputsCount="1" OnClientFileUploaded="fileUploaded" MultipleFileSelection=Automatic
            OnFileUploaded="AsyncUpload1_FileUploaded" AllowedFileExtensions="jpeg,jpg,gif,png,bmp" OnClientValidationFailed="validationFailed">
            <Localization Select="Choose Avatar" />
        </telerik:RadAsyncUpload>
         <telerik:RadButton runat="server" ID="RadButton1" Text="Set Default" AutoPostBack="false"
             OnClientClicked="OnClientClicked">
        </telerik:RadButton>
    </div>
    
    </div>
    </form>
</body>
</html>
