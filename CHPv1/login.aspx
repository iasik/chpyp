<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CHPv1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- BEGIN HEAD -->
<meta charset="utf-8"/>
<title>CHP</title>


<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="theme/assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="theme/assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="theme/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="theme/assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="theme/assets/global/plugins/select2/select2.css" rel="stylesheet" type="text/css"/>
<link href="theme/assets/admin/pages/css/login-soft.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE LEVEL SCRIPTS -->
<!-- BEGIN THEME STYLES -->
<link href="theme/assets/global/css/components.css" id="style_components" rel="stylesheet" type="text/css"/>
<link href="theme/assets/global/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="theme/assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css"/>
<link id="style_color" href="theme/assets/admin/layout/css/themes/darkblue.css" rel="stylesheet" type="text/css"/>
<link href="theme/assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="theme/assets/admin/layout/img/chp-icon.ico">
</head>
<!-- END HEAD -->
    
<body class="login">
<!-- BEGIN LOGO -->
<div class="logo" style="margin-bottom:0px;">
	<a href="#">
	<img src="theme/assets/admin/layout/img/chp_logo_300.png" alt=""/>
    
	</a>
    
</div>

<!-- END LOGO -->
<!-- BEGIN SIDEBAR TOGGLER BUTTON -->
<div class="container">
    
    <h3 style="text-align:center;font-weight:300;color:#eee;">CHP Kocaeli İl Başkanlığı</h3>
    
</div>
<!-- END SIDEBAR TOGGLER BUTTON -->
<!-- BEGIN LOGIN -->
<div class="content">
	<!-- BEGIN LOGIN FORM -->
	<form class="login-form"  id="form1" runat="server" defaultbutton="BtnLogin">
		<h3 class="form-title">Giriş Yap</h3>
		<div class="alert alert-danger display-hide">
			<button class="close" data-close="alert"></button>
			<span>
			Kullanıcı veya Parola Girilmedi. </span>
		</div>
		<div class="form-group">
			<!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
			<label class="control-label visible-ie8 visible-ie9">Username</label>
			<div class="input-icon">
				<i class="fa fa-user"></i>
                <asp:TextBox ID="tbxUsername" runat="server" class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Kullanıcı Adı" name="username"></asp:TextBox>
			</div>
		</div>
		<div class="form-group">
			<label class="control-label visible-ie8 visible-ie9">Password</label>
			<div class="input-icon">
				<i class="fa fa-lock"></i>
				 <asp:TextBox ID="tbxPassword" runat="server" class="form-control placeholder-no-fix" type="password" autocomplete="off" placeholder="Parola" name="Password"></asp:TextBox>

			</div>
		</div>
		<div class="form-actions">
            <asp:Button ID="BtnLogin" runat="server" Text="Giriş" type="submit" class="btn blue pull-right" OnClick="BtnLogin_Click"  />
            
			
		</div>
		
		
		
	</form>
	
	
	
</div>
<!-- END LOGIN -->
<!-- BEGIN COPYRIGHT -->
<div class="copyright">
	 2015 CHP Kocaeli İl Yönetim Paneli
</div>
<!-- END COPYRIGHT -->
<!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
<!-- BEGIN CORE PLUGINS -->
<!--[if lt IE 9]>
<script src="theme/assets/global/plugins/respond.min.js"></script>
<script src="theme/assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
<script src="theme/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="theme/assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
<script type="text/javascript" src="theme/assets/global/plugins/select2/select2.min.js"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="theme/assets/global/scripts/metronic.js" type="text/javascript"></script>
<script src="theme/assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
<script src="theme/assets/admin/layout/scripts/demo.js" type="text/javascript"></script>
<script src="theme/assets/admin/pages/scripts/login-soft.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->
<script>
    jQuery(document).ready(function () {
        Metronic.init(); // init metronic core components
        Layout.init(); // init current layout
        Login.init();
        Demo.init();
        // init background slide images
        $.backstretch([
         "theme/assets/admin/pages/media/bg/ata.jpg",
        // "theme/assets/admin/pages/media/bg/ata2.jpg"
        ], {
            fade: 1000,
            duration: 8000
        }
     );
    });
</script>
<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
