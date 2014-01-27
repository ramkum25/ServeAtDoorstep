<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddService.ascx.cs" Inherits="ServeAtDoorstepWeb.UserControl.AddService" %>
<div>
    <h1>Welcome to the new popup window</h1>
    <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="parent.parent.GB_hide();" />
    </div>