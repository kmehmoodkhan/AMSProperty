<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports-Comments.aspx.cs" Inherits="AMSProjectNew.Clients.Reports_Comments" %>

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
			    <legend class="">Step 3: Comments</legend>
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
			    <br />
			    <div class="form-group">
					<label class="col-xs-12 m-label" for="">Property Description:</label>
				</div>
				<div class="form-group">
					<label class="col-xs-12 m-label" for="">Please provide a description of your property taking into consideration
							internal layout and condition followed by external improvements and condition.
					</label>
					<div class="col-xs-12 ">
						<textarea  class="txt-area" name="textarea" id="txtTab6Standard" runat="server"></textarea>
					</div>
				</div>
				<div class="form-group">
					<label class="col-xs-12 m-label" for="">Please any information relating to possible defects or faults in the home:</label>
					<p class="col-xs-12 help-block">
						Example: White Ants, Rising Damp, Significant Cracking, Damage, Repairs Required or Outstanding Issues.
					</p>
					<div class="col-xs-12 ">
						<textarea  class="txt-area" name="textarea" id="txtTab6Defects" runat="server"></textarea>
					</div>
				</div>
				<div class="form-group col-xs-12 text-center">
				    <asp:Button ID="btnTab6Back" runat="server" Text="Back" OnClick="btnTab6Back_Click"
					CssClass="btn btn-lg btn-danger"  />
					<asp:Button ID="btnTab6Next" runat="server" Text="Finish" OnClick="btnTab6Next_Click"
					CssClass="btn btn-lg btn-danger" OnClientClick="return CheckTab6Validation();" />
				</div>
			</form>
		</div>
	</div><!--form area end here-->
</div>
<script type="text/javascript">
    function CheckTab6Validation() {
        var Msg = "";
        
        if (document.getElementById("<%=txtTab6Standard.ClientID %>").value == "")
            Msg += "Property Description\n";
        if (document.getElementById("<%=txtTab6Defects.ClientID %>").value == "")
            Msg += "Property Defects or Faults\n";
        
        
        if (Msg != "") {
            Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
            alert(Msg);
            return false;
        }
    }
</script>
</body>
</html>
