import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const store = new Vuex.Store({
    // 定义状态
    state: {
        author: 'Wise Wrong'
    },
    mutations: {
        newAuthor(state, msg) {
            state.author=msg
        }
    }
})

export default store