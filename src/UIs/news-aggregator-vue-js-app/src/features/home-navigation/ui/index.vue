<script lang="ts" setup>
  import { RouterLink } from 'vue-router'
</script>

<template>
  <div class="nav-scroller py-1 mb-3 border-bottom">
    <nav class="nav nav-underline justify-content-between">
      <router-link class="nav-item nav-link link-body-emphasis" to="/">
        Home
      </router-link>
      <a class="nav-item nav-link link-body-emphasis">
        News
      </a>
      <a class="nav-item nav-link link-body-emphasis">
        Authors
      </a>
      <a class="nav-item nav-link link-body-emphasis">
        Sources
      </a>
      <a class="nav-item nav-link link-body-emphasis">
        About
      </a>
    </nav>
  </div>
</template>

<style lang="scss" scoped>
  @import './index.scss';
</style>