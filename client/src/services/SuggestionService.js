import { api } from "./AxiosService"


class SuggestionService{
    async getSuggestion(){}
    async createSuggestion(suggestionData){
        let response = await api.post('api/suggestions', suggestionData)
        console.log(response)
    }
    async DeleteSuggestion(){}
}

export const suggestionService = new SuggestionService()