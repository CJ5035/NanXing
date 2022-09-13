<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionOrder_Print.aspx.cs" Inherits="NanXingGuoRen_WMS.ProductionOrder.ProductionOrder_Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
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
        .f-grid{
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
        .f-grid-cell.f-grid-cell-name 
         .f-grid-cell-inner {
            white-space:normal;
            word-break:break-word;
        }

        .f-grid-cell.f-grid-cell-spec 
         .f-grid-cell-inner {
            white-space:normal;
            word-break:break-word;
        }

        .f-grid-cell.f-grid-cell-batchNo 
         .f-grid-cell-inner {
            white-space:normal;
            word-break:break-word;
        }

        .f-grid-cell.f-grid-cell-boxName 
         .f-grid-cell-inner {
            white-space:normal;
            word-break:break-word;
        }

        .f-grid-cell.f-grid-cell-boxNo 
         .f-grid-cell-inner {
            white-space:normal;
            word-break:break-word;
        }

        .f-grid-cell.f-grid-cell-ingredients 
         .f-grid-cell-inner {
            white-space:normal;
            word-break:break-word;
        }

        .f-grid-cell.f-grid-cell-remark1  .f-grid-cell-inner {
            white-space:pre-wrap;
            word-break:normal;
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
        <!--startprint-->
        <f:PageManager runat="server"></f:PageManager>
        <f:Panel runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="5 2 2 2" IsFluid="true" AutoScroll="false">
            <Items>
                <f:Form runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                    <Rows>
                        <f:FormRow>
                            <Items>

                                <f:Label runat="server" ID="title" Text="原料车间生产安排单" CssClass="title" LabelAlign="right"></f:Label>

                                <%--<f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"></f:Image>--%>
                                <f:Label runat="server" ID="Label2" Label=""></f:Label>
                                
                                <f:Label runat="server" Text="" ID="orderNo" LabelAlign="left"></f:Label>

                                <f:Image runat="server" ID="imgBarcode" ImageHeight="50" ImageWidth="50"  LabelAlign="right"></f:Image>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:Label runat="server" ID="lbPosition" Label=""></f:Label>
                                <f:Label runat="server" ID="lbProsn" Label="排产单号"></f:Label>
                                <f:Label runat="server" ID="Label1" Label=""></f:Label>
                                <f:Label runat="server" ID="lbOptdate" Label="" LabelAlign="Left"></f:Label>
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
                     OnRowDataBound="Grid1_RowDataBound"  OnDataBinding="Grid1_DataBinding" EnableCollapse="false" >
                    <Columns>
                        <f:RowNumberField HeaderText="序号" HeaderTextAlign="Center" TextAlign="Center" ColumnID="序号" Width="50px"></f:RowNumberField>
                        <f:BoundField DataField="name" SortField="name" Width="150px" HeaderText="产品名称" ColumnID="name"></f:BoundField>
                        <f:BoundField DataField="spec" SortField="spec" Width="100px" HeaderText="规格" ColumnID="spec"></f:BoundField>
                        <f:BoundField DataField="unit" SortField="unit" Width="70px" HeaderText="单位" ColumnID="unit"></f:BoundField>
                        <%--<f:BoundField DataField="inName" SortField="inName" Width="150px" HeaderText="销售型号" ColumnID="inName"></f:BoundField>--%>

                        <f:RenderField DataField="count" SortField="count" Width="100px" HeaderText="数量" ColumnID="count" FieldType="Float"/>

                        <f:BoundField DataField="batchNo" SortField="batchNo" Width="90px" HeaderText="批号" ColumnID="batchNo" ID="batchNo" Hidden="true"/>
                        <f:BoundField DataField="boxNo" SortField="boxNo" Width="90px" HeaderText="箱号" ColumnID="boxNo" ID="boxNo" Hidden="true"/>
                        <f:BoundField DataField="boxName" SortField="boxName" Width="90px" HeaderText="箱名" ColumnID="boxName" ID="boxName" Hidden="true"/>
                        <f:RenderField ID="ingredients" Width="150px" DataField="ingredients" HeaderText="状态/配料号" ColumnID="ingredients" Hidden="true"/>
                        
                         <f:BoundField  DataField="remark1" SortField="remark1" Width="150px" HeaderText="备注"
                             ColumnID="remark1" ExpandUnusedSpace="true"  HtmlEncode="false" TextAlign="Left">
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
                                <f:Label runat="server" Label="制单" ID="lbPayway" LabelAlign="Left"></f:Label>
                                <f:Label runat="server" Label="审核：" LabelAlign="Left" LabelSeparator=""></f:Label>
                                <f:Label runat="server" Label="" LabelAlign="Left" LabelSeparator=""></f:Label>
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
            </Items>
           
        </f:Panel>
        <!--endprint-->
        <f:ContentPanel runat="server">

            <Items>
                <asp:HiddenField runat="server" ID="hdf" />
                 <asp:HiddenField runat="server" ID="mCells" />
            </Items>
        </f:ContentPanel>
        <f:Toolbar runat="server">
            <Items>
                <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Right">
                    <Items>
                        <f:Button runat="server" ID="btnPrint" Text="打印" Icon="Printer" OnClientClick="preview()" OnClick="btnPrint_Click"></f:Button>

                        <f:HiddenField runat="server" ID="hf_DefectId1"></f:HiddenField>

                       <f:Button runat="server" ID="btnPrint2" OnClientClick="preview()" Hidden="true"></f:Button>
                        <f:Button runat="server" ID="btnPrint3" OnClick="btnPrint2_Click"  Hidden="true"></f:Button>
                    </Items>
                </f:Toolbar>
            </Items>
        </f:Toolbar>
    </form>
    <!--endprint-->


    <script>
        function onGridDataLoad(event) {
            var value = document.getElementById('<%=mCells.ClientID%>').value;
            console.log(value);
            if (value.length>0) {
                var strs = value.split(",");
                this.mergeColumns(strs);
            }
            
        }
        var btn2 = '<%=btnPrint2.ClientID%>';
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
            return true;
        }


        function RenderHeji(value) {
            return F.addCommas(value.toFixed(2));
        }
    </script>
</body>
</html>
