<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="PlanToPro.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanToProControl.PlanToPro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        .f-grid-cell.f-grid-cell-ItemName
        .f-grid-cell-inner 
        {
            white-space: normal;
            word-break: break-all;
        }

        .f-grid-cell.f-grid-cell-Chejianclass
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }

        .f-grid-cell.f-grid-cell-BoxRemark
        .f-grid-cell-inner 
        {
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
        <f:PageManager runat="server" AutoSizePanelID="Panel1" ID="PageManager1" OnCustomEvent="PageManager1_CustomEvent"></f:PageManager>
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" ID="Panel1" Layout="HBox">
            <Items>
                <f:Grid runat="server" IsDatabasePaging="true" DataKeyNames="ID,PlanOrderNo" 
                    AllowPaging="true" ID="Grid1" OnPageIndexChange="Grid1_PageIndexChange"
                    AllowSorting="true" OnSort="Grid1_Sort" EnableTextSelection="true" 
                    SummaryPosition="Bottom" EnableSummary="true" SortField="ID" 
                    Title="排产管理" SortDirection="DESC"  ShowHeader="false"
                    OnRowCommand="Grid1_RowCommand"  OnRowDataBound="Grid1_RowDataBound"
                    BoxFlex="1" EnableCheckBoxSelect="true">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:DatePicker runat="server" ID="dp1" Label="计划排产日期" Width="200px" LabelWidth="80px"/>
                                <f:DatePicker runat="server" ID="dp2" Label="结束日期" ShowLabel="false" Width="120px"/>
                                <f:DropDownList runat="server" Label="排产单状态" ID="ddlPlanState" 
                                    AutoSelectFirstItem="false" EnableEdit="true" Width="180px" LabelWidth="92px">
                                    <f:ListItem Text="已排产" Value="已排产" Selected="true"/>
                                    <f:ListItem Text="已下推" Value="已下推" />
                                    <f:ListItem Text="已删除" Value="已删除" />
                                    <f:ListItem Text="全部" Value="全部" />
                                </f:DropDownList>

                                <f:DropDownList runat="server" Label="排产车间" ID="ddlPosition" 
                                    AutoSelectFirstItem="true" EnableEdit="false" Width="250px" LabelWidth="82px">
                                    <f:ListItem Text="03小包装-小袋" Value="03小包装-小袋" />
                                    <f:ListItem Text="03小包装-罐" Value="03小包装-罐" />
                                    <f:ListItem Text="03小包装-每日坚果" Value="03小包装-每日坚果" />
                                    <f:ListItem Text="07小包装-小袋" Value="07小包装-小袋" />
                                    <f:ListItem Text="07小包装-罐" Value="07小包装-罐" />
                                    <f:ListItem Text="07小包装-每日坚果" Value="07小包装-每日坚果" />
                                  
                                </f:DropDownList>

                                <f:TextBox runat="server" EmptyText="关键词搜索" ID="tbxSearch" MarginLeft="10px" Width="203px"/>
                                <f:ToolbarSeparator runat="server"/>
                                <f:Button runat="server" ID="btnExcel" Icon="PageExcel" Text="导出" OnClick="btnExcel_Click" DisableControlBeforePostBack="false" EnableAjax="false"></f:Button>

                            </Items>
                        </f:Toolbar>

                        <f:Toolbar runat="server">
                            <Items>
                                <f:TextBox runat="server" Label="排产单号" ID="tbxOrderNo" Width="330px" LabelWidth="80px"></f:TextBox>

                                <f:TextBox runat="server" Label="产品名称" ID="tbxname"  Width="390px" LabelWidth="90px"></f:TextBox>
                                <%--<f:TextBox runat="server" Label="规格" ID="tbxspec" Width="200px" LabelWidth="80px"></f:TextBox>--%>
                                <%--<f:TextBox runat="server" Label="批号" ID="tbxprovidername" Width="200px" LabelWidth="80px"></f:TextBox>--%>
                                <%--<f:TextBox runat="server" Label="厂家型号" ID="tbxmodel" Width="190px" LabelWidth="70px"></f:TextBox>
                                <f:TextBox runat="server" Label="销售型号" ID="tbxinName" Width="190px" LabelWidth="70px"></f:TextBox>--%>
                                <f:ToolbarSeparator runat="server"/>
                                <f:Button runat="server" ID="btnSearch" Text="搜索" Icon="SystemSearch" OnClick="btnSearch_Click" Type="Submit"></f:Button>
                                <f:Button runat="server" ID="btnAddOrder" Icon="DatabaseAdd" Text="下推生产单"
                                  ConfirmText="确定将选中项下推生产单？" ConfirmTarget="Top" OnClick="btnAddOrder_Click"></f:Button>

                                <f:Button runat="server" ID="btnAddPrintOrder" Icon="Printer" Text="合拼并打印生产单"
                                  ConfirmText="确定将选中项合拼并打印生产单？" ConfirmTarget="Top" OnClick="btnAddPrintOrder_Click"
                                    hidden="true"></f:Button>


                                <f:ToolbarFill runat="server"></f:ToolbarFill>
                                <f:Button runat="server" ID="btnDelete" Icon="DatabaseDelete" Text="删除排产单"
                                    OnClick="btnDelete_Click" Hidden="true"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>


                    <Toolbars>
                        <f:Toolbar runat="server" Hidden="true">
                            <Items>
                                <f:Button ID="btnBack" Text="后退" runat="server" Icon="PageBack"
                                    OnClick="btnBack_Click" Hidden="true" ></f:Button>
                                <f:Button Type="Reset" Text="重置" runat="server" Icon="ArrowRefresh"
                                    ID="btnReset" OnClick="btnReset_Click" Hidden="true"></f:Button>
                               
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField HeaderText="序号" Width="50px" HeaderTextAlign="Center" TextAlign="Center"></f:RowNumberField>
                       
                        <f:BoundField DataField="PlanOrder_XuHao"  SortField="PlanOrder_XuHao" ColumnID="PlanOrder_XuHao" 
                            HeaderText="排产单明细号" Width="200px"   ColumnOrder="0" />
                         <f:BoundField DataField="Chejianclass" SortField="Chejianclass" ColumnID="Chejianclass"
                            HeaderText="排产车间" Width="150px"/>
                         <f:BoundField DataField="ProListNo" SortField="ProListNo" ColumnID="ProListNo" 
                            HeaderText="生产明细单号" Width="180px" ColumnOrder="1" />


                        <f:RenderField DataField="ItemName" SortField="ItemName" ColumnID="ItemName" 
                            HeaderText="产品名称" Width="300px"  ColumnOrder="2" />

                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" ColumnID="DeliveryDate" 
                            HeaderText="交付日期" Width="110px" DataFormatString="{0:yyyy-MM-dd}"/>
                        

                         <f:BoundField DataField="PlanProDate" SortField="PlanProDate" ColumnID="PlanProDate" 
                            HeaderText="计划生产日期" Width="110px" DataFormatString="{0:yyyy-MM-dd}"/>
                         <f:BoundField DataField="PlanProTime" SortField="PlanProTime" ColumnID="PlanProTime" 
                            HeaderText="生产班次" Width="80px" />
                        
                        <f:BoundField DataField="PlanDate" SortField="PlanDate" ColumnID="PlanDate" 
                            HeaderText="计划排产日期" Width="110px" DataFormatString="{0:yyyy-MM-dd}"/>
                        <f:BoundField DataField="PlanTime" SortField="PlanTime" ColumnID="PlanTime" 
                            HeaderText="排产班次" Width="80px" />
                        
                        <f:BoundField DataField="PcCount" SortField="PcCount" ColumnID="PcCount" 
                            HeaderText="排产计划数" Width="110px"/>
                        
                        
                        <f:RenderField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" 
                            HeaderText="箱号" Width="100px" RendererFunction="renderMajor"/>

                        <f:RenderField DataField="BoxName" SortField="BoxName" ColumnID="BoxName" 
                            HeaderText="箱名" Width="120px" RendererFunction="renderMajor"/>

                         <f:RenderField  DataField="BoxRemark" SortField="BoxRemark" ColumnID="BoxRemark" 
                            HeaderText="包材备注" Width="150px" RendererFunction="renderMajor"/>

                        <%--<f:LinkButtonField HeaderText="打印" Width="100px" Icon="Printer" CommandName="Print" ColumnID="print" TextAlign="Center"/>--%>
                        <f:BoundField DataField="PlanOrder_State" SortField="PlanOrder_State" ColumnID="PlanOrder_State" 
                            HeaderText="排产单状态" Width="130px"/>

                          <f:BoundField DataField="JingBanRen" SortField="JingBanRen" ColumnID="JingBanRen" 
                            HeaderText="计划排产人员" Width="130px"/>
                         <f:BoundField DataField="PlanProRen" SortField="PlanProRen" ColumnID="PlanProRen" 
                            HeaderText="生产下推人员" Width="110px" />
                        <f:BoundField DataField="PushProDate" SortField="PushProDate" ColumnID="PushProDate" 
                            HeaderText="生产下推时间" Width="180px" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"/>

                       
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
            function renderMajor(value) {
                return F.formatString('<span data-qtip="{0}">{0}</span>', F.htmlEncode(value));
            }


            function onAdd(event, selectedValue) {
                // 当前点击的下拉列表项
                var cnode = $(event.target);

                // F.confirm是异步函数，直接返回
                F.confirm({
                    message: '确定将选中项合拼生产单？',
                    ok: function () {
                        // 重新点击
                        F.noEvent(function () {
                            cnode.click();
                        });
                    },
                    cancel: function () {
                        // 啥也不做
                    }
                });

                // 需要显式的返回 false，来阻止执行返回的脚本
                return false;
            }




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
