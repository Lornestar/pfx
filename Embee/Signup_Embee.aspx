<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup_Embee.aspx.cs" Inherits="Peerfx.Embee.Signup_Embee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Passportfx - Clever Currency</title>
    <link href="../Peerfx.css" rel="stylesheet" type="text/css" />
    <script src="http://www.tradepfx.com/Scripts/Mixpanel.js" type="text/javascript"></script>  
    <script src="../Scripts/Scripts.js" type="text/javascript"></script>      
</head>
<body style="background-image:url('../images/homepage/background.jpg');
     background-repeat:no-repeat;
     background-position:center top;">
    <form id="form1" runat="server">
    <div style="min-height:800px; margin-top:50px; ">
     <center>
     <div class="Login_Page">
<telerik:RadScriptManager ID="ScriptManager" runat="server" />       
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <table >
        <tr>
            <td  colspan=2>
                <center>                
                <span class="Login_Header">Sign Up</span>
                </center>
            </td>
        </tr>
        <tr>
            <td>
            First Name
            </td>
            <td>
                <telerik:RadTextBox ID=txtfirstname runat=server Width=200 AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
            Last Name
            </td>
            <td>
                <telerik:RadTextBox ID=txtlastname runat=server Width=200 AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <telerik:RadTextBox ID=txtemail runat=server Width=200 AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <telerik:RadTextBox ID=txtpassword runat=server Width=200 TextMode=Password AutoCompleteType=Disabled></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan=2> <center>
                <telerik:RadButton ID=btnsignup runat=server Text="Sign Up" 
                    onclick="btnsignup_Click"></telerik:RadButton>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan=2>
                <center>
                    <asp:Label ID=lblerror runat=server ForeColor=Red></asp:Label>
                </center>
            </td>
        </tr>
    </table>    

    </telerik:RadAjaxPanel>
    </div>
    </center>
    
    </div>

    <script language=javascript>
        mixpanel.track('page viewed', { 'page name': document.title, 'url': window.location.pathname });

        function loadbodyclass() {
            document.body.className = "mainbody" + document.getElementById("ctl00_hdbodyclass").value;
        }    
</script>

<!-- begin olark code -->
<script data-cfasync="false" type='text/javascript'>/*<![CDATA[*/window.olark||(function(c){var f=window,d=document,l=f.location.protocol=="https:"?"https:":"http:",z=c.name,r="load";var nt=function(){
f[z]=function(){
(a.s=a.s||[]).push(arguments)};var a=f[z]._={
},q=c.methods.length;while(q--){(function(n){f[z][n]=function(){
f[z]("call",n,arguments)}})(c.methods[q])}a.l=c.loader;a.i=nt;a.p={
0:+new Date};a.P=function(u){
a.p[u]=new Date-a.p[0]};function s(){
a.P(r);f[z](r)}f.addEventListener?f.addEventListener(r,s,false):f.attachEvent("on"+r,s);var ld=function(){function p(hd){
hd="head";return["<",hd,"></",hd,"><",i,' onl' + 'oad="var d=',g,";d.getElementsByTagName('head')[0].",j,"(d.",h,"('script')).",k,"='",l,"//",a.l,"'",'"',"></",i,">"].join("")}var i="body",m=d[i];if(!m){
return setTimeout(ld,100)}a.P(1);var j="appendChild",h="createElement",k="src",n=d[h]("div"),v=n[j](d[h](z)),b=d[h]("iframe"),g="document",e="domain",o;n.style.display="none";m.insertBefore(n,m.firstChild).id=z;b.frameBorder="0";b.id=z+"-loader";if(/MSIE[ ]+6/.test(navigator.userAgent)){
b.src="javascript:false"}b.allowTransparency="true";v[j](b);try{
b.contentWindow[g].open()}catch(w){
c[e]=d[e];o="javascript:var d="+g+".open();d.domain='"+d.domain+"';";b[k]=o+"void(0);"}try{
var t=b.contentWindow[g];t.write(p());t.close()}catch(x){
b[k]=o+'d.write("'+p().replace(/"/g,String.fromCharCode(92)+'"')+'");d.close();'}a.P(2)};ld()};nt()})({
loader: "static.olark.com/jsclient/loader0.js",name:"olark",methods:["configure","extend","declare","identify"]});
/* custom configuration goes here (www.olark.com/documentation) */
olark.identify('7271-784-10-6135');/*]]>*/</script><noscript><a href="https://www.olark.com/site/7271-784-10-6135/contact" title="Contact us" target="_blank">Questions? Feedback?</a> powered by <a href="http://www.olark.com?welcome" title="Olark live chat software">Olark live chat software</a></noscript>
<!-- end olark code -->

<!--Gosquared code-->

<script type="text/javascript">
    var GoSquared = {};
    GoSquared.acct = "GSN-168925-A";
    (function (w) {
        function gs() {
            w._gstc_lt = +new Date;
            var d = document, g = d.createElement("script");
            g.type = "text/javascript";
            g.src = "//d1l6p2sc9645hc.cloudfront.net/tracker.js";
            var s = d.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(g, s);
        }
        w.addEventListener ?
      w.addEventListener("load", gs, false) :
      w.attachEvent("onload", gs);
    })(window);
</script>
<!--End of Gosquared code-->

    </form>
</body>
</html>
