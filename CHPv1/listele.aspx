<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listele.aspx.cs" Inherits="CHPv1.listele" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <!-- BEGIN HEAD -->
<meta charset="utf-8">
<title>Chp Kocaeli İl Yönetim Paneli</title>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css">
<link href="theme/assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
<link href="theme/assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css">
<link href="theme/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css">
<link href="theme/assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css">
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
<link href="theme/assets/global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css">
<link href="theme/assets/global/plugins/morris/morris.css" rel="stylesheet" type="text/css">
<!-- END PAGE LEVEL PLUGIN STYLES -->
<!-- BEGIN PAGE STYLES -->
<link href="theme/assets/admin/pages/css/tasks.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE STYLES -->
<!-- BEGIN THEME STYLES -->
<!-- DOC: To use 'rounded corners' style just load 'components-rounded.css' stylesheet instead of 'components.css' in the below style tag -->
<link href="theme/assets/global/css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css">
<link href="theme/assets/global/css/plugins.css" rel="stylesheet" type="text/css">
<link href="theme/assets/admin/layout3/css/layout.css" rel="stylesheet" type="text/css">
<link href="theme/assets/admin/layout3/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color">
<link href="theme/assets/admin/layout3/css/custom.css" rel="stylesheet" type="text/css">
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="theme/assets/admin/layout/img/chp-icon.ico">
<!-- END HEAD -->
</head>
<body style="min-height:100%">
    

    <div class="page-header">
	<!-- BEGIN HEADER TOP -->
	<div class="page-header-top">
		<div class="container">
			<!-- BEGIN LOGO -->
			<div class="page-logo">
				<a href="main.aspx"><img src="theme/assets/admin/layout3/img/chp_logo_2.png" alt="logo" class="logo-default"></a>
			</div>
			<!-- END LOGO -->
			<!-- BEGIN RESPONSIVE MENU TOGGLER -->
			<a href="javascript:;" class="menu-toggler"></a>
			<!-- END RESPONSIVE MENU TOGGLER -->
			<!-- BEGIN TOP NAVIGATION MENU -->
			<div class="top-menu">
				<ul class="nav navbar-nav pull-right">
                    <li class="dropdown dropdown-user dropdown-dark">
						<a href="cikis.aspx">
								<i class="icon-key"></i> Çıkış </a>
                        </li>
						
                </ul>
			</div>
			
		</div>
	</div>
	<!-- END HEADER TOP -->
	<!-- BEGIN HEADER MENU -->
	<div class="page-header-menu">
		<div class="container">
			<!-- BEGIN HEADER SEARCH BOX -->
			<form class="search-form" action="extra_search.html" method="GET">
				<div class="input-group">
					<input type="text" class="form-control" placeholder="Arama" name="query">
					<span class="input-group-btn">
					<a href="javascript:;" class="btn submit"><i class="icon-magnifier"></i></a>
					</span>
				</div>
			</form>
			<!-- END HEADER SEARCH BOX -->
			<!-- BEGIN MEGA MENU -->
			<!-- DOC: Apply "hor-menu-light" class after the "hor-menu" class below to have a horizontal menu with white background -->
			<!-- DOC: Remove data-hover="dropdown" and data-close-others="true" attributes below to disable the dropdown opening on mouse hover -->
			<div class="hor-menu ">
				<ul class="nav navbar-nav">
					<li class="menu-dropdown">
						<a href="main.aspx">Anasayfa</a>
					</li>
                    <li class="menu-dropdown">
						<a href="listele.aspx">Listele</a>
					</li> 
                </ul>
			</div>
			<!-- END MEGA MENU -->
		</div>
	</div>
	<!-- END HEADER MENU -->
<!-- BEGIN PAGE CONTAINER -->
<div class="page-container">
    <div class="page-head">
		<div class="container">
			<!-- BEGIN PAGE TITLE -->
			<div class="page-title">
				<h1>Listele <small>Sandıklar & Kişiler</small></h1>
			</div>
			<!-- END PAGE TITLE -->
        </div>
    </div>
    <div class="page-content">
		<div class="container">
			<!-- BEGIN PAGE BREADCRUMB -->
			<ul class="page-breadcrumb breadcrumb">
				<li>
					<a href="main.aspx">Anasayfa</a><i class="fa fa-circle"></i>
				</li>
				<li class="active">
					 Listele
				</li>
			</ul>
			<!-- END PAGE BREADCRUMB -->

            <form id="form1" runat="server">
                <div class="row margin-bottom-20">
                    <div class="form-group">
                        <label class="col-md-1 control-label">İlçe</label>
                        <div class="col-md-3">
                            <asp:DropDownList class="form-control" ID="ddlIlce" runat="server" AutoPostBack="True">
                                <asp:ListItem Selected="True" Text="Seçiniz..." Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-md-1 control-label">Mahalle</label>
                        <div class="col-md-3">
                            <asp:DropDownList class="form-control" ID="ddlMah" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMah_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Text="Seçiniz..." Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-md-1 control-label">Sandık</label>
                        <div class="col-md-3">
                            <asp:DropDownList class="form-control" ID="ddlSandikNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSandikNo_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Text="Seçiniz..." Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    
                </div>
                <asp:Panel ID="pnl_update" runat="server">
                    <div class="row">
                        <div class="col-md-12">


                            <div class="portlet light bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-equalizer font-blue-hoki"></i>
                                        <span class="caption-subject font-blue-hoki bold uppercase">Seçmen Güncelle</span>
                                        <span class="caption-helper">seçmen formu..</span>
                                    </div>
                                    <div class="tools">
                                        <a href="" class="collapse"></a>
                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <a href="" class="reload"></a>
                                        <a href="" class="remove"></a>
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">
                                        <h3 class="form-section">Seçmen Detayları</h3>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Adı:</label>
                                                    <asp:Label ID="lbl_name" runat="server" Text="Label"></asp:Label>

                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Soyadı:</label>
                                                    <asp:Label ID="lbl_lname" runat="server" Text="Label"></asp:Label>

                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Parti</label>
                                                    <asp:DropDownList class="form-control" ID="ddl_parti" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Cep</label>
                                                    <asp:TextBox ID="txtCep" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->

                                        <div class="row">
                                            <div class="col-md-12 ">
                                                <div class="form-group">
                                                    <label class="control-label">Açıklama</label>
                                                    <asp:TextBox class="form-control" ID="txt_info" TextMode="multiline" Columns="50" Rows="2" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions right">
                                        <button type="button" class="btn default">Cancel</button>
                                        <asp:Button class="btn default" ID="btn_update" runat="server" Text="Kaydet" OnClick="btn_update_Click" />
                                    </div>

                                    <!-- END FORM-->
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet light bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-equalizer font-blue-hoki"></i>
                                        <span class="caption-subject font-blue-hoki bold uppercase">Seçmen Tablosu</span>
                                        <span class="caption-helper">seçmen ler..</span>
                                    </div>
                                    
                                    <div class="tools">
                                        <asp:Button ID="Button1" runat="server" class="btn green" Text="Excel" OnClick="Button1_Click" />
                                        <a href="" class="collapse"></a>
                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <a href="" class="reload"></a>
                                        <a href="" class="remove"></a>
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">
                <div class="dataTables_wrapper no-footer">
                    <asp:GridView ID="grdPeople" runat="server" AllowPaging="True" CssClass="table table-striped table-hover table-bordered dataTable no-footer" EnableSortingAndPagingCallbacks="False" AutoGenerateSelectButton="True" DataKeyNames="id" EnableTheming="True" OnPageIndexChanging="grdPeople_PageIndexChanging" OnSelectedIndexChanged="grdPeople_SelectedIndexChanged" >
                        <PagerStyle  CssClass="DDFooter"/>
                        <PagerSettings
                            Mode="NumericFirstLast"
                            PageButtonCount="5"
                        />
                     </asp:GridView>
                </div>
                                        </div>
                            </div>
            </form>


        </div>
    </div>
</div>


        <div class="page-footer">
	<div class="container">
		 2015 &copy; Chp Kocaeli İl Yönetim Başkanlığı. Tüm Hakları Saklıdır.
	</div>
            </div>
	

<div class="scroll-to-top">
	<i class="icon-arrow-up"></i>
</div>
<!-- END FOOTER -->
<!-- BEGIN JAVASCRIPTS (Load javascripts at bottom, this will reduce page load time) -->
<!-- BEGIN CORE PLUGINS -->
<!--[if lt IE 9]>
<script src="theme/assets/global/plugins/respond.min.js"></script>
<script src="theme/assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
<script src="theme/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
<!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
<script src="theme/assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="theme/assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript"></script>
<!-- IMPORTANT! fullcalendar depends on jquery-ui-1.10.3.custom.min.js for drag & drop support -->
<script src="theme/assets/global/plugins/morris/morris.min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/morris/raphael-min.js" type="text/javascript"></script>
<script src="theme/assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="theme/assets/global/scripts/metronic.js" type="text/javascript"></script>
<script src="theme/assets/admin/layout3/scripts/layout.js" type="text/javascript"></script>
<script src="theme/assets/admin/layout3/scripts/demo.js" type="text/javascript"></script>
<script src="theme/assets/admin/pages/scripts/index3.js" type="text/javascript"></script>
<script src="theme/assets/admin/pages/scripts/tasks.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->
<script>
    jQuery(document).ready(function () {
        Metronic.init(); // init metronic core componets
        Layout.init(); // init layout
        Demo.init(); // init demo(theme settings page)
        Index.init(); // init index page
        Tasks.initDashboardWidget(); // init tash dashboard widget
    });
</script>
<!-- END JAVASCRIPTS -->
</div>
</body>
</html>
