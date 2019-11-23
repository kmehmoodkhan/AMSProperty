<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buildings.aspx.cs" Inherits="AMSProjectNew.Clients.Buildings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
			<img class="img-responsive" src="img/logo.png">
		  </div>
		</div><!--/.container -->
	</div><!--/.navbar -->
	<div class="hr"></div>
	<div class="form-area col-xs-12">
		<div class="forms col-md-12 form-horizontal">
			<form class="form1" id="form1" runat="server">
			    <legend class="">Step 1: Building & Improvements</legend>
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
			    <legend class="">Please answer the following questions with the nearest possible answer available?</legend>
				<div class="form-group">
				  <label for="" class="col-sm-5 ">Approximately what year was your home built?</label>
				  <div class="col-sm-7">
					 <input type="text" class="form-control"  placeholder="Year Built" runat="server" id="txtTab3YearBuilt">
				  </div>
			   </div>
				<div class="form-group  ">
					<label for="" class="col-sm-5 ">What material are the external walls constructed of?</label>
					<div class="col-sm-7">
					<asp:DropDownList ID="ddlTab3ExternalWalls" runat="server" CssClass="s-btn1" Width="250px">
                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Brick" Text="Brick"></asp:ListItem>
                        <asp:ListItem Value="Brick Veneer" Text="Brick Veneer"></asp:ListItem>
                        <asp:ListItem Value="Brick and Rendered" Text="Brick and Rendered"></asp:ListItem>
                        <asp:ListItem Value="Brick with Stone Facade" Text="Brick with Stone Facade"></asp:ListItem>
                        <asp:ListItem Value="Brick and Stone" Text="Brick and Stone"></asp:ListItem>
                        <asp:ListItem Value="Brick and Timber" Text="Brick and Timber"></asp:ListItem>
                        <asp:ListItem Value="Brick & Weatherboard" Text="Brick & Weatherboard"></asp:ListItem>
                        <asp:ListItem Value="Bluestone" Text="Bluestone"></asp:ListItem>
                        <asp:ListItem Value="Concrete Block" Text="Concrete Block"></asp:ListItem>                                                        
                        <asp:ListItem Value="Hardiboard" Text="Hardiboard"></asp:ListItem>
                        <asp:ListItem Value="Iron Clad" Text="Iron Clad"></asp:ListItem>
                        <asp:ListItem Value="Log" Text="Log"></asp:ListItem>
                        <asp:ListItem Value="Mount Gambier Stone" Text="Mount Gambier Stone"></asp:ListItem>
                        <asp:ListItem Value="Painted Stone" Text="Painted Stone"></asp:ListItem>
                        <asp:ListItem Value="Rendered" Text="Rendered"></asp:ListItem>
                        <asp:ListItem Value="Rendered Brick" Text="Rendered Brick"></asp:ListItem>
                        <asp:ListItem Value="Rendered Board" Text="Rendered Board"></asp:ListItem>
                        <asp:ListItem Value="Rendered Stone" Text="Rendered Stone"></asp:ListItem>
                        <asp:ListItem Value="Sandstone" Text="Sandstone"></asp:ListItem>
                        <asp:ListItem Value="Solid Brick" Text="Solid Brick"></asp:ListItem>
                        <asp:ListItem Value="Timber Clad" Text="Timber Clad"></asp:ListItem>
                        <asp:ListItem Value="Weatherboard" Text="Weatherboard"></asp:ListItem>
                    </asp:DropDownList>
				  </div>
				</div>
				<div class="form-group ">
					<label for="" class="col-sm-5 ">What type of roof do you have?</label>
					<div class="col-sm-7">
					 <asp:DropDownList ID="ddltab3Roof" runat="server"  CssClass="s-btn1" Width="250px">
                            <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Tiled" Text="Tiled"></asp:ListItem>
                            <asp:ListItem Value="Colorbond" Text="Colorbond"></asp:ListItem>
                            <asp:ListItem Value="Galvanised Iron" Text="Galvanised Iron"></asp:ListItem>
                            <asp:ListItem Value="Imitation Tiled" Text="Imitation Tiled"></asp:ListItem>
                            <asp:ListItem Value="Iron" Text="Iron"></asp:ListItem>
                            <asp:ListItem Value="Terracotta Tiled" Text="Terracotta Tiled"></asp:ListItem>
                            <asp:ListItem Value="Steel" Text="Steel"></asp:ListItem>
                            <asp:ListItem Value="Shingles" Text="Shingles"></asp:ListItem>
                        </asp:DropDownList>
				  </div>
				</div>
				<div class="form-group   ">
					<label for="" class="col-sm-5 ">What are the internal walls made of?</label>
					<div class="col-sm-7">
					 <asp:DropDownList ID="ddlTab3InteriorLinings" runat="server" CssClass="s-btn1" Width="250px">
                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Plaster" Text="Plaster"></asp:ListItem>
                        <asp:ListItem Value="Plasterboard" Text="Plasterboard"></asp:ListItem>
                        <asp:ListItem Value="Feature Brick" Text="Feature Brick"></asp:ListItem>
                        <asp:ListItem Value="Brick" Text="Brick"></asp:ListItem>
                        <asp:ListItem Value="Concrete Block" Text="Concrete Block"></asp:ListItem>
                        <asp:ListItem Value="Timber Panel" Text="Timber Panel"></asp:ListItem>
                    </asp:DropDownList>
				  </div>
				</div>
				<div class="form-group  ">
					<label for="" class="col-sm-5 ">What are the window frames made of?</label>
					<div class="col-sm-7">
					 <asp:DropDownList ID="ddlTab3WindowFrames" runat="server" CssClass="s-btn1" Width="250px">
                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Timber" Text="Timber"></asp:ListItem>
                        <asp:ListItem Value="Aluminium" Text="Aluminium"></asp:ListItem>
                        <asp:ListItem Value="Steel" Text="Steel"></asp:ListItem>
                        <asp:ListItem Value="Iron" Text="Iron"></asp:ListItem>
                    </asp:DropDownList>
				  </div>
				</div>
				<div class="form-group ">
					<label for="" class="col-sm-5 ">Does your home have a timber of concrete floor?</label>
					
					<div class="col-sm-7">
					 <asp:DropDownList ID="ddlTab3MainFlooring" runat="server" CssClass="s-btn1" Width="250px">
                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Timber" Text="Timber"></asp:ListItem>
                        <asp:ListItem Value="Concrete" Text="Concrete"></asp:ListItem>
                        <asp:ListItem Value="Concrete & Timber" Text="Concrete & Timber"></asp:ListItem>
                    </asp:DropDownList>
				  </div>
				  <p class="col-xs-12 help-block">Homes built prior to 1985 tend to have timber floors<br> Homes built after 1985 are most
				  likely on a concrete slab.<br> Two storey townhouse built in recent years may have a concrete slab ground floor
				  with timber 1st floor.<br> Apartments generally have a concrete slab on every floor.</p>
				</div>
				<!-- page2 -->
				<legend class="">Please choose the most appropriate condition to represent your home</legend>
				<div class="form-group">
				  <label for="" class="col-sm-5 ">Internal Condition Overall</label>
				  <div class="col-sm-7">
					 <asp:DropDownList ID="ddlTab3InternalCondition" runat="server" CssClass="s-btn1" Width="250px">
                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Poor Condition – In Need of Major Upgrading." Text="Poor Condition – In Need of Major Upgrading."></asp:ListItem>
                        <asp:ListItem Value="Fair Condition – Would Benefit from General Upgrading." Text="Fair Condition – Would Benefit from General Upgrading."></asp:ListItem>
                        <asp:ListItem Value="Fair Condition – Dated & Tired." Text="Fair Condition – Dated & Tired."></asp:ListItem>
                        <asp:ListItem Value="Average Condition – Typical For Age and Style of Property." Text="Average Condition – Typical For Age and Style of Property."></asp:ListItem>
                        <asp:ListItem Value="Average Condition – Original Fitout with Partial Upgrades." Text="Average Condition – Original Fitout with Partial Upgrades."></asp:ListItem>
                        <asp:ListItem Value="Average Condition – Upgraded Fitout." Text="Average Condition – Upgraded Fitout."></asp:ListItem>
                        <asp:ListItem Value="Good Condition – Well Maintained." Text="Good Condition – Well Maintained."></asp:ListItem>
                        <asp:ListItem Value="Good Condition – Original Fitout with Partial Upgrades." Text="Good Condition – Original Fitout with Partial Upgrades."></asp:ListItem>
                        <asp:ListItem Value="Good Condition – Upgraded Fitout." Text="Good Condition – Upgraded Fitout."></asp:ListItem>
                        <asp:ListItem Value="Good Condition – Refurbished Throughout." Text="Good Condition – Refurbished Throughout."></asp:ListItem>
                        <asp:ListItem Value="High Quality Condition." Text="High Quality Condition."></asp:ListItem>
                        <asp:ListItem Value="New Fitout." Text="New Fitout."></asp:ListItem>
                        <asp:ListItem Value="Assumed Fair at Date of Valuation." Text="Assumed Fair at Date of Valuation."></asp:ListItem>
                        <asp:ListItem Value="Assumed Average at Date of Valuation." Text="Assumed Average at Date of Valuation."></asp:ListItem>
                        <asp:ListItem Value="Assumed Good at Date of Valuation." Text="Assumed Good at Date of Valuation."></asp:ListItem>
                        <asp:ListItem Value="Poor - Original Fixtures & Fittings Throughout" Text="Poor - Original Fixtures & Fittings Throughout"></asp:ListItem>
                        <asp:ListItem Value="Fair - Original Fixtures & Fittings Throughout" Text="Fair - Original Fixtures & Fittings Throughout"></asp:ListItem>
                        <asp:ListItem Value="Average - Original Fixtures & Fittings Throughout" Text="Average - Original Fixtures & Fittings Throughout"></asp:ListItem>
                        <asp:ListItem Value="Good - Original Fixtures & Fittings Throughout" Text="Good - Original Fixtures & Fittings Throughout"></asp:ListItem>
                    </asp:DropDownList>
				  </div>
				  <p class="col-xs-12 help-block">Take into consideration the overall age and condition of the kitchen, bathroom,
						laundry fit-out, floor coverings, paintwork, light fittings and window treatments</p>
			   </div>
				<div class="form-group  ">
					<label for="" class="col-sm-5 ">External Condition Overall</label>
					<div class="col-sm-7">
					 <asp:DropDownList ID="ddlTab3ExternalCondition" runat="server" CssClass="s-btn1" Width="250px">
                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Poor Condition – In Need of Major Upgrading." Text="Poor Condition – In Need of Major Upgrading."></asp:ListItem>
                        <asp:ListItem Value="Fair Condition – In Need of General Maintenance." Text="Fair Condition – In Need of General Maintenance."></asp:ListItem>
                        <asp:ListItem Value="Fair Condition – Dated and Tired." Text="Fair Condition – Dated and Tired."></asp:ListItem>
                        <asp:ListItem Value="Average Condition – Typical For Age and Style of Property." Text="Average Condition – Typical For Age and Style of Property."></asp:ListItem>
                        <asp:ListItem Value="Good Condition – Well Maintained." Text="Good Condition – Well Maintained."></asp:ListItem>
                        <asp:ListItem Value="Good Condition – Above Average in Comparison to Neighbouring Properties.    High Quality Condition." Text="Good Condition – Above Average in Comparison to Neighbouring Properties.    High Quality Condition."></asp:ListItem>
                        <asp:ListItem Value="Assumed Fair at Date of Valuation." Text="Assumed Fair at Date of Valuation."></asp:ListItem>
                        <asp:ListItem Value="Assumed Average at Date of Valuation." Text="Assumed Average at Date of Valuation."></asp:ListItem>
                        <asp:ListItem Value="Assumed Good at Date of Valuation." Text="Assumed Good at Date of Valuation."></asp:ListItem>                        
                    </asp:DropDownList>
				  </div>
				  <p class="col-xs-12 help-block">Take into consideration the condition of the grounds and gardens, fencing, external paintwork, guttering, shedding, pergolas and pools.</p>
				</div>
				<div class="form-group ">
					<label for="" class="col-sm-5 ">How does your property present from the street?</label>
					<div class="col-sm-7">
					 <asp:DropDownList ID="ddlTab3StreetAppeal" runat="server" CssClass="s-btn1" Width="250px">
                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Typical For Age and Style of Home" Text="Typical For Age and Style of Home"></asp:ListItem>
                        <asp:ListItem Value="Maintained to a Poor Standard" Text="Maintained to a Poor Standard"></asp:ListItem>
                        <asp:ListItem Value="Maintained to a Fair Standard" Text="Maintained to a Fair Standard"></asp:ListItem>
                        <asp:ListItem Value="Maintained to an Average Standard" Text="Maintained to an Average Standard"></asp:ListItem>
                        <asp:ListItem Value="Maintained to a Good Standard" Text="Maintained to a Good Standard"></asp:ListItem>
                        <asp:ListItem Value="Maintained to a High Standard" Text="Maintained to a High Standard"></asp:ListItem>
                        <asp:ListItem Value="Appears Neglected" Text="Appears Neglected"></asp:ListItem>
                        <asp:ListItem Value="In Need of General Repairs" Text="In Need of General Repairs"></asp:ListItem>
                    </asp:DropDownList>
				  </div>
				</div>
				<!-- page3 -->
				<legend class="">Additional Buildings, Landscaping and Other Structures on the Property.</legend>
				<div class="form-group">
					<label class="col-md-12" for="">Please tick the appropriate boxes:</label>
				</div>
				<!-- --------------------------------------- -->
				<div class="form-group">
					<label class="col-md-3 m-label" for="Checkboxes">Pergola/Verandah:</label>
					<div class="col-md-9 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPVGable" runat="server" value="" >Gable Roof Pergola</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPVTimber" runat="server" value="">Timber Verandah</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPVOutdoor" runat="server" value="">Outdoor Kitchen</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPVFlat" runat="server" value="">Flat Roof Pergola</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPVGazebo" runat="server" value="">Gazebo</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPVBuilt" runat="server" value="">Built In BBQ Area</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPVIron" runat="server" value="">Iron verandah</label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-md-3 m-label" for="Checkboxes">Shedding:</label>
					<div class="col-md-9 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHSingleIron" runat="server" value="" >Single Iron Garage</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHSingleGarage" runat="server" value="">Single Garage</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHShedding" runat="server" value="">Shedding</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHDoubleIron" runat="server" value="">Double Iron Garage</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHDoubleGarage" runat="server" value="">Double Garage</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHGarden" runat="server" value="">Garden Shed</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHTripleIron" runat="server" value="">Tripple Iron Garage</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHTripleGarage" runat="server" value="">Tripple Garage</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSHTool" runat="server" value="">Tool Shed</label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-md-3 m-label" for="Checkboxes">Pools:</label>
					<div class="col-md-9 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPInground" runat="server" value="" >Inground Pool</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPOutDoor" runat="server" value="">Out Door Spa</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPPool" runat="server" value="">Pool Fencing</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPAbove" runat="server" value="">Above Ground Pool</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkPIndoor" runat="server" value="">Indoor Inground Pool</label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-md-3 m-label" for="Checkboxes">Gardens:</label>
					<div class="col-md-9 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkGBasic" runat="server" value="" >Basic Garages</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkGEstablished" runat="server" value="">Established Gardens</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkGLandscaped" runat="server" value="">Landscaped Gardens</label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-md-3 m-label " for="Checkboxes">Fencing:</label>
					<div class="col-md-9 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFIron" runat="server" value="" >Iron Fencing</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFBasic" runat="server" value="">Basic Fencing</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFAutomatic" runat="server" value="">Automatic-Gate</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFTimber" runat="server" value="">Timber Fencing</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFSecurity" runat="server" value="">Security Entrance</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFCourtyard" runat="server" value="">Courtyard Fencing</label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-md-3 m-label" for="Checkboxes">Driveway & Paving:</label>
					<div class="col-md-9 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPConcreteDriveway" runat="server" value="">Concrete Driveway </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPConcretePaving" runat="server" value="">Concrete Paving </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPTimber" runat="server" value="">Timber Decking </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPBrickDriveway" runat="server" value="">Brick Driveway </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPBrickPaving" runat="server" value="">Brick Paving </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPGravelPaving" runat="server" value="">Gravel Paving </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPGravelDriveway" runat="server" value="">Gravel Driveway </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDPStonePaving" runat="server" value="">Stone Paving </label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label>
					<div class="col-md-9 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkOOutbuilding" runat="server" value="">Outbuilding </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkOStore" runat="server" value="">Store Room </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkOStudio" runat="server" value="">Studio </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkOSelf" runat="server" value="">Self-Contained Flat </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkOBunglow" runat="server" value="">Bungalow </label>
					</div>
				</div>
				<div class="form-group">
					<label class="col-xs-12 m-label" for="text-area">For additional information please describe below:</label>
					<div class="col-xs-12 ">
						<textarea  class="txt-area" name="textarea" runat="server" id="txtTab3AncillaryImprovements" ></textarea>
					</div>
				</div>
				<div class="form-group">
					<label class="col-md-12" for="">Please tick the appropriate box to best describe the floor layout of your home ensuring
					that you include all rooms in the house an only allocate each room once on the list below:</label>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchen" runat="server" value="">Kitchen </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchenMealsFamily" runat="server" value="">Kitchen/Meals/Family </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchenette" runat="server" value="">Kitchenette </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkKitchenMeals" runat="server" value="">Kitchen/Meals </label>
					</div>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkLounge" runat="server" value="">Lounge</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkLoungeDinning" runat="server" value="">Lounge/Dinning </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFamilyRoom" runat="server" value="">Family Room</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDinning" runat="server" value="">Dinning </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkLivingRoom" runat="server" value="">Living Room </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkRumpus" runat="server" value="">Rumpus </label>
					</div>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkCellar" runat="server" value="">Cellar</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkStudy" runat="server" value="">Study </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkUtility" runat="server" value="">Utility</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSunroom" runat="server" value="">Sunroom </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkStoreRoom" runat="server" value="">Store Room </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkStudio" runat="server" value="">Studio </label>
					</div>
				</div>
				<div class="form-group">
					<!-- <label class="col-md-3 m-label" for="Checkboxes">Outbuildings:</label> -->
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkEntryHall" runat="server" value="">Entry Hall</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkHallway" runat="server" value="">Hallway </label>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-12 ">
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkBedroom" runat="server" value="">Bedroom(s)</label>
						<asp:DropDownList ID="ddlTab4Bedroom" runat="server" CssClass="s-btn">
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
						<input type="checkbox" name="Checkboxes" id="chkBathroom" runat="server" value="">Bathroom(s)</label>
						<asp:DropDownList ID="ddlTab4Bathroom" runat="server" CssClass="s-btn">
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
						<input type="checkbox" name="Checkboxes" id="chkEnsuite" runat="server" value="">Ensuite(s)</label>
						<asp:DropDownList ID="ddlTab4Ensuite" runat="server" CssClass="s-btn">
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
						<input type="checkbox" name="Checkboxes" id="chkToilet" runat="server" value="">Toilet(s)</label>
						<asp:DropDownList ID="ddlTab4Toilet" runat="server" CssClass="s-btn">
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
						<input type="checkbox" name="Checkboxes" id="chkLaundry" runat="server" value="">Laundry</label>
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
						<input type="checkbox" name="Checkboxes" id="chkDuctedReverseCycle" runat="server" value="">Ducted Reverse Cycle</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkWallAirConditioner" runat="server" value="">Wall Air Conditioner </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkOilHeater" runat="server" value="">Oil Heater</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkSplitSystemAirConditioning" runat="server" value="">Split System Air Conditioning </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkCellingFans" runat="server" value="">Celling Fans</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkCombutionHeater" runat="server" value="">Combution Heater</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkRCWallAirConditioner" runat="server" value="">R/C Wall Air Conditioner</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDuctedGasHeating" runat="server" value="">Ducted Gas Heating</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkFireplace" runat="server" value="">Fireplace</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkDuctedEvaporative" runat="server" value="">Ducted Evaporative </label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkGasHeater" runat="server" value="">Gas Heater</label>
						<label class="checkbox-inline" for="">
						<input type="checkbox" name="Checkboxes" id="chkUnderFloorHeating" runat="server" value="">Under Floor Heating</label>
					</div>
				</div>
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
					<button class="btn btn-lg btn-danger">Submit</button>
				</div>
			</form>
		</div>
	</div><!--form area end here-->
</div>
    <%--</form>--%>
</body>
</html>
