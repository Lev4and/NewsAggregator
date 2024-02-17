import { createApp } from 'vue'
import { router } from './providers'
import App from './index.vue'

export const app = createApp(App).use(router)