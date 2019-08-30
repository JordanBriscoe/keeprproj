<template>
  <div class="CreateVault">
    <form @submit="addCreatedVault">
      <label for="name">Name:</label>
      <input type="text" name="name" placeholder="Name of Vault" v-model="newVault.name"><br>
      <label for="description">Description:</label>
      <input type="text" name="description" placeholder="Create a Description" v-model="newVault.description"><br>
      <button type="submit">Create</button>
    </form>
  </div>
</template>


<script>

  import router from '../router'

  export default {
    name: 'CreateVault',
    data() {
      return {
        newVault: {
          name: '',
          description: ''
        }
      }
    },
    computed: {},
    methods: {
      addCreatedVault() {
        this.$store.dispatch('addCreatedVault', this.newVault)
        router.push({ name: 'vaults' })
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>