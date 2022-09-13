<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanOrderEdit2.aspx.cs"
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanOrderEdit2" %>

<%@ Register Src="~/ProductionOrder_SmallBox/PlanOrderControl/UserControls/ProOrderGrid_UC.ascx"
    TagName="ProOrderGrid_UC" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="sourcefiles" content="~/UserControls/ProOrderGrid_UC.ascx" />

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
        <f:PageManager runat="server" AutoSizePanelID="Panel1" ID="PageManager1"
            OnCustomEvent="PageManager1_CustomEvent"></f:PageManager>

        <f:Panel runat="server" ID="Panel1" BodyPadding="5px" AutoScroll="true" ShowBorder="false"
            ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start">
            <Items>

                <f:Grid runat="server" ID="Grid0" PageSize="8" DataKeyNames="ID,Spec"
                    ShowHeader="true" Title="成品基本信息" BoxFlex="1">
                    <Columns>

                        <f:RowNumberField EnablePagingNumber="true"></f:RowNumberField>
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="120px" HeaderText="产品名称" EnableLock="true" Locked="true" />
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="订单单位" />
                        <f:BoundField ColumnID="PcCount" DataField="PcCount" SortField="PcCount" Width="100px" HeaderText="订单数量" />
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="包装规格" />
                        <f:BoundField ColumnID="Biaozhun" DataField="Biaozhun" SortField="Biaozhun" Width="100px" HeaderText="排产标准" />
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="200px" HeaderText="申请单备注" />
                        <f:BoundField ColumnID="ProductRecipe" DataField="ProductRecipe" SortField="ProductRecipe" Width="120px" HeaderText="生产配方" />
                        <f:BoundField ColumnID="InventoryCount" DataField="InventoryCount" SortField="InventoryCount" Width="110px" HeaderText="库存数量(件)" />
                        <f:BoundField ColumnID="EmergencyDegree" DataField="EmergencyDegree" SortField="EmergencyDegree" Width="110px" HeaderText="紧急程度" />
                        <f:RenderField ColumnID="DeliveryDate" DataField="DeliveryDate" SortField="DeliveryDate" Width="120px" HeaderText="交付日期"
                            FieldType="Date" RendererArgument="yyyy-MM-dd">
                            <Editor>
                                <f:DatePicker runat="server"></f:DatePicker>
                            </Editor>
                        </f:RenderField>
                        <f:BoundField ColumnID="CRMApplyNo" DataField="CRMApplyNo" SortField="CRMApplyNo" Width="150px" HeaderText="CRM申请单号" />
                        <f:BoundField ColumnID="CRMApplyNo_Xuhao" DataField="CRMApplyNo_Xuhao" SortField="CRMApplyNo_Xuhao" Width="150px" HeaderText="CRM申请单序号" />
                        <f:BoundField ColumnID="ClientName" DataField="ClientName" SortField="ClientName" Width="150px" HeaderText="客户名称" />

                        <f:BoundField ColumnID="ApplicantName" DataField="ApplicantName" SortField="ApplicantName" Width="120px" HeaderText="申请人" />
                        <f:BoundField ColumnID="OrderDate" DataField="OrderDate" SortField="OrderDate" Width="100px" HeaderText="下单日期"
                            DataFormatString="{0:yyyy-MM-dd}" />
                        <f:BoundField ColumnID="ApplyNoState" DataField="ApplyNoState" SortField="ApplyNoState" Width="100px" HeaderText="申请单状态" />


                    </Columns>


                </f:Grid>


                <f:Panel runat="server" ShowHeader="false" ID="Panel99" Layout="HBox"
                    Width="100%" Enabled="True">
                    <Items>
                        <f:Panel ID="Panel7" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" BoxFlex="1">
                            <Items>
                                <f:Label runat="server" Label="选择车间" Width="150px"></f:Label>
                                <f:Button runat="server" Text="修改" ID="Change01"></f:Button>
                            </Items>
                            <Items>
                                <f:Button runat="server" Text="修改"></f:Button>
                            </Items>
                        </f:Panel>


                        <f:Panel ID="Panel2" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" BoxFlex="9">
                            <Items>
                                <f:CheckBoxList ID="CheckBoxList2" ColumnNumber="3" runat="server" BoxFlex="1"
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

                                 <f:CheckBoxList ID="CheckBoxList3" ColumnNumber="3" runat="server" BoxFlex="1"
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

                        <f:Panel ID="Panel3" ShowHeader="false" CssClass="" ShowBorder="true" Layout="HBox"
                            runat="server" BodyPadding="5px" MarginLeft="-10px" Height="120px" Width="250px"
                             Hidden="true">
                            <Items>
                              
                            </Items>
                        </f:Panel>


                        <f:ToolbarFill runat="server" />
                    </Items>
                </f:Panel>

                <f:TabStrip runat="server" BoxFlex="2" EnableTabCloseMenu="false" ShowBorder="false"
                    ID="TabStrip1" AutoScroll="true">

                    <Tabs>
                        <f:Tab runat="server" ID="Tab1" Title="03小包装-小袋"
                            Layout="Fit" EnableClose="false" Hidden="true">
                            <Items>
                                <f:UserControlConnector runat="server">
                                    <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC1"
                                        Position="03小包装-小袋" />
                                </f:UserControlConnector>
                            </Items>
                        </f:Tab>
                        <f:Tab runat="server" ID="Tab2" Title="03小包装-罐" EnableClose="false"
                            Hidden="true">
                            <Items>
                                <f:Label runat="server" ID="Label1" Text="false" Hidden="true"></f:Label>
                                <f:UserControlConnector runat="server">
                                    <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC2"
                                        Position="03小包装-罐" />
                                </f:UserControlConnector>
                            </Items>
                        </f:Tab>

                        <f:Tab runat="server" ID="Tab3" Title="03小包装-每日坚果"
                            Hidden="true">
                            <Items>
                                <f:Label runat="server" ID="Label2" Text="false" Hidden="true"></f:Label>
                                <f:UserControlConnector runat="server">
                                    <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC3"
                                        Position="03小包装-每日坚果" />
                                </f:UserControlConnector>
                            </Items>
                        </f:Tab>

                        <f:Tab runat="server" ID="Tab4" Title="07小包装-小袋"
                            Hidden="true">
                            <Items>
                                <f:Label runat="server" ID="Label3" Text="false" Hidden="true"></f:Label>
                                <f:UserControlConnector runat="server">
                                    <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC4"
                                        Position="07小包装-小袋" />
                                </f:UserControlConnector>
                            </Items>
                        </f:Tab>

                        <f:Tab runat="server" ID="Tab5" Title="07小包装-罐"
                            Hidden="true">
                            <Items>
                                <f:Label runat="server" ID="Label4" Text="false" Hidden="true"></f:Label>
                                <f:UserControlConnector runat="server">
                                    <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC5"
                                        Position="07小包装-罐" />
                                </f:UserControlConnector>
                            </Items>
                        </f:Tab>

                        <f:Tab runat="server" ID="Tab6" Title="07小包装-每日坚果"
                            Hidden="true">
                            <Items>
                                <f:UserControlConnector runat="server">
                                    <uc1:ProOrderGrid_UC runat="server" ID="ProOrderGrid_UC6"
                                        Position="07小包装-每日坚果" />
                                </f:UserControlConnector>
                            </Items>
                        </f:Tab>



                        <f:Tab runat="server" Title="<span class='highlight'>确认页面</span>">
                            <Items>
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


        <script>
            <%--var dropDownBox1ClientID = '<%= 
            //DropDownBox1.ClientID %>';
            var checkBoxList1ClientID = '<%= 
            //CheckBoxList1.ClientID %>';--%>

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
                        F(tabStrip1).getItem(hasThis + 3).active();
                        return true;
                    }
                }
                F(tabStrip1).getItem(6).active();
            }


           

           
        </script>
    </form>
</body>
</html>
