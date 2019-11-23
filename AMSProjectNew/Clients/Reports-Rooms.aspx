<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports-Rooms.aspx.cs" Inherits="AMSProjectNew.Clients.Reports_Rooms" %>

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
			    <legend class="">Step 2: Rooms & Fixtures</legend>
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
					<label class="col-md-12" for="">Please tick the appropriate box to best describe the floor layout of your home ensuring
					that you include all rooms in the house an only allocate each room once on the list below:</label>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchen" runat="server" value="Kitchen">Kitchen </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchenMealsFamily" runat="server" value="Kitchen/Meals/Family">Kitchen/Meals/Family </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchenette" runat="server" value="Kitchenette">Kitchenette </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchenMeals" runat="server" value="Kitchen/Meals">Kitchen/Meals </label>
					</div>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkLounge" runat="server" value="Lounge">Lounge</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkLoungeDinning" runat="server" value="Lounge/Dining">Lounge/Dining </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFamilyRoom" runat="server" value="Family Room">Family Room</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDinning" runat="server" value="Dining">Dining </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkLivingRoom" runat="server" value="Living Room">Living Room </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkRumpus" runat="server" value="Rumpus">Rumpus </label>
					</div>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkCellar" runat="server" value="Cellar">Cellar</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkStudy" runat="server" value="Study">Study </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkUtility" runat="server" value="Utility">Utility</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSunroom" runat="server" value="Sunroom">Sunroom </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkStoreRoom" runat="server" value="Storeroom">Store Room </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkStudio" runat="server" value="Studio">Studio </label>
					</div>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkEntryHall" runat="server" value="Entry Hall">Entry Hall</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkHallway" runat="server" value="Hallway">Hallway </label>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkBedroom" runat="server" value="Bedroom(s)">Bedroom(s)</label>
						<asp:DropDownList ID="ddlTab4Bedroom" runat="server" CssClass="s-btn1" Width="100px">
                            <asp:ListItem Value="0" Text="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        </asp:DropDownList>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkBathroom" runat="server" value="Bathroom(s)">Bathroom(s)</label>
						<asp:DropDownList ID="ddlTab4Bathroom" runat="server" CssClass="s-btn1" Width="100px">
                            <asp:ListItem Value="0" Text="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        </asp:DropDownList>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkEnsuite" runat="server" value="Ensuite(s)">Ensuite(s)</label>
						<asp:DropDownList ID="ddlTab4Ensuite" runat="server" CssClass="s-btn1" Width="100px">
                            <asp:ListItem Value="0" Text="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        </asp:DropDownList>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkToilet" runat="server" value="Toilet(s)">Toilet(s)</label>
						<asp:DropDownList ID="ddlTab4Toilet" runat="server" CssClass="s-btn1" Width="100px">
                            <asp:ListItem Value="0" Text="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        </asp:DropDownList>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkLaundry" runat="server" value="Laundry">Laundry</label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-xs-12 m-label" for="text-area">For additional rooms not covered above please note below:</label>
					<div class="col-xs-12 ">
						<textarea  class="txt-area" name="textarea" id="Tab4Text1" runat="server" ></textarea>
					</div>
				</div>
				<div class="form-group">
					<label class="col-xs-12 m-label" for="">Heating and Cooling:</label>
				</div>
				<div class="form-group">
					<label class="col-md-12" for="">Please choose the most appropriate style of heating and cooling in your home:</label>
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDuctedReverseCycle" runat="server" value="Ducted Reverse Cycle">Ducted Reverse Cycle</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkWallAirConditioner" runat="server" value="Wall Air Conditioner">Wall Air Conditioner </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkOilHeater" runat="server" value="Oil Heater">Oil Heater</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSplitSystemAirConditioning" runat="server" value="Split System Air Conditioning">Split System Air Conditioning </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkCellingFans" runat="server" value="Ceiling Fans">Celling Fans</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkCombutionHeater" runat="server" value="Combustion Heater">Combution Heater</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkRCWallAirConditioner" runat="server" value="R/C Wall Air Conditioner">R/C Wall Air Conditioner</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDuctedGasHeating" runat="server" value="Ducted Gas Heating">Ducted Gas Heating</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFireplace" runat="server" value="Fireplace">Fireplace</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDuctedEvaporative" runat="server" value="Ducted Evaporative">Ducted Evaporative </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkGasHeater" runat="server" value="Gas Heater">Gas Heater</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkUnderFloorHeating" runat="server" value="Under Floor Heating">Under Floor Heating</label>
					</div>
				</div>
				
				<div class="form-group col-xs-12 text-center">
					<asp:Button ID="btnTab4Back" runat="server" CssClass="btn btn-lg btn-danger" Text="Back" onclick="btnTab4Back_Click"></asp:Button>
                    <asp:Button ID="btnTab4Next" runat="server" CssClass="btn btn-lg btn-danger" Text="Save & Continue" onclick="btnTab4Next_Click"></asp:Button>
				</div>
			</form>
		</div>
	</div><!--form area end here-->
</div>
    <%--</form>--%>
</body>
</html>
