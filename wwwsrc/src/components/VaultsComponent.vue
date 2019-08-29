<template>
  <div class="Vault">
    <div class="row" v-for="vault in vaults">
      <div class="col-4">
        <h2>{{vault.name}}</h2>
        <h4>{{vault.description}}</h4>
        <button @click="deleteVault(vault.id)">Delete</button>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'Vault',
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteVault(id) {
        this.$store.dispatch('deleteVault', id)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>