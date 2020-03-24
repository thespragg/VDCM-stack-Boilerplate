<template>
  <div class="mainBar">
    <div class="detail-container">
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
        <div class="v-bar"></div>
      </div>
      <div class="profile">
        <img src="@/assets/icons/headshot.jpg" class="profile-picture" />
        <h5>Thespragg</h5>
        <img src="@/assets/icons/dropdown.png" class="dropdown" @click="toggleProfileDropdown()" />
      </div>
      <div class="profile-dropdown shadow" v-if="showProfileDropdown">
        <div class="profile-row">
          <img src="@/assets/icons/logout.png"/>
          <p>Logout</p>
        </div>
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
      showProfileDropdown: false
    };
  },
  mounted() {
    let self = this;
    window.addEventListener("click", function(e) {
      if (self.showProfileDropdown && e.target.className != "dropdown") {
        self.showProfileDropdown = false;
      }
    });
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
  methods: {
    toggleProfileDropdown() {
      this.showProfileDropdown = !this.showProfileDropdown;
    }
  }
};
</script>

<style scoped>
.detail-container {
  height: 70px;
  background-color: white;
  display: flex;
  align-items: center;
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
  display: flex;
  align-items: center;
}

.notifications img {
  width: 16px;
  height: 16px;
}

.search-results {
  position: absolute;
  width: 100%;
  z-index: 3;
}
.v-bar {
  width: 3px;
  height: 23px;
  margin-left: 10px;
  background-color: #ebebf2;
}

.profile {
  width: 250px;
  margin: 0 20px;
  display: flex;
  height: 100%;
  align-items: center;
  justify-content: space-between;
}

.profile h5 {
  margin: 0 5px;
}
.profile-picture {
  width: 38px;
  height: 38px;
  border-radius: 50%;
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

.profile-dropdown {
  background-color: white;
  width: 250px;
  position: absolute;
  right: 0;
  top: 70px;
}

.profile-row{
  padding:10px;
  display:flex;
  align-items: center;
  justify-content: center;
}

.profile-row img{
  margin-right:20px;
}
</style>