<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.AboutUs" %>


<asp:Content ID="co1" ContentPlaceHolderID="MainContent" runat="server">

        <div id="MainSection">
            <div id="MainCategory">
            <br>
            <strong><label id="currentLocation" runat="server"> / Current Location:</label></strong>
	        <small style="color:#C03;">&nbsp;&nbsp;&nbsp;[Change]</small>
            <br>
            <hr>
            </div>
            <div id="MainItem">
                <div style="text-align:left; padding-top:5em">
                <h1>Yard e-Cart contact</h1>
                </div>
                <section class="contact"  style="text-align:left;padding-left:5EM">
                    <header>
                        <h3>Phone:</h3>
                    </header>
                    <p>
                        <span class="label">Main:</span>
                        <span>425.555.0100</span>
                    </p>
                    <p>
                        <span class="label">After Hours:</span>
                        <span>425.555.0199</span>
                    </p>
                </section>
                <section class="contact" style="text-align:left;padding-left:5EM">
                    <header>
                        <h3>Email:</h3>
                    </header>
                    <p>
                        <span class="label">Support:</span>
                        <span><a href="mailto:Support@example.com">Support@example.com</a></span>
                    </p>
                    <p>
                        <span class="label">Marketing:</span>
                        <span><a href="mailto:Marketing@example.com">Marketing@example.com</a></span>
                    </p>
                    <p>
                        <span class="label">General:</span>
                        <span><a href="mailto:General@example.com">General@example.com</a></span>
                    </p>
                </section>
                <section class="contact" style="text-align:left;padding-left:5EM">
                    <header>
                        <h3>Address:</h3>
                    </header>
                    <p>
                        One Microsoft Way<br />
                        Redmond, WA 98052-6399
                    </p>
                </section>
            </div>
        </div>

</asp:Content>
