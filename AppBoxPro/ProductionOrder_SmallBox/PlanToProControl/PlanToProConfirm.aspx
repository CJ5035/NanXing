<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanToProConfirm.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanToProControl.PlanToProConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server"></f:PageManager>
        <f:Form runat="server" ShowBorder="false" ShowHeader="false" ID="form2" Margin="10px">
            <Toolbars>
                <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Right">
                    <Items>
                        <f:Button runat="server" ID="btnSubmit" Text="确定" OnClick="btnSubmit_Click" ValidateForms="form2">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:DatePicker runat="server" ID="dp1" Label="计划生产日期"
                               Width="230px" LabelWidth="110px"></f:DatePicker>        
                    </Items>
                   
                </f:FormRow>

                <f:FormRow>
                    <Items>
                           <f:DropDownList runat="server"  ID="ddlPlanTime" Label="计划生产时间"
                               LabelWidth="110px" >
                                <f:ListItem Text="上午" Value="上午" />
                                <f:ListItem Text="下午" Value="下午" />
                                <f:ListItem Text="晚上" Value="晚上" />
                            </f:DropDownList>
                    </Items>

                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
    
        <f:Window runat="server" ID="Window1" EnableIFrame="true" Height="600px" Width="500px" Title=""
            Hidden="true" EnableMaximize="false" EnableMinimize="false" EnableResize="false"
             CloseAction="HidePostBack" ></f:Window>

    <script>
       
    </script>
</body>
</html>
