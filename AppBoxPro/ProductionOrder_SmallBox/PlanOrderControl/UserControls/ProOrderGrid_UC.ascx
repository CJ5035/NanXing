<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProOrderGrid_UC.ascx.cs"
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanOrderControl.UserControls.ProOrderGrid_UC" %>
<style>
     .f-grid-cell-inner {
            opacity: .5;
            filter: alpha(opacity=50);
        }

        .f-grid-cell-editable .f-grid-cell-inner {
            opacity: 1;
            filter: alpha(opacity=100);
        }

        .f-grid-rownumberfield .f-grid-cell-inner {
            opacity: 1;
            filter: alpha(opacity=100);
        }

</style>


<f:Grid runat="server" ID="Grid1"
    Title="合并任务单" ShowHeader="false"
    ClicksToEdit="1" AllowCellEditing="true" EnableCheckBoxSelect="false"
    AutoSelectEditor="true" PageSize="100" 
    DataKeyNames="ID,ProPlanOrderheaders_ID,CRMPlanList_ID,ItemName,ItemName1,ItemName2,Itemno,
    PcCount,PcUnit,BoxNo,BoxName,PlanDate,BoxRemark,BatchNo,PlanTime,Priority,Remark,Spec"
    SortField="ID" IsDatabaseSorting="true"
    AllowColumnLocking="true" EnableColumnLines="true">

    <Toolbars>
        <f:Toolbar runat="server">
            <Items>
                <f:Button runat="server" ID="btnEnableEdit" Text="修改" Icon="ApplicationEdit"  OnClick="btnChange_Click" >
                </f:Button>

                <f:Button runat="server" ID="btnSave" Text="保存"  Icon="SystemSave"
                    ConfirmText="确认保存计划排产单？" ConfirmTarget="Top"
                    OnClick="btnSave_Click" />
                <%--OnClientClick="if(!isValid()){return false;}"--%> 
                <f:Button runat="server" ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false"
                     Hidden="true">
                </f:Button>

                <f:Button runat="server" ID="btnReset" Text="重置表格数据" EnablePostBack="false" >
                </f:Button>

                <f:ToolbarFill runat="server"/>
                <f:Label runat="server" ID="Lab_BeforeCount" Label="BeforeCount" 
                    Width="200px" LabelWidth="80px" MarginLeft="20px" Hidden="true"/>

                <f:TextBox runat="server" ID="tbx_OrderNo" Label="排产单号" 
                    Text="" Enabled="false" EmptyText="保存自动生成"/>

                <f:Label runat="server" ID="Lab_PCY" Label="排产人员" 
                    Width="200px" LabelWidth="80px" MarginLeft="20px"/>

                <f:Label runat="server" ID="Lab_IsHandAdd" Label="是否手动新增" 
                    Width="200px" LabelWidth="80px" MarginLeft="20px" Hidden="true"/>

                <f:Label runat="server" ID="Lab_RedisKey" Label="Redis_Key" 
                    Width="200px" LabelWidth="80px" MarginLeft="20px" Hidden="true"/>

                <f:DatePicker runat="server" ID="hbDate" Label="合并日期" Width="200px" LabelWidth="80px"
                    EnableDateSelectEvent="true" />
                
               
            </Items>
        </f:Toolbar>

    </Toolbars>

    <Columns>
        <f:RowNumberField EnablePagingNumber="true"/>

        <f:BoundField ColumnID="Itemno" DataField="Itemno" SortField="Itemno" Width="120px"
            HeaderText="产品编码" EnableLock="true" Locked="true" Hidden="true" />

         <f:RenderField ColumnID="ProPlanOrderheaders_ID" DataField="ProPlanOrderheaders_ID" SortField="ProPlanOrderheaders_ID" Width="120px"
            HeaderText="排产单表头ID"  EnableLock="true" Locked="true" Hidden="true" />

         <f:BoundField ColumnID="CRMPlanList_ID" DataField="CRMPlanList_ID" SortField="CRMPlanList_ID" Width="120px"
            HeaderText="CRM申请单明细ID" EnableLock="true" Locked="true" Hidden="true" />

        <f:RenderField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="120px"
            HeaderText="产品名称" EnableLock="true" Locked="true"   RendererFunction="renderMajor"/>

         <f:BoundField ID="ItemName1" ColumnID="ItemName1" DataField="ItemName1" SortField="ItemName1" Width="120px"
            HeaderText="排产名称" EnableLock="true" Locked="true" />

         <f:BoundField ColumnID="ItemName2" DataField="ItemName2" SortField="ItemName2" Width="120px"
            HeaderText="原料名称" EnableLock="true" Locked="true" Hidden="true" />

          <f:RenderField ID="Spec" ColumnID="Spec" DataField="Spec" SortField="Spec" Width="80px"
            HeaderText="规格">
            <Editor>
                <f:TextBox runat="server"></f:TextBox>
            </Editor>
        </f:RenderField>



        <f:RenderField ID="PcCount" ColumnID="PcCount" DataField="PcCount" SortField="PcCount" Width="80px"
            HeaderText="排产数量">
            <Editor>
                <f:NumberBox runat="server"></f:NumberBox>
            </Editor>
        </f:RenderField>

     

        <f:RenderField ID="PcUnit" ColumnID="PcUnit" DataField="PcUnit" SortField="PcUnit" Width="80px"
            HeaderText="排产单位">
            <Editor>
                <f:TextBox runat="server"></f:TextBox>
            </Editor>
        </f:RenderField>

        <f:RenderField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="150px"
            HeaderText="排产单备注" ExpandUnusedSpace="true">
            <Editor>
                <f:TextArea runat="server"></f:TextArea>
            </Editor>
        </f:RenderField>

        <f:RenderField ColumnID="PlanDate" DataField="PlanDate" SortField="PlanDate" Width="120px"
            HeaderText="计划排产日期"
            FieldType="Date" RendererArgument="yyyy-MM-dd">
            <Editor>
                <f:DatePicker runat="server"></f:DatePicker>
            </Editor>
        </f:RenderField>

        <f:RenderField ColumnID="PlanTime" DataField="PlanTime" SortField="PlanTime" Width="80px"
            HeaderText="排产班次">
            <Editor>
                <f:DropDownList runat="server">
                    <f:ListItem Text="上午" Value="上午" />
                    <f:ListItem Text="下午" Value="下午" />
                    <f:ListItem Text="晚上" Value="晚上" />
                </f:DropDownList>
            </Editor>
        </f:RenderField>

        <f:RenderField ColumnID="Priority" DataField="Priority" SortField="Priority" Width="80px" 
            HeaderText="优先度" >
            <Editor>
                <f:DropDownList runat="server">
                    <f:ListItem Text="正常" Value="正常" Selected="true" />
                    <f:ListItem Text="紧急" Value="紧急" />
                    <f:ListItem Text="加急" Value="加急" />
                </f:DropDownList>
            </Editor>
        </f:RenderField>

        <f:RenderField ColumnID="BatchNo" DataField="BatchNo" SortField="BatchNo" Width="80px"
            HeaderText="批号">
            <Editor>
                <f:TextBox runat="server"></f:TextBox>
            </Editor>
        </f:RenderField>

        <f:RenderField ID="BoxNo" ColumnID="BoxNo" DataField="BoxNo" SortField="BoxNo" Width="80px"
            HeaderText="箱号">
            <Editor>
                <f:TextBox runat="server"></f:TextBox>
            </Editor>
        </f:RenderField>

        <f:RenderField  ColumnID="BoxName" DataField="BoxName" SortField="BoxName" Width="100px"
            HeaderText="箱名"   RendererFunction="renderMajor">
            <Editor>
                <f:TextBox runat="server"></f:TextBox>
            </Editor>
        </f:RenderField>

        <f:RenderField ColumnID="BoxRemark" DataField="BoxRemark" SortField="BoxRemark" Width="150px"
            HeaderText="包装备注"   RendererFunction="renderMajor">
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

<script>
    
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
       
        console.log(grid1);
        $.each(modifiedData, function (index, rowData) {

            // rowData.id: 行ID
            // rowData.status: 行状态（newadded, modified, deleted）
            // rowData.values: 行中修改单元格对象，比如 { "Name": "刘国2", "Gender": 0, "EntranceYear": 2003 }
            if (rowData.status === 'deleted') {
                return true; // continue
            }

            /*PcCount,PcUnit,BatchNo,Color,GiveDept,Ingredients,BoxNo,BoxName,BoxRemark,Plandate,PcRemark*/

            

            var temp = ['PcCount', 'PcUnit', 'BoxNo', 'BoxName', 'PlanDate'];
            var tempStr = ['排产数量', '排产单位', '箱号', '箱名', '排产日期'];
           
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

</script>
