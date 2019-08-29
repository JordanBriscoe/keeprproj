<template>
  <div class="Vaults">
    <div class="container">
      <div class="row">
        <div class="col-12">
          <h2>Welcome {{user.username}} to your Vaults!!</h2>
        </div>
      </div>
      <div>
        <vaults></vaults>
        <button @click="createAVault">Create Vault</button>
      </div>

    </div>


  </div>
</template>


<script>

  import router from '../router'
  import vaults from '../components/VaultsComponent.vue'

  export default {
    name: 'Vaults',
    data() {
      return {}
    },

    mounted() {
      this.$store.dispatch('getVaults')
    },

    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      createAVault() {
        router.push({ name: "CreateVault" })
      }
    },
    components: {
      vaults
    }
  }
</script>


<style scoped>

</style>