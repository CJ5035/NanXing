<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRMApplyNew2.aspx.cs"
    Inherits="NanXingGuoRen_APS.ProductionOrder_SmallBox.CRMApplyControl.CRMApplyNew2" %>

<%@ Register Src="~/ProductionOrder_SmallBox/PlanOrderControl/UserControls/ProOrderGrid_UC.ascx"
    TagName="ProOrderGrid_UC" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="sourcefiles" content="~/UserControls/ProOrderGrid_UC.ascx" />
    <title></title>
    <style>
        .mybuttongroup .f-btn {
            border-width: 0;
            border-radius: 0;
            margin-bottom: 5px;
            padding-top: 10px;
            padding-bottom: 10px;
        }

        .mytabstrip {
            border-left-width: 1px;
        }

        .f-grid-row-summary .f-grid-cell-inner {
            font-weight: bold;
            color: red;
        }

        .f-grid-cell.f-grid-cell-ItemNo
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-ItemName
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-Spec
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-OrderCount
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-Unit
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-InventoryCount
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-EmergencyDegree
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-Biaozhun
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-Remark
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-CRMApplyNo
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-CRMApplyNo_Xuhao
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-ClientName
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-ApplicantName
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-OrderDate
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-DeliveryDate
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-ApplyNoState
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-ProductRecipe
        .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-BoxName
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-ItemName1
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-ItemName2
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcCount
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcUnit
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-BatchNo
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-Color
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-GiveDept
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-Ingredients
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-BoxNo
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-BoxName
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-BoxRemark
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-Plandate
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcRemark
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-Priority
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcCount_03_Bag
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcCount_03_Tank
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcCount_03_Box
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcCount_07_Bag
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcCount_07_Tank
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PcCount_07_Box
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PlanDate
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PlanTime
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        /*PcCount,PcUnit,BatchNo,Color,GiveDept,Ingredients,BoxNo,BoxName,BoxRemark,Plandate,PcRemark*/
        .f-grid-row .f-grid-cell-ItemName1,
        .f-grid-row .f-grid-cell-ItemName2,
        .f-grid-row .f-grid-cell-PcCount,
        .f-grid-row .f-grid-cell-PcUnit,
        .f-grid-row .f-grid-cell-BatchNo,
        .f-grid-row .f-grid-cell-Color,
        .f-grid-row .f-grid-cell-GiveDept,
        .f-grid-row .f-grid-cell-Ingredients,
        .f-grid-row .f-grid-cell-BoxNo,
        .f-grid-row .f-grid-cell-BoxName,
        .f-grid-row .f-grid-cell-BoxRemark,
        .f-grid-row .f-grid-cell-Plandate,
        .f-grid-row .f-grid-cell-PcRemark,
        .f-grid-row .f-grid-cell-Priority,
        .f-grid-row .f-grid-cell-PcCount_03_Bag,
        .f-grid-row .f-grid-cell-PcCount_03_Tank,
        .f-grid-row .f-grid-cell-PcCount_03_Box,
        .f-grid-row .f-grid-cell-PcCount_07_Bag,
        .f-grid-row .f-grid-cell-PcCount_07_Tank,
        .f-grid-row .f-grid-cell-PcCount_07_Box,
        .f-grid-row .f-grid-cell-PlanDate,
        .f-grid-row .f-grid-cell-PlanTime {
            background-color: #FFE7BA;
            color: #000;
        }

        .f-grid-row .f-grid-cell-Remark
        .f-grid-cell-inner {
            background-color: #FFE7BA;
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>

        <f:Panel runat="server" ID="Panel1" BodyPadding="5px" AutoScroll="true"
            ShowBorder="false" ShowHeader="false" Layout="VBox"
            BoxConfigAlign="Stretch" BoxConfigPosition="Start">
            <Items>

                <f:Panel runat="server" ShowHeader="false" ID="Panel99" Layout="HBox"
                    Height="100px" Width="100%">
                    <Items>
                        <f:Panel ID="Panel7" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" Height="100px" Width="150px">
                            <Items>
                                <f:Label runat="server" Label="选择车间" Height="100px" Width="150px"></f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel2" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" Height="100px" Width="250px">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList2" ColumnNumber="1" runat="server"
                                    Height="120px" Width="250px"
                                    AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged">
                                    <Items>
                                        <f:CheckItem Text="03小包装-小袋" Value="03小包装-小袋" />
                                        <f:CheckItem Text="03小包装-罐" Value="03小包装-罐" />
                                        <f:CheckItem Text="03小包装-每日坚果" Value="03小包装-每日坚果" />

                                    </Items>
                                    <Listeners>
                                        <f:Listener Event="change" Handler="onCheckBoxList2Change" />
                                    </Listeners>
                                </f:CheckBoxList>
                            </Items>
                        </f:Panel>

                        <f:Panel ID="Panel3" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" MarginLeft="-10px" Height="120px" Width="250px">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList3" ColumnNumber="1" runat="server"
                                    Height="120px" Width="300px"
                                    AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList3_SelectedIndexChanged">
                                    <Items>
                                        <f:CheckItem Text="07小包装-小袋" Value="07小包装-小袋" />
                                        <f:CheckItem Text="07小包装-罐" Value="07小包装-罐" />
                                        <f:CheckItem Text="07小包装-每日坚果" Value="07小包装-每日坚果" />
                                    </Items>
                                    <Listeners>
                                        <f:Listener Event="change" Handler="onCheckBoxList2Change" />
                                    </Listeners>

                                </f:CheckBoxList>
                            </Items>
                        </f:Panel>


                        <%--<Listeners>
                                        <f:Listener Event="change" Handler="onCheckBoxListChange" />
                                    </Listeners>--%>

                        <f:ToolbarFill runat="server" />

                    </Items>
                </f:Panel>

                <f:Grid runat="server" ID="Grid1"
                    Title="合并任务单" ShowHeader="false"
                    ClicksToEdit="1" AllowCellEditing="true" EnableCheckBoxSelect="false"
                    AutoSelectEditor="true" PageSize="10" DataKeyNames="ID,Spec"
                    SortField="ID" IsDatabaseSorting="true"
                    AllowColumnLocking="true" EnableColumnLines="true" EnableCollapse="true"
                     BoxFlex="1">

                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:TextBox runat="server" Label="排产单号" Text="" Enabled="false" EmptyText="保存自动生成"></f:TextBox>
                                <f:Label runat="server" ID="Lab_PCY" Label="排产人员" Width="200px" LabelWidth="80px" MarginLeft="20px"></f:Label>
                                <f:DatePicker runat="server" ID="hbDate" Label="合并日期" Width="200px" LabelWidth="80px"
                                    EnableDateSelectEvent="true" OnDateSelect="jiaoFuDate_DateSelect" />

                                <f:CheckBox runat="server" Label="批量计划排产日期" ID="Cb_JFD" OnCheckedChanged="Cb_JFD_CheckedChanged" MarginLeft="30px"
                                    Width="170px" LabelWidth="135px" AutoPostBack="true" Hidden="true">
                                </f:CheckBox>

                                <f:Panel runat="server" ID="Panel98" Layout="HBox" Width="200px" Height="32px" ShowHeader="false"
                                    ShowBorder="false" Enabled="false" Hidden="true">
                                    <Items>
                                        <f:DatePicker runat="server" ID="jiaoFuDate" Label="计划排产日期" Width="120px" LabelWidth="110px"
                                            ShowLabel="false" EnableDateSelectEvent="true" OnDateSelect="jiaoFuDate_DateSelect" />

                                        <f:DropDownList runat="server" ID="jiaoFuTime" Width="80px">
                                            <f:ListItem Text="上午" Value="上午" />
                                            <f:ListItem Text="下午" Value="下午" />
                                            <f:ListItem Text="晚上" Value="晚上" />

                                        </f:DropDownList>
                                    </Items>
                                </f:Panel>



                            </Items>
                        </f:Toolbar>

                        <f:Toolbar runat="server">
                            <Items>

                                <f:Button runat="server" ID="btnSave" Icon="SystemSave" Text="保存"
                                    ConfirmText="确认保存合拼任务单？" ConfirmTarget="Top"
                                    OnClientClick="if(!isValid()){return false;}" OnClick="btnSave_Click" />
                                <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server">
                                </f:Button>
                                <f:ToolbarFill runat="server"></f:ToolbarFill>

                                <f:DropDownBox runat="server" ID="DropDownBox1" DataControlID="CheckBoxList1" EnableMultiSelect="true" Values="" Width="100px"
                                    Label="合并单元格" Hidden="true">
                                    <PopPanel>
                                        <f:SimpleForm ID="SimpleForm2" BodyPadding="10px" runat="server" AutoScroll="true"
                                            ShowBorder="true" ShowHeader="false" Hidden="true">
                                            <Items>
                                                <f:Label ID="Label1" runat="server" Text="请选择编程语言：" Hidden="true"></f:Label>
                                                <f:CheckBoxList ID="CheckBoxList1" ColumnNumber="3" runat="server">
                                                    <f:CheckItem Text="品名" Value="ItemName" />
                                                    <f:CheckItem Text="规格" Value="Spec" />
                                                    <f:CheckItem Text="单位" Value="Unit" />
                                                    <f:CheckItem Text="数量" Value="PcCount" />
                                                    <f:CheckItem Text="批号" Value="BatchNo" />
                                                    <f:CheckItem Text="箱号" Value="BoxNo" />
                                                    <f:CheckItem Text="纸箱" Value="BoxName" />
                                                    <f:CheckItem Text="状态/配料号" Value="Ingredients" />
                                                    <f:CheckItem Text="备注" Value="Remark" Selected="true" />
                                                </f:CheckBoxList>
                                            </Items>
                                            <Toolbars>
                                                <f:Toolbar runat="server" Position="Top">
                                                    <Items>
                                                        <f:Button runat="server" ID="btnSelectAll" EnablePostBack="false" Text="全选">
                                                            <Listeners>
                                                                <f:Listener Event="click" Handler="onSelectAllClick" />
                                                            </Listeners>
                                                        </f:Button>
                                                        <f:Button runat="server" ID="btnClearAll" EnablePostBack="false" Text="清空">
                                                            <Listeners>
                                                                <f:Listener Event="click" Handler="onClearAllClick" />
                                                            </Listeners>
                                                        </f:Button>
                                                    </Items>
                                                </f:Toolbar>
                                            </Toolbars>
                                        </f:SimpleForm>
                                    </PopPanel>
                                </f:DropDownBox>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>

                    <Columns>
                        <f:RowNumberField EnablePagingNumber="true"></f:RowNumberField>
                        <f:BoundField ColumnID="ItemNo" DataField="ItemNo" SortField="ItemNo" Width="120px"
                            HeaderText="产品编码" EnableLock="true" Locked="true" Hidden="true" />

                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="120px"
                            HeaderText="产品名称" EnableLock="true" Locked="true" />

                        <f:BoundField ColumnID="DeliveryDate" DataField="DeliveryDate" SortField="DeliveryDate"
                            Width="120px"  HeaderText="交付日期" DataFormatString="{0:yyyy-MM-dd}" EnableLock="true" Locked="true" />

                        <f:RenderField ColumnID="PcCount" DataField="PcCount" SortField="PcCount" Width="100px" HeaderText="排产数量">
                            <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ID="PcCount_03_Bag" ColumnID="PcCount_03_Bag" DataField="PcCount_03_Bag" SortField="PcCount_03_Bag"
                            Width="120px" HeaderText="03-小袋数量" Hidden="true">
                            <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ID="PcCount_03_Tank" ColumnID="PcCount_03_Tank" DataField="PcCount_03_Tank" SortField="PcCount_03_Tank"
                            Width="120px" HeaderText="03-罐数量" Hidden="true">
                            <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ID="PcCount_03_Box" ColumnID="PcCount_03_Box" DataField="PcCount_03_Box" SortField="PcCount_03_Box"
                            Width="120px" HeaderText="03-每日坚果数量" Hidden="true">
                            <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ID="PcCount_07_Bag" ColumnID="PcCount_07_Bag" DataField="PcCount_07_Bag" SortField="PcCount_07_Bag"
                            Width="120px" HeaderText="07-小袋数量" Hidden="true">
                            <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ID="PcCount_07_Tank" ColumnID="PcCount_07_Tank" DataField="PcCount_07_Tank" SortField="PcCount_07_Tank"
                            Width="120px" HeaderText="07-罐数量" Hidden="true">
                            <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ID="PcCount_07_Box" ColumnID="PcCount_07_Box" DataField="PcCount_07_Box" SortField="PcCount_07_Box"
                            Width="120px" HeaderText="07-每日坚果数量" Hidden="true">
                            <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ColumnID="PcUnit" DataField="PcUnit" SortField="PcUnit" Width="100px" HeaderText="排产单位">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>


                        <f:RenderField ColumnID="BoxNo" DataField="BoxNo" SortField="BoxNo" Width="100px" HeaderText="箱号">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="BoxName" DataField="BoxName" SortField="BoxName" Width="100px" HeaderText="箱名">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="BoxRemark" DataField="BoxRemark" SortField="BoxRemark" Width="150px" HeaderText="包装备注">
                            <Editor>
                                <f:TextArea runat="server"></f:TextArea>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="BatchNo" DataField="BatchNo" SortField="BatchNo" Width="100px" HeaderText="批号">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ColumnID="PlanDate" DataField="PlanDate" SortField="PlanDate" Width="120px" HeaderText="计划排产日期"
                            FieldType="Date" RendererArgument="yyyy-MM-dd">
                            <Editor>
                                <f:DatePicker runat="server"></f:DatePicker>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="PlanTime" DataField="PlanTime" SortField="PlanTime" Width="80px" HeaderText="排产时间">
                            <Editor>
                                <f:DropDownList runat="server">
                                    <f:ListItem Text="上午" Value="上午" />
                                    <f:ListItem Text="下午" Value="下午" />
                                    <f:ListItem Text="晚上" Value="晚上" />
                                </f:DropDownList>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="Priority" DataField="Priority" SortField="Priority"
                            Width="80px" HeaderText="优先度">
                            <Editor>
                                <f:DropDownList runat="server">
                                    <f:ListItem Text="正常" Value="正常" Selected="true" />
                                    <f:ListItem Text="紧急" Value="紧急" />
                                    <f:ListItem Text="加急" Value="加急" />
                                </f:DropDownList>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="PcRemark" DataField="PcRemark" SortField="PcRemark" Width="200px"
                            HeaderText="排产单备注" >
                            <Editor>
                                <f:TextArea runat="server"></f:TextArea>
                            </Editor>
                        </f:RenderField>

                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit1" />--%>
                    </Listeners>
                </f:Grid>

                <%-- <f:Grid runat="server" BoxFlex="1" Title="合并任务单" ShowHeader="false" ID="Grid1" 
                    ClicksToEdit="1"AllowCellEditing="true" EnableCheckBoxSelect="true" AutoSelectEditor="true"
                    PageSize="20" DataKeyNames="ID,Spec"
                    SummaryPosition="Bottom" EnableSummary="true" 
                    SortField="CRMApplyNo" IsDatabaseSorting="true"
                    AllowColumnLocking="true" EnableColumnLines="true">

                   

                </f:Grid>--%>
            </Items>
        </f:Panel>


        <script>


            var checkBoxList2ClientID = '<%= CheckBoxList2.ClientID %>';
            var checkBoxList3ClientID = '<%= CheckBoxList3.ClientID %>';


            var dropDownBox1ClientID = '<%= DropDownBox1.ClientID %>';
            var checkBoxList1ClientID = '<%= CheckBoxList1.ClientID %>';

            function onSelectAllClick() {
                var checkBoxList1 = F(checkBoxList1ClientID);
                $.each(checkBoxList1.items, function (index, item) {
                    item.setValue(true);
                });

                // 将数据控件中的值同步到输入框
                F(dropDownBox1ClientID).syncToBox();
            }
            var grid1ClientID = '<%= Grid1.ClientID %>';

            function updateSummary() {
                var me = F(grid1ClientID), mathTotal = 0;
                me.getRowEls().each(function (index, tr) {
                    mathTotal += me.getCellValue(tr, 'count');
                    //mathTotal += me.getCellValue(tr, 'MathScore');
                });

                // 第三个参数 true，强制更新，不显示左上角的更改标识
                me.updateSummaryCellValue('count', mathTotal, true);
                //me.updateSummaryCellValue('MathScore', mathTotal, true);
            }

            function onGridAfterEdit1() {
                updateSummary();
            }

            function onClearAllClick() {
                var checkBoxList1 = F(checkBoxList1ClientID);

                $.each(checkBoxList1.items, function (index, item) {
                    item.setValue(false);
                });
                //将数据控件中的值同步到输入框
                F(dropDownBox1ClientID).syncToBox();
            }


            function onGridAfterEdit(event, value, params) {
                if (params.columnId === 'count') {
                    if (params.rowValue['count'] > params.rowValue['库存卷数']) {
                        //params.rowValue['count']
                        this.updateCellValue(params.rowId, 'count', params.rowValue['库存卷数'], true);
                        alert("不能大于库存卷数");
                    }
                }
                //改变了入库卷数，则改变面积
                if (params.columnId === 'count' || params.columnId === 'length' || params.columnId === 'width') {
                    this.updateCellValue(params.rowId, 'area', calculateCountValue(params.rowValue), true);
                }
            }

            <%--function editGetterGrid2(editor, columnId, rowId) {
                console.log(2783);
                var tbxSearch = '<%=tbxSearch.ClientID%>';
                F(tbxSearch).focus();
            }--%>

            //复制按钮
            function onCopyClick(event) {
                try {

                    // 选中行数据
                    var rowData = F(grid1ClientID).getSelectedRow(true);

                    var rowValue = rowData.values;
                    console.log(rowValue);
                    F(grid1ClientID).addNewRecord(rowValue, true);
                    //updateSummary();
                }
                catch (error) {
                    F.alert("请选中要复制的行")
                }
            }

            function calculateCountValue(rowValue) {
                var count = 0;
                count = rowValue['width'] / 1000 * rowValue['length'] * rowValue['count'];
                if (isNaN(count)) {
                    count = 0;
                }
                return count;
            }

            function RenderProvider(value) {
                return F(ddlProvider).getTextByValue(value);
            }

            function renderItemno(value) {
                if (!value) {
                    return '';
                }
                var grid2 = F(grid2ClientID);

                return grid2.getRowData(value).text;
            }

            function onGrid2RowClick(event, grid2RowId) {
                var grid1 = F(grid1ClientID);
                var grid1RowId = grid1.getSelectedCell()[0];
                var rowValue = this.getRowValue(grid2RowId);

                grid1.updateCellValue(grid1RowId, {
                    //'Code2': grid2RowId,
                    //'Code': grid2RowId,
                    //'itemno': rowValue.itemno,
                    'name': rowValue.name,
                    'spec': rowValue.spec,
                    'model': rowValue.model,
                    //'inName': rowValue.inName,
                    //'color': rowValue.color,
                    //'material': rowValue.material,
                    //'Class': rowValue.Class,
                    'unit': '件',
                    'count': '0',
                    //'price': rowValue.price,
                    //'priceOut': '',
                    //'length': rowValue.length,
                    //'width': rowValue.width,
                    //'库存数量': rowValue.库存数量,
                    //'库存平方': rowValue.库存平方,
                    'remark': '',
                    //'PO_Item_ID': rowValue.PO_Item_ID,
                    'ingredients': '',
                    'boxName': '',
                    'boxNo': '',
                    'batchNo': '',

                });

            }
            var checkList2 = '<%= CheckBoxList2.ClientID %>';
            var checkList3 = '<%= CheckBoxList3.ClientID %>';

            function isValid() {
                var grid1 = F(grid1ClientID);
                var valid = true, modifiedData = grid1.getModifiedData();


                //if (client.value == undefined || client.value==-1) {
                //    F.alert({
                //            message: '客户不能为空！',
                //            ok: function () {
                //                client.focus(false, 50);
                //            }
                //    });
                //     valid = false;

                //     return false; // break
                //}
                var check2 = F(checkList2);
                var check3 = F(checkList3);



                $.each(modifiedData, function (index, rowData) {

                    // rowData.id: 行ID
                    // rowData.status: 行状态（newadded, modified, deleted）
                    // rowData.values: 行中修改单元格对象，比如 { "Name": "刘国2", "Gender": 0, "EntranceYear": 2003 }
                    if (rowData.status === 'deleted') {
                        return true; // continue
                    }

                    /*PcCount,PcUnit,BatchNo,Color,GiveDept,Ingredients,BoxNo,BoxName,BoxRemark,Plandate,PcRemark*/

                    var checked2 = check2.getValue();
                    var checked3 = check3.getValue();

                    var temp = ['PcCount', 'PcUnit', 'BoxNo', 'BoxName', 'PlanDate'];
                    var tempStr = ['排产数量', '排产单位', '箱号', '箱名', '排产日期'];
                    for (i = 0; i < checked2.length; i++) {
                        if (checked2[i].indexOf('小袋') > -1) {
                            tempStr.push('03-小袋排产数量');
                            temp.push('PcCount_03_Bag');
                        }
                        else if (checked2[i].indexOf('罐') > -1) {
                            tempStr.push('03-罐排产数量');
                            temp.push('PcCount_03_Tank');
                        }
                        else if (checked2[i].indexOf('每日坚果') > -1) {
                            tempStr.push('03-每日坚果排产数量');
                            temp.push('PcCount_03_Box');
                        }
                    }
                    for (i = 0; i < checked3.length; i++) {
                        if (checked3[i].indexOf('小袋') > -1) {
                            tempStr.push('07-小袋排产数量');
                            temp.push('PcCount_07_Bag');
                        }
                        else if (checked3[i].indexOf('罐') > -1) {
                            tempStr.push('07-罐排产数量');
                            temp.push('PcCount_07_Tank');
                        }
                        else if (checked3[i].indexOf('每日坚果') > -1) {
                            tempStr.push('07-每日坚果排产数量');
                            temp.push('PcCount_07_Box');
                        }
                    }
                    console.log(temp.length);
                    console.log(tempStr.length);

                    for (i = 0; i < temp.length; i++) {
                        var tempIndex = rowData.values[temp[i]];
                        if (typeof (tempIndex) == 'undefined' || $.trim(tempIndex) == '') {
                            F.alert({
                                message: tempStr[i] + '不能为空！',
                                ok: function () {
                                    grid1.startEdit(rowData.id, temp[i]);
                                }
                            });
                            valid = false;
                            return false; // break
                        }
                    }
                    if (!valid) {
                        return false;
                    }

                });
                return valid;
            }

            function IsEmpty(colID, colName, rowData) {
                console.log(rowData);
                var temp = rowData.values[colID];
                if (typeof (temp) == 'undefined' || $.trim(temp) == '') {
                    //F.alert({
                    //    message: colName+'不能为空！',
                    //    ok: function () {
                    //        grid1.startEdit(rowData.id, colID);
                    //        console.log(550);
                    //    }
                    //});
                    valid = false;
                    return false; // break
                }
            }
        </script>
    </form>
</body>
</html>
