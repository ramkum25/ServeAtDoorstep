<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Membership.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.Membership" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:content ID="c1" runat="server" ContentPlaceHolderID="MainContent">

        <style>
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <script type="text/javascript">

        function ConfirmationBox(membername) {

            var result = confirm('Are you sure you want to delete ' + membername + ' Details?');
            if (result) {

                return true;
            }
            else {
                return false;
            }
        }

    </script>

    <ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
    </ajax:ToolkitScriptManager>

    <div style="padding-top: 75px; padding-left: 200px">
        <table>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <span style="font-size: 18px; font-weight: bolder;">Membership Details </span>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 10px; text-align: left;">
                    <asp:LinkButton ID="lnkAddMember" runat="server" CssClass="btnRed" Style="width: 130px;" OnClick="lnkAddMember_Click">New Membership</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>

                    <asp:GridView ID="gvMember" runat="server" Width="700px" OnPageIndexChanging="gvMember_PageIndexChanging"
                        OnRowDataBound="gvMember_RowDataBound" AutoGenerateColumns="false"
                        RowStyle-Height="25px" RowStyle-ForeColor="#003300" AllowPaging="true" RowStyle-Wrap="true" HeaderStyle-Wrap="true"
                        OnRowDeleting="gvMember_RowDeleting" OnRowEditing="gvMember_RowEditing" PageSize="50"
                        DataKeyNames="MemberShipID">
                        <Columns>
                            <asp:TemplateField HeaderText="S No" ItemStyle-Height="30px" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MemberShipName" ItemStyle-Height="30px" HeaderText="Name" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="MemberShipType" ItemStyle-Height="30px" HeaderText="Type" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="MemberShipAmount" ItemStyle-Height="30px" HeaderText="Amount" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="MemberShipDays" ItemStyle-Height="30px" HeaderText="Days" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="CreatedOn" ItemStyle-Height="30px" HeaderText="Created On" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:TemplateField>
                                <HeaderTemplate>Action </HeaderTemplate>
                                <HeaderStyle BackColor="#ff8000" Width="75px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" OnClick="lnkEditImg_Click" ImageUrl="~/Image/Edit.jpg" ToolTip="Edit" Height="20px" Width="20px" />
                                    <asp:ImageButton ID="imgbtnDelete" Text="Edit" OnClick="lnkDelImg_Click" runat="server" ImageUrl="~/Image/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>

    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <p>&nbsp;</p>
    <ajax:ModalPopupExtender ID="ModalPopupViewMessage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Width="500px" Style="display: none">
        <div>
            <div style="text-align: right; padding-left: 20px;">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/image/close.png" Height="20px" Width="20px" OnClick="imgClose_Click" />
            </div>
            <table>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div id="divErrorMsg" runat="server" style="color: red; font-weight: 700; border-radius: 5px,5px;"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 70px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label1" runat="server" Text="Membership Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMemberName" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label5" runat="server" Text="Member Type"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMemberType" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label6" runat="server" Text="Amount"></asp:Label>
                    </td>
                    <td>
                        $&nbsp;<asp:TextBox ID="txtAmount" runat="server" CssClass="ServeTextbox" Style="width: 200px;" Text="0.00"
                            onblur="extractNumber(this,2,true);blockInvalid(this);" onkeyup="extractNumber(this,2,true);" 
                            onkeypress="return blockNonNumbers(this, event, true, true);"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label7" runat="server" Text="No of Days"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDays" runat="server" Text="0" CssClass="ServeTextbox" Style="width: 200px" onkeypress="return isNumberKey(event);"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="float: right; width: 150px;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnGreen" Width="100px" OnClick="btnSave_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnGreen" Width="100px" OnClick="btnCancel_Click" />
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                
            </table>
            <asp:HiddenField ID="hdnMemberId" runat="server" Value="0" />
        </div>
    </asp:Panel>
    <script type="text/javascript">
        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : evt.keyCode;

            //if (charCode == 8 || charCode == 13 || charCode == 99 || charCode == 118 || charCode == 46)
            //{ return true; }
            if (charCode > 31 && (charCode < 48 || charCode > 57))
            { return false; }
            return true;
        }
        function extractNumber(obj, decimalPlaces, allowNegative)
        {
            var temp = obj.value;

            // avoid changing things if already formatted correctly
            var reg0Str = '[0-9]*';
            if (decimalPlaces > 0) {
                reg0Str += '\[\,\.]?[0-9]{0,' + decimalPlaces + '}';
            } else if (decimalPlaces < 0) {
                reg0Str += '\[\,\.]?[0-9]*';
            }
            reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
            reg0Str = reg0Str + '$';
            var reg0 = new RegExp(reg0Str);
            if (reg0.test(temp)) return true;

            // first replace all non numbers
            var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (decimalPlaces != 0 ? ',' : '') + (allowNegative ? '-' : '') + ']';
            var reg1 = new RegExp(reg1Str, 'g');
            temp = temp.replace(reg1, '');

            if (allowNegative) {
                // replace extra negative
                var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
                var reg2 = /-/g;
                temp = temp.replace(reg2, '');
                if (hasNegative) temp = '-' + temp;
            }

            if (decimalPlaces != 0) {
                var reg3 = /[\,\.]/g;
                var reg3Array = reg3.exec(temp);
                if (reg3Array != null) {
                    // keep only first occurrence of .
                    //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
                    var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
                    reg3Right = reg3Right.replace(reg3, '');
                    reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
                    temp = temp.substring(0,reg3Array.index) + '.' + reg3Right;
                }
            }

            obj.value = temp;
        }
        function blockNonNumbers(obj, e, allowDecimal, allowNegative)
        {
            var key;
            var isCtrl = false;
            var keychar;
            var reg;
            if(window.event) {
                key = e.keyCode;
                isCtrl = window.event.ctrlKey
            }
            else if(e.which) {
                key = e.which;
                isCtrl = e.ctrlKey;
            }

            if (isNaN(key)) return true;

            keychar = String.fromCharCode(key);

            // check for backspace or delete, or if Ctrl was pressed
            if (key == 8 || isCtrl)
            {
                return true;
            }

            reg = /\d/;
            var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
            var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;
            var isFirstC = allowDecimal ? keychar == ',' && obj.value.indexOf(',') == -1 : false;
            return isFirstN || isFirstD || isFirstC || reg.test(keychar);
        }
        function blockInvalid(obj)
        {
            var temp=obj.value;
            if(temp=="-")
            {
                temp="";
            }

            if (temp.indexOf(".")==temp.length-1 && temp.indexOf(".")!=-1)
            {
                temp=temp+"00";
            }
            if (temp.indexOf(".")==0)
            {
                temp="0"+temp;
            }
            if (temp.indexOf(".") == 1 && temp.indexOf("-") == 0) {
                temp = temp.replace("-", "-0");
            }
            if (temp.indexOf(",") == temp.length - 1 && temp.indexOf(",") != -1) {
                temp = temp + "00";
            }
            if (temp.indexOf(",") == 0) {
                temp = "0" + temp;
            }
            if (temp.indexOf(",") == 1 && temp.indexOf("-") == 0) {
                temp = temp.replace("-", "-0");
            }
            temp = temp.replace(",", ".");
            obj.value = temp;
        }
        // end of price text-box allow numeric and allow 2 decimal points only
        // onblur="extractNumber(this,2,true);blockInvalid(this);" onkeyup="extractNumber(this,2,true);" onkeypress="return blockNonNumbers(this, event, true, true);">
    </script>
</asp:content>