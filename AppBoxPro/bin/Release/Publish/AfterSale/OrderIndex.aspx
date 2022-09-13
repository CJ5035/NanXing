<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderIndex.aspx.cs" Inherits="LCC_PNM.AfterSale.OrderIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="panel1"></f:PageManager>
        <f:Panel runat="server" Layout="VBox" ID="panel1" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:Panel runat="server" ShowBorder="false" ShowHeader="false">
                    <Items>
                        <f:Form runat="server" ID="form2" ShowBorder="true" ShowHeader="false" BodyPadding="20px">
                            <Toolbars>
                                <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Right">
                                    <Items>
                                        <f:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" ValidateForms="form2" Text="提交"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Items>
                                <f:FormRow>
                                    <Items>
                                        <f:DropDownList runat="server" ID="ddlChineseName" Label="实施人员" Required="true"></f:DropDownList>
                                        <f:DropDownList EnableEdit="true" ForceSelection="true" runat="server" ID="ddlClient" Label="客户" Required="true"></f:DropDownList>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:TextBox runat="server" ID="tbxContact" Label="联系人" Required="true"></f:TextBox>
                                        <f:TextBox runat="server" ID="tbxAddress" Label="联系地址" Required="true"></f:TextBox>
                                    </Items>
                                </f:FormRow>

                                <f:FormRow>
                                    <Items>
                                        <f:TextArea runat="server" ID="tbxDescribe" Label="服务需求描述" Required="true"></f:TextArea>
                                        <f:RadioButtonList runat="server" Label="服务性质" ID="rblNature">
                                            <f:RadioItem Selected="true" Text="保内免费服务" Value="保内免费服务" />
                                            <f:RadioItem Text="扩展免费服务" Value="扩展免费服务" />
                                            <f:RadioItem Text="保外收费服务" Value="保外收费服务" />
                                            <f:RadioItem Text="其他收费服务" Value="其他收费服务" />
                                        </f:RadioButtonList>
                                    </Items>
                                </f:FormRow>
                            </Items>
                        </f:Form>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ShowBorder="false" ShowHeader="false">
                    <Items>
                        <f:Grid runat="server" ID="Grid1" DataKeyNames="ID" AllowSorting="true" OnSort="Grid1_Sort" SortField="ID"
                            SortDirection="ASC" AllowPaging="true" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange" EnableTextSelection="true" Title="工单" PageSize="8" Height="500px" OnRowCommand="Grid1_RowCommand">
                            <Columns>
                                <f:RowNumberField></f:RowNumberField>
                                <f:BoundField HeaderText="实施人员" DataField="ChineseName"></f:BoundField>
                                <f:BoundField HeaderText="客户" DataField="Name"  Width="220px"></f:BoundField>
                                <f:GroupField HeaderText="上门服务内容" HeaderTextAlign="Center">
                                    <Columns>
                                        <f:BoundField HeaderText="服务培训描述" DataField="train_desc" Width="120px"></f:BoundField>
                                        <f:BoundField HeaderText="培训岗位对象" DataField="train_instance"></f:BoundField>
                                        <f:BoundField HeaderText="设备信息" DataField="equip_info"></f:BoundField>
                                    </Columns>
                                </f:GroupField>

                                <f:GroupField HeaderText="客户意见" HeaderTextAlign="Center">
                                    <Columns>
                                        <f:BoundField HeaderText="解决问题内容" DataField="soulv_content"></f:BoundField>
                                        <f:BoundField HeaderText="服务评价" DataField="evaluate"></f:BoundField>
                                    </Columns>
                                </f:GroupField>
                                <f:BoundField HeaderText="评分(标准:5)" DataField="grade" Width="120px"  HeaderTextAlign="Center" TextAlign="Center"></f:BoundField>
                                <f:BoundField HeaderText="联系人" DataField="contact"></f:BoundField>
                                <f:BoundField HeaderText="联系地址" DataField="address"></f:BoundField>
                                <f:BoundField HeaderText="服务需求描述" DataField="order_desc"></f:BoundField>
                                <f:BoundField HeaderText="服务性质" DataField="nature"></f:BoundField>

                                <f:RenderField HeaderText="状态" DataField="state" RendererFunction="RenderState" SortField="state"></f:RenderField>
                                <f:ImageField HeaderText="现场图片" DataImageUrlField="imagename" ImageHeight="100px"></f:ImageField>
                                <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除"
                            ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>

        <script>

            function RenderState(value) {
                if (value == '01') {
                    return '已下达'
                }
                if (value == '02') {
                    return '处理完成'
                }
            }

        </script>
    </form>
</body>
</html>
