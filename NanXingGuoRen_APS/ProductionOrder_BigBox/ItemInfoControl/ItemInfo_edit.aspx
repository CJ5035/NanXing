<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemInfo_edit.aspx.cs"
    Inherits="NanXingGuoRen_APS.ProductionOrder.ItemInfoControl.ItemInfo_edit" %>

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
                       
                        <f:TextBox ID="tbxItemNo" runat="server" Label="物料编号" Enabled="false">
                        </f:TextBox>

                        <f:TextBox ID="tbxItemName" runat="server" Label="物料名称" Enabled="false">
                        </f:TextBox>

                         <f:TextBox ID="tbxInName" runat="server" Label="物料别名" Required="true" ShowRedStar="true">
                        </f:TextBox>
                         <f:TextBox ID="tbxMaterialItem" runat="server" Label="原料名称" Required="true" ShowRedStar="true">
                        </f:TextBox>


                        <f:DropDownList runat="server" ID="DropDownList1"
                            Label="选择工序"  AutoSelectFirstItem="false"
                            Required="true" ShowRedStar="true" 
                            EnableGroup="true" EnableMultiSelect="true" EnableCheckBoxSelect="true">
                        </f:DropDownList>

                        
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
