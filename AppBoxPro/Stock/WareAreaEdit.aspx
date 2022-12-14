<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WareAreaEdit.aspx.cs"
    Inherits="NanXingGuoRen_WMS.Stock.WareAreaEdit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false"  AutoScroll="true" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                            Text="关闭">
                        </f:Button>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                            OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
                    BodyPadding="10px"  Title="SimpleForm">
                    <Items>
                        <f:TextBox ID="tbxName" runat="server" Label="库区编号" Required="true" ShowRedStar="true"/>
                        <f:DropDownList ID="ddl_WareHouse" runat="server" Label="所属仓库" Required="true" ShowRedStar="true" AutoSelectFirstItem="false">
                            <%--<f:ListItem Text="硬件" Value="硬件"/>
                            <f:ListItem Text="耗材" Value="耗材"/>
                            <f:ListItem Text="其他" Value="其他"/>--%>
                        </f:DropDownList>

                        <f:DropDownList ID="ddl_WareAreaClass" runat="server" Label="库区类型" Required="true" ShowRedStar="true" AutoSelectFirstItem="false">
                            <%--
                            <f:ListItem Text="硬件" Value="硬件"/>
                            <f:ListItem Text="耗材" Value="耗材"/>
                            <f:ListItem Text="其他" Value="其他"/>
                            --%>
                        </f:DropDownList>

                        <%--<f:NumberBox ID="tbxSortIndex" Label="排序" Required="true" ShowRedStar="true" runat="server"/>--%>
                        <f:TextArea ID="tbxRemark" runat="server" Label="备注"/>
                        <f:CheckBox ID="cbStates"  runat="server" Label="启用" />

                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
