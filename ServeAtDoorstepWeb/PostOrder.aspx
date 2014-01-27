<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostOrder.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.PostOrder" %>


<asp:content ID="c1" runat="server" ContentPlaceHolderID="MainContent">

    <style type="text/css">
        //css
         .file_input_textbox {
            float: left;
        }

        .file_input_div {
            position: absolute;
            width: 120px;
            height: 25px;
            overflow: hidden;
        }

        .file_input_button {
            width: 120px;
            position: relative;
            font-family:Calibri;
            font-size:14px;
            font-weight:bold;
            top: 0px;
            height: 25px;
            background-color: white;
            color: #000000;
            border: 1px solid black;
            border-radius: 10px 10px 10px 10px;
        }

        .file_input_hidden {
            font-size: 25px;
            position: absolute;
            right: 0px;
            top: 0px;
            opacity: 0;
            background-color: #f2eceb;
            filter: alpha(opacity=0);
            -ms-filter: "alpha(opacity=0)";
            -khtml-opacity: 0;
            -moz-opacity: 0;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $('#<%=FileUpload1.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png', 'gif'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.jpeg','.jpg', '.png' and '.gif' formats are allowed.");
                    $(this).val("");
                    document.getElementById('fileName1').value = "";

                }
                else {
                    document.getElementById('fileName1').value = $(this).val();
                }

            });

        });
    </script>
    <div id="MainSection">
        <div id="divCategory" class="MainCategory" runat="server">
            <br />
            <strong>
                <label id="currentLocation" runat="server">/ Current Location:</label></strong>
            <small style="color: #C03;">&nbsp;&nbsp;&nbsp;[Change]</small>
            <br />
            <hr />
        </div>
        <div id="MainItem">
            <p>&nbsp;</p>
            <div style="padding-left: 0px;">
                <div id="divMessage" runat="server" style="font-size: 14px; font-weight: bold; padding-left: 30px; font-family: 'Century Gothic';"></div>
                <div style="font-size: 16px; font-weight: bolder; padding-left: 30px; font-family: 'Century Gothic';">POST ORDER</div>
                <div id="divErrorMessage" style="font-family: 'Century Gothic';color:red;font-weight:bold;
                                             padding-left: 50px; padding-top: 30px;" runat="server"></div>
                <div style="padding-left: 50px;">

                    <table style="font-family: 'Century Gothic'">
                        <tr>
                            <td colspan="2">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px; height: 40px; font-size: 16px; font-weight: normal;">Order Title 
                            </td>
                            <td>
                                <input type="text" id="txtQuoteTitle" name="txtQuoteTitle" runat="server" maxlength="50" class="InputTextbox"
                                    style="height:23px;width:350px;" 
                                     />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px; height: 75px; font-size: 16px; font-weight: 400;">Order Description 
                            </td>
                            <td>
                                <textarea id="txtQuoteDesc" name="txtQuoteDesc" runat="server" maxlength="1000" 
                                    class="InputTextbox"
                                    style="height: 60px; width: 350px;"
                                    ></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px; height: 40px; font-size: 16px; font-weight: 400;">Order Category 
                            </td>
                            <td>
                                <select id="ddlCategory" name="ddlCategory" runat="server" class="ServeDropdownlist" style=" height: 25px; width: 350px;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td style="width: 250px; height: 60px;" colspan="2">
                                <asp:Button ID="btnSubmitOrder" runat="server" Text="Submit" OnClick="btnSubmitOrder_Click" CssClass="SubmitButton"
                                    Style="width: 120px;" />

                            </td>
                        </tr>
                    </table>
                </div>
            </div>

        </div>
    </div>

</asp:content>