<script lang="ts" setup>
  import { Modal } from '@/shared/ui/modal'
</script>

<template>
  <modal id="searchNewsModal" title="Search news">
    <template v-slot:body>
      <form id="searchNewsModalForm" class="needs-validation">
        <div class="row g-3">
          <div class="col-12">
            <label for="searchStringTextInput" class="form-label">Search string</label>
            <input id="searchStringTextInput" class="form-control" type="text" placeholder="" name="searchString">
          </div>
        </div>
      </form>
    </template>
    <template v-slot:footer>
      <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
      <button type="button" class="btn btn-primary">Search news</button>
    </template>
  </modal>
</template>

<style lang="scss" scoped>
  @import './index.scss';
</style>