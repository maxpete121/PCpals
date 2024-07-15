<template>
    <section class="container-fluid">
        <div class="row justify-content-center">
          <div class="col-lg-3 col-11 contact-title-card mt-3 text-center p-1 d-flex flex-column align-items-center">
            <h4>We're here to help!</h4>
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
        <div class="row justify-content-center mt-4">
          <div v-if="!account.id" class="text-center">
            <h5>Please Login/Create Account to submit support tickets.</h5>
          </div>
          <div v-else class="col-lg-3 col-11 contact-title-card d-flex flex-column align-items-center p-1">
            <h4>Submit a support ticket!</h4>
            <form @submit.prevent="createSupportTicket()">
              <div class="d-flex flex-column">
                <label for="name">Name</label>
                <input required v-model="ticketData.customerName" name="name" type="text" minlength="3" maxlength="80">
              </div>
              <div class="d-flex flex-column mt-2">
                <label for="subject">Email</label>
                <input required v-model="ticketData.customerEmail" name="subject" type="text" minlength="10" maxlength="80">
              </div>
              <div class="d-flex flex-column mt-2">
                <label for="subject">Subject</label>
                <input required v-model="ticketData.issueSubject" name="subject" type="text" minlength="3" maxlength="100">
              </div>
              <div class="d-flex flex-column mt-2">
                <label for="issue">Problem description</label>
                <textarea required v-model="ticketData.issueDescription" name="issue" cols="30" rows="4"></textarea>
              </div>
              <div class="mt-2 text-center">
                <button class="btn btn-outline-dark">Submit</button>
              </div>
            </form>
          </div>
        </div>
    </section>
  </template>
  
  <script>
  import { computed, ref } from 'vue'
  import { AppState } from '../AppState'
  import {supportTicketService} from '../services/supportTicketService.js';
  import Pop from '../utils/Pop';
  export default {
    setup() {
      let ticketData = ref()
      ticketData.value = {}
      async function createSupportTicket(){
        try {
          await supportTicketService.createSupportTicket(ticketData.value)
          ticketData.value = {}
          Pop.success("Ticket Submitted")
        } catch (error) {
          Pop.error("Support ticket not submitted")
        }
      }
      return {
        account: computed(()=> AppState.account),
        ticketData,
        createSupportTicket
      }
    }
  }
  </script>
  
  <style lang="scss" scoped>
  @media screen and (min-width: 576px) {
    .social{
  border-top: solid 1px purple;
  width: 45%;
}
}

@media screen and (max-width: 576px) {
  .social{
  border-top: solid 1px purple;
  width: 55%;
}
}

.contact-title-card{
  outline: solid 1px purple;
  background-color: white;
  box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.459);
  border-radius: 10px;
}

</style>