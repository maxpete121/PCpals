import { AppState } from "../AppState"
import { Suggestion } from "../models/Suggestion"
import { api } from "./AxiosService"


class SuggestionService{
    async getSuggestions(){
        let response = await api.get('api/suggestions')
        let pcSuggestions = response.data.map(suggestion => new Suggestion(suggestion))
        AppState.suggestedBuilds = pcSuggestions
    }
    async createSuggestion(suggestionData){
        let response = await api.post('api/suggestions', suggestionData)
        let newSuggestion = new Suggestion(response.data)
        AppState.suggestedBuilds.unshift(newSuggestion)
    }
    async deleteSuggestion(suggestionId){
        let response = await api.delete(`api/suggestions/${suggestionId}`)
        let buildIndex = AppState.suggestedBuilds.findIndex(build => build.id == suggestionId)
        AppState.suggestedBuilds.slice(buildIndex, 1)
        return response.data
    }
}

export const suggestionService = new SuggestionService()