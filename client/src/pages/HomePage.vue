<template>
<section class="container-fluid">
  <div class="row justify-content-center">
    <div class="col-10 p-2 d-lg-flex justify-content-between align-items-center">
      <img class="img-resize" src="https://www.intel.com/content/dam/www/public/us/en/images/video-thumbnails/15s-vid-intel-pro-rpls-14thg-ag-na-hqprim-na-us-eng-16x9-video-thumbnail.png.rendition.intel.web.1920.1080.png" alt="Pc set up picture.">
      <div class="d-flex flex-column align-items-center">
        <h2>Need a PC?</h2>
        <h4 class="mt-2 mb-2">Let us help!</h4>
        <p>Choose from multiple pre-made PC builds or create your own with our guided tour!</p>
        <div>
          <button class="btn btn-outline-secondary me-2">Browse PCs</button>
          <button class="btn btn-outline-secondary">Create Build</button>
        </div>
      </div>
    </div>
  </div>
  <div class="row justify-content-center">
    <div class="col-5">
      <h4>Top Reviewed</h4>
      <div></div>
    </div>
    <div class="col-5">
      <h4>Our Favorites</h4>
      <div></div>
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
.img-resize{
  max-height: 300px;
  max-width: 600px;
}
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
