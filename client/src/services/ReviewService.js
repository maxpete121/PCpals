import { AppState } from "../AppState"
import { PcBuild } from "../models/PcBuild"
import { Reviews } from "../models/Reviews"
import { api } from "./AxiosService"


class ReviewService{
    async setActiveBuild(buildId){
        let response = await api.get(`api/pcBuilds/${buildId}`)
        let foundBuild = new PcBuild(response.data)
        AppState.activeBuildForReview = foundBuild
    }
    async getActiveReviews(buildId){
        let response = await api.get(`api/reviews/${buildId}/build`)
        let buildReviews = await response.data.map(review => new Reviews(review))
        AppState.activeBuildReviews = buildReviews
        console.log(AppState.activeBuildReviews)
    }

    async createReview(reviewData){
        console.log(reviewData)
        let response = await api.post('api/reviews', reviewData)
        let newReview = new Reviews(response.data)
        AppState.activeBuildReviews.unshift(newReview)
    }
}

export const reviewService = new ReviewService()