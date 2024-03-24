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
        // console.log(AppState.activeBuildReviews)
    }

    async createReview(reviewData){
        // console.log(reviewData)
        let response = await api.post('api/reviews', reviewData)
        let newReview = new Reviews(response.data)
        AppState.activeBuildReviews.unshift(newReview)
        this.averageReview()
    }

    async deleteReview(reviewId){
        let response = await api.delete(`api/reviews/${reviewId}`)
        let reviewIndex = AppState.activeBuildReviews.findIndex(review => review.id == reviewId)
        AppState.activeBuildReviews.splice(reviewIndex, 1)
        return response.data
    }

    async averageReview(){
        let totalStars = 0
        for(let i = 0; AppState.activeBuildReviews.length > i; i++){
            totalStars += AppState.activeBuildReviews[i].stars
        }
        let reviewCount = AppState.activeBuildReviews.length
        let average = totalStars / reviewCount
        let roundedAverage = Math.round(average * 100) / 100
        console.log(roundedAverage)
    }
}

export const reviewService = new ReviewService()