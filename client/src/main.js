import Vue from 'vue'
import App from './App.vue'
import Vuex from 'vuex'
import router from './router';
import { store } from './store/store'
import axios from 'axios'
import VueMq from 'vue-mq'

const axiosConf = {
  baseURL: "http://localhost:44301/api/"
}
Vue.prototype.$http = axios.create(axiosConf)

Vue.use(Vuex)
Vue.config.productionTip = false
Vue.use(VueMq, {
  breakpoints: {
    sm: 750,
    lg: Infinity,
  }
})

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
