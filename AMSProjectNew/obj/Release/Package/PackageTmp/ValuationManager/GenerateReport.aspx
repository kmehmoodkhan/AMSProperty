<%@ Page Title="" EnableEventValidation="false" ValidateRequest="false" ClientIDMode="Static" Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="AMSProjectNew.ValuationManager.GenerateReport" %>

<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .loading {
            font-family: Arial;
            font-size: 12pt;
            border: 5px solid #156aaa;
            padding: 10px 20px;
            width: 300px;
            left: 50%;
            top: 50%;
            height: auto;
            position: fixed;
            background-color: White;
            z-index: 100000000;
            text-align: center;
            margin: -50px 0 0 -150px;
        }

        .divoverlay {
            height: 100%;
            width: 100%;
            position: fixed;
            left: 0;
            top: 0;
            z-index: 1 !important;
            background-color: rgba(0, 0, 0, 0.5);
        }

        .show {
            display: block;
        }

        .hide {
            display: none;
        }

        .headerCssClass {
            background-color: #FAFAFA;
            border: solid 1px #F1F1F1;
            padding: 4px;
            font-size: 12px;
            font-weight: bold;
        }

        .contentCssClass {
            padding: 4px;
        }

        .headerSelectedCss {
            background-color: #E9E9E9;
            border: solid 1px #F1F1F1;
            padding: 4px;
            font-size: 12px;
            font-weight: bold;
        }
    </style>
    <script src="jquery-1.8.2.js"></script>
    <script src="jquery.MultiFile.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showLoader() {
            $("#ctl00_ContentPlaceHolder1_dvoverlay").show();
            $("#ctl00_ContentPlaceHolder1_dvload").show();
        }
    </script>
    <div style="display: none;">
        <asp:Label ID="lblPropertyAddress" runat="server"></asp:Label>
        <asp:Label ID="lblJobId" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyAddress" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyPhone" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyLogo" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyUrl" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyTermsandCondition" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblCompanyCertificationQualification" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblCompanyFamilyLawCertification" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblValuerName" runat="server"></asp:Label>
        <asp:Label ID="lblValuersAddress" runat="server"></asp:Label>
        <asp:Label ID="lblValuersSuburb" runat="server"></asp:Label>
        <asp:Label ID="lblValuersState" runat="server"></asp:Label>
        <asp:Label ID="lblValuersPostcode" runat="server"></asp:Label>
        <asp:Label ID="lblValuersPhone1" runat="server"></asp:Label>
        <asp:Label ID="lblValuersTitle" runat="server"></asp:Label>
        <asp:Label ID="lblValuersQualifications" runat="server"></asp:Label>
        <asp:Label ID="lblValuersExperience" runat="server"></asp:Label>
        <asp:Label ID="lblValuersMembershipStatus" runat="server"></asp:Label>
        <asp:Label ID="lblValuersMembershipBody" runat="server"></asp:Label>
        <asp:Label ID="lblValuersSignature" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyHeaderImage" runat="server"></asp:Label>
        <asp:Label ID="lblCompanyFooterImage" runat="server"></asp:Label>
    </div>
    <div id="dvoverlay" class="divoverlay" runat="server" style="display: none"></div>
    <div id="dvload" class="loading" runat="server" style="display: none">
        Final Report Now Being Generated - Please Wait...<br />
        <br />
        <img src="../Images/bx-loader.gif" alt="Loading..." />
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" class="bootstrap-iso">
        <tr>
            <td class="LeftTitle" align="left" style="height: 35px;"><i>Generate Report #
                <asp:Label ID="lblJobId1" runat="server"></asp:Label></i></td>
        </tr>
        <tr>
            <td class="LeftTitle" align="left" style="font-size: 12px; height: 15px; font-weight: normal;">Address:
                <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="LeftTitle" align="left" style="font-size: 12px; height: 25px; font-weight: normal;">Client:
                <asp:Label ID="lblClient" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" width="100px" runat="server" id="tdTab1Summary">
                            <asp:LinkButton ID="lbtnTab1Summary" runat="server" Text="1. Summary" OnClick="lbtnTab1Summary_Click"></asp:LinkButton></td>
                        <td align="center" width="80px" runat="server" id="tdTab2Land">
                            <asp:LinkButton ID="lbtnTab2Land" runat="server" Text="2. Land" OnClick="lbtnTab2Land_Click"></asp:LinkButton></td>
                        <td align="center" width="210px" runat="server" id="tdTab3BuildingImprovements">
                            <asp:LinkButton ID="lbtnTab3BuildingImprovements" runat="server" Text="3. Building & Improvements" OnClick="lbtnTab3BuildingImprovements_Click"></asp:LinkButton></td>
                        <td align="center" width="160px" runat="server" id="tdTab4RoomsFixtures">
                            <asp:LinkButton ID="lbtnTab4RoomsFixtures" runat="server" Text="4. Rooms & Fixtures" OnClick="lbtnTab4RoomsFixtures_Click"></asp:LinkButton></td>
                        <td align="center" width="80px" runat="server" id="tdTab5Area">
                            <asp:LinkButton ID="lbtnTab5Area" runat="server" Text="5. Area" OnClick="lbtnTab5Area_Click"></asp:LinkButton></td>
                        <td align="center" width="110px" runat="server" id="tdTab6Comments">
                            <asp:LinkButton ID="lbtnTab6Comments" runat="server" Text="6. Comments" OnClick="lbtnTab6Comments_Click"></asp:LinkButton></td>
                        <td align="center" width="150px" runat="server" id="tdTab7SalesEvidence">
                            <asp:LinkButton ID="lbtnTab7SalesEvidence" runat="server" Text="7. Sales Evidence" OnClick="lbtnTab7SalesEvidence_Click"></asp:LinkButton></td>
                        <td align="center" width="130px" runat="server" id="tdTab8Attachments">
                            <asp:LinkButton ID="lbtnTab8Attachments" runat="server" Text="8. Attachments" OnClick="lbtnTab8Attachments_Click"></asp:LinkButton></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnStatus" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="background: white;" align="center">
                <asp:Label CssClass="Error" ID="lblErrorMessage" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="background: white;">
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab1Summary">
                    <tr>
                        <td><b>TAB 1 – Summary</b></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="Error" ID="lblTab1Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Property Address:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight"></td>
                                </tr>
                                <tr style="display: none;">
                                    <td class="TDLeftNormalText">Unit/Lot:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtUnitLot" runat="server" CssClass="TextBox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Address:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>Street Number:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td>Street Name:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td>Street Type:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtStreetNumber" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtStreetName" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtStreetType" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Suburb:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td>Postcode:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td>State:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtSuburb" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtPostcode" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Value="ACT" Text="ACT" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="NSW" Text="NSW"></asp:ListItem>
                                                        <asp:ListItem Value="NT" Text="NT"></asp:ListItem>
                                                        <asp:ListItem Value="QLD" Text="QLD"></asp:ListItem>
                                                        <asp:ListItem Value="SA" Text="SA"></asp:ListItem>
                                                        <asp:ListItem Value="TAS" Text="TAS"></asp:ListItem>
                                                        <asp:ListItem Value="VIC" Text="VIC"></asp:ListItem>
                                                        <asp:ListItem Value="WA" Text="WA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">
                                        <b>Other Details</b>
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight"></td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Valuation Approach:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:DropDownList ID="ddlValuationApproach" runat="server" CssClass="DDL" Width="210px">
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Purpose:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:DropDownList ID="ddlPurpose" runat="server" CssClass="DDL" Width="210px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlPurpose_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Instructions:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtTab1Instructions" TextMode="MultiLine" Height="80" runat="server" CssClass="TextBox" Width="500px"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Client:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtClient" runat="server" CssClass="TextBox" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Instructed By:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtInstructedBy" runat="server" CssClass="TextBox" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Inspection Date:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtInspectionDate" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                                        <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                                            AlternateText="Click to show calendar" /><br />
                                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="calendarButtonExtender" runat="server"
                                            TargetControlID="txtInspectionDate" PopupButtonID="ImageButton1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Valuations Date:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtValuationsDate" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                                        <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Images/Calendar_scheduleHS.png"
                                            AlternateText="Click to show calendar" /><br />
                                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server"
                                            TargetControlID="txtValuationsDate" PopupButtonID="ImageButton2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Value Component:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:DropDownList ID="ddlValueComponent" runat="server" CssClass="DDL" Width="210px">
                                            <asp:ListItem Text="AS IS" Value="AS IS" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="AS IF COMPLETE" Value="AS IF COMPLETE"></asp:ListItem>
                                            <asp:ListItem Text="ON COMPLETION" Value="ON COMPLETION"></asp:ListItem>
                                            <asp:ListItem Text="RETROSPECTIVE" Value="RETROSPECTIVE"></asp:ListItem>
                                            <asp:ListItem Text="REPLACEMENT COST" Value="REPLACEMENT COST"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">
                                        <b>Price Details</b>
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight"></td>
                                </tr>
                                <tr style="display: none;">
                                    <td class="TDLeftNormalText">Land Value:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtLandValue" runat="server" CssClass="TextBox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td class="TDLeftNormalText">Improvements:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtImprovements" runat="server" CssClass="TextBox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText">Market Value:
                                    </td>
                                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                                    <td class="TDRight">
                                        <asp:TextBox ID="txtMarketValue" runat="server" CssClass="TextBox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button OnClientClick="return CheckTab1Validation();" ID="btnTab1Submit" runat="server" CssClass="Button" Text="Next" OnClick="btnTab1Submit_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab1Validation() {
                                                var Msg = "";

                                                if (document.getElementById("<%=txtStreetNumber.ClientID %>").value == "")
                                                    Msg += "Street number\n";
                                                if (document.getElementById("<%=txtStreetName.ClientID %>").value == "")
                                                    Msg += "Street name\n";
                                                if (document.getElementById("<%=txtStreetType.ClientID %>").value == "")
                                                    Msg += "Street type\n";
                                                if (document.getElementById("<%=txtSuburb.ClientID %>").value == "")
                                                    Msg += "Suburb\n";
                                                if (document.getElementById("<%=txtPostcode.ClientID %>").value == "")
                                                    Msg += "Post code\n";
                                                if (document.getElementById("<%=ddlPurpose.ClientID %>").value == "0" && document.getElementById("<%=txtTab1Instructions.ClientID %>").value == "")
                                                    Msg += "Purpose\n";
                                                if (document.getElementById("<%=txtClient.ClientID %>").value == "")
                                                    Msg += "Client\n";
//                                                if (document.getElementById("<%=txtInspectionDate.ClientID %>").value == "")
//                                                    Msg += "Inspection Date\n";
//                                                if (document.getElementById("<%=txtValuationsDate.ClientID %>").value == "")
                                                //                                                    Msg += "Valuations Date\n";
                                                if (document.getElementById("<%=ddlValueComponent.ClientID %>").value == "0")
                                                    Msg += "Value Component\n";
                                                if (document.getElementById("<%=txtMarketValue.ClientID %>").value == "")
                                                    Msg += "Market Value\n";
                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab2Land">
                    <tr>
                        <td><b>TAB 2 - Land</b></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="Error" ID="lblTab2Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Title Details:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td colspan="2">Property Type:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="ddlTab2PropertyType" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Property Identification:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="ddlTab2PropertyIdentification" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Title Search:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="ddlTab2TitleSearch" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="160px">Lot Number:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>Plan:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtTab2LotNumber" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab2Plan" runat="server" CssClass="DDL" Width="163px"></asp:DropDownList>
                                                    <asp:TextBox Width="150px" Visible="false" ID="txtTab2PlanText" runat="server" CssClass="TextBox" Text="Plan"></asp:TextBox>
                                                    <asp:TextBox Width="150px" ID="txtTab2PlanNumber" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Volume:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>Folio:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtTab2Volume" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtTab2Folio" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Registered Proprietors:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:DropDownList onclick="SetRegisteredProprietorsText();" ID="ddltab2RegisteredProprietors" runat="server" CssClass="DDL" Width="500px">
                                                    </asp:DropDownList>
                                                    <script type="text/javascript">
                                                        function SetRegisteredProprietorsText() {
                                                            if (document.getElementById("<%=ddltab2RegisteredProprietors.ClientID%>").value != "0")
                                                                document.getElementById("<%=txtTab2RegisteredProprietors.ClientID%>").value = document.getElementById("<%=ddltab2RegisteredProprietors.ClientID%>").value;
                                                            else
                                                                document.getElementById("<%=txtTab2RegisteredProprietors.ClientID%>").value = "";
                                                        }
                                                    </script>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:TextBox Width="487px" ID="txtTab2RegisteredProprietors" runat="server" CssClass="TextBox" Text="Refer to Certificate of Title"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Encumbrances:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:DropDownList onclick="SetEncumbrancesText();" ID="ddlTab2Encumbrances" runat="server" CssClass="DDL" Width="500px">
                                                    </asp:DropDownList>
                                                    <script type="text/javascript">
                                                        function SetEncumbrancesText() {
                                                            if (document.getElementById("<%=ddlTab2Encumbrances.ClientID%>").value != "0")
                                                                document.getElementById("<%=txtTab2Encumbrances.ClientID%>").value = document.getElementById("<%=ddlTab2Encumbrances.ClientID%>").value;
                                                            else
                                                                document.getElementById("<%=txtTab2Encumbrances.ClientID%>").value = "";
                                                        }
                                                    </script>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:TextBox Width="487px" ID="txtTab2Encumbrances" runat="server" CssClass="TextBox" Text="Refer to Certificate of Title"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Site Area:&nbsp;</td>
                                                <td>Sqm/Hectares:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtTab2SiteArea" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab2SqmHectares" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Selected="True" Value="Square Metres" Text="Square Metres"></asp:ListItem>
                                                        <asp:ListItem Value="Hectares" Text="Hectares"></asp:ListItem>
                                                        <asp:ListItem Value="Acres" Text="Acres"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Zoning & Planning:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Local Government Area:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="487px" ID="txtTab2LocalGovernmentArea" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Zoning:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="487px" ID="txtTab2Zoning" runat="server" CssClass="TextBox" Text="Residential"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Overlays:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="487px" ID="txtTab2Overlays" runat="server" CssClass="TextBox" Text="None Effecting the Property"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Zoning Effect:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab2ZoningEffect" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Location:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Shops:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>Within&nbsp;</td>
                                                <td>
                                                    <asp:TextBox Width="50px" ID="txtTab2Shops" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp;Kilometres
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Transport:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>Within&nbsp;</td>
                                                <td>
                                                    <asp:TextBox Width="50px" ID="txtTab2Transport" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp;Kilometres
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Schools:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>Within&nbsp;</td>
                                                <td>
                                                    <asp:TextBox Width="50px" ID="txtTab2Schools" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp;Kilometres
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>CBD:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>Approximately &nbsp;</td>
                                                <td>
                                                    <asp:TextBox Width="50px" ID="txtTab2CBD" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp;Kilometres
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Site Description
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&<br />
                                        Topography:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Site Layout:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList onclick="SetSiteLayoutText();" ID="ddlTab2SiteLayout" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                    <script type="text/javascript">
                                                        function SetSiteLayoutText() {
                                                            if (document.getElementById("<%=ddlTab2SiteLayout.ClientID%>").value != "0")
                                                                document.getElementById("<%=txtTab2SiteLayout.ClientID%>").value = document.getElementById("<%=ddlTab2SiteLayout.ClientID%>").value;
                                                            else
                                                                document.getElementById("<%=txtTab2SiteLayout.ClientID%>").value = "";
                                                        }
                                                    </script>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="487px" ID="txtTab2SiteLayout" runat="server" CssClass="TextBox" Text="At Road Level."></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Services:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddltab2Services" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Environmental Hazards:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab2EnvironmentalHazards" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Pest Infestation:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab2PestInfestation" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnTab2Back" runat="server" CssClass="Button" Text="Back" OnClick="btnTab2Back_Click"></asp:Button>
                                                    <asp:Button ID="btnTab2Next" runat="server" CssClass="Button" Text="Next" OnClick="btnTab2Next_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab2Validation() {
                                                var Msg = "";
                                                if (document.getElementById("<%=ddlTab2PropertyType.ClientID %>").value == "0")
                                                    Msg += "Property Type\n";
                                                if (document.getElementById("<%=ddlTab2PropertyIdentification.ClientID %>").value == "0")
                                                    Msg += "Property Identificatio\n";
                                                if (document.getElementById("<%=ddlTab2TitleSearch.ClientID %>").value == "0")
                                                    Msg += "Title Search\n";
                                                if (document.getElementById("<%=txtTab2LotNumber.ClientID %>").value == "")
                                                    Msg += "Lot Number\n";
                                                if (document.getElementById("<%=txtTab2PlanNumber.ClientID %>").value == "")
                                                    Msg += "Plan Number\n";
                                                if (document.getElementById("<%=txtTab2Volume.ClientID %>").value == "")
                                                    Msg += "Volume\n";
                                                if (document.getElementById("<%=txtTab2Folio.ClientID %>").value == "")
                                                    Msg += "Folio\n";
                                                if (document.getElementById("<%=ddltab2RegisteredProprietors.ClientID %>").value == "0" && document.getElementById("<%=txtTab2RegisteredProprietors.ClientID %>").value == "")
                                                    Msg += "Registered Proprietors\n";
                                                if (document.getElementById("<%=ddlTab2Encumbrances.ClientID %>").value == "0" && document.getElementById("<%=txtTab2Encumbrances.ClientID %>").value == "")
                                                    Msg += "Encumbrances\n";
                                                if (document.getElementById("<%=txtTab2LocalGovernmentArea.ClientID %>").value == "")
                                                    Msg += "Local Government Area\n";
                                                if (document.getElementById("<%=txtTab2Zoning.ClientID %>").value == "")
                                                    Msg += "Zoning\n";
                                                if (document.getElementById("<%=ddlTab2ZoningEffect.ClientID %>").value == "0")
                                                    Msg += "Zoning Effect\n";
                                                if (document.getElementById("<%=txtTab2Shops.ClientID %>").value == "")
                                                    Msg += "Shops\n";
                                                if (document.getElementById("<%=txtTab2Transport.ClientID %>").value == "")
                                                    Msg += "Transport\n";
                                                if (document.getElementById("<%=txtTab2Schools.ClientID %>").value == "")
                                                    Msg += "Schools\n";
                                                if (document.getElementById("<%=txtTab2CBD.ClientID %>").value == "")
                                                    Msg += "CBD\n";
                                                if (document.getElementById("<%=ddlTab2SiteLayout.ClientID %>").value == "0" && document.getElementById("<%=txtTab2SiteLayout.ClientID %>").value == "")
                                                    Msg += "Site Layout\n";
                                                if (document.getElementById("<%=ddltab2Services.ClientID %>").value == "0")
                                                    Msg += "Services\n";
                                                if (document.getElementById("<%=ddlTab2EnvironmentalHazards.ClientID %>").value == "0")
                                                    Msg += "Environmental Hazards\n";
                                                if (document.getElementById("<%=ddlTab2PestInfestation.ClientID %>").value == "0")
                                                    Msg += "Pest Infestation\n";
                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab3BuildingImprovements">
                    <tr>
                        <td>TAB 3 – Building & Improvements</td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="Error" ID="lblTab3Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Property:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Property Style:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3PropertyStyle" runat="server" CssClass="DDL" Width="163px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Year Built:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="150px" ID="txtTab3YearBuilt" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Construction:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>External Walls:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td>Roof:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td>Wall Linings:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3ExternalWalls" runat="server" CssClass="DDL" Width="163px"></asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddltab3Roof" runat="server" CssClass="DDL" Width="163px"></asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3InteriorLinings" runat="server" CssClass="DDL" Width="163px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Main Flooring:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td>Window Frames:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>&nbsp;</td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3MainFlooring" runat="server" CssClass="DDL" Width="163px"></asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3WindowFrames" runat="server" CssClass="DDL" Width="163px"></asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Condition:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Internal Condition:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3InternalCondition" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>External Condition:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3ExternalCondition" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Street Appeal:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab3StreetAppeal" runat="server" CssClass="DDL" Width="500px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Ancillary Improvements:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Pergola/ Verandah:&nbsp;</td>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab3PergolaVerandah" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Gable Roof Pergola" Text="Gable Roof Pergola"></asp:ListItem>
                                                        <asp:ListItem Value="Flat Roof Pergola" Text="Flat Roof Pergola"></asp:ListItem>
                                                        <asp:ListItem Value="Iron Verandah" Text="Iron Verandah"></asp:ListItem>
                                                        <asp:ListItem Value="Timber Verandah" Text="Timber Verandah"></asp:ListItem>
                                                        <asp:ListItem Value="Gazebo" Text="Gazebo"></asp:ListItem>
                                                        <asp:ListItem Value="Outdoor Kitchen" Text="Outdoor Kitchen"></asp:ListItem>
                                                        <asp:ListItem Value="Built in BBQ Area" Text="Built in BBQ Area"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Shedding:&nbsp;</td>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab3Shedding" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Single Iron Garage" Text="Single Iron Garage"></asp:ListItem>
                                                        <asp:ListItem Value="Double Iron Garage" Text="Double Iron Garage"></asp:ListItem>
                                                        <asp:ListItem Value="Triple Iron Garage" Text="Triple Iron Garage"></asp:ListItem>
                                                        <asp:ListItem Value="Single Garage" Text="Single Garage"></asp:ListItem>
                                                        <asp:ListItem Value="Double Garage" Text="Double Garage"></asp:ListItem>
                                                        <asp:ListItem Value="Triple Garage" Text="Triple Garage"></asp:ListItem>
                                                        <asp:ListItem Value="Shedding" Text="Shedding"></asp:ListItem>
                                                        <asp:ListItem Value="Garden Shed" Text="Garden Shed"></asp:ListItem>
                                                        <asp:ListItem Value="Tool Shed" Text="Tool Shed"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Pools:&nbsp;</td>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab3Pools" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Inground Pool" Text="Inground Pool"></asp:ListItem>
                                                        <asp:ListItem Value="Above Ground Pool" Text="Above Ground Pool"></asp:ListItem>
                                                        <asp:ListItem Value="Out Door Spa" Text="Out Door Spa"></asp:ListItem>
                                                        <asp:ListItem Value="Indoor Inground Pool" Text="Indoor Inground Pool"></asp:ListItem>
                                                        <asp:ListItem Value="Pool Fencing" Text="Pool Fencing"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Gardens:&nbsp;</td>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab3Gardens" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Basic Gardens" Text="Basic Gardens"></asp:ListItem>
                                                        <asp:ListItem Value="Established Gardens" Text="Established Gardens"></asp:ListItem>
                                                        <asp:ListItem Value="Landscaped Gardens" Text="Landscaped Gardens"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Fencing:&nbsp;</td>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab3Fencing" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Iron Fencing" Text="Iron Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="Timber Fencing" Text="Timber Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="Brush Fencing" Text="Brush Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="Security Entrance" Text="Security Entrance"></asp:ListItem>
                                                        <asp:ListItem Value="Automatic-Gate" Text="Automatic-Gate"></asp:ListItem>
                                                        <asp:ListItem Value="Courtyard Fencing" Text="Courtyard Fencing"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Driveway & Paving:&nbsp;</td>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab3DrivewayPaving" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Concrete Driveway" Text="Concrete Driveway"></asp:ListItem>
                                                        <asp:ListItem Value="Brick Driveway" Text="Brick Driveway"></asp:ListItem>
                                                        <asp:ListItem Value="Gravel Driveway" Text="Gravel Driveway"></asp:ListItem>
                                                        <asp:ListItem Value="Concrete Paving" Text="Concrete Paving"></asp:ListItem>
                                                        <asp:ListItem Value="Brick Paving" Text="Brick Paving"></asp:ListItem>
                                                        <asp:ListItem Value="Stone Paving" Text="Stone Paving"></asp:ListItem>
                                                        <asp:ListItem Value="Timber Decking" Text="Timber Decking"></asp:ListItem>
                                                        <asp:ListItem Value="Gravel Paving" Text="Gravel Paving"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Outbuildings:&nbsp;</td>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab3Outbuildings" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Outbuilding" Text="Outbuilding"></asp:ListItem>
                                                        <asp:ListItem Value="Self-Contained Flat" Text="Self-Contained Flat"></asp:ListItem>
                                                        <asp:ListItem Value="Storeroom" Text="Storeroom"></asp:ListItem>
                                                        <asp:ListItem Value="Bungalow" Text="Bungalow"></asp:ListItem>
                                                        <asp:ListItem Value="Studio" Text="Studio"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:TextBox Width="487px" TextMode="MultiLine" Height="50px" ID="txtTab3AncillaryImprovements" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnTab3Back" runat="server" CssClass="Button" Text="Back" OnClick="btnTab3Back_Click"></asp:Button>
                                                    <asp:Button ID="btnTab3Next" runat="server" CssClass="Button" Text="Next" OnClick="btnTab3Next_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab3Validation() {
                                                var Msg = "";

                                                if (document.getElementById("<%=txtTab3YearBuilt.ClientID %>").value == "")
                                                    Msg += "Year Built\n";
                                                if (document.getElementById("<%=ddlTab3ExternalWalls.ClientID %>").value == "0")
                                                    Msg += "External Walls\n";
                                                if (document.getElementById("<%=ddltab3Roof.ClientID %>").value == "0")
                                                    Msg += "Roof\n";
                                                if (document.getElementById("<%=ddlTab3InteriorLinings.ClientID %>").value == "0")
                                                    Msg += "Interior Linings\n";
                                                if (document.getElementById("<%=ddlTab3MainFlooring.ClientID %>").value == "0")
                                                    Msg += "Main Flooring\n";
                                                if (document.getElementById("<%=ddlTab3WindowFrames.ClientID %>").value == "0")
                                                    Msg += "Window Frames\n";
                                                if (document.getElementById("<%=ddlTab3InternalCondition.ClientID %>").value == "0")
                                                    Msg += "Internal Condition\n";
                                                if (document.getElementById("<%=ddlTab3ExternalCondition.ClientID %>").value == "0")
                                                    Msg += "External Condition\n";


                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab4RoomsFixtures">
                    <tr>
                        <td>Tab 4 - Rooms & Fixtures</td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="Error" ID="lblTab4Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Rooms:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Rooms1" RepeatColumns="3">
                                                        <asp:ListItem Value="Kitchen" Text="Kitchen"></asp:ListItem>
                                                        <asp:ListItem Value="Kitchen/Meals" Text="Kitchen/Meals"></asp:ListItem>
                                                        <asp:ListItem Value="Kitchen/Meals/Family" Text="Kitchen/Meals/Family"></asp:ListItem>
                                                        <asp:ListItem Value="Kitchenette" Text="Kitchenette"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Rooms2" RepeatColumns="3" Width="375px">
                                                        <asp:ListItem Value="Lounge" Text="Lounge&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="Dining" Text="Dining"></asp:ListItem>
                                                        <asp:ListItem Value="Lounge/Dining" Text="Lounge/Dining&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="Living Room" Text="Living Room"></asp:ListItem>
                                                        <asp:ListItem Value="Family Room" Text="Family Room"></asp:ListItem>
                                                        <asp:ListItem Value="Rumpus" Text="Rumpus"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Rooms3" RepeatColumns="3" Width="325px">
                                                        <asp:ListItem Value="Cellar" Text="Cellar"></asp:ListItem>
                                                        <asp:ListItem Value="Sunroom" Text="Sunroom"></asp:ListItem>
                                                        <asp:ListItem Value="Study" Text="Study"></asp:ListItem>
                                                        <asp:ListItem Value="Storeroom" Text="Storeroom&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="Utility" Text="Utility"></asp:ListItem>
                                                        <asp:ListItem Value="Studio" Text="Studio"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Rooms4" RepeatColumns="3">
                                                        <asp:ListItem Value="Entry Hall" Text="Entry Hall&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="Hallway" Text="Hallway"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td width="106px">
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Bedroom" RepeatColumns="3">
                                                        <asp:ListItem Value="Bedroom(s)" Text="Bedroom(s)"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab4Bedroom" runat="server" CssClass="DDL" Width="50px">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Bathroom" RepeatColumns="3">
                                                        <asp:ListItem Value="Bathroom(s)" Text="Bathroom(s)"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab4Bathroom" runat="server" CssClass="DDL" Width="50px">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Ensuite" RepeatColumns="3">
                                                        <asp:ListItem Value="Ensuite(s)" Text="Ensuite(s)"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab4Ensuite" runat="server" CssClass="DDL" Width="50px">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Toilet" RepeatColumns="3">
                                                        <asp:ListItem Value="Toilet(s)" Text="Toilet(s)"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab4Toilet" runat="server" CssClass="DDL" Width="50px">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBoxList runat="server" ID="chkTab4Laundry" RepeatColumns="3">
                                                        <asp:ListItem Value="Laundry" Text="Laundry"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:TextBox Width="487px" TextMode="MultiLine" Height="50px" ID="Tab4Text1" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Heating/Cooling:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>
                                                    <asp:CheckBoxList runat="server" ID="chkTab4HeatingCooling" RepeatColumns="3" Width="500px">
                                                        <asp:ListItem Value="Ducted Reverse Cycle" Text="Ducted Reverse Cycle"></asp:ListItem>
                                                        <asp:ListItem Value="Split System Air Conditioning " Text="Split System Air Conditioning "></asp:ListItem>
                                                        <asp:ListItem Value="R/C Wall Air Conditioner" Text="R/C Wall Air Conditioner"></asp:ListItem>
                                                        <asp:ListItem Value="Ducted Evaporative" Text="Ducted Evaporative"></asp:ListItem>
                                                        <asp:ListItem Value="Wall Air Conditioner" Text="Wall Air Conditioner"></asp:ListItem>
                                                        <asp:ListItem Value="Ceiling Fans" Text="Ceiling Fans"></asp:ListItem>
                                                        <asp:ListItem Value="Ducted Gas Heating" Text="Ducted Gas Heating"></asp:ListItem>
                                                        <asp:ListItem Value="Gas Heater" Text="Gas Heater"></asp:ListItem>
                                                        <asp:ListItem Value="Oil Heater" Text="Oil Heater"></asp:ListItem>
                                                        <asp:ListItem Value="Combustion Heater" Text="Combustion Heater"></asp:ListItem>
                                                        <asp:ListItem Value="Fireplace" Text="Fireplace"></asp:ListItem>
                                                        <asp:ListItem Value="Under Floor Heating" Text="Under Floor Heating"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnTab4Back" runat="server" CssClass="Button" Text="Back" OnClick="btnTab4Back_Click"></asp:Button>
                                                    <asp:Button ID="btnTab4Next" runat="server" CssClass="Button" Text="Next" OnClick="btnTab4Next_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab4Validation() {
                                                var Msg = "";
                                                //                                           

                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                            function CheckTab4Validation_1() {
                                                var Msg = "";


                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab5Area">
                    <tr>
                        <td>TAB 5 – Areas </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="Error" ID="lblTab5Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Areas:<br />
                                        (Square Metres)
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Living Area:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>Sqm/Eq Sqm:&nbsp;<span class="ErrorBold">*</span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5LivingArea" runat="server" CssClass="TextBox"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab5SqmEq" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Value="sqm" Text="sqm" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="equivalent sqm" Text="equivalent sqm"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Garage:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5Garage" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;sqm</td>
                                            </tr>
                                            <tr>
                                                <td>Carport:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5Carport" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;sqm</td>
                                            </tr>
                                            <tr>
                                                <td>Car Spaces:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5CarSpaces" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;sqm</td>
                                            </tr>
                                            <tr>
                                                <td>Balcony:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5Balcony" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;sqm</td>
                                            </tr>
                                            <tr>
                                                <td>Verandah:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5Verandah" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;sqm</td>
                                            </tr>
                                            <tr>
                                                <td>Alfresco:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5Alfresco" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;sqm</td>
                                            </tr>
                                            <tr>
                                                <td>Pergola:&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab5Pergola" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>&nbsp;sqm</td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btntab5Back" runat="server" CssClass="Button" Text="Back" OnClick="btnTab5Back_Click"></asp:Button>
                                                    <asp:Button OnClientClick="return CheckTab5Validation();" ID="btnTab5Next" runat="server" CssClass="Button" Text="Next" OnClick="btnTab5Next_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab5Validation() {
                                                var Msg = "";
                                                if (document.getElementById("<%=txtTab5LivingArea.ClientID %>").value == "")
                                                    Msg += "Living Area\n";
                                                if (document.getElementById("<%=ddlTab5SqmEq.ClientID %>").value == "0")
                                                    Msg += "Sqm/Eq Sqm\n";
    //                                            if (document.getElementById("<%=txtTab5Garage.ClientID %>").value == "")
    //                                                Msg += "Garage\n";
    //                                            if (document.getElementById("<%=txtTab5Carport.ClientID %>").value == "")
    //                                                Msg += "Carport\n";
    //                                            if (document.getElementById("<%=txtTab5CarSpaces.ClientID %>").value == "")
    //                                                Msg += "Car Spaces\n";
    //                                            if (document.getElementById("<%=txtTab5Balcony.ClientID %>").value == "")
    //                                                Msg += "Balcony\n";
    //                                            if (document.getElementById("<%=txtTab5Verandah.ClientID %>").value == "")
    //                                                Msg += "Verandah\n";
    //                                            if (document.getElementById("<%=txtTab5Alfresco.ClientID %>").value == "")
    //                                                Msg += "Alfresco\n";
    //                                            if (document.getElementById("<%=txtTab5Pergola.ClientID %>").value == "")
                                                //                                                Msg += "Pergola\n";




                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab6Comments">
                    <tr>
                        <td>Tab 6 - Comments</td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error" align="left">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label CssClass="Error" ID="lblTab6Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Instructions & General Comments: (New)</td>
                                                <td>Instructions & General Comments: (Old)</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="500px" ID="txtTab6Instructions" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="500px" ID="txtTab6InstructionsOld" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Standard Property Comments: (New)</td>
                                                <td>Standard Property Comments: (Old)</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="300px" ID="txtTab6Standard" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="300px" ID="txtTab6StandardOld" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Last Sale of Property: (New)</td>
                                                <td>Last Sale of Property: (Old)</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="100px" ID="txtTab6LastSaleofProperty" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="100px" ID="txtTab6LastSaleofPropertyOld" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>

                                            <tr>
                                                <td>Defects & Effect On Value: (New)</td>
                                                <td>Defects & Effect On Value: (Old)</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="100px" ID="txtTab6Defects" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="100px" ID="txtTab6DefectsOld" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Methodology & Sales Evidence Discussion Comments: (New)</td>
                                                <td>Methodology & Sales Evidence Discussion Comments: (Old)</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="700px" ID="txtTab6Methodology" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="700px" ID="txtTab6MethodologyOld" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td><b>Sample Text:</b></td>
                                            </tr>
                                            <tr>
                                                <td>Sale 1:<br />
                                                    72 Smith Road, Heidleberg Heights  sold in December 2012 at $415,000.  A 2 bedroom rendered home on a 648 sqm allotment.  The home has a dated/original condition fit out and was sold with poor presentation and appeal. Considered inferior overall, a value above this price point should be adopted for the subject property. </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Closing Commentary Relating to Market Value Adopted Comments: (New)</td>
                                                <td>Closing Commentary Relating to Market Value Adopted Comments: (Old)</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="300px" ID="txtTab6Closing" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox Width="650px" TextMode="MultiLine" Height="300px" ID="txtTab6ClosingOld" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnTab6Back" runat="server" CssClass="Button" Text="Back" OnClick="btnTab6Back_Click"></asp:Button>
                                                    <asp:Button ID="Button2" runat="server" CssClass="Button" Text="Next" OnClick="btnTab6Next_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab6Validation() {
                                                var Msg = "";
                                                if (document.getElementById("<%=txtTab6Instructions.ClientID %>").value == "")
                                                    Msg += "Instructions & General Comments\n";
                                                if (document.getElementById("<%=txtTab6Standard.ClientID %>").value == "")
                                                    Msg += "Standard Property Comments\n";
                                                if (document.getElementById("<%=txtTab6LastSaleofProperty.ClientID %>").value == "")
                                                    Msg += "Last Sale of Property\n";
                                                if (document.getElementById("<%=txtTab6Defects.ClientID %>").value == "")
                                                    Msg += "Defects & Effect On Value\n";
                                                if (document.getElementById("<%=txtTab6Methodology.ClientID %>").value == "")
                                                    Msg += "Methodology & Sales Evidence Discussion Comments\n";
                                                if (document.getElementById("<%=txtTab6Closing.ClientID %>").value == "")
                                                    Msg += "Closing Commentary Relating to Market Value AdoptedComments\n";

                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab7SalesEvidence">
                    <tr>
                        <td>Tab 7 – Sales Evidence</td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="Error" ID="lblTab7Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide">Sales Details:
                                    </td>
                                    <td class="TDTopBottom"></td>
                                    <td class="TDRight">
                                        <table cellpadding="0" cellspacing="3" style="display: none;">
                                            <tr>
                                                <td>Address:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:TextBox Width="500px" ID="txtTab7Address" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Sale Date:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab7SaleDate" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Sale Price:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab7SalePrice" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Type:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab7Type" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="Test Val 1" Text="Test Val 1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Year:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab7Year" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Construction:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddltab7Construction" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="Test Val 1" Text="Test Val 1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Roof Type:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab7RoofType" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Value="0" Text="Select One" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="Test Val 1" Text="Test Val 1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Bedrooms:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTab7Bedrooms" runat="server" CssClass="DDL" Width="113px">
                                                        <asp:ListItem Value="1" Text="1" Selected="True"></asp:ListItem>
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Bathrooms:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddltab7Bathrooms" runat="server" CssClass="DDL" Width="113px">
                                                        <asp:ListItem Value="1" Text="1" Selected="True"></asp:ListItem>
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Car Accommodation:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddltab7CarAccommodation" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Value="No" Text="No" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>Living Area:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:TextBox Width="100px" ID="txtTab7LivingArea" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Land Area:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:TextBox Width="60px" ID="txtTab7LandArea" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp;
                                                    <asp:DropDownList ID="ddlTab7LandArea" runat="server" CssClass="DDL" Width="80px">
                                                        <asp:ListItem Value="Square Metres" Text="Sq. Metres" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="Square Hectares" Text="Sq. Hectares"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Ancillary Improvements/<br />
                                                    Comments & Comparision:</td>
                                                <td>
                                                    <asp:TextBox Width="500px" TextMode="MultiLine" Height="100px" ID="txtTab7Ancillary" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>Category:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSalesCategory" runat="server" CssClass="DDL" Width="163px">
                                                        <asp:ListItem Value="0" Text="Please Select" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="Inferior Sales" Text="Inferior Sales"></asp:ListItem>
                                                        <asp:ListItem Value="Most Comparable Sales" Text="Most Comparable Sales"></asp:ListItem>
                                                        <asp:ListItem Value="Superior Sales" Text="Superior Sales"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab7Photo" runat="server"></asp:FileUpload></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button OnClientClick="return CheckTab7Validation();" ID="btnTab7AddSalesDetails" runat="server" CssClass="Button" Text="Add Sales Details" OnClick="btnTab7AddSalesDetails_Click"></asp:Button></td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvSalesDetails" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SalesCategory" HeaderText="Category" />
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <img src='../Tab7Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnDelete" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnDelete_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab7Validation() {
                                                var Msg = "";
                                                if (document.getElementById("<%=fuTab7Photo.ClientID %>").value == "")
                                                    Msg += "Photo\n";
                                                if (document.getElementById("<%=ddlSalesCategory.ClientID %>").value == "0")
                                                    Msg += "Category\n";



                                                if (Msg != "") {
                                                    Msg = "Error to submit details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnTab7Back" runat="server" CssClass="Button" Text="Back" OnClick="btnTab7Back_Click"></asp:Button>
                                                    <asp:Button ID="btnTab7Next" runat="server" CssClass="Button" Text="Next" OnClick="btnTab7Next_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="10" width="100%" runat="server" id="tblTab8Attachments">
                    <tr>
                        <td>Tab 8 - Attachments</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbtnTab8Primary" runat="server" OnClick="lbtnTab8PrimaryPhoto_Click">Primary Photos</asp:LinkButton>&nbsp;|&nbsp;
                            <asp:LinkButton ID="lbtnTab8External" runat="server" OnClick="lbtnTab8ExternalPhoto_Click">External Photos</asp:LinkButton>&nbsp;|&nbsp;
                            <asp:LinkButton ID="lbtnTab8Internal" runat="server" OnClick="lbtnTab8InternalPhoto_Click">Internal Photos</asp:LinkButton>&nbsp;|&nbsp;
                            <asp:LinkButton ID="lbtnTab8Defect" runat="server" OnClick="lbtnTab8DefectPhoto_Click">Defect Photos</asp:LinkButton>&nbsp;|&nbsp;
                            <asp:LinkButton ID="lbtnTab8Title" runat="server" OnClick="lbtnTab8TitlePhoto_Click">Title Details</asp:LinkButton>&nbsp;|&nbsp;
                            <asp:LinkButton ID="lbtnTab8Zoning" runat="server" OnClick="lbtnTab8ZoningPhoto_Click">Zoning Details</asp:LinkButton>&nbsp;|&nbsp;
                            <asp:LinkButton ID="lbtnTab8Overlay" runat="server" OnClick="lbtnTab8OverlayPhoto_Click">Overlay Details</asp:LinkButton>&nbsp;|&nbsp;
                            <asp:LinkButton ID="lbtnTab8Others" runat="server" OnClick="lbtnTab8OthersPhoto_Click">Others</asp:LinkButton>&nbsp;|&nbsp;
                             <asp:LinkButton ID="lbtnTab8AddDocuments" runat="server" OnClick="lbtnTab8AddDocuments_Click">+Add Documents</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" width="900px">
                                <tr>
                                    <td colspan="3" align="center" style="height: 50px; background-color: #FFFBCE;">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td class="Error">Fields marked as * are mandatory fields.</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="Error" ID="lblTab8Error" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftBoldTextLeftSide" style="width: 10%">Photos/Documents:
                                    </td>
                                    <td class="TDRight" colspan="2" style="width: 90%">
                                        <table cellpadding="0" cellspacing="3" id="tblTab8Primary" runat="server">
                                            <tr>
                                                <td>Primary Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8Primary" runat="server" Multiple="Multiple" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8PrimaryValidation();" ID="btnTab8PrimaryPhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8PrimaryPhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8Primary" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeletePrimaryPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeletePrimaryPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript" language="javascript">
                                            var validFilesTypes = ["bmp", "gif", "png", "jpg", "jpeg", "pdf"];
                                            function ValidateFile(id) {
                                                var file = document.getElementById(id);
                                                var path = file.value;
                                                var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
                                                var isValidFile = false;
                                                for (var i = 0; i < validFilesTypes.length; i++) {
                                                    if (ext == validFilesTypes[i]) {
                                                        isValidFile = true;
                                                        break;
                                                    }
                                                }
                                                return isValidFile;
                                            }
                                            function CheckTab8PrimaryValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8Primary.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <table cellpadding="0" cellspacing="3" id="tblTab8External" runat="server">
                                            <tr>
                                                <td>External Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8External" runat="server" Multiple="Multiple" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8ExternalValidation();" ID="btnTab8ExternalPhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8ExternalPhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8ExternalPhoto" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteExternalPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteExternalPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab8ExternalValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8External.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <table cellpadding="0" cellspacing="3" id="tblTab8Internal" runat="server">
                                            <tr>
                                                <td>Internal Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8Internal" runat="server" Multiple="Multiple" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8InternalValidation();" ID="btnTab8InternalPhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8InternalPhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8InternalPhoto" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteInternalPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteInternalPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab8InternalValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8Internal.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>

                                        <table cellpadding="0" cellspacing="3" id="tblTab8Defect" runat="server">
                                            <tr>
                                                <td>Defect Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8Defect" runat="server" Multiple="Multiple" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8DefectValidation();" ID="btnTab8DefectPhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8DefectPhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8DefectPhoto" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteDefectPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteDefectPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab8DefectValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8Defect.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <table cellpadding="0" cellspacing="3" id="tblTab8Title" runat="server">
                                            <tr>
                                                <td>Title Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8Title" runat="server" Multiple="Multiple" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8TitleValidation();" ID="btnTab8TitlePhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8TitlePhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8TitlePhoto" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteTitlePhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteTitlePhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab8TitleValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8Title.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <table cellpadding="0" cellspacing="3" id="tblTab8Zoning" runat="server">
                                            <tr>
                                                <td>Zoning Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8Zoning" runat="server" Multiple="Multiple" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8ZoningValidation();" ID="btnTab8ZoningPhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8ZoningPhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8ZoningPhoto" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteZoningPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteZoningPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab8ZoningValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8Zoning.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <table cellpadding="0" cellspacing="3" id="tblTab8Overlay" runat="server">
                                            <tr>
                                                <td>Overlay Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8Overlay" runat="server" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8OverlayValidation();" ID="btnTab8OverlayPhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8OverlayPhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8OverlayPhoto" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteOverlayPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteOverlayPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab8OverlayValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8Overlay.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <table cellpadding="0" cellspacing="3" id="tblTab8Others" runat="server">
                                            <tr>
                                                <td>Others Photo:&nbsp;<span class="ErrorBold">*</span></td>
                                                <td>
                                                    <asp:FileUpload ID="fuTab8Others" runat="server" Multiple="Multiple" /></td>
                                                <td>
                                                    <asp:Button Width="155px" OnClientClick="return CheckTab8OthersValidation();" ID="btnTab8OthersPhoto" runat="server" CssClass="Button" Text="Upload" OnClick="btnTab8OthersPhoto_Click"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvTab8OthersPhoto" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteOthersPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteOthersPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <script type="text/javascript">
                                            function CheckTab8OthersValidation() {
                                                var Msg = "";
                                                var id = "<%=fuTab8Others.ClientID %>"
                                                if (document.getElementById(id).value == "") {
                                                    Msg += "- Photo upload is required.\n";
                                                }
                                                if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                                                    Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
                                                }
                                                if (Msg != "") {
                                                    Msg = "Error to submit details : \n\n" + Msg;
                                                    alert(Msg);
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <table cellpadding="3" cellspacing="3" border="0" id="tblTab8AddDocuments" clientidmode="Static" runat="server" style="width: 100%">
                                            <tr>
                                                <td colspan="3">
                                                   
                                                    <ajaxToolkit:Accordion ID="Accordion1" runat="server" HeaderCssClass="headerCssClass" ContentCssClass="contentCssClass" HeaderSelectedCssClass="headerSelectedCss" FadeTransitions="true" TransitionDuration="500" AutoSize="None" SelectedIndex="0">
                                                        <Panes>
                                                            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                                                                <Header>File Upload
                                                                </Header>
                                                                <Content>

                                                                    <table cellpadding="5" cellspacing="5" style="width: 100%" border="0">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:UpdatePanel ID="updatePanelDdlSection" runat="server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>
                                                                                        <asp:DropDownList Width="350px" ID="dropDownSection" OnSelectedIndexChanged="dropDownSection_SelectedIndexChanged" runat="server" AutoPostBack="true" DataTextField="SectionName" DataValueField="AMS_ReportSectionsId" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="background-color: #28578F">
                                                                                <div style="width: 800px; height: 150px; background-color: white; margin: 30px; overflow-y: scroll">
                                                                                    <asp:UpdatePanel runat="server" ID="UpdatePanelFileUpload">
                                                                                        <ContentTemplate>
                                                                                            <ajaxToolkit:AjaxFileUpload ID="fuTab8AddDocs" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete"
                                                                                                OnUploadCompleteAll="AjaxFileUpload1_UploadCompleteAll" OnClientUploadCompleteAll="reloadFilesGrid" ThrobberID="myThrobber" MaximumNumberOfFiles="10" />
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="dropDownSection"
                                                                                                EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>


                                                                </Content>
                                                            </ajaxToolkit:AccordionPane>
                                                            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                                                <Header>Add Section</Header>
                                                                <Content>
                                                                    <table cellpadding="5" cellspacing="5" style="width: 100%">
                                                                        <tr>
                                                                            <td colspan="3" style="text-align: left">
                                                                                <asp:UpdatePanel ID="updatePanelSection" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <div style="padding:10px">
                                                                                            <table cellpadding="5" cellspacing="5" border="0">
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:Label ID="lblMessage" Visible="false" runat="server" style="color:green"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="vertical-align:top">
                                                                                                        Section Name:
                                                                                                    </td>
                                                                                                    <td style="text-align:left">
                                                                                                         <asp:TextBox ID="txtSectionName" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="rfvSection" ValidationGroup="addSection" runat="server" ErrorMessage="Section name is required" ControlToValidate="txtSectionName"></asp:RequiredFieldValidator>
                                                                                                        <p style="padding-top:5px">
                                                                                                            <asp:Button Width="100px" ID="btnAddSection" runat="server" ValidationGroup="addSection" CssClass="Button" Text="Add" OnClick="btnAddSection_Click"></asp:Button>
                                                                                                        </p>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table> 
                                                                                            
                                                                                            <asp:GridView ID="GridViewSectionsList" Width="100%" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#28578F" HeaderStyle-ForeColor="White">
                                                                                            <Columns>
                                                                                                <asp:BoundField HeaderText="Section Name" DataField="SectionName" HeaderStyle-Height="25px" ItemStyle-Width="200px" />
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AMS_ReportSectionsId") %>'></asp:Label>
                                                                                                        <asp:ImageButton ID="btnDeleteSection" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                                                            OnClick="btnDeleteSection_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                        </div>
                                                                                        

                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </Content>
                                                            </ajaxToolkit:AccordionPane>
                                                            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                                                                <Header>Photos/Documents</Header>
                                                                <Content>
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:UpdatePanel ID="updatePanelSectionsGrid" runat="server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>
                                                                                        <asp:Button runat="server" style="display:none" ClientIDMode="Static" ID="buttonDocumentsGrid" OnClick="buttonDocumentsGrid_Click" />
                                                                                        <asp:GridView ID="GridViewSections" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#28578F" HeaderStyle-ForeColor="White">
                                                                                            <Columns>
                                                                                                <asp:BoundField HeaderText="Section Name" DataField="SectionName" HeaderStyle-Height="25px" ItemStyle-Width="200px" />
                                                                                                <asp:TemplateField HeaderText="Image/Documents">
                                                                                                    <ItemTemplate>
                                                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"ImageUrl").ToString().Replace("~/","/") %>' target="0">
                                                                                                            <img src='<%#DataBinder.Eval(Container.DataItem,"ImageUrl").ToString().Replace("~/","/") %>' style="height: 80px; width: 200px;" /></a>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                                                        <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageUrl") %>'></asp:Label>
                                                                                                        <asp:ImageButton ID="btnDeleteDocs" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                                                            OnClick="btnDeleteDocs_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                    <%--<Triggers>
                                                                                        <asp:AsyncPostBackTrigger ControlID="btnAddSection" EventName="Click" />
                                                                                    </Triggers>--%>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </Content>
                                                            </ajaxToolkit:AccordionPane>
                                                        </Panes>
                                                    </ajaxToolkit:Accordion>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="false" GridLines="None" Width="500px">
                                                        <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                                                        <HeaderStyle CssClass="JobListGridHeader" />
                                                        <RowStyle CssClass="JobGridDateRow" />
                                                        <AlternatingRowStyle CssClass="JobGridAlt" />
                                                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Image">
                                                                <ItemTemplate>
                                                                    <a href='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' target="0">
                                                                        <img src='../Tab8Files/<%#DataBinder.Eval(Container.DataItem,"ImageName") %>' style="height: 40px; width: 100px;" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName") %>'></asp:Label>
                                                                    <asp:ImageButton ID="btnTab8DeleteOthersPhoto" runat="server" Style="padding-right: 5px;" ImageUrl="~/Images/btn_delete.gif"
                                                                        OnClick="btnTab8DeleteOthersPhoto_Click" ToolTip="Delete Record" OnClientClick="return confirm('Are you sure to delete the record?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TDLeftNormalText" colspan="3">
                                        <table cellpadding="0" cellspacing="5" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnTab8Back" runat="server" CssClass="Button" Text="Back" OnClick="btnTab8Back_Click"></asp:Button>
                                                    <asp:Button ID="btnTab8Next" runat="server" CssClass="Button" Text="Generate PDF" OnClick="btnTab8Next_Click" OnClientClick="showLoader()"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblReportHtml" runat="server"></asp:Label>

    <script type="text/javascript">


        //CheckTab8OthersValidation
        function CheckTab8AddDocValidation() {
            var Msg = "";
            var id = "<%=fuTab8AddDocs.ClientID %>"
            if (document.getElementById(id).value == "") {
                Msg += "- Document upload is required.\n";
            }
            if (document.getElementById(id).value != "" && !ValidateFile(id)) {
                Msg += "- Please upload a File with" + " extension " + validFilesTypes.join(", ");
            }
            if (Msg != "") {
                Msg = "Error to submit details : \n\n" + Msg;
                alert(Msg);
                return false;
            }
        }

        function reloadFilesGrid() {
            document.getElementById('buttonDocumentsGrid').click();
        }

    </script>
</asp:Content>
