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
import { HubConnectionState } from "@microsoft/signalr";
import { Component, Vue } from "vue-property-decorator";

@Component
export default class HomeView extends Vue {
  customers: { id: number; name: string }[] = [];

  async created() {
    this.$customersHub.start();

    this.$customersHub.on("CustomerCreated", (id: number, name: string) => {
      this.customers.push({ id, name });
    });
  }

  async destroyed() {
    this.$customersHub.off("CustomerCreated");

    if (this.$customersHub.state === HubConnectionState.Connected) {
      this.$customersHub.stop();
    }
  }
}
</script>
