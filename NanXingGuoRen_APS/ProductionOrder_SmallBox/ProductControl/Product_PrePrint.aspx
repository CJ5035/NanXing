<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Product_PrePrint.aspx.cs"
    Inherits="NanXingGuoRen_APS.ProductionOrder_SmallBox.PlanOrderControl.Product_PrePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .print_Div {
            page-break-before: always;
        }

        .f-checkbox-label {
            font-size: 14px;
        }

        .f-image {
        }

        .td {
            border: solid #add9c0;
            border-width: 0px 5px 5px 0px;
        }

        .table {
            border: solid #add9c0;
            border-width: 5px 0px 0px 5px;
        }


        .f-grid-row.color1,
        .f-grid-row.color1 a {
            /*background-color: #EEEEE0;*/
            color: #000000;
        }

        .mytable td.f-layout-table-cell {
            border: 2px;
        }

        .f-grid-row-summary .f-grid-cell-inner {
            font-weight: bold;
            color: black;
            /*background-color: grey*/
        }

        .title {
            text-align: center;
            font-size: 14px;
            line-height: 1.2em;
            margin: 10px 0;
            font-weight: bold;
        }

        .Number {
            text-align: right;
            /*font-size: 10px;
            line-height: 0.8em;*/
        }

        .Date {
            text-align: left;
            /*font-size: 10px;
            line-height: 0.8em;*/
        }

        .f-grid-colheader-text span {
            font-weight: bold;
        }

        body {
            /*font-family:'Microsoft YaHei UI';*/
        }

        .f-grid {
            border: 2px solid #000000;
            font-size: 14px;
        }
        /* 限定[备注]列自动换行，其他列不自动换行 */
        /*.f-grid-cell.f-grid-cell-remark .f-grid-cell-inner {
            border-left: 1px solid #000000;
            border-bottom: 1px solid #000000;
            /*border-right: 1px solid #000000;*/

        /*white-space: normal;
            word-break: break-all;
        }*/



        .title {
            text-align: right;
            font-size: 14px;
            line-height: 1.2em;
            margin: 0px 0;
            font-weight: bold;
        }

        #orderNo .title2 {
            text-align: right;
        }

        .f-grid-cell.f-grid-cell-ItemName
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-Spec
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-BatchNo
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-BoxName
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-DeliveryDate
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }


        .f-grid-cell.f-grid-cell-BoxNo
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-ClientName
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-PlanOrderNo
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-Remark .f-grid-cell-inner {
            white-space: pre-wrap;
            word-break: break-word;
        }

        .f-grid-row-lines .f-grid-cell, f-grid-colheader-row {
            border: 1px solid;
            border-color: black !important;
        }

        .f-grid-colheader {
            border: 1px solid;
            border-color: black !important;
            border-bottom-width: 0px;
        }

        body {
            font-weight: bold;
            font-size: 14px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">

        <f:Toolbar runat="server">
            <Items>
                <f:Toolbar runat="server" Position="top" ToolbarAlign="Right">
                    <Items>
                        <f:DropDownBox runat="server" ID="DropDownBox1" DataControlID="CheckBoxList1" EnableMultiSelect="true" Values="" Width="700px"
                            Label="选择部门" CssClass="f-checkbox-label" Hidden="true">
                            <PopPanel>
                                <f:SimpleForm ID="SimpleForm2" BodyPadding="10px" runat="server" AutoScroll="true"
                                    ShowBorder="true" ShowHeader="false" Hidden="true">
                                    <Items>

                                        <f:CheckBoxList ID="CheckBoxList1" ColumnNumber="1" runat="server">
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

                        <f:ToolbarFill runat="server"></f:ToolbarFill>



                        <f:HiddenField runat="server" ID="hf_DefectId1"></f:HiddenField>

                        <f:Button runat="server" ID="btnPrint2" OnClientClick="preview()" Hidden="true"></f:Button>

                    </Items>
                    <Items>
                        <f:Button runat="server" ID="btnSure" Text="确定" IconFont="Check" OnClick="btnSure_Click"></f:Button>

                        <f:Button runat="server" ID="btnPrint" Text="打印" Icon="Printer"
                            OnClientClick="preview()" OnClick="btnPrint_Click">
                        </f:Button>
                        <f:Button runat="server" ID="btnPrint3" OnClick="btnPrint2_Click" Hidden="true"></f:Button>
                    </Items>
                </f:Toolbar>

            </Items>
        </f:Toolbar>

        <f:PageManager runat="server"></f:PageManager>
        <!--startprint-->
        <f:Panel runat="server" ID="Panel1" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true"
            CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title1" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label5" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label6" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <%--<f:Label runat="server" Text="" ID="Label3" LabelAlign="left"></f:Label>--%>

                                <f:Image runat="server" ID="imgBarcode1" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition1" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn1" Label=""></f:Label>
                                <f:Label runat="server" ID="Label9" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate1" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid1" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>--%>

                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="客户名称" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="80px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrder_XuHao" DataField="PlanOrder_XuHao" Width="150px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--  DataImageUrlFormatString="~/res/images/16/{0}.png"
                          <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="true">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway1" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel2" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title2" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label2" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="orderNo" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode2" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition2" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn2" Label=""></f:Label>
                                <f:Label runat="server" ID="Label1" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate2" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid2" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>

                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway2" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel3" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="title3" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>
                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label12" Label=""></f:Label>
                                <f:Label runat="server" Text="" ID="Label13" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode3" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition3" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn3" Label=""></f:Label>
                                <f:Label runat="server" ID="Label16" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate3" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid3" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway3" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel4" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title4" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label20" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label21" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode4" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition4" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn4" Label=""></f:Label>
                                <f:Label runat="server" ID="Label4" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate4" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid4" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway4" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel5" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title5" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label28" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label29" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode5" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition5" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn5" Label=""></f:Label>
                                <f:Label runat="server" ID="Label32" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate5" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid5" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway5" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel6" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title6" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label36" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label37" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode6" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition6" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn6" Label=""></f:Label>
                                <f:Label runat="server" ID="Label99" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate6" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid6" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway6" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel7" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title7" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label44" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label45" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode7" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition7" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn7" Label=""></f:Label>
                                <f:Label runat="server" ID="Label48" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate7" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid7" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway7" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel8" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title8" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label52" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label53" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode8" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition8" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn8" Label=""></f:Label>
                                <f:Label runat="server" ID="Label56" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate8" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid8" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway8" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel9" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title9" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label60" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label61" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode9" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition9" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn9" Label=""></f:Label>
                                <f:Label runat="server" ID="Label64" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate9" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid9" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway9" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>

        <f:Panel runat="server" ID="Panel10" ShowBorder="true" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false" Hidden="true" CssClass="print_Div">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title10" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label68" Label=""></f:Label>

                                <f:Label runat="server" Text="" ID="Label69" LabelAlign="left"></f:Label>
                                <%--<f:Panel CssClass=""></f:Panel>--%>
                                <f:Image runat="server" ID="imgBarcode10" ImageHeight="50" ImageWidth="50" LabelAlign="right" Hidden="true"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition10" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn10" Label=""></f:Label>
                                <f:Label runat="server" ID="Label72" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate10" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid10" CssClass="blockpanel" EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                    OnRowDataBound="Grid1_RowDataBound" OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>

                        <f:RowNumberField ColumnID="#" HeaderText="#" HeaderTextAlign="Center" TextAlign="Center" Width="20px"></f:RowNumberField>
                        <f:BoundField DataField="BoxNo" SortField="BoxNo" ColumnID="BoxNo" HeaderText="箱号" Width="80px" />
                        <f:BoundField ColumnID="ItemName" DataField="ItemName" SortField="ItemName" Width="150px" HeaderText="产品名称"></f:BoundField>
                        <f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="100px" HeaderText="规格"></f:BoundField>
                        <f:RenderField ColumnID="NoWorkCount_OrderHeader" DataField="NoWorkCount_OrderHeader" SortField="NoWorkCount_OrderHeader"
                            Width="70px" HeaderText="总欠数" FieldType="Float" />

                        <%--<f:BoundField ColumnID="Spec" DataField="Spec" SortField="Spec" Width="60px" HeaderText="规格"></f:BoundField>
                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="60px" HeaderText="单位"></f:BoundField>
                        --%>  <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>
                        <f:BoundField DataField="ClientName" SortField="ClientName" Width="90px"
                            HeaderText="批号" ColumnID="ClientName" />
                        <f:BoundField DataField="DeliveryDate" SortField="DeliveryDate" Width="100px"
                            HeaderText="出货期" ColumnID="DeliveryDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:RenderField ColumnID="NoWorkCount" DataField="NoWorkCount" SortField="NoWorkCount"
                            Width="70px" HeaderText="欠货数" FieldType="Float" />


                        <f:BoundField ColumnID="Unit" DataField="Unit" SortField="Unit" Width="100px" HeaderText="单位"></f:BoundField>
                        <f:BoundField ColumnID="Remark" DataField="Remark" SortField="Remark" Width="100px" HeaderText="备注"
                            HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                        <f:BoundField ColumnID="PlanOrderNo" DataField="PlanOrderNo" Width="120px" HeaderText="排产单号" />
                        <f:ImageField Width="70px" ColumnID="ImageUrl" DataImageUrlField="ImageUrl"
                            ImageWidth="50px" ImageHeight="50px" HeaderText="二维码">
                        </f:ImageField>
                        <%--<f:TemplateField Width="70px" ColumnID="BarCode"  HeaderText="二维码" ExpandUnusedSpace="true">
                            <ItemTemplate>
                                <asp:Image runat="server" Height="50px"  Width="50px" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            </ItemTemplate>
                        </f:TemplateField> --%>
                    </Columns>
                    <Listeners>
                        <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                        <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right" Hidden="True">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" Label="制单" ID="lbPayway10" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>

        </f:Panel>
        <!--endprint-->
        <f:ContentPanel runat="server" ShowHeader="false">

            <Items>
                <asp:HiddenField runat="server" ID="hdf" />
                <asp:HiddenField runat="server" ID="mCells" />
            </Items>
        </f:ContentPanel>

        <f:Window runat="server" ID="Window1" EnableIFrame="true" Height="600px" Width="500px" Title="" Hidden="true" IsModal="true"
            OnClose="Window1_Close" EnableMaximize="true" EnableMinimize="true" EnableResize="true" Target="Parent">
        </f:Window>
    </form>
    <!--endprint-->

    <script src="../../res/printlabel/YuanLiaoCheJian.js"></script>
    <script>

        var btn = '<%=btnSure.ClientID%>';
        window.onload = function () {
            //InitPrint();
            setTimeout(onSelectAllClick, 500);
            setTimeout(SureClick, 1000);

        }
        function SureClick() {
            F(btn).click();
        }


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
            //将数据控件中的值同步到输入框
            F(dropDownBox1ClientID).syncToBox();
        }



        function onGridDataLoad(event) {
            //var value = document.getElementById('<%=mCells.ClientID%>').value;
            //console.log(value);
            var strs = ['BoxNo', 'ItemName', 'NoWorkCount_OrderHeader', 'ClientName', 'DeliveryDate', 'NoWorkCount', 'Remark', 'PlanOrderNo', 'ImageUrl'];
            this.mergeColumns(strs);
            //if (value.length > 0) {
            //    //var strs = value.split(",");

            //}

        }

        var btn2 = '<%=btnPrint.ClientID%>';
        var btn3 = '<%=btnPrint3.ClientID%>';
        function preview() {

            //document.getElementById("form1")[0].style.zoom = 1.3;
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";//设置打印开始区域
            eprnstr = "<!--endprint-->";//设置打印结束区域
            prnhtml = bdhtml.substring(bdhtml.indexOf(sprnstr) + 18); //从开始代码向后取html
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));//从结束代码向前取html

            //hf_DefectId1.value = prnhtml;
         <%--   document.getElementById('<%=hdf.ClientID%>').value = prnhtml;--%>

            window.document.body.innerHTML = prnhtml;
            //f.contentDocument.write(printhtml); //写入到新的iframe窗口
            //f.contentDocument.close();
            //f.contentWindow.print(); 
            window.print();
            window.document.body.innerHTML = bdhtml;
            var a = "<%=ChangeState()%>";//JavaScript中调用C#后台的函数

            console.log(a);
            return true;
        }


        function RenderHeji(value) {
            return F.addCommas(value.toFixed(2));
        }
    </script>
</body>
</html>
