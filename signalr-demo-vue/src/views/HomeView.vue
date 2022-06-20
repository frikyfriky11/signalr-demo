<template>
  <div>
    <h2>Home view</h2>

    <ul>
      <li v-for="customer in customers" :key="customer.id">
        {{ customer.id }} {{ customer.name }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

@Component
export default class HomeView extends Vue {
  customers: { id: number; name: string }[] = [];

  customersHub?: HubConnection = undefined;

  async created() {
    this.customersHub = new HubConnectionBuilder()
      .withUrl("https://localhost:7100/signalr/customers-hub")
      .withAutomaticReconnect()
      .build();

    this.customersHub.start();

    this.customersHub.on("CustomerCreated", (id: number, name: string) => {
      this.customers.push({ id, name });
    });
  }
}
</script>
