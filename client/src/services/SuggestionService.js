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
        console.log(response)
    }
    async DeleteSuggestion(){}
}

export const suggestionService = new SuggestionService()