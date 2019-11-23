<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageValuationType.aspx.cs" Inherits="AMSProjectNew.Admin.ManageValuationType" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
function SelectAllCheckboxesCategoryList(spanChk)
{
    var chkALL = document.getElementById(spanChk);
    var the_form = window.document.forms[0];
    for(var i=0; i<the_form.length; i++)
    {
        var temp = the_form.elements[i].type;
        if(temp == "checkbox")
        {
            if (the_form.elements[i].name.indexOf("chkDelete") > -1)
            {
                the_form.elements[i].checked = chkALL.checked;
            }
        }
    }  
}

function UncheckAllCategoryList(CheckItemClientID)
{
    var chkItem = document.getElementById(CheckItemClientID);
    var the_form = window.document.forms[0];
    for(var i=0; i<the_form.length; i++)
    {
        var temp = the_form.elements[i].type;
        if(temp == "checkbox")
        {
            if (the_form.elements[i].name.indexOf("cbheaderCategory") > -1)
            {  
                if(the_form.elements[i].checked = false)
                    the_form.elements[i].checked = chkItem.checked;
            }
        }
    }  
}
function ConfirmDelete()
{ 
    var the_form = window.document.forms[0];
    var flagDel=1;
    for(var i=0; i<the_form.length; i++)
    {
        var temp = the_form.elements[i].type;
        if(temp == "checkbox")
        {
            if (the_form.elements[i].name.indexOf("chkDelete") > -1)
            {
                 if(the_form.elements[i].checked == true)
                 {
                    flagDel=0;
                    break;
                 } 
            }
        }
    }  
    if(flagDel==0)
    {
        var DialogRes = confirm("Are you sure you want to delete records?");
        return DialogRes;
    }
    else
    {
       alert("Must Select Atleast One Record To Delete.");
       return false;
    }
}
</script>
<asp:UpdatePanel ID="updJob" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left" height="40px" style="padding-bottom:10px;"><i>Manage Valuation Types</i></td>
    </tr>
    <tr>
        <td  style="background:white;">
            <table cellpadding="0" cellspacing="10" width="100%">
                <tr>
                    <td><asp:Label CssClass="Error" ID="lblTotal" runat="server"></asp:Label></td>
                    <td align="right"><asp:Button CssClass="Button" ID="btnNewEntry" runat="server" Text="New Valuation Types" onclick="btnNewEntry_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvValuationType" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                            PageSize="10" Width="100%" OnPageIndexChanging="gvValuationType_PageIndexChanging" 
                            CssClass="Grid" onrowdatabound="gvValuationType_RowDataBound" GridLines="None">
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" />
                            <RowStyle CssClass="GridRow" />
                            <AlternatingRowStyle CssClass="GridAlt" />
                            <Columns>
                                <asp:TemplateField HeaderText="Delete" Visible="false">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbheaderCategory" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDelete" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Valuation Type" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>                                            
                                        &nbsp;<asp:Label ID="lblValuationTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ValuationTypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>                     
                                <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        &nbsp;<asp:ImageButton ID="btnEdit" runat="server" Style="padding-right: 5px; height:15px;" ImageUrl="~/Images/btn_edit.gif" OnClick="btnEdit_Click" CausesValidation="False" ToolTip="Edit record" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                        <asp:ImageButton ID="btnDelete" runat="server" Style="padding-right: 5px; height:15px;" ImageUrl="~/Images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="False" ToolTip="Delete record" OnClientClick="return confirm('Are you sure to delete the recor?');" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
    <ajaxToolkit:ModalPopupExtender ID="mdlPopUp" BehaviorID="mdlPopUp" runat="server" CancelControlID="btnCancel"
        TargetControlID="LinkButton1" PopupControlID="pnlPopup" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlPopup" runat="server" CssClass="confirm-dialog1" Style="display: none;">
        <table width="400px" cellpadding="0" cellspacing="0" style="background-color: White;border: solid 2px #28578F;">
            <tr>
                <td class="PopupHeader">Valuation Type Add/Edit</td>
            </tr>              
            <tr>
                <td align="center" height="120px">
                    <table cellpadding="0" cellspacing="10">
                        <tr>
                            <td colspan="2" height="30px">
                                <asp:Label ID="lblPopupError" runat="server"></asp:Label>
                                <asp:Label Visible="false" ID="lblPopupId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Valuation Type:</td>
                            <td><asp:TextBox Width="200px" ID="txtValuationType" runat="server" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" height="40px">
                                <asp:Button CssClass="Button" ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return CheckValidation();" onclick="btnSubmit_Click" />
                                <asp:Button CssClass="Button" ID="btnCancel" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
    function CheckValidation() {
        var Msg = "";
        if (document.getElementById("<%=txtValuationType.ClientID%>").value == "")
            Msg += "Valuation type is required\n";
        
        if (Msg != "") {
            Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
            alert(Msg);

            if (document.getElementById("<%=txtValuationType.ClientID%>").value == "") document.getElementById("<%=txtValuationType.ClientID%>").focus();
            return false;
        }
    }
</script>
</asp:Content>
