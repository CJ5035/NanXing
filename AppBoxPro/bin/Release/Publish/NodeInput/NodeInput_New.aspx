<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NodeInput_New.aspx.cs" Inherits="NanXingGuoRen_WMS_Project.NodeInput.NodeInput_New" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="../res/css/jquery-ui-themes.css" type="text/css" rel="stylesheet" />
    <link href="../res/css/axure_rp_page.css" type="text/css" rel="stylesheet" />
    <link href="../res/data/styles.css" type="text/css" rel="stylesheet" />
    <link href="../res/files/page_1/styles.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../res/scripts/jquery-ui-1.8.10.custom.min.js"></script>
    <script src="../res/scripts/prototypePre.js"></script>
    <script src="../res/data/document.js"></script>
    <script src="../res/scripts/prototypePost.js"></script>
    <script src="../res/files/page_1/data.js"></script>
    <script type="text/javascript">
        $axure.utils.getTransparentGifPath = function () { return '../res/../res/images/transparent.gif'; };
        $axure.utils.getOtherPath = function () { return '../res/Other.html'; };
        $axure.utils.getReloadPath = function () { return '../res/reload.html'; };
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <f:PageManager ID="PageManager1" AutoSizePanelID="Panel_All" runat="server" />
            <f:Panel ID="Panel_All" runat="server" IsFluid="true" AutoScroll="true" BoxConfigChildMargin="5 5 5 5" Layout="VBox" ShowBorder="false" ShowHeader="false">
                <Items>
                    <%--Panel1：选择订单--%>
                    <f:Panel runat="server" Layout="HBox">
                        <Items>
                            <f:Panel runat="server" ID="Panel1" BoxFlex="5" BodyPadding="10px"
                                IsFluid="false" AutoScroll="false" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="true"
                                        DataKeyNames="派工单号" AllowSorting="true" OnSort="Grid1_Sort" SortField="跟单签订日期"
                                        AllowPaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                                        SortDirection="DESC" EnableSummary="true" EnableRowClickEvent="true"
                                        EnableMultiSelect="false" IsDatabasePaging="true" Height="420px" Title="工单选择"
                                        EnableCheckBoxSelect="true" OnRowSelect="Grid1_RowSelect">
                                        <Toolbars>
                                            <f:Toolbar ID="Toolbar3" runat="server" Hidden="false">
                                                <Items>
                                                    <%--  <f:DatePicker runat="server" Label="生产日期" ID="dpStart" LabelAlign="Right" LabelWidth="90px" Width="200px"></f:DatePicker>
                                <f:DatePicker runat="server" ID="dpEnd" Width="110px"></f:DatePicker>--%>
                                                    <f:TextBox runat="server" Width="300px" EmptyText="派工单号(多个工单号用 ,分割)" ID="tbxWorkNo" NextClickControl="btnSearch"></f:TextBox>
                                                    <%-- <f:CheckBox runat="server" AutoPostBack="true" ID="cbxEnd" Text="只显示未完结" OnCheckedChanged="cbxEnd_CheckedChanged" Checked="true"></f:CheckBox> OnCheckedChanged="CheckBox2_CheckedChanged"--%>
                                                    <f:Button runat="server" Text="搜索" ID="btnSearch" Icon="SystemSearch" OnClick="btnSearch_Click"></f:Button>
                                                    <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                                    </f:ToolbarFill>
                                                </Items>
                                            </f:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <f:RowNumberField EnablePagingNumber="true"></f:RowNumberField>
                                            <f:BoundField DataField="派工单号" SortField="派工单号" ColumnID="派工单号" Width="100px" HeaderText="派工单号" />
                                            <f:BoundField DataField="总数量" SortField="总数量" ColumnID="总数量" Width="100px" HeaderText="总数量" ExpandUnusedSpace="true" />
                                            <f:BoundField DataField="跟单签订日期" SortField="跟单签订日期" ColumnID="跟单签订日期" Width="100px" HeaderText="跟单签订日期" DataFormatString="{0:yyyy-MM-dd}" ExpandUnusedSpace="true" />
                                            <f:BoundField DataField="信息修改日期" ColumnID="信息修改日期" Width="100px" HeaderText="信息修改日期" DataFormatString="{0:yyyy-MM-dd}" ExpandUnusedSpace="true" />

                                        </Columns>
                                    </f:Grid>
                                </Items>
                            </f:Panel>

                            <f:Panel  ID="Panel3" runat="server" BoxFlex="5" BodyPadding="10px" IsFluid="false" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:ContentPanel ID="ContentPanel1" runat="server" BoxFlex="5" BodyPadding="10px" EnableCollapse="true"  Height="420px">
                                        <div id="base" class="">
                                        <div id="base_1" class="base_1" style="left: 0px; top: 0px;">
                                            <!-- Unnamed (矩形) -->
                                            <div id="u86" class="ax_default flow_shape flow_shape_box">
                                                <div id="u86_div" class="flow_shape_div_success"></div>
                                                <!-- Unnamed () -->
                                                <div id="u87" class="text shape_text">
                                                    <p><span>录入人：XXX</span></p>
                                                    <p><span>时间：2020-08-21</span></p>
                                                    <p><span>情况：准时</span></p>
                                                </div>
                                            </div>


                                            <!-- Unnamed (矩形) -->
                                            <div id="u88" class="ax_default label label_box">
                                                <div id="u88_div" class="label_box_div"></div>
                                                <!-- Unnamed () -->
                                                <div id="u89" class="text">
                                                    <p><span>1、合同签订</span></p>
                                                </div>
                                            </div>

                                            <!-- Unnamed (菱形) -->
                                            <div id="u90" class="ax_default label tip">
                                                <img id="u90_img" class="img tip_img" src="../res/images/page_1/u28.png" />
                                                <!-- Unnamed () -->
                                                <div id="u91" class="text tip_text">
                                                    <p><span>完</span></p>
                                                </div>
                                            </div>

                                        </div>

                                        </div>
                                    </f:ContentPanel>
                                </Items>
                            </f:Panel>
                        </Items>
                    </f:Panel>



                    <%-- BodyPadding="5 5 0 5"--%>
                    <%--Panel1：上载文件表示该流程已完成--%>
                    <f:ContentPanel ID="ccpanel" runat="server" BoxFlex="5" BodyPadding="10px" ShowHeader="false" ShowBorder="false" EnableCollapse="true">
                        <f:Form ID="SimpleForm1" IsFluid="true" CssClass="blockpanel" BodyPadding="10px" LabelAlign="Left"
                            Title="表单" runat="server">
                            <Items>
                                <f:Panel ID="Panel2" ShowHeader="false" CssClass="" ShowBorder="false" Layout="Column" runat="server">
                                    <Items>
                                        <f:Label ID="Label2" Width="80px" runat="server" CssClass="marginr" ShowLabel="false"
                                            Text="用户名：">
                                        </f:Label>
                                        <f:TextBox ID="TextBox2" ShowLabel="false"  Label="用户名" Required="true" Width="150px" CssClass="marginr" runat="server" Readonly="true">
                                        </f:TextBox>
                                        <f:Button ID="Button3" Text="按钮一" CssClass="marginr" runat="server">
                                        </f:Button>
                                        <f:Button ID="Button4" Text="按钮二" runat="server">
                                        </f:Button>
                                    </Items>
                                </f:Panel>

                                <f:ContentPanel runat="server" Height="250px" ShowHeader="false" ShowBorder="true">
                                 <%--   <div id="base" class="">
                                        <div id="base_1" class="base_1" style="left: 0px; top: 0px;">
                                            <!-- Unnamed (矩形) -->
                                            <div id="u86" class="ax_default flow_shape flow_shape_box">
                                                <div id="u86_div" class="flow_shape_div_success"></div>
                                                <!-- Unnamed () -->
                                                <div id="u87" class="text shape_text">
                                                    <p><span>情况：准时</span></p>
                                                    <p><span>时间：2020-08-21</span></p>
                                                    <p><span>录入人：XXX</span></p>
                                                </div>
                                            </div>


                                            <!-- Unnamed (矩形) -->
                                            <div id="u88" class="ax_default label label_box">
                                                <div id="u88_div" class="label_box_div"></div>
                                                <!-- Unnamed () -->
                                                <div id="u89" class="text">
                                                    <p><span>1、合同签订</span></p>
                                                </div>
                                            </div>

                                            <!-- Unnamed (菱形) -->
                                            <div id="u90" class="ax_default label tip">
                                                <img id="u90_img" class="img tip_img" src="images/page_1/u28.png" />
                                                <!-- Unnamed () -->
                                                <div id="u91" class="text tip_text">
                                                    <p><span>完</span></p>
                                                </div>
                                            </div>

                                        </div>

                                    </div>--%>
                                </f:ContentPanel>

                            </Items>
                        </f:Form>

                    </f:ContentPanel>




                    <%-- <f:Panel runat="server"  ID="Panel2"  BoxFlex="5"  BodyPadding="10px" BoxConfigChildMargin="0 0 0 0"
                     IsFluid="false" AutoScroll="true" Layout="VBox" ShowBorder="false" ShowHeader="false">
                         
                      </f:Panel>--%>
                </Items>
            </f:Panel>
        </div>
    </form>
</body>
</html>
