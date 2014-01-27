<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostQuote.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.PostQuote" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <style type="text/css">
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

            $('#<%=FileUpload2.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png', 'gif'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.jpeg','.jpg', '.png' and '.gif' formats are allowed.");
                    $(this).val("");
                    document.getElementById('fileName2').value = "";

                }
                else {
                    document.getElementById('fileName2').value = $(this).val();
                }

            });

            $('#<%=FileUpload3.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png', 'gif'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.jpeg','.jpg', '.png' and '.gif' formats are allowed.");
                    $(this).val("");
                    document.getElementById('fileName3').value = "";

                }
                else {
                    document.getElementById('fileName3').value = $(this).val();
                }

            });

            $('#<%=FileUpload4.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png', 'gif'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.jpeg','.jpg', '.png' and '.gif' formats are allowed.");
                    $(this).val("");
                    document.getElementById('fileName4').value = "";

                }
                else {
                    document.getElementById('fileName4').value = $(this).val();
                }

            });

            $('#<%=FileUpload5.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png', 'gif'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.jpeg','.jpg', '.png' and '.gif' formats are allowed.");
                    $(this).val("");
                    document.getElementById('fileName5').value = "";

                }
                else {
                    document.getElementById('fileName5').value = $(this).val();
                }

            });

            $('#<%=FileUploadVid.ClientID %>').change(function () {
                var fileExtension = ['avi', 'wmv', 'mpg'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.avi','.wmv' and '.mpg' formats are allowed.");
                    $(this).val("");
                    document.getElementById('fileVideo').value = "";

                }
                else {
                    document.getElementById('fileVideo').value = $(this).val();
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
                <div style="font-size: 16px; font-weight: bolder; padding-left: 30px; font-family: 'Century Gothic';">POST INQUIRY</div>
                <div id="divErrorMessage" style="font-family: 'Century Gothic';color:red;font-weight:bold;
                                             padding-left: 50px; padding-top: 30px;" runat="server"></div>
                <div style="padding-left: 50px;">

                    <table style="font-family: 'Century Gothic'">
                        <tr>
                            <td colspan="2">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px; height: 40px; font-size: 16px; font-weight: normal;">Inquiry Title 
                            </td>
                            <td>
                                <input type="text" id="txtQuoteTitle" name="txtQuoteTitle" runat="server" maxlength="50" class="InputTextbox"
                                    style="height:23px;width:350px;" 
                                     />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px; height: 75px; font-size: 16px; font-weight: 400;">Inquiry Description 
                            </td>
                            <td>
                                <textarea id="txtQuoteDesc" name="txtQuoteDesc" runat="server" maxlength="1000" 
                                    class="InputTextbox"
                                    style="height: 60px; width: 350px;"
                                    ></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px; height: 40px; font-size: 16px; font-weight: 400;">Inquiry Category 
                            </td>
                            <td>
                                <select id="ddlCategory" name="ddlCategory" runat="server" class="ServeDropdownlist" style=" height: 25px; width: 350px;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 16px; font-weight: normal;">Upload Photos
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td style="">
                                            <input type="text" id="fileName1" name="fileName1" class="InputTextbox" 
                                                style="height: 23px; width: 350px;" readonly="readonly" />&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <div class="file_input_div">
                                                <input type="button" value="Browse..." class="file_input_button" />
                                                <input id="FileUpload1" runat="server" name="FileUpload1" type="file" class="file_input_hidden"  />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: small; font-weight: normal;">
                            (each max 50 KB)
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td style="">
                                            <input type="text" id="fileName2" class="InputTextbox" style="height: 23px; width: 350px;" readonly="readonly" />&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <div class="file_input_div">
                                                <input type="button" value="Browse..." class="file_input_button" />
                                                <input id="FileUpload2" runat="server" name="FileUpload1" type="file" class="file_input_hidden" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 16px; font-weight: normal;">&nbsp;
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td style="">
                                            <input type="text" id="fileName3" class="InputTextbox" style="height: 23px; width: 350px;" readonly="readonly" />&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <div class="file_input_div">
                                                <input type="button" value="Browse..." class="file_input_button" />
                                                <input id="FileUpload3" runat="server" name="FileUpload1" type="file" class="file_input_hidden" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 16px; font-weight: normal;">&nbsp;
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td style="">
                                            <input type="text" id="fileName4" class="InputTextbox" style="height: 23px; width: 350px;" readonly="readonly" />&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <div class="file_input_div">
                                                <input type="button" value="Browse..." class="file_input_button" />
                                                <input id="FileUpload4" runat="server" name="FileUpload1" type="file" class="file_input_hidden" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 16px; font-weight: normal;">&nbsp;
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td style="height:40px;">
                                            <input type="text" id="fileName5" class="InputTextbox" style="height: 23px; width: 350px;" readonly="readonly" />&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <div class="file_input_div">
                                                <input type="button" value="Browse..." class="file_input_button" />
                                                <input id="FileUpload5" runat="server" name="FileUpload1" type="file" class="file_input_hidden" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td style="width: 200px; height: 40px; font-size: 16px; font-weight: normal;">Inquiry Video link <br />
                            &nbsp;<span style="font-size:small;">(max 500 KB)</span>

                            </td>
                            <td>
                                <%--<input type="text" id="txtVideolink" name="txtVideolink" runat="server" maxlength="50" class="InputTextbox" 
                                    style="height: 25px; width: 350px;" />--%>
                                <table>
                                    <tr>
                                        <td style="height:40px;">
                                            <input type="text" id="fileVideo" class="InputTextbox" style="height: 23px; width: 350px;" readonly="readonly" />&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <div class="file_input_div">
                                                <input type="button" value="Browse..." class="file_input_button" />
                                                <input id="FileUploadVid" runat="server" name="FileUploadVid" type="file" class="file_input_hidden" />
                                                
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 250px; height: 30px;" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 250px; height: 60px;" colspan="2">
                                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnPost_Click" CssClass="SubmitButton"
                                    Style="width: 120px;" />

                            </td>
                        </tr>
                    </table>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
