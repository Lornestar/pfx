function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}


function AdjustRadWidow() {
    var oWindow = GetRadWindow();
    setTimeout(function () {
        oWindow.autoSize(true);
        if ($telerik.isChrome || $telerik.isSafari) {
            ChromeSafariFix(oWindow);
        }
        else {
            var bounds = oWindow.getWindowBounds();
            var x = bounds.x;
            oWindow.moveTo(x, 50);
        }

    }, 310);
}

//fix for Chrome/Safari due to absolute positioned popup not counted as part of the content page layout
function ChromeSafariFix(oWindow) {
    var iframe = oWindow.get_contentFrame();
    var body = iframe.contentWindow.document.body;

    setTimeout(function () {
        var height = body.scrollHeight;
        var width = body.scrollWidth;

        var iframeBounds = $telerik.getBounds(iframe);
        var heightDelta = height - iframeBounds.height;
        var widthDelta = width - iframeBounds.width;

        if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
        if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
        oWindow.center();
        var bounds = oWindow.getWindowBounds();
        var x = bounds.x;
        oWindow.moveTo(x, 50);

    }, 310);
}

function openSignup(type) {    
    var oWnd = radopen("Signup2.aspx?type="+type, "Signup");
    $.blockUI({message:''});
}

function OnClientCloseSignup(sender, args) {
    //get the transferred arguments
    //var arg = args.get_argument();        
    var arg = args.get_argument();
    if (arg) {
        if (arg == '1') {
            window.location = "/User/Dashboard.aspx";            
            $.blockUI();
        }
    }
    $.unblockUI();
}

function openExchangeNotVerified() {
    var oWnd = radopen("/Windows/ExchangeCurrency_NotVerified.aspx", "wndExchangeCurrencyNotVerified");
    $.blockUI({ message: '' });
}

function OnClientCloseExchangeNotVerified(sender, args) {
    //get the transferred arguments
    //var arg = args.get_argument();    
    var arg = args.get_argument();
    if (arg) {
        if (arg == '1') {
            window.location = "/User/Verification.aspx";
            $.blockUI();
        }
    }
    $.unblockUI();
}