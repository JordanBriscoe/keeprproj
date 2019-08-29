<template>
  <div class="UsersVaults">
    <p>Here are your Vaults</p>


  </div>
</template>


<script>
  import router from '../router'

  export default {
    name: 'UsersVaults',
    data() {
      return {}
    },

    computed: {
      user() {
        return this.$store.state.user
      },
    },

    methods: {},

    components: {}
  }
</script>


<style scoped>

</style>