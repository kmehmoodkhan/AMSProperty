<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports-Finish.aspx.cs" Inherits="AMSProjectNew.Clients.Reports_Finish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Job Details</title>
    <link rel="icon" href="img/favicon.png" />
	<link rel="stylesheet" href="css/bootstrap.css" />
	<link rel="stylesheet" href="css/style.css" />
	<link rel="stylesheet" href="css/responsive.css" />
	<script src="js/jquery.min.js" ></script>
	<script src="js/bootstrap.min.js"></script>
	<script src="js/modernizr.custom.86080.js"></script>
</head>
<body>
    <%--<form id="form1" runat="server">--%>
    <div class="container">
	<div class="navbar navbar-custom mynavbar" id="nav">
		<div class="container">
		  <div class="navbar-header">
			<asp:Label ID="lblCompanyLogo" runat="server"></asp:Label>
		  </div>
		</div><!--/.container -->
	</div><!--/.navbar -->
	<div class="hr"></div>
	<div class="form-area col-xs-12">
		<div class="forms col-md-12 form-horizontal">
			<form class="form1" id="form1" runat="server">
			    <legend class="">You are done!</legend>
			    <table cellpadding="0" cellspacing="0" style="line-height:30px;border-bottom:solid 1px white;" width="100%">
			        <tr>
			            <td width="10%">Job ID:</td>
			            <td><asp:Label ID="lblJobId" runat="server"></asp:Label></td>
			        </tr>
			        <tr>
			            <td>Client:</td>
			            <td><asp:Label ID="lblClientName" runat="server"></asp:Label></td>
			        </tr>
			        <tr>
			            <td>Address:</td>
			            <td><asp:Label ID="lblAddress" runat="server"></asp:Label></td>
			        </tr>
			    </table>
				<br /><br /><br />
			    <legend class=""><asp:Label ID="lblMessage" runat="server">Thank you to submit your property details. We will review it and contact you for further details.</asp:Label></legend>
			    <br />
			    <br />
			</form>
		</div>
	</div><!--form area end here-->
</div>
</body>
</html>
