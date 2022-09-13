<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionOrder_Print.aspx.cs" Inherits="NanXingGuoRen_WMS.ProductionOrder.ProductionOrder_Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../../res/hiprint/hiprint.css" />
    <link rel="stylesheet" href="../../res/hiprint/print-lock.css" />
    <link rel="stylesheet" href="../../res/hiprint/print-lock.css" media="print" />
    <%--<script src="../../js/jquery-1.8.3.min.js"></script>--%>

    <style>
        .f-checkbox-label {
            font-size: 16px;
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
            font-size: 20px;
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
            font-size: 18px;
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
            font-size: 20px;
            line-height: 1.2em;
            margin: 0px 0;
            font-weight: bold;
        }

        #orderNo .title2 {
            text-align: right;
        }
        /*.f-grid-cell.f-grid-cell-spec
        .f-grid-cell.f-grid-cell-batchNo
        .f-grid-cell.f-grid-cell-boxName 
        .f-grid-cell.f-grid-cell-ingredients*/
        .f-grid-cell.f-grid-cell-ItmeName
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

        .f-grid-cell.f-grid-cell-BoxNo
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-Ingredients
        .f-grid-cell-inner {
            white-space: normal;
            word-break: break-word;
        }

        .f-grid-cell.f-grid-cell-Remark .f-grid-cell-inner {
            white-space: pre-wrap;
            word-break: normal;
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
            font-size: 18px;
        }
    </style>
</head>
<body>


    <form id="form1" runat="server">

        <f:Toolbar runat="server">
            <Items>
                <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Right">
                    <Items>
                        <f:CheckBoxList ID="CheckBoxList2" Label="选择部门" ColumnNumber="5" runat="server" CssClass="f-checkbox-label">
                        </f:CheckBoxList>

                        <f:ToolbarFill runat="server"></f:ToolbarFill>

                        <f:Button runat="server" ID="btnPrint" Text="打印" Icon="Printer"></f:Button>

                        <f:HiddenField runat="server" ID="hf_DefectId1"></f:HiddenField>

                        <f:Button runat="server" ID="btnPrint2" OnClientClick="preview()" Hidden="true"></f:Button>
                        <f:Button runat="server" ID="btnPrint3" OnClick="btnPrint2_Click" Hidden="true"></f:Button>
                    </Items>
                </f:Toolbar>
            </Items>
        </f:Toolbar>


        <f:PageManager runat="server"></f:PageManager>
        <!--startprint-->
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="true">
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
                                <f:Image runat="server" ID="imgBarcode1" ImageHeight="50" ImageWidth="50" LabelAlign="right"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition1" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn1" Label="排产单号"></f:Label>
                                <f:Label runat="server" ID="Label9" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate1" Label="" LabelAlign="Left"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Items>
                <f:Grid runat="server" ID="Grid1" CssClass="blockpanel"  EnableSummary="false" SummaryPosition="Bottom"
                    ShowBorder="true" ShowHeader="false" IsDatabasePaging="true"
                    SortDirection="ASC" SortField="ID" OnSort="Grid1_Sort" EnableCheckBoxSelect="false" DataKeyNames="ID"
                    IsFluid="true" AllowSorting="true" PageSize="100"
                    EnableColumnLines="true" EnableRowLines="true" MinHeight="250px"
                     OnRowDataBound="Grid1_RowDataBound"  OnDataBinding="Grid1_DataBinding" EnableCollapse="false">
                    <Columns>
                        <f:RowNumberField HeaderText="序号" HeaderTextAlign="Center" TextAlign="Center" ColumnID="序号" Width="50px"></f:RowNumberField>
                        <f:BoundField DataField="name" SortField="name" Width="150px" HeaderText="产品名称" ColumnID="name"></f:BoundField>
                        <f:BoundField DataField="spec" SortField="spec" Width="100px" HeaderText="规格" ColumnID="spec"></f:BoundField>
                        <f:BoundField DataField="unit" SortField="unit" Width="70px" HeaderText="单位" ColumnID="unit"></f:BoundField>
                        <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>

                        <f:RenderField DataField="count" SortField="count" Width="100px" HeaderText="数量" ColumnID="count" FieldType="Float"/>

                        <f:BoundField ID="BatchNo1"  DataField="batchNo" SortField="batchNo" Width="90px" HeaderText="批号" ColumnID="batchNo" Hidden="true"/>
                        <f:BoundField ID="BoxNo1" DataField="boxNo" SortField="boxNo" Width="90px" HeaderText="箱号" ColumnID="boxNo" Hidden="true"/>
                        <f:BoundField ID="BoxName1" DataField="boxName" SortField="boxName" Width="90px" HeaderText="箱名" ColumnID="boxName" Hidden="true"/>
                        <f:RenderField ID="Ingredients1" Width="150px" DataField="ingredients" HeaderText="状态/配料号" ColumnID="ingredients" Hidden="true"/>
                        
                         <f:BoundField  DataField="remark" SortField="remark1" Width="150px" HeaderText="备注"
                             ColumnID="remark" ExpandUnusedSpace="true"  HtmlEncode="false" TextAlign="Left">
                        </f:BoundField>
                    </Columns>
                     <Listeners>
                         <%--<f:Listener Event="afteredit" Handler="onGridAfterEdit" />--%>
                         <f:Listener Event="dataload" Handler="onGridDataLoad" />
                    </Listeners>
                </f:Grid>
            </Items>
            <Items>
                <f:Form runat="server" ShowBorder="false" ShowHeader="false" LabelAlign="Right">
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


       
        <!--endprint-->
        <f:ContentPanel runat="server" Width="1500px" Height="600px">
            <div id="templateDesignDiv" style="width: 100%; height: 100%;">
            </div>


            <Items>
                <asp:HiddenField runat="server" ID="hdf" />
                <asp:HiddenField runat="server" ID="mCells" />


            </Items>
        </f:ContentPanel>

    </form>

    <%--<script src="../../res/hiprint/jq-3.31.js"></script>--%>
    <script src="../../res/hiprint/polyfill.min.js"></script>
    <script src="../../res/hiprint/hiprint.bundle.js"></script>
    <script src="../../res/hiprint/jquery.hiwprint.js"></script>
    <script src="../../res/hiprint/qrcode.js"></script>
    <script src="../../res/hiprint/socket.io.js"></script>
    <script src="../../res/hiprint/hiprint.config.js"></script>
    <script src="../../res/hiprint/jquery.jqprint-0.3.js"></script>
    <script>
        window.onload = function () {
            //InitPrint();
            setTimeout(InitPrint, 500);
        }

        function onGridDataLoad(event) {
            var value = document.getElementById('<%=mCells.ClientID%>').value;

            if (value.length > 0) {
                var strs = value.split(",");
                console.log(strs);
                console.log(this);

                this.mergeColumns(strs);
                console.log(this);
            }

        }
        var btn2 = '<%=btnPrint.ClientID%>';
        function preview() {

            //document.getElementById("form1")[0].style.zoom = 1.3;
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";//设置打印开始区域
            eprnstr = "<!--endprint-->";//设置打印结束区域
            prnhtml = bdhtml.substring(bdhtml.indexOf(sprnstr) + 18); //从开始代码向后取html
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));//从结束代码向前取html
            console.log(prnhtml);
            window.document.body.innerHTML = prnhtml;
            //f.contentDocument.write(printhtml); //写入到新的iframe窗口
            //f.contentDocument.close();
            //f.contentWindow.print(); 
            window.print();
            window.document.body.innerHTML = bdhtml;
        }

        function InitPrint() {
            let mypanel1 = { "panels": [{ "index": 0, "height": 297, "width": 210, "paperHeader": 49.5, "paperFooter": 780, "printElements": [{ "options": { "left": 27, "top": 12, "height": 25.5, "width": 267, "field": "title", "fontSize": 19.5, "fontWeight": "600", "lineHeight": 26.25, "hideTitle": true }, "printElementType": { "type": "text" } }, { "options": { "left": 519, "top": 13.5, "height": 49.5, "width": 48, "title": "46545", "field": "PlanOrder_XuHao", "textType": "qrcode", "barcodeMode": "CODE39" }, "printElementType": { "type": "text" } }, { "options": { "left": 322.5, "top": 22.5, "height": 15, "width": 171, "title": "单号", "field": "PlanOrder_XuHao", "fontSize": 12, "fontWeight": "400", "lineHeight": 12 }, "printElementType": { "type": "text" } }, { "options": { "left": 322.5, "top": 52.5, "height": 15, "width": 169.5, "title": "计划排产日期", "field": "PlanDate", "dataType": "datetime", "format": "yyyy-MM-dd", "fontSize": 12, "lineHeight": 12 }, "printElementType": { "type": "text" } }, { "options": { "left": 28.5, "top": 54, "height": 15, "width": 141, "field": "position", "fontSize": 12, "lineHeight": 12, "hideTitle": true }, "printElementType": { "type": "text" } }, { "options": { "left": 25.5, "top": 73.5, "height": 36, "width": 550, "fontSize": 12, "textAlign": "center", "field": "table", "columns": [[{ "title": "序号", "field": "xuhao", "width": 41.615409615384614, "colspan": 1, "rowspan": 1, "checked": true, "columnId": "xuhao" }, { "title": "产品名称", "field": "ItemName", "width": 183.97105444399708, "colspan": 1, "rowspan": 1, "checked": true, "columnId": "ItemName" }, { "title": "规格", "field": "Spec", "width": 47.47157944399703, "colspan": 1, "rowspan": 1, "checked": true }, { "title": "单位", "field": "Unit", "width": 42.347633136094686, "colspan": 1, "rowspan": 1, "checked": true }, { "title": "数量", "field": "PcCount", "width": 39.08236265361861, "colspan": 1, "rowspan": 1, "checked": true }, { "title": "备注", "field": "Remark", "width": 195.51196070690804, "colspan": 1, "rowspan": 1, "checked": true }]] }, "printElementType": { "title": "表格", "type": "tableCustom" } }, { "options": { "left": 187.5, "top": 120, "height": 15, "width": 139.5, "title": "制单日期", "field": "Newdate", "dataType": "datetime", "format": "yyyy-MM-dd", "fontSize": 12, "lineHeight": 12 }, "printElementType": { "type": "text" } }, { "options": { "left": 381, "top": 120, "height": 15, "width": 120, "title": "审核", "field": "d", "fontSize": 12, "lineHeight": 12 }, "printElementType": { "type": "text" } }, { "options": { "left": 28.5, "top": 120, "height": 15, "width": 120, "title": "制单", "field": "Jingbanren", "fontSize": 12, "lineHeight": 12 }, "printElementType": { "type": "text" } }], "paperNumberLeft": 565.5, "paperNumberTop": 819 }] };
            let mypanel2 = {
                "panels": [{
                    "index": 0,
                    "height": 297,
                    "width": 210,
                    "paperHeader": 49.5,
                    "paperFooter": 780,
                    "printElements": [{
                        "options": {
                            "left": 27,
                            "top": 12,
                            "height": 25.5,
                            "width": 267,
                            "field": "title",
                            "fontSize": 19.5,
                            "fontWeight": "600",
                            "lineHeight": 26.25,
                            "hideTitle": true
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }, {
                        "options": {
                            "left": 519,
                            "top": 13.5,
                            "height": 49.5,
                            "width": 48,
                            "title": "46545",
                            "field": "PlanOrder_XuHao",
                            "textType": "qrcode",
                            "barcodeMode": "CODE39"
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }, {
                        "options": {
                            "left": 322.5,
                            "top": 22.5,
                            "height": 15,
                            "width": 171,
                            "title": "单号",
                            "field": "PlanOrder_XuHao",
                            "fontSize": 12,
                            "fontWeight": "400",
                            "lineHeight": 12
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }, {
                        "options": {
                            "left": 322.5,
                            "top": 52.5,
                            "height": 15,
                            "width": 169.5,
                            "title": "计划排产日期",
                            "field": "PlanDate",
                            "dataType": "datetime",
                            "format": "yyyy-MM-dd",
                            "fontSize": 12,
                            "lineHeight": 12
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }, {
                        "options": {
                            "left": 28.5,
                            "top": 54,
                            "height": 15,
                            "width": 141,
                            "field": "position",
                            "fontSize": 12,
                            "lineHeight": 12,
                            "hideTitle": true
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }, {
                        "options": {
                            "left": 25.5,
                            "top": 73.5,
                            "height": 36,
                            "width": 550,
                            "fontSize": 12,
                            "textAlign": "center",
                            "field": "table",
                            "columns": [
                                [{
                                    "title": "序号",
                                    "field": "xuhao",
                                    "width": 41.615409615384614,
                                    "colspan": 1,
                                    "rowspan": 2,
                                    "checked": true,
                                    "columnId": "xuhao"
                                }, {
                                    "title": "产品名称",
                                    "field": "ItemName",
                                    "width": 183.97105444399708,
                                    "colspan": 1,
                                    "rowspan": 2,
                                    "checked": true,
                                    "columnId": "ItemName"
                                }, {
                                    "title": "规格",
                                    "field": "Spec",
                                    "width": 47.47157944399703,
                                    "colspan": 1,
                                    "rowspan": 2,
                                    "checked": true
                                }, {
                                    "title": "单位",
                                    "field": "Unit",
                                    "width": 42.347633136094686,
                                    "colspan": 1,
                                    "rowspan": 2,
                                    "checked": true
                                }, {
                                    "title": "数量",
                                    "field": "PcCount",
                                    "width": 39.08236265361861,
                                    "colspan": 1,
                                    "rowspan": 2,
                                    "checked": true
                                }, {
                                    "title": "备注",
                                    "field": "Remark",
                                    "width": 195.51196070690804,
                                    "colspan": 1,
                                    "rowspan": 2,
                                    "checked": true
                                }]
                            ]
                        },
                        "printElementType": {
                            "title": "表格",
                            "type": "tableCustom"
                        }
                    }, {
                        "options": {
                            "left": 187.5,
                            "top": 120,
                            "height": 15,
                            "width": 139.5,
                            "title": "制单日期",
                            "field": "Newdate",
                            "dataType": "datetime",
                            "format": "yyyy-MM-dd",
                            "fontSize": 12,
                            "lineHeight": 12
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }, {
                        "options": {
                            "left": 381,
                            "top": 120,
                            "height": 15,
                            "width": 120,
                            "title": "审核",
                            "field": "d",
                            "fontSize": 12,
                            "lineHeight": 12
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }, {
                        "options": {
                            "left": 28.5,
                            "top": 120,
                            "height": 15,
                            "width": 120,
                            "title": "制单",
                            "field": "Jingbanren",
                            "fontSize": 12,
                            "lineHeight": 12
                        },
                        "printElementType": {
                            "type": "text"
                        }
                    }],
                    "paperNumberLeft": 565.5,
                    "paperNumberTop": 819
                }]
            };

            let data = {
                title: "11234",
                position: "234556",
                PlanOrder_XuHao: "20201*464116",
                PlanDate: "2021-01-01",
                Jingbanren: "CJ",
                Newdate: "2021-01-01",
                table: [
                    { xuhao: 1, ItemName: '51561dfsdfsdfsdfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsfd6', Spec: '50kg', Unit: 50, PcCount: 50, Remark: 4654 },
                    { xuhao: 1, ItemName: '51561dfsdfsdfsdfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsfd6', Spec: '50kg', Unit: 50, PcCount: 50, Remark: 4654 }
                ],
                d: ""
            };
            hiprint.init();
            //调用接口获取数据


            document.getElementById('<%=btnPrint.ClientID%>').onclick =
                function () {
                    var hiprintTemplate = new hiprint.PrintTemplate({
                        template: mypanel2,
                        //settingContainer: "#templateDesignDiv",
                    });
                    hiprintTemplate.print([data, data]);
                };
        }


        function printTest() {

            hiprintTemplate.print([data]);
        }

        function RenderHeji(value) {
            return F.addCommas(value.toFixed(2));
        }
    </script>
</body>
</html>
