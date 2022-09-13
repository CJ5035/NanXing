Vue.component('css-table', {
    template: `
        <table class="pure-table">
                                <thead style="height:10%">
                                    <tr>
                                        <th>序号</th>
                                        <th>任务单号</th>
                                        <th>品名</th>
                                        <th>规格</th>
                                        <th>数量（箱）</th>
                                        <th>交期</th>

                                    </tr>
                                </thead>

                                <tbody  style="height:90%">
                                    <tr v-for="(user,index) in tableData"
                                        :class="{ 'pure-table td':index%2==1,'pure-table-odd': index%2==0}">
                                        <td>{{index+1}}</td>
                                        <td>{{user.CRMApplyNo_Xuhao}}</td>
                                        <td>{{user.ItemName}}</td>
                                        <td>{{user.Spec}}</td>
                                        <td>{{user.OrderCount}}</td>
                                        <td>{{user.DeliveryDateStr}}</td>

                                    </tr>
                                 </tbody>
                            </table>
`,
    data: function () {
        return {
            productList:[], //所有数据
            totalPage: 1, // 统共页数，默认为1
            currentPage: 1, //当前页数 ，默认为1
            pageSize: 10, // 每页显示数量
            currentPageData: [] //当前页显示内容
           
        }
    },
    props: ['componentId', 'labelName', 'index', 'valueName','value','unit' ],
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