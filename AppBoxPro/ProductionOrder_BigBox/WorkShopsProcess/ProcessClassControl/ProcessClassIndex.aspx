<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessClassIndex.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder.WorkShopsProcess.ProcessClassControl.ProcessClassIndex" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="5px" 
         ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" ShowHeader="false" Title="工序分组管理">
        <Items>
            <f:Form ID="Form2" runat="server" Height="36px" BodyPadding="5px" ShowHeader="false"
                ShowBorder="false" >
                <Rows>
                    <f:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在工序分组中搜索"
                                Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false" OnTrigger2Click="ttbSearchMessage_Trigger2Click"
                                OnTrigger1Click="ttbSearchMessage_Trigger1Click">
                            </f:TwinTriggerBox>
                            <f:Label runat="server">
                            </f:Label>
                            <f:Label ID="Label1" runat="server">
                            </f:Label>
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                EnableCheckBoxSelect="true"  DataKeyNames="ID" AllowSorting="true"
                OnSort="Grid1_Sort"  SortField="ProcessSort" SortDirection="ASC" AllowPaging="true"
                IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound" OnRowCommand="Grid1_RowCommand"
                OnPageIndexChange="Grid1_PageIndexChange">
                <Toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <%--<f:Button ID="btnDeleteSelected" Icon="Delete" runat="server" Text="删除选中记录" OnClick="btnDeleteSelected_Click">
                            </f:Button>--%>
                            <%-- <f:ToolbarFill ID="ToolbarFill1" runat="server">
                            </f:ToolbarFill>--%>
                            <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增工序分组"/>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Columns>
                    <f:RowNumberField />
                    <f:BoundField DataField="ProcessClassName" SortField="ProcessClassName" Width="200px" HeaderText="工序组名" />
                    <f:BoundField DataField="ProcessSort" SortField="ProcessSort" Width="100px" HeaderText="分组排序" />

                    <%--<f:CheckBoxField DataField="Enabled" HeaderText="启用" RenderAsStaticField="false"
                        AutoPostBack="true" CommandName="Enabled" Width="80px" />--%>
                  
                    <f:BoundField DataField="ProcessReamrk" ExpandUnusedSpace="true" HeaderText="备注" />
                    <f:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑" WindowID="Window1"
                        Title="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="~/ProductionOrder/WorkShopsProcess/ProcessClassControl/ProcessClass_edit.aspx?id={0}" Width="50px" />
                    <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除" ConfirmText="确定删除此工序类型记录？"
                        ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                </Columns>
            </f:Grid>
        </Items>
    </f:Panel>
    <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true" Target="Top"
        EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="900px" Height="500px" OnClose="Window1_Close">
    </f:Window>
    </form>
    
    <script>
        function RenderHeji(value) {
            console.log(value);
           
            if (value=="True")
                return "启用";
            else {
                return "停用";
            }
        }
        
    </script>

</body>
</html>
