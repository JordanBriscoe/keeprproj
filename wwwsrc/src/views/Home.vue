<template>
  <div class="home">
    <div class="container">
      <div class="row">
        <h1>Welcome {{user.username}}</h1>
        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
        <button @click="vaults">User's Vaults</button>
        <keeps></keeps>
      </div>
    </div>
  </div>
</template>

<script>

  import router from '../router'
  import keeps from '../components/KeepsComponent.vue'
  import vaults from '../components/VaultsComponent.vue'

  export default {
    name: "home",

    computed: {
      user() {
        return this.$store.state.user;
      }
    },

    mounted() {
      this.$store.dispatch('getKeeps')
    },

    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      vaults() {
        router.push({ name: "vaults" });
      }
    },

    components: {
      keeps
    },
  };
</script>