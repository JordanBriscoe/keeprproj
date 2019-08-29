<template>
  <div class="Keep">
    <div class="row" v-for="keep in keeps">
      <div class="col-3">
        <div class="card mb-3">
          <div class="row no-gutters">
            <div class="col-md-8">
              <div class="card-body">
                <h5>{{keep.name}}</h5>
                <div class="col-md-4">
                  <img src="keep.img" class="card-img" alt="...">
                </div>
                <p>{{keep.description}}</p>
                <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'Keep',
    data() {
      return {}
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>