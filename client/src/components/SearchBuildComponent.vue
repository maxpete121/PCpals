<template>
    <div>
        <form action="">
            <div class="d-flex align-items-center">
                <input class="search-input" type="text">
                <button class="search-button">Search</button>
            </div>
        </form>
    </div>
  </template>
  
  <script>
  import { computed } from 'vue'
  import { AppState } from '../AppState'
  import { AuthService } from '../services/AuthService'
  export default {
    setup() {
      return {

      }
    }
  }
  </script>
  
  <style lang="scss" scoped>
.search-button{
    all: unset;
    outline: solid 2px purple;
    height: 26px;
    padding-left: 8px;
    padding-right: 8px;
    border-top-right-radius: 5px;
    border-bottom-right-radius: 5px;
    background-color: white;
}

.search-button:hover{
    all: unset;
    outline: solid 2px purple;
    height: 26px;
    padding-left: 8px;
    padding-right: 8px;
    border-top-right-radius: 5px;
    border-bottom-right-radius: 5px;
    background-color: rgb(235, 235, 235);
    cursor: pointer;
}

.search-input{
    all: unset;
    border: solid 2px purple;
    height: 26px;
    padding-left: 4px;
    padding-right: 4px;
    border-top-left-radius: 8px;
    border-bottom-left-radius: 8px;
    background-color: white;
}

.search-input:focus{
    all: unset;
    border: solid 2px purple;
    height: 26px;
    padding-left: 4px;
    padding-right: 4px;
    border-top-left-radius: 8px;
    border-bottom-left-radius: 8px;
    background-color: rgb(243, 243, 243);
}
</style>
  