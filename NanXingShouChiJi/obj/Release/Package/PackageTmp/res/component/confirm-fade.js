Vue.component('confirm-fade', {
    template: `
  <div v-if="isShowConfirm" class="my-confirm" @click.stop="clickFun('clickCancel')">
      <div class="confirm-content-wrap" @click.stop>
        <h3 class="my-confirm-title">{{ titleText }}</h3>
        <p class="my-confirm-content">{{ content }}</p>
        <div class="my-operation">
          <div v-if="type==='confirm'" class="my-cancel-btn" @click="clickFun('clickCancel')">
            <p class="my-btn-text my-border-right">{{ cancelText }}</p>
          </div>
          <div class="confirm-btn" @click="clickFun('clickConfirm')">
            <p class="my-btn-text">{{ confirmText }}</p>
          </div>
        </div>
      </div>
    </div>
`,
    data: function () {
        return {
            isShowConfirm: false, // 用于控制整个窗口的显示/隐藏
            titleText: '操作提示', // 提示框标题
            content: 'Say Something ...', // 提示框的内容
            cancelText: '取消', // 取消按钮的文字
            confirmText: '确认', // 确认按钮的文字
            type: 'confirm', // 表明弹框的类型：confirm - 确认弹窗（有取消按钮）；alert - 通知弹框（没有取消按钮）
            outerData: null // 用于记录外部传进来的数据，也可以给外部监听userBehavior，事件的函数提供判断到底是哪个事件触发的
            
        }
    },
    props: ['componentId', 'options', 'labelName', 'value'],
    created: function () {
        // 点全局范围收起下拉框
        
    },
    methods: {// 点击基本框显示或隐藏选项列表盒子
        show(content, config) {
            this.content = content || 'Say Something ...'

            if (Object.prototype.toString.call(config) === '[object Object]') {
                // 确保用户传递的是一个对象
                this.titleText = config.titleText || '操作提示'
                this.cancelText = config.cancelText || '取消'
                this.confirmText = config.confirmText || '确认'
                this.type = config.type || 'confirm'
                this.outerData = config.data || null
            }

            this.isShowConfirm = true
        },
        hidden() {
            this.isShowConfirm = false
            this.titleText = '操作提示'
            this.cancelText = '取消'
            this.confirmText = '确认'
            this.type = 'confirm'
            this.outerData = null
        },
        clickFun(type) {
            this.$emit('userBehavior', type, this.outerData)
            this.hidden()
        }
    },
    computed: {
        selectedValues() {
            return this.$store.state.selectValues
        }
    }
})

//var app = new Vue({
//    el: '#app',
//    data: {
//        selectPro: ''
//    },
//    methods: {
       
//    }
//})