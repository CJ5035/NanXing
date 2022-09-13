Vue.component('image-text', {
    template: `
        <div class="div-box" :valueName="valueName" 
            :value="value" :unit="unit">
            <img :src="carImg" class="imageList"/>
              <div class="value">
                    {{value}}
               </div>
              <div class="unit">
                     {{unit}}
               </div>
                <div class="name">
                    {{valueName}}
                </div>
          </div>                  
`,
    data: function () {
        return {
            cardImgList: [
                ('/res/images/小图标/feiqi.png'),
                ('/res/images/小图标/电能实时.png'),
                ('/res/images/小图标/湿度2.png'),
                ('/res/images/小图标/噪音2.png'),
                ('/res/images/小图标/粉尘2.png'),
                ('/res/images/小图标/温度2.png')
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