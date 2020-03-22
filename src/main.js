import Vue from 'vue'
import App from './App.vue'
import Vuex from 'vuex'
import router from './router';
import { store } from './store/store'

Vue.use(Vuex)
Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
