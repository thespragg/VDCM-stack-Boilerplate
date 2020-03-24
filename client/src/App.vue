<template>
  <div id="app">
    <div v-if="$mq == 'lg'">
      <Sidebar v-on:visible="reset()" v-on:sidebar-toggled="SidebarToggled()" />
      <DetailBar :class="changeWidth" class="shadow" />
    </div>
     <div v-if="$mq == 'sm'">
        <MobileMenu class="shadow" />
      </div>
    <RouterView class="main-container" :class="$mq == 'lg' ? changeWidth : ''"></RouterView>
  </div>
</template>

<script>
import Sidebar from "@/components/Sidebar";
import DetailBar from "@/components/DetailBar";
import MobileMenu from "@/components/MobileMenu";

export default {
  name: "App",
  components: {
    Sidebar,
    DetailBar,
    MobileMenu
  },
  data() {
    return {
      sidebarPinned: false,
      size: this.$mq,
    };
  },
  computed: {
    changeWidth() {
      return this.sidebarPinned ? "pinned-sidebar" : "unpinned-sidebar";
    }
  },
  methods: {
    SidebarToggled() {
      this.sidebarPinned = !this.sidebarPinned;
    },
    reset() {
      this.sidebarPinned = false;
    }
  }
};
</script>

<style>
html,
body {
  background-color: #efedec;
  margin: 0;
  padding: 0;
}

a{
  text-decoration: none;
}
article,
aside,
details,
figcaption,
figure,
footer,
header,
hgroup,
menu,
nav,
section {
  display: block;
}
input{
  border:none;
}
button {
  border: none;
}
body {
  line-height: 1;
}
ol,
ul {
  list-style: none;
}
blockquote,
q {
  quotes: none;
}
blockquote:before,
blockquote:after,
q:before,
q:after {
  content: "";
  content: none;
}
table {
  border-collapse: collapse;
  border-spacing: 0;
}

#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  font-family: "Source Sans Pro", sans-serif;
}

.shadow {
  -webkit-box-shadow: 0px 2px 6px 0px rgba(0, 0, 0, 0.25);
  -moz-box-shadow: 0px 2px 6px 0px rgba(0, 0, 0, 0.25);
  box-shadow: 0px 2px 6px 0px rgba(0, 0, 0, 0.25);
}

.pinned-sidebar {
  margin-left: 70px;
  width: calc(100vw - 70px);
}

.unpinned-sidebar {
  margin-left: 260px;
  width: calc(100vw - 260px);
}

.main-container{
  padding:10px;
}
</style>
