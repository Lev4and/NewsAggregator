<script lang="ts" setup>
  import { Routing } from '@/pages'
  import { HomeLayout } from '@/shared/ui/home-layout'
  import { HomeHeader } from '@/widgets/home-header/ui'
  import { HomeFooter } from '@/widgets/home-footer/ui'
</script>

<template>
  <home-layout>
    <template v-slot:header>
      <home-header />
    </template>
    <template v-slot:content>
      <routing />
    </template>
    <template v-slot:footer>
      <home-footer />
    </template>
  </home-layout>
</template>

<style lang="scss" scoped>
  @import './index.scss';
</style>