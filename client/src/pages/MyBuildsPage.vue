<template>
  <section class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-5 mt-3">
        <h4>Welcome to your builds!</h4>
        <div>
          <h5>Create new build...</h5>
          <form action="">
            <input class="form-input" placeholder="Build name..." type="text">
            <button class="form-button">Create</button>
          </form>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  setup() {
    return {
    }
  }
}
</script>

<style scoped lang="scss">
.form-button{
  all: unset;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-right: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 3px;
  padding-right: 3px;
  border-top-right-radius: 5px;
  border-bottom-right-radius: 5px;
}
.form-button:hover{
  all: unset;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-right: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 3px;
  padding-right: 3px;
  cursor: pointer;
  color: darkblue;
  border-top-right-radius: 5px;
  border-bottom-right-radius: 5px;
}
.form-input{
  all: unset;
  outline: none !important;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-left: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 3px;
  padding-right: 3px;
  border-top-left-radius: 5px;
  border-bottom-left-radius: 5px;
}
.form-input:focus{
  all: unset;
  outline: none !important;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-left: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 3px;
  padding-right: 3px;
  border-top-left-radius: 5px;
  border-bottom-left-radius: 5px;
}
</style>
