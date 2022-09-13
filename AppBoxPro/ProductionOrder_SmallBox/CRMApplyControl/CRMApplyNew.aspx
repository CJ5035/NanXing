<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRMApplyNew.aspx.cs"
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.CRMApplyControl.CRMApplyNew" %>

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

        /* .f-grid-cell-inner,
        .f-grid-cell.f-grid-cell-Remark
*/
        /*.f-grid-cell.f-grid-cell-ItemNo
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
        .f-grid-row .f-grid-cell-PcCount_03
        .f-grid-cell-inner,
        .f-grid-row .f-grid-cell-PlanDate
        .f-grid-cell-inner,*/
        .f-grid-row .f-grid-cell-Remark
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
        .f-grid-row .f-grid-cell-PcCount_03,
        .f-grid-row .f-grid-cell-PlanDate,
        .f-grid-row .f-grid-cell-PlanTime,
        {
            background-color: #FFE7BA;
            color: #000;
        }

       
       
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
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" AutoSizePanelID="Panel1" ID="PageManager1"
            OnCustomEvent="PageManager1_CustomEvent"></f:PageManager>

        <f:Panel runat="server" ID="Panel1" BodyPadding="5px" AutoScroll="true"
            ShowBorder="false" ShowHeader="false" Layout="VBox"
            BoxConfigAlign="Stretch" BoxConfigPosition="Start">
            <Items>

                <f:Grid runat="server" ID="Grid0" PageSize="8" DataKeyNames="ID,Spec"
                    ShowHeader="true" Title="成品基本信息" BoxFlex="1">
                    <Columns>

                        <f:RowNumberField EnablePagingNumber="true"></f:RowNumberField>
                        <f:RenderField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="120px"
                            HeaderText="产品名称" EnableLock="true" Locked="true" RendererFunction="renderMajor"/>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="80px" HeaderText="订单单位" />
                        <f:BoundField ColumnID="OrderCount" DataField="OrderCount" SortField="OrderCount" Width="80px" 
                            HeaderText="订单数量" />
                        <f:RenderField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="80px"
                            HeaderText="包装规格" RendererFunction="renderMajor"/>
                        <f:BoundField ColumnID="Biaozhun" DataField="Biaozhun" SortField="Biaozhun" Width="80px" 
                            HeaderText="排产标准" />
                        <f:RenderField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="200px" 
                            HeaderText="申请单备注" RendererFunction="renderMajor"/>
                        <f:RenderField ColumnID="ProductRecipe" DataField="ProductRecipe" SortField="ProductRecipe" 
                            Width="80px" HeaderText="生产配方" RendererFunction="renderMajor"/>
                        <f:BoundField ColumnID="InventoryCount" DataField="InventoryCount" SortField="InventoryCount" 
                            Width="80px" HeaderText="库存数量" />
                        <f:BoundField ColumnID="EmergencyDegree" DataField="EmergencyDegree" SortField="EmergencyDegree"
                            Width="80px" HeaderText="紧急程度" />
                        <f:RenderField ColumnID="DeliveryDate" DataField="DeliveryDate" SortField="DeliveryDate" Width="100px" HeaderText="交付日期"
                            FieldType="Date" RendererArgument="yyyy-MM-dd">
                            <Editor>
                                <f:DatePicker runat="server"></f:DatePicker>
                            </Editor>
                        </f:RenderField>
                        <f:BoundField ColumnID="CRMApplyNo" DataField="CRMApplyNo" SortField="CRMApplyNo" Width="150px" HeaderText="CRM申请单号" />
                        <f:BoundField ColumnID="CRMApplyNo_Xuhao" DataField="CRMApplyNo_Xuhao" SortField="CRMApplyNo_Xuhao" Width="150px" HeaderText="CRM申请单序号" />
                        <f:RenderField ColumnID="ClientName" DataField="ClientName" SortField="ClientName" Width="150px"
                            HeaderText="客户名称" RendererFunction="renderMajor"/>

                        <f:BoundField ColumnID="ApplicantName" DataField="ApplicantName" SortField="ApplicantName" Width="120px" HeaderText="申请人" />
                        <f:BoundField ColumnID="OrderDate" DataField="OrderDate" SortField="OrderDate" Width="100px" HeaderText="下单日期"
                            DataFormatString="{0:yyyy-MM-dd}" />
                        <f:BoundField ColumnID="ApplyNoState" DataField="ApplyNoState" SortField="ApplyNoState" Width="100px" HeaderText="申请单状态" />

                    </Columns>
                </f:Grid>

                <f:Panel runat="server" ShowHeader="false" ID="Panel99" Layout="HBox" Width="100%">
                    <Items>
                        <f:Panel ID="Panel7" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="0px"  BoxFlex="1">
                            <Items>
                                <f:Label runat="server" Label="选择车间" Width="150px"></f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel2" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" BoxFlex="10">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList2" ColumnNumber="3" runat="server"
                                    AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged"
                                    BoxFlex="2">
                                    <Items>
                                        <f:CheckItem Text="03小包装-小袋" Value="03小包装-小袋" />
                                        <f:CheckItem Text="03小包装-罐" Value="03小包装-罐" />
                                        <f:CheckItem Text="03小包装-每日坚果" Value="03小包装-每日坚果" />

                                    </Items>
                                    <Listeners>
                                        <f:Listener Event="change" Handler="onCheckBoxList2Change" />
                                    </Listeners>
                                </f:CheckBoxList>

                                <f:CheckBoxList ID="CheckBoxList3" ColumnNumber="3" runat="server"
                                    BoxFlex="2"
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
                                <f:Label runat="server" BoxFlex="1"> </f:Label>
                            </Items>
                        </f:Panel>

                    </Items>
                </f:Panel>

                <f:Panel ID="Panel8" runat="server" ShowHeader="false" ShowBorder="false"
                    IsFluid="false" BoxFlex="2"
                    Layout="HBox">
                    <Items>
                        <f:ButtonGroup ID="ButtonGroup1" CssClass="mybuttongroup f-state-default"
                            Layout="VBox" runat="server" Vertical="true" BoxFlex="1" Hidden="true">
                            <Items>
                                <f:Button ID="Button0" runat="server" Text="车间工序" Pressed="true" Hidden="false" Icon="Cake" EnablePress="true"></f:Button>

                                <f:Button ID="Button1" runat="server" Text="03小包装-小袋" Icon="Cake">
                                </f:Button>
                                <f:Button ID="Button2" runat="server" Text="03小包装-罐" IconFont="_Bank">
                                </f:Button>
                                <f:Button ID="Button3" runat="server" Text="03小包装-每日坚果" IconFont="_Group">
                                </f:Button>
                                <f:Button ID="Button4" runat="server" Text="07小包装-小袋" IconFont="_Group">
                                </f:Button>
                                <f:Button ID="Button5" runat="server" Text="07小包装-罐" IconFont="_Group">
                                </f:Button>
                                <f:Button ID="Button6" runat="server" Text="07小包装-每日坚果" IconFont="_Group">
                                </f:Button>
                            </Items>
                            <Listeners>
                                <f:Listener Event="presschange" Handler="onButtonGroupPressChange" />
                            </Listeners>
                        </f:ButtonGroup>

                        <%----%>
                        <f:TabStrip ID="TabStrip1" CssClass="mytabstrip"
                            EnableTabCloseMenu="true" BoxFlex="8"
                            ShowBorder="false" ShowTabHeader="true"
                            runat="server" AnimationType="Fade"
                            MarginTop="0" ActiveTabIndex="6"
                            AutoScroll="true">
                            <Tabs>

                                <f:Tab runat="server" ID="Tab1" Title="03小包装-小袋"
                                    Layout="Fit" EnableClose="false" Hidden="true">
                                    <Items>
                                        <f:Label runat="server" ID="EditFinish" Text="false" Hidden="true"></f:Label>
                                        <f:UserControlConnector runat="server">
                                            <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC1" 
                                                Position="03小包装-小袋" />
                                        </f:UserControlConnector>
                                    </Items>
                                </f:Tab>

                                <f:Tab runat="server" ID="Tab2" Title="03小包装-罐" EnableClose="false"
                                    Layout="Fit" Hidden="true">
                                    <Items>
                                        <f:Label runat="server" ID="Label1" Text="false" Hidden="true"></f:Label>
                                        <f:UserControlConnector runat="server">
                                            <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC2" 
                                                Position="03小包装-罐" />
                                        </f:UserControlConnector>
                                    </Items>
                                </f:Tab>

                                 <f:Tab runat="server" ID="Tab3" Title="03小包装-每日坚果"
                                    Layout="Fit"  Hidden="true">
                                    <Items>
                                        <f:Label runat="server" ID="Label2" Text="false" Hidden="true"></f:Label>
                                        <f:UserControlConnector runat="server">
                                            <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC3" 
                                                Position="03小包装-每日坚果" />
                                        </f:UserControlConnector>
                                    </Items>
                                </f:Tab>

                                <f:Tab runat="server" ID="Tab4" Title="07小包装-小袋"
                                    Layout="Fit" Hidden="true">
                                    <Items>
                                        <f:Label runat="server" ID="Label3" Text="false" Hidden="true"></f:Label>
                                        <f:UserControlConnector runat="server">
                                            <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC4" 
                                                Position="07小包装-小袋" />
                                        </f:UserControlConnector>
                                    </Items>
                                </f:Tab>

                                <f:Tab runat="server" ID="Tab5" Title="07小包装-罐"
                                    Layout="Fit" Hidden="true">
                                    <Items>
                                        <f:Label runat="server" ID="Label4" Text="false" Hidden="true"></f:Label>
                                        <f:UserControlConnector runat="server">
                                            <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC5" 
                                                Position="07小包装-罐" />
                                        </f:UserControlConnector>
                                    </Items>
                                </f:Tab>

                                <f:Tab runat="server" ID="Tab6" Title="07小包装-每日坚果"
                                    Layout="Fit" Hidden="true">
                                    <Items>
                                        <f:UserControlConnector runat="server">
                                            <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC6" 
                                                Position="07小包装-每日坚果" />
                                        </f:UserControlConnector>
                                    </Items>
                                </f:Tab>



                                <f:Tab runat="server" Title="<span class='highlight'>确认页面</span>">
                                    <Items>

                                        <%--<f:PageManager ID="PageManager1"  runat="server" />--%>
                                        <f:Label runat="server"></f:Label>
                                        <f:Button runat="server" ID="Btn_SaveExit" Text="退出并保存"
                                            OnClick="Btn_SaveExit_Click">
                                        </f:Button>
                                    </Items>
                                </f:Tab>
                            </Tabs>


                        </f:TabStrip>
                    </Items>
                </f:Panel>

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
            var tabStrip1 = '<%= TabStrip1.ClientID %>';


            function onButtonGroupPressChange(event) {
                var btnIndex = btn.el.index('.f-btn');

                // 激活相应的选项卡
                F(tabStrip1).getItem(btnIndex).active();
            }

            var checkBoxList2ClientID = '<%= CheckBoxList2.ClientID %>';
            var checkBoxList3ClientID = '<%= CheckBoxList3.ClientID %>';
            function onCheckBoxList2Change(event, btn) {
                var checkBoxList2 = F(checkBoxList2ClientID);
                var selectedValues2 = checkBoxList2.getValue();

                var checkBoxList3 = F(checkBoxList3ClientID);
                var selectedValues3 = checkBoxList3.getValue();
                console.log(btn);
                if (selectedValues2.length > 0) {
                   
                    var hasThis = selectedValues2.indexOf(btn.inputValue);
                    if (hasThis > -1) {
                        console.log(btn);
                        console.log(hasThis);
                        F(tabStrip1).getItem(hasThis).active();
                        return true;
                    }
                }
                if (selectedValues3.length > 0) {
                    var hasThis = selectedValues3.indexOf(btn.inputValue);
                    if (hasThis > -1) {
                        console.log(btn);
                        console.log(hasThis);
                        F(tabStrip1).getItem(hasThis+3).active();
                        return true;
                    }
                }
                F(tabStrip1).getItem(6).active();
            }

            <%--function editGetterGrid2(editor, columnId, rowId) {
                console.log(2783);
                var tbxSearch = '<%=tbxSearch.ClientID%>';
                F(tbxSearch).focus();
            }--%>

            var checkList2 = '<%= CheckBoxList2.ClientID %>';
            var checkList3 = '<%= CheckBoxList3.ClientID %>';

            function renderMajor(value) {
                return F.formatString('<span data-qtip="{0}">{0}</span>', F.htmlEncode(value));
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
