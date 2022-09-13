Vue.component('css-table', {
    template: `
        <table class="pure-table">
            <thead style="height:5%">
                <tr>
                    <th>序号</th>
                    <th>任务单号</th>
                    <th>产品名称</th>
                    <th>排产日期</th>
                    <th>交付日期</th>
                    <th>生产日期</th>
                    <th>完成日期</th>
                    <th>生产车间</th>
                    <th>交付超期</th>
                    <th>计划产量</th>
                    <th>实际产量</th>
                    <th>单位</th>
                    <th>完成率</th>
                    <th>生产状态</th>

                 </tr>
           </thead>

           <tbody  style="height:90%">
               <tr v-for="(user,index) in tableData"
                   :class="{ 'pure-table td':index%2==1,'pure-table-odd': index%2==0}"
                    style="height:10%">
                   <td>{{user.Index}}</td>
                   <td>{{user.ProductOrder_XuHao}}</td>
                   <td style="text-align:left">{{user.ItemName}}</td>
                   <td>{{user.PlanDateStr}}</td>
                   <td>{{user.DeliveryDateStr}}</td>
                   <td>{{user.PlanProDateStr}}</td>
                   <td>{{user.FinishTimeStr}}</td>
                   <td>{{user.CheJianNameStr}}</td>
                   <td :class="{'errorState':user.JFCQ=='是'}">
                        {{user.JFCQ}}</td>
                   <td>{{user.PcCount}}</td>
                   <td>{{user.ProCount}}</td>
                   <td>{{user.Unit}}</td>
                   <td>{{user.WCLStr}}</td>
                   <td :class="{'productState':user.ProOrderList_State=='生产中',
                    'noWorkState':user.ProOrderList_State=='未生产',
                    'stopProduct':user.ProOrderList_State=='暂停生产',
                    'errorState':user.ProOrderList_State=='异常',
                    'finishedState':user.ProOrderList_State=='已完成'
                    ,'errorFinishedState':user.ProOrderList_State=='异常完成'}">
                        {{user.ProOrderList_State}}</td>
               </tr>
            </tbody>
    </table>
`,
    data: function () {
        return {
            productList: [], //所有数据
            totalPage: 1, // 统共页数，默认为1
            currentPage: 1, //当前页数 ，默认为1
            pageSize: 10, // 每页显示数量
            currentPageData: [] //当前页显示内容

        }
    },
    props: ['componentId', 'labelName', 'index', 'valueName', 'value', 'unit'],
    created: function () {

        //console.log()
    },
    methods: {
        // 点击基本框显示或隐藏选项列表盒子
        // 设置当前页面数据，对数组操作的截取规则为[0~10],[10~20]...,
        setCurrentPageData() {
            let begin = (this.currentPage - 1) * this.pageSize;
            let end = this.currentPage * this.pageSize;
            this.currentPageData = this.productList.slice(
                begin,
                end
            );
        },
        //上一页
        prevPage() {
            console.log(this.currentPage);
            if (this.currentPage == 1) return;

            this.currentPage--;
            this.setCurrentPageData();

        },
        // 下一页
        nextPage() {
            if (this.currentPage == this.totalPage) return;

            this.currentPage++;
            this.setCurrentPageData();

        }

    },
    computed: {
        tableData() {

            return this.$store.state.currentPageData
        }
    }
})