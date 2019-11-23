<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobHistory.ascx.cs" Inherits="AMSProjectNew.UserControls.JobHistory" %>
<asp:GridView ID="gvJobHistory" runat="server" AutoGenerateColumns="false" GridLines="None">
    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="TDRightTextLeft" width="150px">Date</td>
                        <td class="TDRightTextLeft">Details</td>
                        <td class="TDRightTextLeft" width="150px">Added By</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="TDRightTextLeft" width="150px"><%# DataBinder.Eval(Container.DataItem,"CreatedDate") %></td>
                        <td class="TDRightTextLeft"><%# DataBinder.Eval(Container.DataItem,"Comment") %></td>
                        <td class="TDRightTextLeft" width="150px"><%# DataBinder.Eval(Container.DataItem,"CreatedByName") %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>