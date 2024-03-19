import { AppState } from "../AppState"
import { Reviews } from "../models/Reviews"
import { api } from "./AxiosService"


class ReviewService{
    async setActiveBuild(buildId){
        let recentBuild = AppState.recentBuilds.find(pc => pc.id = buildId)
        let reviewedBuild = AppState.topReviewed.find(pc => pc.id == buildId)
        if(recentBuild){AppState.activeBuildForReview = recentBuild}
        else if(reviewedBuild){AppState.activeBuildForReview = reviewedBuild}
    }
    async getActiveReviews(buildId){
        let response = await api.get(`api/reviews/${buildId}/build`)
        let buildReviews = await response.data.map(review => new Reviews(review))
        AppState.activeBuildForReview = buildReviews
    }

    async createReview(reviewData){
        let response = await api.post('api/reviews', reviewData)
        let newReview = new Reviews(response.data)
        AppState.activeBuildReviews.unshift(newReview)
    }
}

export const reviewService = new ReviewService()