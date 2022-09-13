Vue.component('title-bar', {
    template: `
            <div v-bind:id="componentId"  class="bar">
                        <div class="pic"></div>
                        <div class="title">
                            <span class="spans">{{value}}</span>
                        </div>
             </div>
`,
    data: function () {
        return {
           
        }
    },
    props: ['componentId', 'labelName', 'value'],
    created: function () {
        
    },
    methods: {// 点击基本框显示或隐藏选项列表盒子
        
    },
    computed: {
        
    }
})