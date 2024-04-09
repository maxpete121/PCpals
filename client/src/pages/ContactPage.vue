<template>
    <section class="container-fluid">
        <div class="row justify-content-center">
          <div class="col-3 contact-title-card mt-3 text-center p-1 d-flex flex-column align-items-center">
            <h5>Give us a call or send us a message!</h5>
            <h3>We're here to help!</h3>
            <div class="d-flex justify-content-center align-items-center social mt-2 pt-1 ps-1 pe-1">
              <h5 class="me-2">
                <i class="mdi mdi-facebook"></i>
              </h5>
              <h6>Our Facebook Link</h6>
            </div>
            <div class="d-flex justify-content-center align-items-center social pt-1 ps-1 pe-1 mt-2">
              <h5 class="me-2">
                <i class="mdi mdi-instagram"></i>
              </h5>
              <h6>Our Instagram Link</h6>
            </div>
            <div class="d-flex justify-content-center align-items-center social pt-1 ps-1 pe-1 mt-2">
              <h5 class="me-2">
                <i class="mdi mdi-phone"></i>
              </h5>
              <h6>Our phone number</h6>
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
.contact-title-card{
  outline: solid 1px purple;
  background-color: white;
  box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.459);
  border-radius: 10px;
}

.social{
  border-top: solid 1px purple;
  width: 38%;
}
</style>