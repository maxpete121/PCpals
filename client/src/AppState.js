import { reactive } from 'vue'
import { PcBuild } from './models/PcBuild'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  // /** @type {import('./models/Account.js').Account} */
  account: {},
  /**@type {PcBuild[]} */
  userBuilds: [],
 /**@type {PcBuild[]} */
  savedUserBuilds: [],
// /**@type {PcBuild} */
  activeBuildToEdit: {},
// /**@type {} */
  suggestedBuilds: [],

  activeStockParts: [],

  activeBuildParts: [],

  recentBuilds: [],

  topReviewed: [],

  activeBuildForReview: {},
  activeBuildReviews: [],

  cpu: [],
  gpu: [],
  motherboard: [],
  case: [],
  ram: [],
  storage: [],
  cooler: [],
  powerSupply: [],
})
