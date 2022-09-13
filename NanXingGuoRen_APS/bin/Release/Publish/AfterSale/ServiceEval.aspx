<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEval.aspx.cs" Inherits="LCC_PNM.AfterSale.ServiceEval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>售后服务工单</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="../layui-v2.4.5/layui/css/layui.css" rel="stylesheet" />
    <script src="../layui-v2.4.5/layui/layui.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/vue/dist/vue.js"></script>
</head>
<body>
    <form class="layui-form layui-form-pane" id="form1">
        <div id="app">
            <input type="hidden" v-model="ID" name="ID" />

            <fieldset class="layui-elem-field" style="margin-top: 10px;">
                <legend><i class="layui-icon layui-icon-reply-fill" style="color: #FF5722;"></i>客户评价</legend>
                <div class="layui-field-box">
                    <div class="layui-form-item">
                        <label class="layui-form-label">解决问题:</label>
                        <div class="layui-input-block">
                            <%--<input type="text" name="soulv_content" lay-verify="required" lay-reqtext="" placeholder="" autocomplete="off" class="layui-input" v-model="soulv_content">--%>
                            <input type="radio" name="soulv_content" value="已完成" title="已完成" checked>
                            <input type="radio" name="soulv_content" value="基本完成" title="基本完成" >
                            <input type="radio" name="soulv_content" value="未完成" title="未完成" >
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">服务评价:</label>
                        <div class="layui-input-block">
                            <input type="text" name="evaluate" hidden="hidden"  v-model="evaluate">
                            <input type="checkbox" name="pingjia1" title="服务态度好" lay-filter="switchTest">
                            <input type="checkbox" name="pingjia2" title="衣着整洁" lay-filter="switchTest">
                            <input type="checkbox" name="pingjia3" title="处理速度快" lay-filter="switchTest">
                            <hr />
                            <input type="checkbox" name="pingjia4" title="服务态度一般" lay-filter="switchTest">
                            <input type="checkbox" name="pingjia5" title="着装脏乱" lay-filter="switchTest">
                            <input type="checkbox" name="pingjia6" title="没准时处理" lay-filter="switchTest">
                        </div>
                    </div>
                    <label class="layui-form-label">评分:</label><div id="grade" style="margin-left: 30px">
                    </div>
                    <input name="grade" type="text" v-model="grade" hidden="hidden" />
                </div>

            </fieldset>

            <div class="layui-form-item">
                <div class="layui-input-block">
                    <button id="submit" type="submit" class="layui-btn" lay-submit="" lay-filter="demo1"><i class="layui-icon">&#xe609;</i>立即提交</button>
                    <a class="layui-btn layui-btn-normal" href="pic.bmp"><i class="layui-icon">&#xe677;</i>关注我们</a>
                </div>
            </div>

        </div>


    </form>

    <script>
        var ID = getParam("ID", decodeURI(window.location));

        var evaluate = [];

        $(document).ready(function () {
            app.ID = ID;
            $.ajax({
                type: "GET",
                url: "GetAllOrder.ashx?ID=" + ID,
                dataType: "json",
                success: function (result) {
                    if (result.count == 0) {
                        alert('参数错误');
                        window.location = 'selectEval.html';
                    }

                    //app.Name = result.data[0].Name;
                    //app.contact = result.data[0].contact;
                    //app.address = result.data[0].address;
                    //app.order_desc = result.data[0].order_desc;
                    //app.nature = result.data[0].nature;
                    //app.train_desc = result.data[0].train_desc;
                    //app.train_instance = result.data[0].train_instance;
                    //app.equip_info = result.data[0].equip_info;
                    app.soulv_content = result.data[0].soulv_content;
                    app.evaluate = result.data[0].evaluate;
                }
            })

        });


        var app = new Vue({
            el: "#app",
            data: {
                ID: '',
                Name: '',
                contact: '',
                address: '',
                order_desc: '',
                nature: '',
                train_desc: '',
                train_instance: '',
                equip_info: '',
                soulv_content: '',
                evaluate: '',
                grade: 0
            }
        })


        layui.use(['form', 'upload'], function () {
            var form = layui.form
                , layer = layui.layer
                , upload = layui.upload;


            form.on('checkbox(switchTest)', function (data) {
                console.log(data.elem); //得到checkbox原始DOM对象
                console.log(data.elem.checked); //是否被选中，true或者false
                console.log(data.value); //复选框value值，也可以通过data.elem.value得到
                console.log(data.othis); //得到美化后的DOM对象

                console.log(data.elem.title);

                //evaluate.splice(0, evaluate.length);

                if (data.elem.checked == true) {
                    evaluate.push(data.elem.title)
                    console.log(evaluate);
                } else if (data.elem.checked == false) {
                    evaluate.pop(data.elem.title)
                    console.log(evaluate);
                }

                app.evaluate = '';

                for (let i = 0, len = evaluate.length; i < len; i++) {
                    app.evaluate += evaluate[i]+',';
                }
            })


            form.on('submit(demo1)', function (data) {
                //layer.alert(JSON.stringify(data.field), {
                //    title: '最终的提交信息'
                //})

                $.ajax({
                    type: "POST",
                    url: "UpdateEval.ashx",
                    data: $("#form1").serialize(),
                    success: function (result) {
                        if (result == 'true') {
                            console.log($("#form1").serialize());
                            layer.msg("提交成功");
                            alert('提交成功');
                            window.location = "selecteval.html";
                        } else {
                            layer.msg("提交失败");
                        }
                    }
                });

                return false;//阻止表单跳转
            })

        });

        layui.use(['rate'], function () {
            var rate = layui.rate;
            //基础效果
            rate.render({
                elem: '#grade',
                choose: function (value) {
                    app.grade = value;
                }
            })
        });

        function getParam(paramName, urlParamName) {

            if (urlParamName == undefined || urlParamName == "") {

                urlParamName = "returnurl";
            }

            paramValue = "";
            isFound = false;
            paramName = paramName.toLowerCase();
            var arrSource = this.location.search.substring(1, this.location.search.length).split("&");
            if (this.location.search.indexOf("?") == 0 && this.location.search.indexOf("=") > 1) {
                if (paramName == urlParamName) {
                    var retIndex = this.location.search.toLowerCase().indexOf(urlParamName);
                    if (retIndex > -1) {
                        var returnUrl = unescape(this.location.search.substring(retIndex + 10, this.location.search.length));
                        if ((returnUrl.indexOf("http") != 0) && returnUrl != "" && returnUrl.indexOf(location.host.toLowerCase()) == 0) returnUrl = "http://" + returnUrl;
                        return returnUrl;
                    }
                }
                i = 0;
                while (i < arrSource.length && !isFound) {
                    if (arrSource[i].indexOf("=") > 0) {
                        if (arrSource[i].split("=")[0].toLowerCase() == paramName.toLowerCase()) {
                            paramValue = arrSource[i].toLowerCase().split(paramName + "=")[1];
                            paramValue = arrSource[i].substr(paramName.length + 1, paramValue.length);
                            isFound = true;
                        }
                    }
                    i++;
                }
            }
            return paramValue;
        }
    </script>
</body>
</html>
