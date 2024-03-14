<template>
    <div class="build-card d-flex align-items-center w-100">
        <div>
            <img class="cover-img" :src="casePic" alt="Case picture">
            <h3>{{ recentBuild.name }}</h3>
        </div>
        <div>
            <div class="specs text-center me-lg-4 ms-lg-4 ps-2 pe-2 pb-2 mt-1">
                <div class="sticky-top part-title">
                    <h5 class="fst-italic">Parts</h5>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Case</p>
                    <p class="fst-italic" v-if="recentBuild.pcCase && recentBuild.pcCase !== 'none'">{{
                recentBuild.pcCase
            }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">CPU</p>
                    <p class="fst-italic" v-if="recentBuild.pcCpu && recentBuild.pcCpu !== 'none'">{{ recentBuild.pcCpu
                        }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">GPU</p>
                    <p class="fst-italic" v-if="recentBuild.gpu && recentBuild.gpu !== 'none'">{{ recentBuild.gpu }}✅
                    </p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Ram</p>
                    <p class="fst-italic" v-if="recentBuild.ram && recentBuild.ram !== 'none'">{{ recentBuild.ram }}✅
                    </p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Motherboard</p>
                    <p class="fst-italic" v-if="recentBuild.motherBoard && recentBuild.motherBoard !== 'none'">{{
                recentBuild.motherBoard }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Storage</p>
                    <p class="fst-italic" v-if="recentBuild.pcStorage && recentBuild.pcStorage !== 'none'">{{
                recentBuild.pcStorage }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Power Supply</p>
                    <p class="fst-italic" v-if="recentBuild.powerSupply && recentBuild.powerSupply !== 'none'">{{
                recentBuild.powerSupply }}✅</p>
                    <p v-else>None🚫</p>
                </div>
            </div>
            <div class="d-flex justify-content-center mt-2">
                <button class="btn-build me-2">Add to Cart</button>
                <button  class="btn-build me-2">Save Build</button>
                <button  class="btn-build me-2">Edit Build</button>
                <button  class="btn-delete">Delete<i class="mdi mdi-delete"></i></button>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { PcBuild } from '../models/PcBuild';
export default {
    props: { recentBuild: { type: PcBuild, required: true } },
    setup(props) {
        return {
            casePic: computed(() => {
                if (props.recentBuild.casePicture == 'none' || props.recentBuild.casePicture == null) {
                    return 'https://rusutikaa.github.io/docs/developer.apple.com/library/archive/referencelibrary/GettingStarted/DevelopiOSAppsSwift/Art/defaultphoto_2x.png'
                } else { return props.recentBuild.casePicture }
            }),
        }
    }
};
</script>


<style lang="scss" scoped>
.build-card {
    outline: solid 1px purple;
    box-shadow: 3px 3px 3px 2px rgba(0, 0, 0, 0.219);
}

.specs {
    width: 380px;
    height: 170px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);

}

.part-title {
    background-color: rgba(255, 255, 255, 0.24);
    backdrop-filter: blur(5px);
    // padding-bottom: 3px;
}

.part-section {
    border-bottom: solid 1px purple;
    height: 28px;
    margin-top: 7px;
}

.cover-img {
    max-width: 140px;
    max-height: 100;
}

.btn-build {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px black;
    border-radius: 2px;
    color: white;
    background-color: purple;
}

.btn-build:hover {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px black;
    border-radius: 2px;
    color: white;
    background-color: rgb(146, 0, 146);
    cursor: pointer;
}

.btn-delete {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px red;
    background-color: red;
    color: white;
    border-radius: 2px;
}

.btn-delete:hover {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px red;
    border-radius: 2px;
    background-color: rgb(211, 0, 0);
    color: white;
    cursor: pointer;
}
</style>