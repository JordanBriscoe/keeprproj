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
        <userkeeps></userkeeps>
        <button @click="createAVault">Create Vault</button> <br>
        <button @click="createAKeep">Create Keep</button> <br>
        <button @click="goHome">User Page</button>
      </div>
    </div>
  </div>
</template>


<script>

  import router from '../router'
  import vaults from '../components/VaultsComponent.vue'
  import userkeeps from '../components/UserKeepsComponent.vue'

  export default {
    name: 'Vaults',
    data() {
      return {}
    },

    mounted() {
      this.$store.dispatch('getVaults');
      this.$store.dispatch('getUsersKeeps')
    },

    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      createAVault() {
        router.push({ name: "CreateVault" })
      },
      createAKeep() {
        router.push({ name: "CreateKeep" })
      },
      goHome() {
        router.push({ name: "home" })
      }
    },

    components: {
      vaults,
      userkeeps
    }
  }
</script>


<style scoped>

</style>