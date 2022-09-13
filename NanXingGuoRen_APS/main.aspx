<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="NanXingGuoRen_APS.main" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>首页</title>
    <link href="res/css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:pagemanager id="PageManager1" autosizepanelid="regionPanel" runat="server" />
        <f:panel id="regionPanel" layout="Region" cssclass="mainpanel" showborder="false" showheader="false" runat="server">
            <items>
                <%--页头--%>
                <f:contentpanel id="topPanel" cssclass="topregion bgpanel" showborder="false" showheader="false" regionposition="Top" runat="server">

                    <div id="header" class="f-widget-header f-mainheader">
                        <table>
                            <tr>
                                <td>
                                    <div style="display: inline; position: absolute">
                                        <f:label runat="server" text="南兴天虹生产管理系统" cssstyle="font-size:20px;display:block" height="38px"
                                            marginleft="15px" margintop="-15px" absolutey="0px" ID="LabTitle">
                                        </f:label>

                                    </div>
                                    <div style="display: inline; position: absolute">
                                        <f:label runat="server" text="" cssstyle="font-size:12px;float:left;"
                                            marginleft="00px" margintop="35px">
                                        </f:label>
                                    </div>
                                    <asp:HyperLink Visible="false" ID="linkSystemTitle" CssClass="logo" runat="server" NavigateUrl="~/main.aspx"></asp:HyperLink>
                                </td>
                                <td style="text-align: right;">

                                    <f:button runat="server" id="btnUserName" cssclass="userpicaction" text="" iconalign="Left"
                                        enablepostback="false" enabledefaultstate="false" enabledefaultcorner="false">
                                        <menu runat="server">
                                            <f:menubutton id="btnHelp" enablepostback="false" icon="Help" text="帮助" runat="server">
                                            </f:menubutton>
                                            <f:menuseparator runat="server">
                                            </f:menuseparator>
                                            <f:menubutton runat="server" text="安全退出" confirmtext="确定退出系统？" onclick="btnExit_Click">
                                            </f:menubutton>
                                        </menu>
                                    </f:button>
                                </td>
                            </tr>
                        </table>
                    </div>


                </f:contentpanel>

                <%--左边选择功能部分--%>
                <f:panel id="leftPanel" cssclass="leftregion bgpanel"
                    enablecollapse="true" width="200px" regionsplit="true" regionspliticon="true" regionsplitwidth="3px"
                    showheader="false" title="系统菜单" layout="Fit" regionposition="Left" runat="server">
                </f:panel>

                <%--右边操作部分--%>
                <f:tabstrip id="mainTabStrip" cssclass="centerregion" regionposition="Center" showinkbar="true" enabletabclosemenu="true" showborder="true" runat="server">
                    <tabs>
                        <f:tab id="Tab1" title="首页" enableiframe="true" iframeurl="~/admin/default.aspx"
                            icon="House" runat="server">
                        </f:tab>
                    </tabs>
                    <tools>
                        <f:tool runat="server" enablepostback="false" iconfont="_Refresh" cssclass="tabtool" tooltip="刷新本页" id="toolRefresh">
                            <listeners>
                                <f:listener event="click" handler="onToolRefreshClick" />
                            </listeners>
                        </f:tool>
                        <f:tool runat="server" enablepostback="false" iconfont="_Maximize" cssclass="tabtool" tooltip="最大化" id="toolMaximize">
                            <listeners>
                                <f:listener event="click" handler="onToolMaximizeClick" />
                            </listeners>
                        </f:tool>
                    </tools>
                </f:tabstrip>
            </items>
        </f:panel>
        <f:window id="Window1" runat="server" ismodal="true" hidden="true" enableiframe="true"
            enableresize="true" enablemaximize="true" iframeurl="about:blank" width="800px"
            height="500px">
        </f:window>
        <a id="toggleheader" href="javascript:;"></a>
    </form>
    <%--<script src="res/js/main.js" type="text/javascript"></script>--%>
    <script>

        var mainTabStripClientID = '<% =mainTabStrip.ClientID%>';
        var topPanelClientID = '<%=topPanel.ClientID%>';
        var leftPanelClientID = '<%= leftPanel.ClientID %>';

        // 点击标题栏工具图标 - 刷新
        function onToolRefreshClick(event) {
            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            if (activeTab.iframe) {
                var iframeWnd = activeTab.getIFrameWindow();
                iframeWnd.location.reload();
            }
        }

        // 点击标题栏工具图标 - 最大化
        function onToolMaximizeClick(event) {
            var topPanel = F(topPanelClientID);
            var leftPanel = F(leftPanelClientID);

            var currentTool = this;
            F.noAnimation(function () {
                if (currentTool.iconFont === 'f-iconfont-maximize') {
                    currentTool.setIconFont('f-iconfont-restore');

                    leftPanel.collapse();
                    topPanel.collapse();
                } else {
                    currentTool.setIconFont('f-iconfont-maximize');

                    leftPanel.expand();
                    topPanel.expand();
                }
            });
        }

        // 添加示例标签页
        // id： 选项卡ID
        // iframeUrl: 选项卡IFrame地址 
        // title： 选项卡标题
        // icon： 选项卡图标
        // createToolbar： 创建选项卡前的回调函数（接受tabOptions参数）
        // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
        // iconFont： 选项卡图标字体
        function addExampleTab(tabOptions) {

            if (typeof (tabOptions) === 'string') {
                tabOptions = {
                    id: arguments[0],
                    iframeUrl: arguments[1],
                    title: arguments[2],
                    icon: arguments[3],
                    createToolbar: arguments[4],
                    refreshWhenExist: arguments[5],
                    iconFont: arguments[6]
                };
            }

            F.addMainTab(F(mainTabStripClientID), tabOptions);
        }


        // 移除选中标签页
        function removeActiveTab() {
            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            activeTab.hide();
        }


        F.ready(function () {

            var mainTabStrip = F(mainTabStripClientID);
            var leftPanel = F(leftPanelClientID);
            var treeMenu = leftPanel.getItem(0);

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // updateHash: 切换Tab时，是否更新地址栏Hash值（默认值：true）
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame（默认值：false）
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame（默认值：false）
            // maxTabCount: 最大允许打开的选项卡数量
            // maxTabMessage: 超过最大允许打开选项卡数量时的提示信息
            F.initTreeTabStrip(treeMenu, mainTabStrip, {
                refreshWhenExist: false,
                refreshWhenTabChange: false,
                maxTabCount: 10,
                maxTabMessage: '请先关闭一些选项卡（最多允许打开 10 个）！'
            });


        });
    </script>
</body>
</html>
