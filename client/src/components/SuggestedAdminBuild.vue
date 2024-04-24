<template>
    <div class="mt-2 bg-white d-flex">
        <div>
            <div class="d-flex">
              <h4>Name:</h4>
              <h4 class="ms-4">{{ suggestedBuild.build.name }}</h4>
            </div>
            <div class="d-flex">
              <h4>ID:</h4>
              <h4 class="ms-4">{{ suggestedBuild.id }}</h4>
            </div>
            <div class="d-flex">
              <h3>Admin Approved:</h3>
              <h4 v-if="suggestedBuild.adminCode == adminCode" class="ms-4">Yes✅</h4>
              <h4 v-else>NOT APPROVED</h4>
            </div>
        </div>
        <div class="d-flex align-items-center ms-4">
            <button @click="deleteSuggestion()">Delete</button>
        </div>
    </div>
    </template>
    
    <script>
    import { computed } from 'vue'
    import { AppState } from '../AppState'
    import { AuthService } from '../services/AuthService'
  import { PcBuild } from '../models/PcBuild'
import { Suggestion } from '../models/Suggestion'
import { suggestionService } from '../services/SuggestionService'
import Pop from '../utils/Pop'
    export default {
      props: {suggestedBuild: {type: Suggestion, required: true}},
      setup(props) {
        async function deleteSuggestion(){
            if(window.confirm("Do you want to remove this suggestion?")){
                let message = await suggestionService.deleteSuggestion(props.suggestedBuild.id)
                Pop.confirm(`${message}`)
            }
        }
        return {
            adminCode: 17448,
            deleteSuggestion,
        }
      }
    }
    </script>
    
    <style lang="scss" scoped></style>