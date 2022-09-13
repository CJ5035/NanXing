<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRMApplyConfirm.aspx.cs" 
    Inherits="NanXingGuoRen_WMS.ProductionOrder_SmallBox.CRMApplyControl.CRMApplyConfirm" %>

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
                       <f:TextArea runat="server" ID="TextArea_Remark"></f:TextArea>    
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
