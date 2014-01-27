<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInquiry.aspx.cs" Inherits="ServeAtDoorstepWeb.ShowInquiry" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">

        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajax:ToolkitScriptManager>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Button ID="btnPrevious" runat="server" Text="<<" Font-Size="20" />
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="400" Width="400" />
                    <ajax:SlideShowExtender ID="SlideShowExtender" runat="server" TargetControlID="Image1"
                        SlideShowServiceMethod="GetImages" ImageTitleLabelID="lblImageTitle" ImageDescriptionLabelID="lblImageDescription"
                        AutoPlay="true" Loop="true" PlayButtonID="btnPlay" StopButtonText="Stop"
                        PlayButtonText="Play" NextButtonID="btnNext" PreviousButtonID="btnPrevious">
                    </ajax:SlideShowExtender>
                </td>
                <td>
                    <asp:Button ID="btnNext" runat="server" Text=">>" Font-Size="20" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="btnPlay" runat="server" Text="Play" Font-Size="20" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <br />
                    <b>Name:</b>
                    <asp:Label ID="lblImageTitle" runat="server" Text="Label" /><br />
                    <b>Description:</b>
                    <asp:Label ID="lblImageDescription" runat="server" Text="Label" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
