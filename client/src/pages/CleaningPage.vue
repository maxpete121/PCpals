<template>
    <section class="container-fluid">
        <div class="row mt-3 d-flex flex-column align-items-center mb-2">
          <div class="col-4">
            <img class="img-fluid img-style" src="https://www.digitaltrends.com/wp-content/uploads/2022/04/cleaning-inside-of-pc-desktop.jpg?p=1" alt="Dirty PC picture.">
          </div>
          <div class="col-4 mt-4">
            <div class="clean-info">
              <h3>Need your PC cleaned?</h3>
              <p>Submit a ticket to our cleaning team and we will be in touch within the same business day to schedule a clean for your PC!</p>
            </div>
            <div class="d-flex justify-content-center mt-3">
              <div class="me-4 clean-info">
                <h5 class="border-bottom">Clean details...</h5>
                <span class="d-flex">
                  <p class="fst-italic me-2 list-item">Price:</p>
                  <p class="list-item text-success">$30</p>
                </span>
                <span class="">
                  <p class="fst-italic list-item">What we do:</p>
                  <p class="list-item">✅Dusting</p>
                  <p class="list-item">✅New thermal Paste</p>
                  <p class="list-item">✅Exterior Wipe down</p>
                </span>
              </div>
              <div class="text-center clean-info ms-4">
                <h5>Submit a ticket</h5>
                <form action="">
                  <div class="d-flex flex-column">
                    <label for="email">Email</label>
                    <input name="email" type="text" required>
                  </div>
                  <button class="mt-2 btn btn-dark">Send Ticket</button>
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
    padding: 10px;
    border-radius: 10px;
    background-color: white;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.527);
  }

  .list-item{
    height: 12px;
  }

  .img-style{
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.527);
  }
</style>