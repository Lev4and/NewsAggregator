<script lang="ts" setup>
  import { DefaultLayout } from '@/shared/ui/default-layout'
  import { DefaultHeader } from '@/widgets/default-header/ui'
  import { DefaultFooter } from '@/widgets/default-footer/ui'
</script>

<template>
  <default-layout>
    <template v-slot:header>
      <default-header />
    </template>
    <template v-slot:content>
      This is page content!
    </template>
    <template v-slot:footer>
      <default-footer />
    </template>
  </default-layout>
</template>