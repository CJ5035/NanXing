<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ProductionIndex.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.ProductControl.ProductionIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        .f-grid-cell.f-grid-cell-ItemNameStr
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }

        .f-grid-cell.f-grid-cell-Workshops
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }
         .f-grid-cell[data-color=color1] {
            /*background-color: #fff;*/
            color: #990033;
        }
        .f-grid-cell[data-color=color2] {
            /*background-color: #fff;*/
            color: #282523;
        }
        .f-grid-cell[data-color=color3] {
            /*background-color: #fff;*/
            color: #00a03e;
        }

    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" ID="Panel1" Layout="HBox">
            <Items>
                <f:Grid runat="server" IsDatabasePaging="true" 
                    DataKeyNames="ID,ProPlanOrderlists_ID,PlanOrderNo" 
                    AllowPaging="true" ID="Grid1" OnPageIndexChange="Grid1_PageIndexChange"
                    AllowSorting="true" OnSort="Grid1_Sort" EnableTextSelection="true" 
                    SummaryPosition="Bottom" EnableSummary="true" SortField="Optdate" 
                    Title="生产管理" SortDirection="DESC" 
                    EnableRowDoubleClickEvent="true" 
                    OnRowCommand="Grid1_RowCommand"  OnRowDataBound="Grid1_RowDataBound"
                    BoxFlex="1" EnableCheckBoxSelect="false">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:DatePicker runat="server" ID="dp1" Label="交付日期" Width="200px" LabelWidth="80px"/>
                                <f:DatePicker runat="server" ID="dp2" Label="结束日期" ShowLabel="false" Width="120px"/>
                                 <f:DropDownList runat="server" Label="打印状态" ID="ddlPrintState" 
                                    AutoSelectFirstItem="true" EnableEdit="true" Width="200px" LabelWidth="80px">
                                    <f:ListItem Text="未打印" Value="未打印" />
                                    <f:ListItem Text="已打印" Value="已打印" />
                                    <f:ListItem Text="全部" Value="全部" />
                                </f:DropDownList>
                                <f:DropDownList runat="server" Label="生产状态" ID="ddlProductState" 
                                    AutoSelectFirstItem="true" EnableEdit="true" Width="180px" LabelWidth="82px">
                                    <f:ListItem Text="未生产" Value="未生产" />
                                    <f:ListItem Text="生产中" Value="生产中" />
                                    <f:ListItem Text="已完成" Value="已完成" />
                                    <f:ListItem Text="全部" Value="全部" />
                                </f:DropDownList>
                                <f:DropDownList runat="server" Label="排产车间" ID="ddlPosition" 
                                    AutoSelectFirstItem="false" EnableEdit="false" Width="250px" LabelWidth="82px">
                                    <f:ListItem Text="全部" Value="全部" Selected="true" />
                                    <f:ListItem Text="03小包装-小袋" Value="03小包装-小袋" />
                                    <f:ListItem Text="03小包装-罐" Value="03小包装-罐" />
                                    <f:ListItem Text="03小包装-每日坚果" Value="03小包装-每日坚果" />
                                    <f:ListItem Text="07小包装-小袋" Value="07小包装-小袋" />
                                    <f:ListItem Text="07小包装-罐" Value="07小包装-罐" />
                                    <f:ListItem Text="07小包装-每日坚果" Value="07小包装-每日坚果" />
                                  
                                </f:DropDownList>
                            </Items>
                        </f:Toolbar>

                        <f:Toolbar runat="server">
                            <Items>
                                <f:TextBox runat="server" Label="排产单号" ID="tbxOrderNo" Width="330px" LabelWidth="80px"></f:TextBox>

                                <f:TextBox runat="server" Label="产品名称" ID="tbxname"  Width="390px" LabelWidth="80px"></f:TextBox>
                                <%--<f:TextBox runat="server" Label="规格" ID="tbxspec" Width="200px" LabelWidth="80px"></f:TextBox>--%>
                                <%--<f:TextBox runat="server" Label="批号" ID="tbxprovidername" Width="200px" LabelWidth="80px"></f:TextBox>--%>
                                <%--<f:TextBox runat="server" Label="厂家型号" ID="tbxmodel" Width="190px" LabelWidth="70px"></f:TextBox>
                                <f:TextBox runat="server" Label="销售型号" ID="tbxinName" Width="190px" LabelWidth="70px"></f:TextBox>--%>
                                <f:TextBox runat="server" EmptyText="关键词搜索" ID="tbxSearch" MarginLeft="10px" Width="203px"/>

                                <f:ToolbarSeparator runat="server"/>
                                <f:Button runat="server" ID="btnSearch" Text="搜索" Icon="SystemSearch" OnClick="btnSearch_Click" Type="Submit"></f:Button>
                                 <f:Button runat="server" ID="btnExcel" Icon="PageExcel" Text="导出" OnClick="btnExcel_Click" DisableControlBeforePostBack="false" EnableAjax="false"></f:Button>

                                 <f:Button runat="server" ID="btnEditPro" Icon="ApplicationAdd" 
                                     Text="编辑生产单" OnClick="btnPushProOrder_Click"></f:Button>

                                 <f:Button runat="server" ID="btnPrint" Icon="Printer" Text="打印生产单" OnClick="btnPrint_Click"></f:Button>
                                
                            </Items>
                        </f:Toolbar>
                    </Toolbars>


                    <Toolbars>
                        <f:Toolbar runat="server" Hidden="true">
                            <Items>
                                <f:Button ID="btnBack" Text="后退" runat="server" Icon="PageBack" OnClick="btnBack_Click" Hidden="true"></f:Button>
                                <f:Button Type="Reset" Text="重置" runat="server" Icon="ArrowRefresh" ID="btnReset" OnClick="btnReset_Click" Hidden="true"></f:Button>
                               <%--<f:Button runat="server" ID="btnAddOrder" Icon="DatabaseAdd" Text="新增排产单" OnClick="btnAddOrder_Click"></f:Button>--%>
                                <f:ToolbarFill runat="server"></f:ToolbarFill>
                                <f:Button runat="server" ID="btnDelete" Icon="DatabaseDelete" Text="删除排产单" OnClick="btnDelete_Click" Hidden="true"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField HeaderText="序号" Width="50px" HeaderTextAlign="Center" TextAlign="Center"></f:RowNumberField>
                        <f:BoundField DataField="ProductOrderNo"  SortField="ProductOrderNo"
                            ColumnID="ProductOrderNo" HeaderText="生产单号" Width="200px"/>
                        
                        <f:BoundField DataField="Optdate" SortField="Optdate" ColumnID="Optdate" 
                            HeaderText="生成日期" Width="120px" DataFormatString="{0:yyyy-MM-dd}"/>
                        <f:BoundField DataField="ItemName" SortField="ItemName" ColumnID="ItemName"
                            HeaderText="产品名称" Width="300px"/>
                        <f:BoundField DataField="Workshops" SortField="Workshops" ColumnID="Workshops"
                            HeaderText="排产车间" Width="120px"/>
                        <f:BoundField DataField="Priority" SortField="Priority" ColumnID="Priority"
                            HeaderText="紧急状态" Width="100px" Hidden="true"/>
                        
                        <f:BoundField DataField="NoWorkCount" SortField="NoWorkCount" ColumnID="NoWorkCount"
                            HeaderText="总欠数" Width="100px"/>
                        <f:BoundField DataField="WorkCount" SortField="WorkCount" ColumnID="WorkCount"
                            HeaderText="已生产数" Width="100px"/>
                        <f:BoundField DataField="BatchNo" SortField="BatchNo" ColumnID="BatchNo"
                            HeaderText="批号" Width="100px"  Hidden="true"/>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo"
                            HeaderText="箱号" Width="100px" Hidden="true"/>
                        <f:BoundField DataField="Remark" SortField="Remark" ColumnID="Remark"
                            HeaderText="备注" Width="200px" />
                        
                        <f:BoundField DataField="PrintState" SortField="PrintState" ColumnID="PrintState"
                            HeaderText="打印状态" Width="90px"/>
                       
                        <%--<f:LinkButtonField HeaderText="打印" Width="100px" Icon="Printer" CommandName="Print" ColumnID="print" TextAlign="Center"/>--%>
                        <f:BoundField DataField="ProductState" SortField="ProductState" ColumnID="ProductState"
                            HeaderText="生产状态" Width="90px"/>
                        <f:BoundField DataField="ProOrder_XuHao"  SortField="ProOrder_XuHao"
                            ColumnID="ProOrder_XuHao" HeaderText="生产单序号" Width="200px" Hidden="true"/>
                        <%-- <f:RenderField DataField="isClose" SortField="isClose" Width="100px" HeaderText="完结状态" ColumnID="isClose" RendererFunction="RenderClose"></f:RenderField>--%>
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
