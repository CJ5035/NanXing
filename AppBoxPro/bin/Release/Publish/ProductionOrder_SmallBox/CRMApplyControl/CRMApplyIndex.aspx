<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="CRMApplyIndex.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.CRMApplyControl.CRMApplyIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        /*.f-grid-cell.f-grid-cell-ItemName
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }
        .f-grid-cell.f-grid-cell-ItemName1
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }
        .f-grid-cell.f-grid-cell-ItemName2
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }
        .f-grid-cell.f-grid-cell-BoxName
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }
		
		.f-grid-cell.f-grid-cell-Remark
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }*/

        .f-grid-cell[data-color=color1] {
            /*background-color: #fff;*/
            color: #00a03e;
        }
        .f-grid-cell[data-color=color2] {
            /*background-color: #fff;*/
            color: #990033;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" ID="Panel1" Layout="HBox">
            <Items>
                <%--SortField="EmergencyDegree"  SortDirection="DESC"
                   --%> 
                <f:Grid runat="server" Title="排产申请单" IsDatabasePaging="true"
                    DataKeyNames="ID,PlanOrder_XuHao,ApplyNoState"  BoxFlex="1"
                    AllowPaging="true" ID="Grid1" OnPageIndexChange="Grid1_PageIndexChange" 
                    EnableCheckBoxSelect="true" EnableTextSelection="true" 
                    SummaryPosition="Bottom" EnableSummary="true" 
                    EnableRowDoubleClickEvent="false" OnRowDoubleClick="Grid1_RowDoubleClick" 
                    OnRowCommand="Grid1_RowCommand"   OnRowDataBound="Grid1_RowDataBound"
                    AllowSorting="true" SortingCancel="true" SortingToolTip="true" SortingMulti="true" 
                    SortFieldArray="DeliveryDate,ASC,EmergencyDegree,DESC,ItemName,ASC,CRMApplyNo,ASC"
                    OnSort="Grid1_Sort"
                    AllowColumnLocking="true" EnableColumnLines="true" >
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:DatePicker runat="server" ID="dp1" Label="下单日期" Width="200px" LabelWidth="80px"></f:DatePicker>
                                <f:DatePicker runat="server" ID="dp2" Label="结束日期" ShowLabel="false" Width="120px"></f:DatePicker>
                                <f:DropDownList runat="server" Label="任务状态" ID="ddlState" AutoSelectFirstItem="false" EnableEdit="true" 
                                    Width="180px" LabelWidth="82px">
                                    <f:ListItem Text="未排产" Value="未排产" Selected="true" />
                                    <f:ListItem Text="已排产" Value="已排产" />
                                    <f:ListItem Text="不需排产" Value="不需排产" />
                                    <%--<f:ListItem Text="生产中" Value="生产中" />
                                    <f:ListItem Text="已完成" Value="已完成" />
                                    <f:ListItem Text="已终止" Value="已终止" />
                                    <f:ListItem Text="已取消" Value="已取消" />
                                    
                                    <f:ListItem Text="冻结" Value="冻结" />--%>
                                    <f:ListItem Text="全部" Value="全部" />
                                </f:DropDownList>
                                <f:TextBox runat="server" EmptyText="关键词搜索" ID="tbxSearch" MarginLeft="10px" Width="203px"></f:TextBox>
                                <f:ToolbarSeparator runat="server"/>
                                <f:Button runat="server" ID="btnExcel" Icon="PageExcel" Text="导出" OnClick="btnExcel_Click"
                                    DisableControlBeforePostBack="false" EnableAjax="false"></f:Button>

                            </Items>
                        </f:Toolbar>
                        <f:Toolbar runat="server">
                            <Items>
                               <f:TextBox runat="server" Label="申请单号" ID="tbxApplyNo" Width="330px" LabelWidth="80px"></f:TextBox>
                                <%-- <f:TextBox runat="server" Label="规格" ID="tbxspec" Width="200px" LabelWidth="80px"></f:TextBox>--%>
                                <f:TextBox runat="server" Label="产品名称" ID="tbxName" Width="390px" LabelWidth="80px"></f:TextBox>
                                <%-- <f:TextBox runat="server" Label="厂家型号" ID="tbxmodel" Width="190px" LabelWidth="70px"></f:TextBox>
                                <f:TextBox runat="server" Label="销售型号" ID="tbxinName" Width="190px" LabelWidth="70px"></f:TextBox>--%>
                                <f:ToolbarSeparator runat="server"/>
                                <f:Button runat="server" ID="btnSearch" Text="搜索" Icon="SystemSearch" OnClick="btnSearch_Click" Type="Submit"></f:Button>
                                <f:Button runat="server" ID="btnAddOrder" Icon="DatabaseAdd" Text="合并申请单" OnClick="btnAddOrder_Click"></f:Button>
                                 <f:Button runat="server" ID="btnAddOrder2" Icon="DatabaseAdd" Text="合并申请单2" OnClick="btnAddOrder2_Click" Hidden="true"></f:Button>
                                <f:Button runat="server" ID="btnChangeNoPC" Icon="Decline"
                                    Text="不需排产" OnClick="btnChangeNoPC_Click"
                                    ConfirmText="确定改变申请单状态为不需排产？" ConfirmTarget="Top"></f:Button>

                            </Items>
                        </f:Toolbar>
                    </Toolbars>


                    <Toolbars>
                        <f:Toolbar runat="server" Hidden="true" >
                            <Items>
                               
                                <f:ToolbarSeparator runat="server"></f:ToolbarSeparator>
                                <f:Button ID="btnBack" Text="后退" runat="server" Icon="PageBack" OnClick="btnBack_Click" Hidden="true"></f:Button>
                                <f:Button Type="Reset"  Text="重置" runat="server" Icon="ArrowRefresh" ID="btnReset" OnClick="btnReset_Click" Hidden="true"></f:Button>
                                
                                <f:ToolbarFill runat="server"></f:ToolbarFill>
                                <f:Button runat="server" ID="btnDelete" Icon="DatabaseDelete" Text="删除排产单" OnClick="btnDelete_Click" Hidden="true"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField HeaderText="序号" Width="50px" HeaderTextAlign="Center" TextAlign="Center"></f:RowNumberField>
                        <f:RenderField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="220px" HeaderText="产品名称"
                            EnableLock="true" Locked="true" RendererFunction="renderMajor"/>
                        <f:BoundField ColumnID="DeliveryDate" DataField="DeliveryDate"  SortField="DeliveryDate"  Width="100px"  HeaderText="交付日期"
                            DataFormatString="{0:yyyy-MM-dd}"  EnableLock="true" Locked="true"/>  
                        <f:BoundField ColumnID="crmListStatus" DataField="crmListStatus" SortField="crmListStatus" Width="80px"  HeaderText="任务状态" />


                        <f:RenderField ColumnID="ClientName" DataField="ClientName" SortField="ClientName" Width="120px" HeaderText="客户名称" 
                            RendererFunction="renderMajor"/>
                        
                       <f:BoundField ColumnID="ApplyTime" DataField="ApplyTime"  SortField="ApplyTime"  Width="150px"  HeaderText="下单时间"
                            DataFormatString="{0:yyyy-MM-dd}" />

                        <f:BoundField ColumnID="ApplyNoState" DataField="ApplyNoState" SortField="ApplyNoState" Width="80px" HeaderText="申请状态"/>
                        <f:RenderField ColumnID="EmergencyDegree" DataField="EmergencyDegree" SortField="EmergencyDegree" Width="80px" HeaderText="紧急程度"/>
                        <f:RenderField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="150px"  HeaderText="申请单备注"
                             RendererFunction="renderMajor"/>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="80px"  HeaderText="包装规格" />
                        <f:BoundField ColumnID="OrderCount" DataField="OrderCount" SortField="OrderCount" Width="80px"  HeaderText="订单数量" />
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="80px"  HeaderText="排产单位" />
                        <f:BoundField ColumnID="InventoryCount" DataField="InventoryCount" SortField="InventoryCount" Width="110px"  HeaderText="库存数量" />
                        <f:BoundField ColumnID="OrderCount" DataField="OrderCount" SortField="OrderCount" Width="80px"  HeaderText="排产数量" />
                        <f:BoundField ColumnID="Biaozhun" DataField="Biaozhun" SortField="Biaozhun" Width="80px"  HeaderText="标准" />
                        <f:BoundField ColumnID="ProductRecipe" DataField="ProductRecipe" SortField="ProductRecipe" Width="80px"  HeaderText="生产配方" />
                       
                        <f:BoundField ColumnID="BoxNo" DataField="BoxNo" SortField="BoxNo" Width="100px"  HeaderText="箱号" />
                        <f:RenderField ColumnID="BoxName" DataField="BoxName" SortField="BoxName" Width="200px"  HeaderText="箱名"
                            RendererFunction="renderMajor"/>
                        <f:BoundField ColumnID="BatchNo" DataField="BatchNo" SortField="BatchNo" Width="100px"  HeaderText="批号" />
                        <f:BoundField ColumnID="ItemNo" DataField="ItemNo" SortField="ItemNo" Width="200px" HeaderText="产品编码"/>

                        <f:BoundField ColumnID="CRMApplyNo_Xuhao" DataField="CRMApplyNo_Xuhao" SortField="CRMApplyNo_Xuhao" Width="150px" HeaderText="CRM申请单序号" Hidden="true" />

                         <%--排产数量、排产单位--%>
                        
                        <f:BoundField ColumnID="CRMApplyNo"  DataField="CRMApplyNo" SortField="CRMApplyNo"  Width="150px" HeaderText="CRM申请单号"  EnableLock="true"/>
                          <f:BoundField ColumnID="ApplicantName" DataField="ApplicantName" SortField="ApplicantName" Width="100px" HeaderText="申请人" "/>
                        <f:BoundField ColumnID="ApplicantDept" DataField="ApplicantDept" SortField="ApplicantDept" Width="100px" HeaderText="申请部门" />

                      
                        <f:BoundField ColumnID="PlanNewdate" DataField="PlanNewdate" SortField="PlanNewdate" Width="180px" HeaderText="合并时间"
                             DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                        <f:BoundField ColumnID="PlanOrder_XuHao" DataField="PlanOrder_XuHao" SortField="PlanOrder_XuHao" Width="150px" 
                            HeaderText="排产单号" />
                        <f:BoundField ColumnID="Jingbanren" DataField="Jingbanren" SortField="Jingbanren" Width="100px"  HeaderText="排产人员" />
                          <f:BoundField ColumnID="PlanDate" DataField="PlanDate" SortField="PlanDate" Width="100px"  HeaderText="计划排产日期"
                            DataFormatString="{0:yyyy-MM-dd}" />
                       
                       

                           <%--  FieldType="Float" RendererFunction="RenderPrice" SummaryType="Sum"/>--%>

                        <f:BoundField ColumnID="ItemName1" DataField="ItemName1" SortField="ItemName1" Width="200px" HeaderText="产品别名" Hidden="True"/>
                        <f:BoundField ColumnID="ItemName2" DataField="ItemName2" SortField="ItemName2" Width="150px"  HeaderText="原料名" Hidden="True"/>


                        <%--<f:LinkButtonField HeaderText="打印" Width="100px" Icon="Printer" CommandName="Print" ColumnID="print" TextAlign="Center"></f:LinkButtonField>--%>

                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window runat="server" ID="Window1" EnableIFrame="true" Height="600px" Width="500px" Title="" Hidden="true"
            OnClose="Window1_Close"  EnableMaximize="true" EnableMinimize="true" EnableResize="true"></f:Window>

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
            function renderMajor(value) {
                return F.formatString('<span data-qtip="{0}">{0}</span>', F.htmlEncode(value));
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
