import { reactive } from 'vue'
import { PcBuild } from './models/PcBuild'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  // /** @type {import('./models/Account.js').Account} */
  account: {},
  /**@type {PcBuild[]} */
  userBuilds: [],
  savedUserBuilds: [],
  userBuildType: 'created',
  activeBuildToEdit: {},
  suggestedBuilds: [],
  currentPartType: '',
  partCompany: 'Intel',
  activeStockParts: [],
  activeBuildParts: [],
  recentBuilds: [],
  topReviewed: [],
  activeBuildForReview: {},
  activeBuildReviews: [],
  cart: [],
  totalCart: 100,
  cpu: [],
  gpu: [],
  motherboard: [],
  case: [],
  ram: [],
  storage: [],
  cooler: [],
  powerSupply: [],
})
