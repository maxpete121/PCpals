<template>
    <section class="container-fluid">
        <div class="row mt-3 justify-content-center">
          <div class="col-3">
            <img class="img-fluid" src="https://www.digitaltrends.com/wp-content/uploads/2022/04/cleaning-inside-of-pc-desktop.jpg?p=1" alt="Dirty PC picture.">
          </div>
          <div class="col-4 ms-3">
            <div>
              <h3>Need your PC cleaned?</h3>
              <p>Submit a ticket to our cleaning team and we will be in touch within the same business day to schedule a clean for your PC!</p>
            </div>
            <div class="d-flex justify-content-between">
              <div class="ms-">
                <h5 class="border-bottom">Clean details...</h5>
                <span class="d-flex">
                  <p class="fst-italic me-2 list-item">Price:</p>
                  <p class="list-item text-success">$50</p>
                </span>
                <span class="">
                  <p class="fst-italic me-2 list-item">What we do:</p>
                  <p class="list-item">✅Dusting</p>
                  <p class="list-item">✅New thermal Paste</p>
                  <p class="list-item">✅Exterior Wipe down</p>
                </span>
              </div>
              <div class="text-center me-4">
                <h5>Submit a ticket</h5>
                <form action="">
                  <div class="d-flex flex-column">
                    <label for="email">Email</label>
                    <input name="email" type="text" required>
                  </div>
                  <button class="mt-2">Schedule a clean</button>
                </form>
              </div>
            </div>
          </div>
        </div>
    </section>
  </template>
  
  <script>
  import { computed } from 'vue'
  import { AppState } from '../AppState'
  export default {
    setup() {
      return {

      }
    }
  }
  </script>
  
  <style lang="scss" scoped>
  .clean-info{
    outline: solid 1px purple;
  }

  .list-item{
    height: 10px;
  }
</style>