<template>
  <div id="app">
    <div v-if="authenticated">
      <RouterView></RouterView>
    </div>
    <div v-else>
      <Login v-on:authorised="authenticated = true"/>
    </div>
  </div>
</template>

<script>
const Login = () => import("@/Views/Login");

export default {
  name: 'App',
  components:{
    Login
  },
  data() {
    return {
      authenticated: false
    };
  }
}
</script>

<style>
html,
body {
  background-color: #efedec;
  margin: 0;
  padding: 0;
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

button{
  border:none;
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
  font-family: 'Source Sans Pro', sans-serif;
}
</style>
