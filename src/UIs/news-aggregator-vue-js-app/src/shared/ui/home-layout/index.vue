<script lang="ts" setup>
  
</script>

<template>
  <div class="layout">
    <slot name="header" />
    <main class="container">
      <slot name="content" />
    </main>
    <slot name="footer" />
  </div>
</template>