<template>
  <div class="UsersKeeps">
    <div class="row" v-for="keep in userkeeps">
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
                <button @click="deleteKeep(keep.id)">Delete</button>
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
    name: 'UsersKeeps',
    data() {
      return {}
    },
    computed: {
      userkeeps() {
        return this.$store.state.userkeeps
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch('deleteKeep', id)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>