<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageResize.aspx.cs" Inherits="AMSProjectNew.ImageResize" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <h2>
                        Uploading multiple files (Limit the maximum number of files allowed to upload)</h2>
                    <p>
                        This example shows you how to limit the maximum number of files allowed to upload.
                        In the following example, you can only upload 3 files.</p>
                    <fieldset style="height: 130px">
                        <legend>
                            <CuteWebUI:Uploader runat="server" ID="Uploader1" InsertText="Upload Multiple files Now"
                                MultipleFilesUpload="true" OnFileUploaded="Uploader_FileUploaded">
                            </CuteWebUI:Uploader>
                        </legend>
                        <div>
                            <CuteWebUI:UploadAttachments runat="server" ID="Attachments1" OnAttachmentAdded="Attachments1_AttachmentAdded">
                            </CuteWebUI:UploadAttachments>
                        </div>
                    </fieldset>
                    <p>
                        <asp:Button ID="ButtonDeleteAll" runat="server" Text="Delete All" OnClick="ButtonDeleteAll_Click" />&nbsp;&nbsp;
                        <asp:Button ID="ButtonTellme" runat="server" Text="Show Uploaded File Information"
                            OnClick="ButtonTellme_Click" />
                    </p>
                    <p>
                        Server Trace:
                        <br />
                        <asp:ListBox runat="server" ID="ListBoxEvents" />
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
    
    <div>
    <table>
        <tr><td><asp:FileUpload ID="fileUploader" runat="server" /></td>
        <td><asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" /></td></tr>
    </table>
    <table runat="server" cellpadding="5" id="tblResize" visible="false">
        <tr>
            <td>Oroginal</td>
            <td>Width:</td>
            <td><asp:Label ID="lblWidth" runat="server"></asp:Label></td>
            <td>Height:</td>
            <td><asp:Label ID="lblHeight" runat="server"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td>Resize with<asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td>Width:</td>
            <td><asp:TextBox ID="txtWidth" runat="server" placeholder="300"></asp:TextBox></td>
            <td>Height:</td>
            <td><asp:TextBox ID="txtHeight" runat="server" placeholder="300"></asp:TextBox></td>
            <td><asp:Button ID="Button1" runat="server" Text="Resize" OnClick="Button1_Click" /></td>
        </tr>
    </table>
    <table>
        <tr><td>Resized Image</td><td>Required in PDF</td></tr>
        <tr>
            <td><asp:Image ID="Image2" runat="server" /></td>
            <td><asp:Image ID="Image3" runat="server" /></td>
        </tr>
        <tr><td colspan="2"><asp:Image ID="Image1" runat="server" /></td></tr>
    </table>
        Resized Image:<br />
        <br /><br /><br />
        Original Image:<br />
        
        
    </div>
    </form>
</body>
</html>
