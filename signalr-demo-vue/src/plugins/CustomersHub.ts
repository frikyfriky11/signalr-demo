import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import Vue, { PluginFunction } from "vue";

const plugin: PluginFunction<unknown> = () => {
  const connection = new HubConnectionBuilder()
    .withUrl("https://localhost:7100/signalr/customers-hub")
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
