<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionOrderNew.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder.ProductOrderControl.ProductionOrderNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <style>
        .f-grid-cell.f-grid-cell-ItemNo
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-ItemName
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-InName
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }
        .f-grid-cell.f-grid-cell-MaterialItem
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }
        .f-grid-cell.f-grid-cell-Workshops
		.f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }
        
        .f-grid-row-summary .f-grid-cell-inner {
            font-weight: bold;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>

        <f:Panel runat="server" ID="Panel1" BodyPadding="5px" AutoScroll="true" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start">
            <Items>
                <f:Panel runat="server" ShowHeader="false" ID="Panel99" Layout="HBox" Height="100px" Width="100%" >
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

                <f:Grid runat="server" BoxFlex="1" Title="编辑生产单" ShowHeader="false" ID="Grid1" ClicksToEdit="1"
                    AllowCellEditing="true" EnableCheckBoxSelect="true" PageSize="20" AutoSelectEditor="true"
                    DataKeyNames="ID" SortField="ID" OnRowDataBound="Grid1_RowDataBound"
                     SummaryPosition="Bottom" EnableSummary="true">


                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:Button ID="btnChange" runat="server" Icon="ApplicationFormEdit" EnablePostBack="true" Text="修改"
                                     OnClientClick="OnChange()" OnClick="btnChange_Click"   Enabled="false" />
                                <f:ToolbarSeparator runat="server"></f:ToolbarSeparator>
                                <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增"/>
                                <f:Button ID="btnCopy" Text="复制选中行" Icon="Add" EnablePostBack="false" runat="server">
                                    <Listeners>
                                        <f:Listener Event="click" Handler="onCopyClick" />
                                    </Listeners>
                                </f:Button>

                                <f:Button runat="server" ID="btnSave"
                                     ConfirmText="确认保存该排产单的修改？" ConfirmTarget="Top" Text="保存" Icon="SystemSave"
                                    OnClientClick="if(!isValid()){return false;}"  OnClick="btnSave_Click" />

                                <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server" />

                                <f:Button ID="btnReset" Text="重置表格数据" EnablePostBack="false" runat="server" />

                                <f:ToolbarFill runat="server"></f:ToolbarFill>

                                <f:DropDownBox runat="server" ID="DropDownBox1" DataControlID="CheckBoxList1" EnableMultiSelect="true" 
                                    Values="" Width="500px" Label="合并单元格" >
                                    <PopPanel>
                                        <f:SimpleForm ID="SimpleForm2" BodyPadding="10px" runat="server" AutoScroll="true"
                                            ShowBorder="true" ShowHeader="false" Hidden="true">
                                            <Items>
                                                <f:Label ID="Label1" runat="server" Text="请选择编程语言：" Hidden="true"></f:Label>
                                                <f:CheckBoxList ID="CheckBoxList1" ColumnNumber="3" runat="server">
                                                    <f:CheckItem Text="品名" Value="name" />
                                                    <f:CheckItem Text="规格" Value="spec" />
                                                    <f:CheckItem Text="单位" Value="unit" />
                                                    <f:CheckItem Text="数量" Value="count" />
                                                    <f:CheckItem Text="批号" Value="batchNo" />
                                                    <f:CheckItem Text="箱号" Value="boxNo" />
                                                    <f:CheckItem Text="纸箱" Value="boxName" />
                                                    <f:CheckItem Text="状态/配料号" Value="ingredients" />
                                                    <f:CheckItem Text="备注" Value="remark1" Selected="true" />
                                                    
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
                        <f:RenderField Width="100px" ColumnID="Itemno" DataField="Itemno" HeaderText="料号（隐藏列，用来将料号保存到数据库中）" Hidden="true">
                        </f:RenderField>
                        
                        <f:RenderField HeaderText="产品料号" DataField="Itemno2" ColumnID="Itemno2"  Width="180px" RendererFunction="renderCode" >
                            <Editor>
                                <f:DropDownBox runat="server" ID="DropDownBox2" EmptyText="请选择" MatchFieldWidth="false" EnableMultiSelect="false">
                                    <PopPanel>
                                        <f:Grid runat="server"  ID="Grid2" ShowBorder="true" ShowHeader="false"  DataIDField="ItemNo"
                                            DataTextField="ItemNo" Hidden="true" Width="1200px" Height="300px" EnableMultiSelect="false">
                                            <Toolbars>
                                                <f:Toolbar runat="server">
                                                    <Items>
                                                        <f:TextBox runat="server" ID="tbxSearchItem" Label="关键字">
                                                        </f:TextBox>
                                                        <f:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click"
                                                             Text="搜索">
                                                        </f:Button>
                                                    </Items>
                                                </f:Toolbar>
                                            </Toolbars>

                                            <Columns>
                                                 <f:RowNumberField />
                                                 <f:BoundField DataField="ItemNo" SortField="ItemNo" ColumnID="ItemNo" HeaderText="物料编号" Width="200px"/>
                                                 <f:BoundField DataField="ItemName" SortField="ItemName" ColumnID="ItemName" HeaderText="物料名称" Width="250px"/>
                                                 <f:BoundField DataField="InName" SortField="InName" ColumnID="InName" HeaderText="产品别名" Width="250px"/>
                                                 <f:BoundField DataField="MaterialItem" SortField="MaterialItem" ColumnID="MaterialItem" HeaderText="原料名称" Width="250px"/>
                                                 <f:BoundField DataField="Spec" SortField="Spec" ColumnID="Spec" HeaderText="规格" Width="100px"/>
                                                 <f:BoundField DataField="SlaveUtil" SortField="SlaveUtil" ColumnID="SlaveUtil" HeaderText="辅单位" Width="90px"/>
                                                 <f:BoundField DataField="Workshops" SortField="Workshops" ColumnID="Workshops" HeaderText="排产车间" Width="250px"/>
                                            </Columns>

                                            <Listeners>
                                                <f:Listener Event="rowclick" Handler="onGrid2RowClick" />
                                            </Listeners>
                                        </f:Grid>

                                    </PopPanel>

                                </f:DropDownBox>
                            </Editor>
                       </f:RenderField>
                        <f:RenderField HeaderText="品名" ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="250px">
                            
                        </f:RenderField>
                        <f:RenderField HeaderText="规格" ColumnID="Spec" DataField="Spec" SortField="Spec"  Width="90px">
                           
                        </f:RenderField>

                        <f:RenderField HeaderText="单位" DataField="Unit" SortField="Unit" ColumnID="Unit"  Width="90px"  SummaryText="合计：">
                            <Editor>
                                <%--<f:TextBox runat="server"></f:TextBox>--%>
                                 <f:DropDownList  runat="server">
                                      <f:ListItem  Text="件" Value="件" Selected="true"/>
                                      <f:ListItem  Text="kg" Value="kg"/>
                                      <f:ListItem  Text="g" Value="g"/>
                                      <f:ListItem  Text="吨" Value="吨"/>
                                      <f:ListItem  Text="柜" Value="柜"/>
                                      <f:ListItem  Text="包" Value="包"/>

                                  </f:DropDownList>
                            </Editor>
                        </f:RenderField>
                          
                        <f:RenderField HeaderText="数量" ColumnID="PcCount" FieldType="Float" DataField="PcCount" ID="PcCount"   SummaryType="Sum">
                            <Editor>
                                <f:NumberBox runat="server" NoNegative="true" DecimalPrecision="4"></f:NumberBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField HeaderText="批号" ID="BatchNo" DataField="BatchNo" ColumnID="BatchNo"  SummaryText="箱">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField HeaderText="箱号" ID="BoxNo" DataField="BoxNo" ColumnID="BoxNo" >
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>


                        <f:RenderField HeaderText="纸箱" ID="BoxName" DataField="BoxName" ColumnID="BoxName">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField HeaderText="状态/配料号" ID="Ingredients" DataField="Ingredients" ColumnID="Ingredients">
                            <Editor>
                                <f:TextBox runat="server" ></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField HeaderText="CRM订单" DataField="ERPOrderNo" ColumnID="ERPOrderNo"  Width="150px" Hidden="true">
                           <Editor>
                               <f:TextBox runat="server"></f:TextBox>
                           </Editor>
                       </f:RenderField>
                      
                        <f:RenderField HeaderText="计划排产日期" DataField="PlanDate" ColumnID="PlanDate"  Width="120px" 
                             RendererArgument="yyyy-MM-dd" Renderer="Date">
                           <Editor>
                               <f:DatePicker runat="server"></f:DatePicker>
                           </Editor>
                       </f:RenderField>
                        <f:RenderField HeaderText="备注" DataField="Remark" ColumnID="Remark" ExpandUnusedSpace="true" MinWidth="200px">
                            <Editor>
                                <f:TextArea runat="server"></f:TextArea>
                            </Editor>
                        </f:RenderField>
                    </Columns>

                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
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


            function onClearAllClick() {
                var checkBoxList1 = F(checkBoxList1ClientID);
                $.each(checkBoxList1.items, function (index, item) {
                    item.setValue(false);
                });

                // 将数据控件中的值同步到输入框
                F(dropDownBox1ClientID).syncToBox();
            }


            var grid1ClientID = '<%= Grid1.ClientID %>';
            var grid2ClientID = '<%= Grid2.ClientID %>';

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

            function onGridDataLoad(event) {
                //this.mergeColumns(['ingredients', 'remark1']);
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
         
            function renderCode(value) {
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
                    'Itemno2': grid2RowId,
                    'Itemno': grid2RowId,
                    'ItemName': rowValue.ItemName,
                    'Spec': rowValue.Spec,
                    'Unit': rowValue.SlaveUtil,
                });

            }


            function calculateCountValue(rowValue) {
                var count = 0;
                count = rowValue['width'] / 1000 * rowValue['length'] * rowValue['count'];
                if (isNaN(count)) {
                    count = 0;
                }
                return count;
            }

            
            function isValid() {
                var grid1 = F(grid1ClientID);
                var valid = true, modifiedData = grid1.getModifiedData();
              

                $.each(modifiedData, function (index, rowData) {

                    // rowData.id: 行ID
                    // rowData.status: 行状态（newadded, modified, deleted）
                    // rowData.values: 行中修改单元格对象，比如 { "Name": "刘国2", "Gender": 0, "EntranceYear": 2003 }
                    if (rowData.status === 'deleted') {
                        return true; // continue
                    }

                    //var itemno = rowData.values['itemno'];
                    var count = rowData.values['count'];
                    //var price = rowData.values['price'];
                    //var priceOut = rowData.values['priceOut'];
                    //// 更改了姓名列，并且为空字符串
                    //// 如果typeof(name)=='undefined'，则表示姓名没有更改，需要排除在外！！
                    //if (typeof (itemno) != 'undefined' && $.trim(itemno) == '') {
                    //    F.alert({
                    //        message: '料号不能为空！',
                    //        ok: function () {
                    //            grid1.startEdit(rowData.id, 'itemno');
                    //        }
                    //    });

                    //    valid = false;

                    //    return false; // break
                    //}

                    //count
                    if (typeof (count) != 'undefined' && $.trim(count) == '') {
                        F.alert({
                            message: '数量不能为空！',
                            ok: function () {
                                grid1.startEdit(rowData.id, 'count');
                            }
                        });

                        valid = false;

                        return false; // break
                    }

                });


                return valid;
            }
            
            var columnsStr = "Itemno ItemName Spec Unit PcCount BatchNo BatchNo BoxNo BoxName Ingredients ERPOrderNo PlanDate Remark";
            function OnChange() {
                var columsArr = columnsStr.split(' ');
                var grid1 = F(grid1ClientID);
                for (var index = 0; index < 20; index++) {
                    try {
                        columsArr.forEach(item => {
                            //console.log(index + ':' + item);
                            grid1.updateCellValue(index, item + '.cls', '');

                        });
                    } catch (err) {
                        break;
                    }
                }
            }
        </script>
    </form>
</body>
</html>
