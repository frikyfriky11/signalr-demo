import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import CustomersHub from "./plugins/CustomersHub";

Vue.config.productionTip = false;

Vue.use(CustomersHub);

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
