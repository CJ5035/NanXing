<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRMApplyNew.aspx.cs" Inherits="NanXingGuoRen_WMS.ProductionOrder.CRMApplyControl.CRMApplyNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .f-grid-row-summary .f-grid-cell-inner {
            font-weight: bold;
            color: red;
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
         .f-grid-row .f-grid-cell-PcRemark
         {
            background-color: #FFE7BA;
            color: #000;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>

        <f:Panel runat="server" ID="Panel1" BodyPadding="5px" AutoScroll="true" ShowBorder="false" ShowHeader="false" Layout="VBox"
            BoxConfigAlign="Stretch" BoxConfigPosition="Start">
            <Items>

                <f:Panel runat="server" ShowHeader="false" ID="Panel99" Layout="HBox" Height="100px" Width="100%"  >
                    <Items>
                        <f:Panel ID="Panel7" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" Height="80px" Width="150px">
                            <Items>
                                <f:Label runat="server" Label="选择车间" Height="80px"  Width="150px"></f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel2" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" Height="80px" Width="150px">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList2" ColumnNumber="1" runat="server" Height="80px" Width="150px">
                                    <Items>
                                        <f:CheckItem Text="原料挑选车间" Value="原料挑选车间" />
                                        <f:CheckItem Text="夏果出仁车间" Value="夏果出仁车间" />
                                    </Items>
                                </f:CheckBoxList>
                            </Items>
                        </f:Panel>

                        <f:Panel ID="Panel3" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" MarginLeft="-10px" Height="80px"  Width="300px">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList3" ColumnNumber="2" runat="server" Height="80px" Width="300px">
                                    <Items>
                                        <f:CheckItem Text="04烘烤车间" Value="04烘烤车间" />
                                        <f:CheckItem Text="开心果烘烤车间" Value="开心果烘烤车间" />
                                        <f:CheckItem Text="捞味车间" Value="捞味车间" />
                                        <f:CheckItem Text="夏果仁烘烤车间" Value="夏果仁烘烤车间" />
                                    </Items>
                                </f:CheckBoxList>
                            </Items>
                        </f:Panel>

                        <f:Panel ID="Panel4" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" MarginLeft="-10px" Height="80px"  Width="150px">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList4" ColumnNumber="1" runat="server" Height="80px"  Width="120px">
                                    <Items>
                                        <f:CheckItem Text="烘焗车间" Value="烘焗车间" />

                                    </Items>
                                </f:CheckBoxList>
                            </Items>
                        </f:Panel>

                        <f:Panel ID="Panel5" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" MarginLeft="-10px" Height="80px"  Width="150px">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList5" ColumnNumber="1" runat="server" Height="80px"  Width="120px">
                                    <Items>
                                        <f:CheckItem Text="油炸车间" Value="油炸车间" />

                                    </Items>
                                </f:CheckBoxList>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel6" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" MarginLeft="-10px" Height="80px"  Width="300px">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList6" ColumnNumber="2" runat="server" Width="400px">
                                    <Items>
                                        <f:CheckItem Text="大包装车间" Value="大包装车间" />
                                        <f:CheckItem Text="小包装车间" Value="小包装车间" />
                                        <f:CheckItem Text="夏果包装车间" Value="夏果包装车间" />

                                    </Items>
                                </f:CheckBoxList>
                            </Items>
                        </f:Panel>
                        <%--<Listeners>
                                        <f:Listener Event="change" Handler="onCheckBoxListChange" />
                                    </Listeners>--%>



                        <%--<f:DropDownList runat="server" ID="ddl_Class" AutoPostBack="true" OnSelectedIndexChanged="ddl_Class_SelectedIndexChanged"
                                     Width="300px">
                                  
                                </f:DropDownList>
                                
                                <f:TextBox runat="server" ID="ddlCheJian" Required="false" ShowRedStar="true" Label="车间类型"  ShowLabel="true" Hidden="true" Width="300px"></f:TextBox>

                                <f:TextBox runat="server" ID="orderNo" Required="true" ShowRedStar="true" Label="编号" ShowLabel="true" Width="200px" Hidden="true"></f:TextBox>

                                <f:DatePicker runat="server" Label="下单日期" Required="true" ID="datepicker1" ShowRedStar="true"></f:DatePicker>--%>
                        <f:ToolbarFill runat="server"/>

                    </Items>
                </f:Panel>
                

                <f:Grid runat="server" BoxFlex="1" Title="合并任务单" ShowHeader="false" ID="Grid1" ClicksToEdit="1"
                    AllowCellEditing="true" EnableCheckBoxSelect="true" PageSize="20" AutoSelectEditor="true" DataKeyNames="ID,Spec"
                    SummaryPosition="Bottom" EnableSummary="true" SortField="CRMApplyNo" IsDatabaseSorting="true"
                    AllowColumnLocking="true" EnableColumnLines="true" >

                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                

                                <f:TextBox runat="server"  Label="排产单号" Text="" Enabled="false" EmptyText="保存自动生成"  ></f:TextBox>
                                 <f:Label runat="server" ID="Lab_PCY" Label="排产人员" Width="200px" LabelWidth="80px"  MarginLeft="20px"></f:Label>
                                <f:DatePicker runat="server" ID="hbDate"  Label="合并日期" Width="200px" LabelWidth="80px"
                                     EnableDateSelectEvent="true" OnDateSelect="jiaoFuDate_DateSelect" />

                                <%--<f:DatePicker runat="server" ID="heBingDate"  Required="true"  Label="下单日期" ShowRedStar="true" Width="220px" LabelWidth="100px"/>--%>
                                <f:CheckBox runat="server" Label="批量计划排产日期" ID="Cb_JFD" OnCheckedChanged="Cb_JFD_CheckedChanged" MarginLeft="30px"
                                    Width="170px" LabelWidth="135px" AutoPostBack="true"></f:CheckBox>
                                
                                <f:Panel runat="server"  ID="Panel98"  Layout="HBox" Width="200px" Height="32px" ShowHeader="false"
                                    ShowBorder="false" Enabled="false">
                                    <Items>
                                           <f:DatePicker runat="server" ID="jiaoFuDate"  Label="计划排产日期" Width="120px" LabelWidth="110px"
                                                ShowLabel="false"  EnableDateSelectEvent="true" OnDateSelect="jiaoFuDate_DateSelect" />
                                    </Items>
                                </f:Panel>
                                
                                

                            </Items>
                        </f:Toolbar>

                        <f:Toolbar runat="server">
                            <Items>
                               <%-- <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增"></f:Button>
                                <f:Button ID="btnCopy" Text="复制选中行" Icon="Add" EnablePostBack="false" runat="server">
                                    <Listeners>
                                        <f:Listener Event="click" Handler="onCopyClick" />
                                    </Listeners>
                                </f:Button>--%>
                                <f:Button runat="server"  ID="btnSave" Icon="SystemSave" Text="保存"
                                    ConfirmText="确认保存合拼任务单？" ConfirmTarget="Top"
                                   OnClientClick="if(!isValid()){return false;}" OnClick="btnSave_Click" />
                                <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server">
                                </f:Button>

                              <%--  <f:Button ID="btnReset" Text="重置表格数据" EnablePostBack="false" runat="server">
                                </f:Button>--%>
                                <f:ToolbarFill runat="server"></f:ToolbarFill>

                                <f:DropDownBox runat="server" ID="DropDownBox1" DataControlID="CheckBoxList1" EnableMultiSelect="true" Values="" Width="500px"
                                    Label="合并单元格">
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
                        <f:BoundField ColumnID="ItemNo" DataField="ItemNo" SortField="ItemNo" Width="120px" HeaderText="产品编码" EnableLock="true" Locked="true"/>
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="120px" HeaderText="产品名称" EnableLock="true"  Locked="true"/>

                        <f:RenderField ColumnID="ItemName1" DataField="ItemName1" SortField="ItemName1" Width="120px" HeaderText="产品别名" EnableLock="true"  Locked="true">
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ColumnID="ItemName2" DataField="ItemName2" SortField="ItemName2" Width="150px" HeaderText="原料名"  Locked="true">
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="包装规格" />
                        <f:BoundField ColumnID="OrderCount" DataField="OrderCount" SortField="OrderCount" Width="100px" HeaderText="订单数量" />
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="订单单位" />
                        <f:BoundField ColumnID="InventoryCount" DataField="InventoryCount" SortField="InventoryCount" Width="110px" HeaderText="库存数量(件)" />
                        <f:BoundField ColumnID="EmergencyDegree" DataField="EmergencyDegree" SortField="EmergencyDegree" Width="110px" HeaderText="紧急程度" />
                        <f:BoundField ColumnID="Biaozhun" DataField="Biaozhun" SortField="Biaozhun" Width="100px" HeaderText="排产标准" />
                       
                        <f:RenderField ColumnID="PcCount" DataField="PcCount" SortField="PcCount" Width="100px" HeaderText="排产数量">
                             <Editor>
                                <f:NumberBox runat="server"></f:NumberBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="PcUnit" DataField="PcUnit" SortField="PcUnit" Width="100px" HeaderText="排产单位" >
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                         <f:RenderField ColumnID="BatchNo" DataField="BatchNo" SortField="BatchNo" Width="100px" HeaderText="批号" >
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                         <f:RenderField ColumnID="Color" DataField="Color" SortField="Color" Width="100px" HeaderText="颜色" >
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="GiveDept" DataField="GiveDept" SortField="GiveDept" Width="100px" HeaderText="供给部门" >
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ColumnID="Ingredients" DataField="Ingredients" SortField="Ingredients" Width="150px" HeaderText="状态/配料号" >
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="BoxNo" DataField="BoxNo" SortField="BoxNo" Width="100px" HeaderText="箱号" >
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="BoxName" DataField="BoxName" SortField="BoxName" Width="100px" HeaderText="箱名" >
                             <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="BoxRemark" DataField="BoxRemark" SortField="BoxRemark" Width="150px" HeaderText="包装备注" >
                             <Editor>
                                <f:TextArea runat="server"></f:TextArea>
                            </Editor>
                        </f:RenderField>
                         <f:RenderField ColumnID="PlanDate" DataField="PlanDate" SortField="PlanDate" Width="120px" HeaderText="计划排产日期"
                            FieldType="Date" RendererArgument="yyyy-MM-dd"  >
                            <Editor>
                                <f:DatePicker runat="server"></f:DatePicker>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField ColumnID="PcRemark" DataField="PcRemark" SortField="PcRemark" Width="200px" HeaderText="排产单备注" >
                             <Editor>
                                <f:TextArea runat="server"></f:TextArea>
                            </Editor>
                        </f:RenderField>

                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="200px" HeaderText="申请单备注" />

                       

                        <f:BoundField ColumnID="CRMApplyNo" DataField="CRMApplyNo" SortField="CRMApplyNo" Width="150px" HeaderText="CRM申请单号" />
                        <f:BoundField ColumnID="CRMApplyNo_Xuhao" DataField="CRMApplyNo_Xuhao" SortField="CRMApplyNo_Xuhao" Width="150px" HeaderText="CRM申请单序号" />
                        <f:BoundField ColumnID="ClientName" DataField="ClientName" SortField="ClientName" Width="150px" HeaderText="客户名称" />

                        <f:BoundField ColumnID="ApplicantName" DataField="ApplicantName" SortField="ApplicantName" Width="120px" HeaderText="申请人" />
                        <f:BoundField ColumnID="OrderDate" DataField="OrderDate" SortField="OrderDate" Width="100px" HeaderText="下单日期"
                            DataFormatString="{0:yyyy-MM-dd}" />
                         <f:RenderField ColumnID="optdate" DataField="optdate" SortField="optdate" Width="120px" HeaderText="交付日期"
                            FieldType="Date" RendererArgument="yyyy-MM-dd"  >
                            <Editor>
                                <f:DatePicker runat="server"></f:DatePicker>
                            </Editor>
                        </f:RenderField>
                        <f:BoundField ColumnID="ApplyNoState" DataField="ApplyNoState" SortField="ApplyNoState" Width="100px" HeaderText="申请单状态" />

                        <f:BoundField ColumnID="ProductRecipe" DataField="ProductRecipe" SortField="ProductRecipe" Width="120px" HeaderText="生产配方" />
                        
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit1" />--%>
                    </Listeners>

                </f:Grid>
            </Items>
        </f:Panel>


        <script>
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

                $.each(checkBoxList1.i++ + tems, function (index, item) {
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

                $.each(modifiedData, function (index, rowData) {

                    // rowData.id: 行ID
                    // rowData.status: 行状态（newadded, modified, deleted）
                    // rowData.values: 行中修改单元格对象，比如 { "Name": "刘国2", "Gender": 0, "EntranceYear": 2003 }
                    if (rowData.status === 'deleted') {
                        return true; // continue
                    }

                    /*PcCount,PcUnit,BatchNo,Color,GiveDept,Ingredients,BoxNo,BoxName,BoxRemark,Plandate,PcRemark*/

                    var temp = ['BatchNo', 'PcCount', 'PcUnit', 'Color', 'GiveDept', 'Ingredients', 'BoxNo', 'BoxName', 'PlanDate'];
                    var tempStr = ['批号', '排产数量', '排产单位', '颜色', '供给部门', '配料号', '箱号', '箱名', '排产日期'];
                    for (i = 0; i < temp.length;i++) {
                        var tempIndex = rowData.values[temp[i]];
                        if (typeof (tempIndex) == 'undefined' || $.trim(tempIndex) == '') {
                            F.alert({
                                message: tempStr[i]+'不能为空！',
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
