<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ProductListReport.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.ProductControl.ProductListReport" %>

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

        .f-grid-cell.f-grid-cell-Workshops
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-all;
        }
          .f-grid-cell[data-color=color1] {
            /*background-color: #fff;*/
            color: #CEA307;
        }
        .f-grid-cell[data-color=color2] {
            /*background-color: #fff;*/
            color: #990033;
        }
        .f-grid-cell[data-color=color3] {
            /*background-color: #fff;*/
            color: #00A03E;
        }
        .f-grid-cell[data-color=color4] {
            /*background-color: #fff;*/
            color: #0094ff;
        }
        .f-grid-cell[data-color=color5] {
            /*background-color: #fff;*/
            color: #000000;
        }

    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" ID="Panel1" Layout="HBox">
            <Items>
                <f:Grid runat="server" IsDatabasePaging="true" 
                    DataKeyNames="ID,ProductOrder_XuHao" 
                    AllowPaging="true" ID="Grid1" OnPageIndexChange="Grid1_PageIndexChange"
                    AllowSorting="true" OnSort="Grid1_Sort" EnableTextSelection="true" 
                    SummaryPosition="Bottom" EnableSummary="true" SortField="ProductOrder_XuHao" 
                    Title="生产明细报表" SortDirection="DESC" 
                    EnableRowDoubleClickEvent="true" 
                    OnRowCommand="Grid1_RowCommand"  OnRowDataBound="Grid1_RowDataBound"
                    BoxFlex="1" EnableCheckBoxSelect="false">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:DropDownList runat="server" Label="日期类型" ID="DDL_DateType" ShowLabel="false" 
                                    AutoSelectFirstItem="true" EnableEdit="true" Width="90px" LabelWidth="80px">
                                    <f:ListItem Text="计划日期" Value="计划日期" />
                                    <f:ListItem Text="交付日期" Value="交付日期" />
                                    <f:ListItem Text="生产日期" Value="生产日期" />
                                    <f:ListItem Text="完成日期" Value="完成日期" />
                                </f:DropDownList>

                                <f:DatePicker runat="server" ID="dp1" Label="交付日期" ShowLabel="false" Width="120px" LabelWidth="80px"/>
                                <f:DatePicker runat="server" ID="dp2" Label="结束日期" ShowLabel="false" Width="120px"/>

                                <%--车间、生产超期、交付超期、生产状态、物料编码、物料名称、；
                                排产日期起止、客户交付日期起止、计划生产日期起止、实际完成日期起止、--%>
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

                                										
                                <f:DropDownList runat="server" Label="生产状态" ID="ddlProState" 
                                    AutoSelectFirstItem="true" EnableEdit="true" Width="200px" LabelWidth="80px">
                                    <f:ListItem Text="全部" Value="" />
                                    <f:ListItem Text="未生产" Value="未生产" />
                                    <f:ListItem Text="生产中" Value="生产中" />
                                    <f:ListItem Text="暂停生产" Value="暂停生产" />
                                    <f:ListItem Text="异常" Value="异常-" />
                                    <f:ListItem Text="异常完成" Value="异常完成" />
                                    <f:ListItem Text="已完成" Value="已完成" />
                                </f:DropDownList>

                                 <f:DropDownList runat="server" Label="生产超期" ID="ddlProCQ" 
                                    AutoSelectFirstItem="true" EnableEdit="true" Width="150px" LabelWidth="80px">
                                    <f:ListItem Text="全部" Value="" />
                                    <f:ListItem Text="是" Value="是" />
                                    <f:ListItem Text="否" Value="否" />
                                </f:DropDownList>
                                <f:DropDownList runat="server" Label="交付超期" ID="ddlJfCQ" 
                                    AutoSelectFirstItem="true" EnableEdit="true" Width="150px" LabelWidth="80px">
                                    <f:ListItem Text="全部" Value="" />
                                    <f:ListItem Text="是" Value="是" />
                                    <f:ListItem Text="否" Value="否" />
                                </f:DropDownList>
                                    <f:TextBox runat="server" EmptyText="关键词搜索" ID="tbxSearch" MarginLeft="10px" Width="203px"></f:TextBox>

                            </Items>
                        </f:Toolbar>

                        <f:Toolbar runat="server">
                            <Items>

                                
                                 <f:TextBox runat="server" Label="生产单号" ID="tbxProNo"  Width="280px" LabelWidth="80px"></f:TextBox>

                                   <f:TextBox runat="server" Label="排产单号" ID="tbxPcNo"  Width="280px" LabelWidth="80px"></f:TextBox>

                                 <f:TextBox runat="server" Label="产品名称" ID="tbxItemName"  Width="390px" LabelWidth="80px"></f:TextBox>

                                 <f:TextBox runat="server" Label="产品编码" ID="tbxItemNo"  Width="280px" LabelWidth="80px"></f:TextBox>

                                <f:ToolbarSeparator runat="server"/>
                                <f:Button runat="server" ID="btnSearch" Text="搜索" Icon="SystemSearch" OnClick="btnSearch_Click" Type="Submit"></f:Button>
                                 <f:Button runat="server" ID="btnExcel" Icon="PageExcel" Text="导出" OnClick="btnExcel_Click" DisableControlBeforePostBack="false" EnableAjax="false"></f:Button>

                                 <%--<f:Button runat="server" ID="btnPrint" Icon="Printer" Text="打印生产明细报表" OnClick="btnPrint_Click"></f:Button>--%>
                                
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
                                
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField HeaderText="序号" Width="50px" HeaderTextAlign="Center" TextAlign="Center"></f:RowNumberField>
                        <f:BoundField DataField="ProductOrder_XuHao"  SortField="ProductOrder_XuHao"
                            ColumnID="ProductOrder_XuHao" HeaderText="生产明细单号" Width="140px"/>
                        <f:BoundField DataField="Itemno"  SortField="Itemno"
                            ColumnID="Itemno" HeaderText="产品编码" Width="150px"/>
                         <f:BoundField DataField="ItemName"  SortField="ItemName"
                            ColumnID="ItemName" HeaderText="产品名称" Width="200px"/>
                            <f:BoundField DataField="Spec" SortField="Spec" ColumnID="Spec"
                            HeaderText="包装规格" Width="80px" />

                        <f:BoundField DataField="CheJianName"  SortField="CheJianName"
                            ColumnID="CheJianName" HeaderText="车间名称" Width="120px"/>
                        <f:BoundField DataField="PlanDate" SortField="PlanDate" ColumnID="PlanDate" 
                            HeaderText="排产计划日期" Width="110px" DataFormatString="{0:yyyy-MM-dd}"/>
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" ColumnID="DeliveryDate"
                            HeaderText="客户交付日期" Width="110px" DataFormatString="{0:yyyy-MM-dd}"/>
                        <f:BoundField DataField="PlanProDate" SortField="PlanProDate" ColumnID="PlanProDate"
                            HeaderText="计划生产日期" Width="110px" DataFormatString="{0:yyyy-MM-dd}"/>
                        <f:BoundField DataField="FinishTime" SortField="FinishTime" ColumnID="FinishTime"
                            HeaderText="实际完成日期" Width="110px" DataFormatString="{0:yyyy-MM-dd}"/>

                        <f:BoundField DataField="PcCQ" SortField="PcCQ" ColumnID="PcCQ"
                            HeaderText="生产超期" Width="80px"/>
                        <f:BoundField DataField="JFCQ" SortField="JFCQ" ColumnID="JFCQ"
                            HeaderText="交付超期" Width="80px" />

                      
                         <f:BoundField DataField="PcCount" SortField="PcCount" ColumnID="PcCount"
                            HeaderText="计划生产量" Width="100px"/>
                        <f:BoundField DataField="ProCount" SortField="ProCount" ColumnID="ProCount"
                            HeaderText="实际生产量" Width="100px"/>
                        <f:BoundField DataField="Unit" SortField="Unit" ColumnID="Unit"
                            HeaderText="单位" Width="60px"/>

                          <f:BoundField DataField="ConvertRate" SortField="ConvertRate" ColumnID="ConvertRate"  HeaderText="转换率" Width="80px"/> 
                        <f:BoundField DataField="PcCountOnKg" SortField="PcCountOnKg" ColumnID="PcCountOnKg"  HeaderText="排产数量(kg)" Width="110px"
                            DataFormatString="{0:0.00}"/> 
                        <f:BoundField DataField="ProCountOnKg" SortField="ProCountOnKg" ColumnID="ProCountOnKg"  HeaderText= "实际产量(kg)" Width="110px"
                            DataFormatString="{0:0.00}"/>

                        <f:BoundField DataField="WCL" SortField="WCL" ColumnID="WCL"
                            HeaderText="完成率" Width="80px" DataFormatString="{0}%"/>
                        <f:BoundField DataField="ProOrderList_State" SortField="ProOrderList_State" ColumnID="ProOrderList_State" HeaderText="生产状态" Width="100px"  />
                        <f:BoundField DataField="ProPlanOrder_XuHao"  SortField="ProPlanOrder_XuHao"
                            ColumnID="ProPlanOrder_XuHao" HeaderText="排产单明细号" Width="200px"/>
                         <f:BoundField DataField="PlanProTime" SortField="PlanProTime" ColumnID="PlanProTime" HeaderText="生产班次" Width="80px"  />
                        <f:BoundField DataField="UploadRen" SortField="UploadRen" ColumnID="UploadRen" HeaderText="最近上报人" Width="100px"  />
                        <f:BoundField DataField="UploadTime" SortField="UploadTime" ColumnID="UploadTime" HeaderText="最近上报时间" Width="180px"  />
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
