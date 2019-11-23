<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploading.aspx.cs" Inherits="AMSProjectNew.FileUploading" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>jQuery Upload multiple files in asp.net</title>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="3" id="tblTab8External" runat="server">
                <tr>
                    <td valign="top">External Photo:&nbsp;<span class="ErrorBold">*</span></td>
                    <td valign="top">
                    <CuteWebUI:UploadAttachments InsertText="Upload Multiple files Now" runat="server" ID="Attachments1External" 
                        MultipleFilesUpload="true" OnAttachmentAdded="Attachments1External_AttachmentAdded">
                    </CuteWebUI:UploadAttachments>
                    <br />
                    <asp:ListBox runat="server" ID="ListBoxEvents" Visible="false" />
                    <asp:FileUpload ID="fuTab8External" runat="server" Visible="false" />
                    </td>
                    <td valign="top">
                    <asp:Button Width="155px" ID="btnTab8ExternalPhoto" runat="server" CssClass="Button" Text="Upload" onclick="btnTab8ExternalPhoto_Click"></asp:Button>
                    <script runat="server">
                    void InsertMsg(string msg)
                    {
                        ListBoxEvents.Items.Insert(0, msg);
                        ListBoxEvents.SelectedIndex = 0;
                    }
                    void Attachments1External_AttachmentAdded(object sender, AttachmentItemEventArgs args)
                    {
                        InsertMsg(args.Item.FileName + " has been uploaded.");
                    }

                    void ButtonDeleteAll_Click(object sender, EventArgs e)
                    {
                        InsertMsg("Attachments1External.DeleteAllAttachments();");
                        Attachments1External.DeleteAllAttachments();
                    }
                    
                </script>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <asp:FileUpload ID="file_upload" class="multi" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" 
            onclick="btnUpload_Click" /><br />
        <asp:Label ID="lblMessage" runat="server" />
    </div>
        </form>
</body>
</html>
