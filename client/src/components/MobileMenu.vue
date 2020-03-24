<template>
  <div class="detail-container">
    <div class="unpinned sidebar-menu" v-if="menuShowing">
      <div class="logo">
        <h3 class="logo-text">CONTRAKTER</h3>
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

        <router-link :to="{name:'Invoices'}" class="link-row">
          <div class="selected"></div>
          <img src="@/assets/icons/componentsIcon.png" class="icon" />
          <h4>Components</h4>
        </router-link>

        <router-link :to="{name: 'Home'}" class="link-row">
          <div class="selected"></div>
          <img src="@/assets/icons/coloursIcon.png" class="icon" />
          <h4>Colour Palettes</h4>
        </router-link>
      </div>
      <span class="side-padding"></span>
      <div class="support-links">
        <router-link :to="{name:'Support'}" class="link-row bottom">
          <div class="selected"></div>
          <img src="@/assets/icons/supportIcon.png" class="icon" />
          <h4>Help</h4>
        </router-link>

        <router-link :to="{name: 'Contact'}" class="link-row bottom">
          <div class="selected"></div>
          <img src="@/assets/icons/contactIcon.png" class="icon" />
          <h4>Contact</h4>
        </router-link>
      </div>
    </div>
    <div class="detail-container">
      <div class="logo">
        <div class="hamburger-icon" @click="toggleSidebar()">
          <img src="@/assets/icons/hamburger.png" />
        </div>
      </div>
      <div class="search">
        <img src="@/assets/icons/search.png" class="search-icon" />
        <input
          type="text"
          class="search-box"
          v-model="currString"
          placeholder="Search for a company, project, or invoice"
        />
      </div>
      <div class="notifications">
        <img src="@/assets/icons/notifications.png" />
      </div>
    </div>
    <div class="search-results" v-if="searchResults.length != 0">
      <div v-for="(result,index) in searchResults" :key="result.id">
        <div class="bg-white search-row" :class="index == searchResults.length -1 ? 'shadow' : ''">
          <p>{{result.item[0]}}</p>
          <span class="w-16"></span>
          <p
            class="pill"
            :class="[(result.item[1] == 'project' ? 'bg-purple-700' : ''),(result.item[1] == 'company' ? 'bg-blue-700' : ''),(result.item[1] == 'invoice' ? 'bg-green-700' : '')]"
          >{{result.item[1]}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      currString: "",
      menuShowing: false
    };
  },
  computed: {
    searchResults() {
      if (this.currString) {
        let data = this.$store.getters.search;
        let count = data.length;
        let c = this.currString;
        let res = [];
        for (let i = 0; i < count; i++) {
          if (data[i][0].toLowerCase().includes(c.toLowerCase())) {
            res.push({ id: i, item: data[i] });
          }
        }
        return res;
      } else {
        return [];
      }
    }
  },
  methods:{
      toggleSidebar(){
          this.menuShowing = !this.menuShowing;
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
  }
  
  .unpinned .support-links {
    display: flex;
    margin-bottom: 3px;
  }
  
  .support-links .router-link-active .selected{
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
  
  .router-link-active {
    background-color: #02354b !important;
  }
  
  .router-link-active .icon {
    filter: brightness(150%);
  }
  
  .pinned .router-link-active .link-icon {
    margin-left: 20px !important;
  }
  
  .router-link-active .selected {
    display: block;
    background-color: #1d8dbf;
    height: 100%;
    width: 5px;
  }
  
  .unpinned .router-link-active .icon{
    margin-left: 20px;
  }

.detail-container {
  height: 70px;
  width:100%;
  background-color: white;
  display: flex;
  align-items: end;
}

.search-results{
    position: absolute;
    width:100%;
    margin-top:70px;
    z-index: 3;
}

.search {
  width: 100%;
  display: flex;
  align-items: center;
  height: 100%;
  margin-left: 30px;
}

.search-icon {
  width: 16px;
  height: 16px;
}

.notifications {
  height: 100%;
  width: 40px;
  display: flex;
  align-items: center;
  margin-left: 20px;
}

.notifications img {
  width: 16px;
  height: 16px;
}

.logo {
  height: 70px;
  background-color: #003f5c;
  display: flex;
  justify-self: end;
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
.dropdown {
  width: 11px;
  height: 7px;
}

input:focus {
  outline: none;
}

.search-box {
  width: 100%;
  color: #4d4f5c;
  font-size: 13px;
  margin-left: 5px;
}

.search-row {
  padding-left: 35px;
  height: 50px;
  display: flex;
  align-items: center;
  border-bottom: 1px solid rgba(0, 0, 0, 0.15);
}

.search-row:hover {
  @apply bg-blue-100;
}
.pill {
  padding: 1px 20px;
  border-radius: 16px;
  color: white;
  font-size: 13px;
}
</style>