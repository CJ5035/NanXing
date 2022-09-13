<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemInfoIndex.aspx.cs" Inherits="NanXingGuoRen_WMS.ProductionOrder.ItemInfoControl.ItemInfoIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        .f-grid-cell.f-grid-cell-ItemName
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }
        .f-grid-cell.f-grid-cell-InName
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }
        .f-grid-cell.f-grid-cell-MaterialItem
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }

        .f-grid-cell.f-grid-cell-Workshops
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" ID="Panel1" Layout="HBox">
            <Items>
                <f:Grid runat="server" IsDatabasePaging="true" DataKeyNames="ID,PlanOrderNo" AllowPaging="true" ID="Grid1" OnPageIndexChange="Grid1_PageIndexChange"
                    AllowSorting="true" OnSort="Grid1_Sort" EnableTextSelection="true" SummaryPosition="Bottom" EnableSummary="true" SortField="ID" Title="物料信息"
                    SortDirection="DESC" EnableRowDoubleClickEvent="true" OnRowDoubleClick="Grid1_RowDoubleClick" OnRowCommand="Grid1_RowCommand"
                    BoxFlex="1" EnableCheckBoxSelect="true">
                    <Toolbars>
                        <f:Toolbar runat="server" Hidden="true">
                            <Items>
                               <%-- <f:DatePicker runat="server" ID="dp1" Label="排产日期" Width="200px" LabelWidth="80px"/>
                                <f:DatePicker runat="server" ID="dp2" Label="结束日期" ShowLabel="false" Width="120px"/>--%>
                                <%--<f:DropDownList runat="server" Label="排产状态" ID="ddlPositionClass" AutoSelectFirstItem="false" EnableEdit="true" Width="200px" LabelWidth="80px">
                                    <f:ListItem Text="未开始" Value="未开始" />
                                    <f:ListItem Text="生产中" Value="生产中" />
                                    <f:ListItem Text="已完成" Value="已完成" />
                                </f:DropDownList>--%>
                            </Items>
                        </f:Toolbar>

                        <f:Toolbar runat="server">
                            <Items>
                                <%--<f:TextBox runat="server" Label="排产单号" ID="tbxOrderNo" Width="330px" LabelWidth="80px"></f:TextBox>--%>

                                <f:TextBox runat="server" Label="产品名称" ID="tbxname" Width="200px" LabelWidth="80px"/>
                                <f:TextBox runat="server" Label="产品别名" ID="tbxInName" Width="200px" LabelWidth="80px"/>
                                <f:TextBox runat="server" Label="产品原料" ID="tbxMaterName" Width="200px" LabelWidth="80px"/>

                                <f:TextBox runat="server" Label="规格" ID="tbxspec" Width="200px" LabelWidth="80px"/>

                                <f:TextBox runat="server" EmptyText="关键词搜索" ID="tbxSearch"/>

                                <%--<f:TextBox runat="server" Label="批号" ID="tbxprovidername" Width="200px" LabelWidth="80px"></f:TextBox>--%>
                                <%--<f:TextBox runat="server" Label="厂家型号" ID="tbxmodel" Width="190px" LabelWidth="70px"></f:TextBox>
                                <f:TextBox runat="server" Label="销售型号" ID="tbxinName" Width="190px" LabelWidth="70px"></f:TextBox>--%>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>


                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                               
                                <f:ToolbarSeparator runat="server"></f:ToolbarSeparator>
                                <f:Button runat="server" ID="btnSearch" Text="搜索" Icon="SystemSearch" OnClick="btnSearch_Click" Type="Submit"></f:Button>
                                <f:Button ID="btnBack" Text="后退" runat="server" Icon="PageBack" OnClick="btnBack_Click" Hidden="true"></f:Button>
                                <f:Button Type="Reset" Text="重置" runat="server" Icon="ArrowRefresh" ID="btnReset" OnClick="btnReset_Click" Hidden="true"></f:Button>
                                <f:Button runat="server" ID="btnExcel" Icon="PageExcel" Text="导出" OnClick="btnExcel_Click" DisableControlBeforePostBack="false" EnableAjax="false"></f:Button>
                                
                                <f:Button runat="server" ID="btnAddOrder" Icon="DatabaseAdd" Text="修改物料信息" OnClick="btnAddOrder_Click"></f:Button>
                                <f:ToolbarFill runat="server"></f:ToolbarFill>
                                <f:Button runat="server" ID="btnDelete" Icon="DatabaseDelete" Text="删除排产单" OnClick="btnDelete_Click" Hidden="true"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField HeaderText="序号" Width="50px" HeaderTextAlign="Center" TextAlign="Center"></f:RowNumberField>
                        <f:BoundField DataField="ItemNo" SortField="ItemNo" ColumnID="ItemNo" HeaderText="物料编号" Width="200px"/>
                        <f:BoundField DataField="ItemName" SortField="ItemName" ColumnID="ItemName" HeaderText="物料名称" Width="250px"/>
                        <f:BoundField DataField="InName" SortField="InName" ColumnID="InName" HeaderText="产品别名" Width="250px"/>
                        <f:BoundField DataField="MaterialItem" SortField="MaterialItem" ColumnID="MaterialItem" HeaderText="原料名称" Width="250px"/>

                        <f:BoundField DataField="Spec" SortField="Spec" ColumnID="Spec" HeaderText="规格" Width="100px"/>
                        <f:BoundField DataField="MainUtil" SortField="MainUtil" ColumnID="MainUtil" HeaderText="主单位" Width="90px"/>
                        <f:BoundField DataField="SlaveUtil" SortField="SlaveUtil" ColumnID="SlaveUtil" HeaderText="辅单位" Width="90px"/>
                        <f:BoundField DataField="ConvertRate" SortField="ConvertRate" ColumnID="ConvertRate" HeaderText="转换率" Width="90px"/>

                        <f:BoundField DataField="Workshops" SortField="Workshops" ColumnID="Workshops" HeaderText="排产车间" Width="250px"/>

                        <f:BoundField DataField="ModTime_CRM" SortField="ModTime_CRM" ColumnID="ModTime_CRM" HeaderText="CRM修改日期" Width="130px" DataFormatString="{0:yyyy-MM-dd}"/>
                        <f:BoundField DataField="UpdateTime" SortField="UpdateTime" ColumnID="UpdateTime" HeaderText="APS更新日期" Width="130px" DataFormatString="{0:yyyy-MM-dd}"/>

                       
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window runat="server" ID="Window1" EnableIFrame="true" Height="600px" Width="500px" Title="" Hidden="true"
            OnClose="Window1_Close"  EnableMaximize="false" EnableMinimize="false" EnableResize="false"></f:Window>

        <f:Window runat="server" ID="Window2" EnableIFrame="true" Height="900px" Width="1500px" Title="" Hidden="true" 
            EnableMaximize="true" EnableMinimize="true" OnClose="Window2_Close"  EnableResize="true"></f:Window>

        <script src="../js/LodopFuncs.js"></script>
        <script>
            function RenderPrice(value) {
                return F.addCommas(value.toFixed(2));
            }

            function RenderClose(value) {
                if (value == 0)
                    return '未完结';
                else
                    return '已完结';
            }
        </script>

        <script type="text/javascript">
            function Print(PurOrderDto) {
                console.log(PurOrderDto);
                var LODOP = getLodop();
                LODOP.PRINT_INITA(0, 0, 2100, 2970, "自定义");
                LODOP.SET_PRINT_PAGESIZE(0, 2100, 2970, 'A4');
                LODOP.SET_PRINT_MODE("PRINT_PAGE_PERCENT", "85%");
                var header = PurOrderDto.title;
                var printList = PurOrderDto.pol;
                //for (var z = 0; z < PurOrderDto.length; z++) {


                //每页记录数
                var pageSize = 10;
                //表格中字体大小
                var fontSize = 12;
                //需要多少页
                var pageCount = Math.ceil(printList.length / pageSize);
                LODOP.NewPage();
                //表头
                LODOP.ADD_PRINT_TEXT(12, 290, 377, 45, PurOrderDto.title);
                LODOP.SET_PRINT_STYLEA(0, "FontSize", 23);
                LODOP.SET_PRINT_STYLEA(0, "Alignment", 2);
                for (var j = 0; j < pageCount; j++) {
                    var maxPage = (j + 1) * pageSize;//最后一页的最后索引
                    var minPage = j * pageSize;//开始索引
                    var top = 363;
                    var height = 64;
                    //本页的明细数
                    var singlePageCount = 0;
                    for (var i = minPage; i < maxPage; i++) {
                        
                        if (i == printList.length) {
                            if (i < 3)
                            {
                                singlePageCount++;
                                let currentTop = top + i % pageSize * height;
                                LODOP.ADD_PRINT_RECT(currentTop, 31,804, 65, 0, 1);
                                LODOP.ADD_PRINT_RECT(currentTop, 83, 100, 65, 0, 1);
                                LODOP.ADD_PRINT_RECT(currentTop, 330, 197, 65, 0, 1);
                                LODOP.ADD_PRINT_RECT(currentTop, 592, 59, 65, 0, 1);

                            }else
                                break;
                        }
                        else
                        {
                            singlePageCount++;

                            let currentTop = top + i % pageSize * height;

                            LODOP.ADD_PRINT_RECT(currentTop, 31,804, 65, 0, 1);
                            LODOP.ADD_PRINT_RECT(currentTop, 83, 100, 65, 0, 1);
                            LODOP.ADD_PRINT_RECT(currentTop, 330, 197, 65, 0, 1);
                            LODOP.ADD_PRINT_RECT(currentTop, 592, 59, 65, 0, 1);

                            LODOP.ADD_PRINT_TEXT(currentTop + 20, 31, 52, 29, i + 1);
                            LODOP.SET_PRINT_STYLEA(0, "FontSize", fontSize);
                            LODOP.SET_PRINT_STYLEA(0, "Alignment", 2);
                        }
                    }
                }

                //}
                LODOP.PREVIEW();
            }

        </script>
    </form>
</body>
</html>
