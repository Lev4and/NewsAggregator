<script lang="ts" setup>
  import { SearchLogo } from '@/shared/ui/search-logo'
</script>

<template>
  <a class="link-secondary" data-bs-toggle="modal" data-bs-target="#searchNewsModal" aria-label="Search">
    <search-logo />
  </a>
</template>

<style lang="scss" scoped>
  @import './index.scss'
</style>