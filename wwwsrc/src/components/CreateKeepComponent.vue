<template>
  <div class="CreateKeep">
    <form @submit="addCreatedKeep">
      <label for="name">Name:</label>
      <input type="text" name="name" placeholder="Name of Keep" v-model="newKeep.name"><br>
      <label for="img">Image:</label>
      <input type="text" name="image" placeholder="Image URL" v-model="newKeep.img"><br>
      <label for="description">Description:</label>
      <input type="text" name="description" placeholder="Create a Description" v-model="newKeep.description"><br>
      <button type="submit">Create</button>
    </form>
  </div>
</template>


<script>

  import router from '../router'

  export default {
    name: 'CreateKeep',
    data() {
      return {
        newKeep: {
          name: '',
          img: '',
          description: ''
          // views: '',
          // shares: '',
          // keeps: ''
        }
      }
    },
    computed: {},
    methods: {
      addCreatedKeep() {
        this.$store.dispatch('addCreatedKeep', this.newKeep)
        router.push({ name: 'keeps' })
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>