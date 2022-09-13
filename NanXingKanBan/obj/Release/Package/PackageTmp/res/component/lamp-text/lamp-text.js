Vue.component('lamp-text', {
    template: `
        <div class="div-lamptext">
            <img :src="carImg"
            class="image-lamp"/>
             <div class="lampText-Value">{{value}}</div>
         </div>                   
`,
    data: function () {
        return {
            cardImgList: [
                ('/res/images/小灯/blue.bmp'),
                ('/res/images/小灯/green.bmp'),
                ('/res/images/小灯/yellow.bmp'),
                ('/res/images/小灯/red.bmp'),
            ],
            carImg: '',
        }
    },
    props: ['componentId', 'labelName', 'index', 'valueName','value','unit' ],
    created: function () {
        var that = this;
        that.carImg = that.cardImgList[that.index];
        //console.log()
    },
    methods: {// 点击基本框显示或隐藏选项列表盒子

    },
    computed: {

    }
})