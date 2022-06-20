<template>
  <div>
    <h1>SignalR Demo - Vue.js</h1>
    <router-view />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class App extends Vue {}
</script>
