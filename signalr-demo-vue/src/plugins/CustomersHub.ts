import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import Vue, { PluginFunction } from "vue";

const plugin: PluginFunction<unknown> = () => {
  const connection = new HubConnectionBuilder()
    .withUrl(process.env.VUE_APP_CUSTOMERS_HUB_URL)
    .withAutomaticReconnect()
    .build();

  Vue.prototype.$customersHub = connection;
};

declare module "vue/types/vue" {
  interface Vue {
    $customersHub: HubConnection;
  }
}

export default plugin;
