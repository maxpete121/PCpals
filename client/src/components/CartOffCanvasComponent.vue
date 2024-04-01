<template>
  <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasCart" aria-labelledby="offcanvasExampleLabel">
  <div class="offcanvas-header">
    <h5 class="offcanvas-title" id="offcanvasExampleLabel">Cart</h5>
    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
  </div>
  <div class="offcanvas-body">
    <div class="d-flex flex-column justify-content-between h-100">
      <div class="">
        Items
      </div>
      <div class="d-flex total">
        <h4>Total</h4>
      </div>
    </div>
  </div>
</div>
  </template>
  
  <script>
  import { computed } from 'vue'
  export default {
    setup() {
      return {

      }
    }
  }
  </script>
  
  <style lang="scss" scoped>
.total{
  border-top: solid 1px purple;
}
</style>