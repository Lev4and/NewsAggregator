<script lang="ts" setup>
  import { toRefs} from 'vue'

  interface ModalProps {
    id: string,
    title: string
  }

  const props = defineProps<ModalProps>()
  const { id } = toRefs(props)
</script>

<template>
  <div class="modal fade" :id="id" tabindex="-1" :aria-labelledby="`${id}Label`" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <slot name="header" title="title">
            <h1 class="modal-title fs-5" :id="`${id}Label`" v-text="title" />
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </slot>
        </div>
        <div class="modal-body">
          <slot name="body" />
        </div>
        <div class="modal-footer">
          <slot name="footer" />
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  @import './index.scss';
</style>