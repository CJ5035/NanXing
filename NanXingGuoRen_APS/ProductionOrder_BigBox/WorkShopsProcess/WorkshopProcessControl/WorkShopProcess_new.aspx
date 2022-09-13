﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkShopProcess_new.aspx.cs" 
    Inherits="NanXingGuoRen_APS.ProductionOrder.WorkShopsProcess.WorkShopProcessControl.WorkShopProcess_new" %>

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
                        <f:TextBox ID="tbxName" runat="server" Label="车间名称" Required="true" ShowRedStar="true">
                        </f:TextBox>
                         <f:NumberBox ID="tbxSort" runat="server" Label="车间排序" Required="true" ShowRedStar="true">
                        </f:NumberBox>
                        <f:DropDownList runat="server" ID="ddl_ProcessClass" Label="车间分组" Required="true" ShowRedStar="true"
                             AutoSelectFirstItem="false"></f:DropDownList>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>