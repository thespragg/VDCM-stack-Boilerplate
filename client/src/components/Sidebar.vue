<template>
  <div>
    <div class="sidebar-menu pinned" v-if="isPinned">
      <div class="logo" @click="toggleSidebar()">
        <div class="hamburger-icon">
          <img src="@/assets/icons/hamburger.png" />
        </div>
      </div>
      <div class="nav-links">
        <router-link :to="{name:'Home'}" class="link-row">
          <div class="selected"></div>
          <div class="link-icon">
            <img src="@/assets/icons/homeIcon.png" class="icon" />
          </div>
        </router-link>
        <router-link :to="{name:'Components'}" class="link-row">
          <div class="selected"></div>
          <div class="link-icon">
            <img src="@/assets/icons/componentsIcon.png" class="icon" />
          </div>
        </router-link>
        <router-link :to="{name: 'Colours'}" class="link-row">
          <div class="selected"></div>
          <div class="link-icon">
            <img src="@/assets/icons/coloursIcon.png" class="icon" />
          </div>
        </router-link>
      </div>
      <span class="side-padding"></span>
      <div class="bottom-links">
        <router-link :to="{name:'Support'}" class="link-row">
          <div class="selected"></div>
          <div class="link-icon">
            <img src="@/assets/icons/supportIcon.png" class="icon" />
          </div>
        </router-link>
        <router-link :to="{name: 'Contact'}" class="link-row">
          <div class="selected"></div>
          <div class="link-icon">
            <img src="@/assets/icons/contactIcon.png" class="icon" />
          </div>
        </router-link>
      </div>
    </div>
    <div class="sidebar-menu unpinned" v-if="!isPinned">
      <div class="logo">
        <h3 class="logo-text">BOILERPLATE</h3>
        <div class="hamburger-icon" @click="toggleSidebar()">
          <img src="@/assets/icons/hamburger.png" />
        </div>
      </div>
      <div class="nav-links">
        <router-link :to="{name:'Home'}" class="link-row">
          <div class="selected"></div>
          <img src="@/assets/icons/homeIcon.png" class="icon" />
          <h4>Home</h4>
        </router-link>

        <router-link :to="{name:'Components'}" class="link-row">
          <div class="selected"></div>
          <img src="@/assets/icons/componentsIcon.png" class="icon" />
          <h4>Components</h4>
        </router-link>

        <router-link :to="{name: 'Colours'}" class="link-row">
          <div class="selected"></div>
          <img src="@/assets/icons/coloursIcon.png" class="icon" />
          <h4>Colour Palettes</h4>
        </router-link>
      </div>
      <span class="side-padding"></span>
      <div class="support-links">
        <router-link :to="{name: '/support'}" class="link-row bottom">
          <div class="selected"></div>
          <img src="@/assets/icons/supportIcon.png" class="icon" />
          <h4>Help</h4>
        </router-link>

        <router-link :to="{name: '/contact'}" class="link-row bottom">
          <div class="selected"></div>
          <img src="@/assets/icons/contactIcon.png" class="icon" />
          <h4>Contact</h4>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Sidebar",
  data() {
    return {
      isPinned: false
    };
  },
  created(){
    this.$emit('visible')
  },
  methods: {
    toggleSidebar() {
      this.isPinned = !this.isPinned;
      this.$emit('sidebar-toggled')
    }
  }
};
</script>

<style scoped>
.sidebar-menu {
    position: fixed;
    height: 100vh;
    background-color: #003f5c;
    display: flex;
    flex-direction: column;
    color: white;
    z-index: 5;
  }
  .unpinned {
    width: 260px;
  }
  
  .pinned {
    width: 70px;
  }
  
  .logo {
    height: 70px;
    background-color: rgba(0, 0, 0, 0.1);
    display: flex;
  }
  
  .logo-text{
    margin:0;
  }

  .hamburger-icon {
    width: 70px;
    background-color: rgba(0, 0, 0, 0.1);
    display: flex;
    align-items: center;
    justify-content: center;
  }
  
  .hamburger-icon img {
    width: 21px;
    height: 14px;
  }
  
  .link-row {
    margin-top: 6px;
    height: 53px;
    display: flex;
    align-items: center;
  }
  
  .unpinned .link-row {
    width: 260px;
    background-color: #013b55;
  }
  
  .pinned .link-row .link-icon {
    display: flex;
    margin-left: 25px;
    align-items: center;
    height: 53px;
  }
  
  .icon {
    width: 16px;
    height: 16px;
  }
  
  .unpinned .link-row .icon {
    margin-left: 25px;
  }
  
  .selected {
    display: none;
  }
  
  .unpinned .logo-text {
    width: 174px;
    height: 100%;
    display: flex;
    align-items: center;
    margin-left: 20px;
    font-weight: 700;
    letter-spacing: 3px;
  }
  
  .unpinned .link-row h4 {
    margin-left: 14px;
    color:white;
  }
  
  .unpinned .support-links {
    display: flex;
    margin-bottom: 3px;
  }
  
  .support-links .router-link-exact-active .selected{
    display:none;
  }
  
  
  .unpinned .bottom {
    width: 125.5px !important;
    justify-content: center;
    margin-left: 3px;
  }
  
  .unpinned .bottom .icon {
    margin-left: 0 !important;
  }
  
  .side-padding {
    flex-grow: 1;
  }
  
  .router-link-exact-active {
    background-color: #02354b !important;
  }
  
  .router-link-exact-active .icon {
    filter: brightness(150%);
  }
  
  .pinned .router-link-exact-active .link-icon {
    margin-left: 20px !important;
  }
  
  .router-link-exact-active .selected {
    display: block;
    background-color: #1d8dbf;
    height: 100%;
    width: 5px;
  }
  
  .unpinned .router-link-exact-active .icon{
    margin-left: 20px;
  }
</style>