<template>
  <div class="container">
    <div class="body shadow">
      <h1>
        <u>Welcome to the Vue.js, Dotnet Core, MongoDb with authentication boilerplate</u>
      </h1>
      <h2>Goal</h2>
      <p>This boilerplate was made to make setting up a new vue.js with a c# web api as the backend much simpler.</p>
      <p>Some things have been pre-configured for convenience such as JWT authentication and user logins (local only for now but google/facebook logins coming soon)</p>
    </div>

    <div class="changelog shadow">
      <div class="version">
          <h2>Version 0.8</h2>
          <ul>
              <li>
                  Added homepage
              </li>
          </ul>
      </div>
      <div class="version">
          <h2>Version 0.7</h2>
          <ul>
              <li>
                  Added permission based routing
              </li>
          </ul>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.container {
  text-align: left;
}

.body {
  background-color: white;
  padding: 20px;
}

.changelog {
  margin-top: 20px;
  background-color:white;
  padding:15px;
}
</style>