<script lang="ts" setup>
  import { RouterLink } from 'vue-router'
  import { SearchNewsModalToggle } from '@/features/search-news-modal-toggle/ui'
  import { HomeNavigation } from '@/features/home-navigation/ui'
  import { SearchNewsModal } from '@/features/search-news-modal/ui'
</script>

<template>
  <div class="container position-sticky top-0">
    <header class="border-bottom lh-1 py-3">
      <div class="row flex-nowrap justify-content-between align-items-center">
        <div class="col-4 pt-1">
          <a class="link-secondary" href="#">Subscribe</a>
        </div>
        <div class="col-4 text-center">
          <router-link class="blog-header-logo text-body-emphasis text-decoration-none" to="/">
            NewsAggregator
          </router-link>
        </div>
        <div class="col-4 d-flex justify-content-end align-items-center">
          <search-news-modal-toggle />
          <a class="btn btn-sm btn-outline-secondary" href="#">Sign up</a>
        </div>
      </div>
    </header>
    <home-navigation />
    <search-news-modal />
  </div>
</template>

<style lang="scss" scoped>
  @import './index.scss';
</style>