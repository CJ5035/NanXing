<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionOrderEdit.aspx.cs" Inherits="NanXingGuoRen_WMS.ProductionOrder.ProductionOrderEdit" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1"></f:PageManager>

        <f:Panel runat="server" ID="Panel1" BodyPadding="5px" AutoScroll="true" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start">
            <Items>
                <f:Form runat="server" ID="form2" ShowBorder="false" ShowHeader="false" Layout="Fit">
                    <Rows>

                        <f:FormRow>
                            <Items>
                                <f:DropDownList runat="server" ID="ddl_Class" AutoPostBack="true" OnSelectedIndexChanged="ddl_Class_SelectedIndexChanged"
                                    Width="300px">
                                    <f:ListItem Text="原料车间" Value="原料车间" />
                                    <f:ListItem Text="烘烤车间" Value="烘烤车间" />
                                    <f:ListItem Text="大包装车间" Value="大包装车间" />
                                    <f:ListItem Text="小包装车间" Value="小包装车间" />
                                </f:DropDownList>
                                <f:TextBox runat="server" ID="ddlCheJian" Required="false" ShowRedStar="true" Label="车间类型" ShowLabel="true" Hidden="true" Width="300px"></f:TextBox>

                                <f:TextBox runat="server" ID="orderNo" Required="true" ShowRedStar="true" Label="编号" ShowLabel="true" Width="200px" Hidden="true"></f:TextBox>

                                <f:DatePicker runat="server" Label="下单日期" Required="true" ID="datepicker1" ShowRedStar="true"></f:DatePicker>

                                <f:ToolbarFill runat="server" />

                            </Items>
                        </f:FormRow>
                    </Rows>

                </f:Form>

                <f:Grid runat="server" BoxFlex="1" Title="编辑生产单" ShowHeader="false" ID="Grid1" ClicksToEdit="1"
                    AllowCellEditing="true" EnableCheckBoxSelect="true" PageSize="20" AutoSelectEditor="true" DataKeyNames="ID" SortField="id"
                     SummaryPosition="Bottom" EnableSummary="true">


                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增"></f:Button>
                                <f:Button ID="btnCopy" Text="复制选中行" Icon="Add" EnablePostBack="false" runat="server">
                                    <Listeners>
                                        <f:Listener Event="click" Handler="onCopyClick" />
                                    </Listeners>
                                </f:Button>
                                <f:Button runat="server" OnClientClick="if(!isValid()){return false;}" ID="btnSave" OnClick="btnSave_Click" Text="保存" Icon="SystemSave"></f:Button>
                                <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server">
                                </f:Button>

                                <f:Button ID="btnReset" Text="重置表格数据" EnablePostBack="false" runat="server">
                                </f:Button>

                                <f:ToolbarFill runat="server"></f:ToolbarFill>

                                <f:DropDownBox runat="server" ID="DropDownBox1" DataControlID="CheckBoxList1" EnableMultiSelect="true" Values="" Width="500px"
                                     Label="合并单元格">
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
                        <f:RenderField Width="100px" ColumnID="itemno" DataField="itemno" HeaderText="料号（隐藏列，用来将料号保存到数据库中）" Hidden="true">
                        </f:RenderField>
                        <f:RenderField HeaderText="客户" DataField="clientname" ColumnID="clientname" Width="150px" RendererFunction="RenderClient" Hidden="true">
                            <Editor>
                                <f:DropDownList runat="server" ID="ddlClient" Label="客户" EnableEdit="true" ShowLabel="false"
                                    AutoSelectFirstItem="false" ForceSelection="true" Required="true" ShowRedStar="true">
                                </f:DropDownList>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField HeaderText="物料编号" DataField="Code" ColumnID="Code" RendererFunction="renderItemno" Width="150px"
                            EnableColumnEdit="true" Hidden="true">
                            <Editor>
                                <f:DropDownBox runat="server" ID="ddbAllitem" EmptyText="请选择" MatchFieldWidth="false" EnableMultiSelect="false" EnableEdit="true"
                                    AutoPostBack="true" OnTextChanged="ddbAllitem_TextChanged">
                                    <PopPanel>
                                        <f:Grid runat="server" BoxFlex="1" Title="物料基础表" ID="Grid2" IsDatabasePaging="false" PageSize="1000" DataKeyNames="ID" Hidden="true"
                                            DataIDField="z" DataTextField="itemno" AllowSorting="true" SortField="库存平方" SortDirection="desc" OnSort="Grid2_Sort"
                                            Height="800px">
                                            <%-- <Toolbars>
                                                <f:Toolbar runat="server">
                                                    <Items>
                                                        <f:TextBox runat="server" Label="关键词" ID="tbxSearch" FocusOnPageLoad="true"></f:TextBox>
                                                        <f:Button runat="server" Text="搜索" ID="btnSearch" OnClick="btnSearch_Click" Icon="SystemSearch"></f:Button>
                                                    </Items>
                                                </f:Toolbar>
                                            </Toolbars>--%>
                                            <Columns>
                                                <f:RowNumberField EnablePagingNumber="true"></f:RowNumberField>
                                                <f:RenderField HeaderText="物料编号" DataField="itemno" SortField="itemno" ColumnID="itemno">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="名称" DataField="name" SortField="name" ColumnID="name" Width="150px">
                                                </f:RenderField>
                                                <f:RenderField HeaderText="规格" DataField="spec" SortField="spec" ColumnID="spec">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>

                                                <f:RenderField HeaderText="销售型号" DataField="inName" SortField="inName" ColumnID="inName">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="颜色" DataField="color" SortField="color" ColumnID="color">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="材质" DataField="material" SortField="material" ColumnID="material">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="宽" DataField="width" SortField="width" ColumnID="width">
                                                </f:RenderField>
                                                <f:RenderField HeaderText="长" DataField="length" SortField="length" ColumnID="length">
                                                </f:RenderField>

                                                <f:RenderField HeaderText="库存数量" DataField="库存数量" SortField="库存数量" ColumnID="库存数量" FieldType="Int">
                                                </f:RenderField>
                                                <f:RenderField HeaderText="库存平方(m²)" DataField="库存平方" SortField="库存平方" ColumnID="库存平方" FieldType="Double">
                                                </f:RenderField>
                                                <f:RenderField HeaderText="单价" DataField="price" SortField="price" ColumnID="price">
                                                    <Editor>
                                                        <f:NumberBox runat="server" NoNegative="true" DecimalPrecision="4"></f:NumberBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="单位" DataField="unit" SortField="unit" ColumnID="unit">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>

                                                <f:RenderField HeaderText="物品类别" DataField="Class" SortField="Class" ColumnID="Class">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="科目类别" DataField="SubjectClass" SortField="SubjectClass" ColumnID="SubjectClass">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="配置1" DataField="config1" SortField="config1" ColumnID="config1">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>

                                                <f:RenderField HeaderText="配置2" DataField="config2" SortField="config2" ColumnID="config2">
                                                </f:RenderField>

                                                <f:RenderField HeaderText="配置3" DataField="config3" SortField="config3" ColumnID="config3">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="配置4" DataField="config4" SortField="config4" ColumnID="config4">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="厂家型号" DataField="model" SortField="model" ColumnID="model">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="配置5" DataField="config5" SortField="config5" ColumnID="config5">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="备注说明" DataField="remark" SortField="remark" ColumnID="remark">
                                                    <Editor>
                                                        <f:TextBox runat="server"></f:TextBox>
                                                    </Editor>
                                                </f:RenderField>
                                                <f:RenderField HeaderText="供应商" DataField="Provider" SortField="Provider" ColumnID="Provider" RendererFunction="RenderProvider" Width="250px">
                                                </f:RenderField>
                                                <f:RenderField DataField="PO_Item_ID" ColumnID="PO_Item_ID" HeaderText="物料ID" Hidden="true"></f:RenderField>
                                            </Columns>

                                            <Listeners>
                                                <f:Listener Event="rowclick" Handler="onGrid2RowClick" />
                                            </Listeners>
                                        </f:Grid>
                                    </PopPanel>
                                </f:DropDownBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField HeaderText="品名" DataField="name" SortField="name" ColumnID="name" Width="250px">
                            <Editor>
                                <f:DropDownList runat="server" ID="ddlname" EnableEdit="true"></f:DropDownList>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField HeaderText="规格" DataField="spec" SortField="spec" ColumnID="spec" Width="150px">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField HeaderText="单位" DataField="unit" SortField="unit" ColumnID="unit"  SummaryText="合计：">
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

                        <f:RenderField HeaderText="数量" DataField="count" ColumnID="count" FieldType="Float" SummaryType="Sum">
                            <Editor>
                                <f:NumberBox runat="server" NoNegative="true" DecimalPrecision="4"></f:NumberBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField HeaderText="批号" ID="batchNo" DataField="batchNo" ColumnID="batchNo"  SummaryText="箱">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField HeaderText="箱号" ID="boxNo" Hidden="true" DataField="boxNo" ColumnID="boxNo">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>


                        <f:RenderField HeaderText="纸箱" ID="boxName" Hidden="true" DataField="boxName" ColumnID="boxName">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField HeaderText="状态/配料号" ID="ingredients" Hidden="true" DataField="ingredients" ColumnID="ingredients">
                            <Editor>
                                <f:TextBox runat="server"></f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField HeaderText="ERP订单" DataField="ERPOrderNo" ColumnID="ERPOrderNo"  Width="150px" >
                           <Editor>
                               <f:TextBox runat="server"></f:TextBox>
                           </Editor>
                       </f:RenderField>
                        <f:RenderField HeaderText="ERP料号" DataField="itemno" ColumnID="itemno"  Width="120px" >
                           <Editor>
                               <f:TextBox runat="server"></f:TextBox>
                           </Editor>
                       </f:RenderField>
                        <f:RenderField HeaderText="计划完成日期" DataField="PlanDate" ColumnID="PlanDate"  Width="120px" 
                             RendererArgument="yyyy-MM-dd" Renderer="Date">
                           <Editor>
                               <f:DatePicker runat="server"></f:DatePicker>
                           </Editor>
                       </f:RenderField>
                        <f:RenderField HeaderText="备注" DataField="remark1" ColumnID="remark1" ExpandUnusedSpace="true" MinWidth="200px">
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

            var ddlClient = '<%=ddlClient.ClientID%>';
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
            <%--function editGetterGrid2(editor, columnId, rowId) {
                console.log(2783);
                var tbxSearch = '<%=tbxSearch.ClientID%>';
                F(tbxSearch).focus();
            }--%>



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
            function RenderClient(value) {
                return F(ddlClient).getTextByValue(value);
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
                    'unit': rowValue.unit,
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
                var datepicker1 = F('<%= datepicker1.ClientID %>');
                console.log(datepicker1.value);
                //var client = F('<%= ddlClient.ClientID %>');

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
        </script>
    </form>
</body>
</html>
