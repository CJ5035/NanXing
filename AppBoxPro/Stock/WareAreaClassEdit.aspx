<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WareAreaClassEdit.aspx.cs" Inherits="NanXingGuoRen_WMS.Stock.WareAreaClassEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
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
                        <f:TextBox ID="tbxName" runat="server" Label="类型名称" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <%--<f:DropDownList ID="tbxBigClass" runat="server" Label="类型分类" Required="true" ShowRedStar="true" AutoSelectFirstItem="false">
                            <f:ListItem Text="硬件" Value="硬件" />
                            <f:ListItem Text="耗材" Value="耗材"/>
                            <f:ListItem Text="其他" Value="其他"/>
                        </f:DropDownList>--%>
                        <f:NumberBox ID="tbxSortIndex" Label="排序" Required="true" ShowRedStar="true" runat="server">
                        </f:NumberBox>
                        <f:TextArea ID="tbxRemark" runat="server" Label="备注">
                        </f:TextArea>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
