<template>
  <div class="login-container">
    <div class="login-logo">Title</div>
    <div class="login-box">
      <h3>LOGIN</h3>

      <div class="login-input-outer" data-validate="Username is required">
        <input
          v-model="username"
          class="login-input"
          type="text"
          name="username"
          placeholder="Username"
        />
        <span class="input-anim"></span>
      </div>

      <div class="login-input-outer" data-validate="Password is required">
        <input
          v-model="password"
          class="login-input"
          type="password"
          name="pass"
          placeholder="Password"
        />
        <span class="input-anim"></span>
      </div>

      <div class="options">
        <div>
          <input id="ckb1" class="rmb-check" type="checkbox" name="remember-me" />
          <label for="ckb1" class="lbl-check">Remember me</label>
        </div>

        <div class="forgot">
          <a href="#">Forgot?</a>
        </div>
      </div>

      <div class="btn-container">
        <button class="login-btn" @click="login()">Login</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      username: "",
      password: ""
    };
  },
  methods: {
    login() {
      if (this.username && this.password) {
        let apiCall = this.$store.getters.api + "/Account/Login";
        this.$http
          .post(apiCall, { username: this.username, password: this.password })
          .then(res => {
            //create proper response handler
            if (res.data) {
              this.$emit("authorised");
            }
          });
      }
    }
  }
};
</script>

<style scoped>
.login-container {
  width: 100vw;
  height: 100vh;
  background-color: #003f5c;
  overflow: hidden;
  display: flex;
  justify-content: center;
  align-items: center;
}

.login-box {
  width: 50%;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.login-logo {
  font-size: 24pt;
  color: white;
  position: absolute;
  top: 50px;
  left: 50px;
}

h3 {
  font-size: 26pt;
  color: white;
}

.login-input-outer {
  width: 390px;
  background: #fff;
  border-radius: 10px;
  position: relative;
  height: 62px;
  display: flex;
  align-content: center;
  margin-top: 30px;
}

.login-input {
  color: #403866;
  line-height: 1.2;
  font-size: 18px;
  outline: none;
  width: 100%;
  background: transparent;
  height: 62px;
  padding: 0 20px 0 38px;
  border: none;
}

.input-anim {
  position: absolute;
  display: block;
  width: calc(100% + 2px);
  height: calc(100% + 2px);
  top: -1px;
  left: -1px;
  pointer-events: none;
  border: 1px solid #827ffe;
  border-radius: 3px;

  visibility: hidden;
  opacity: 0;

  -webkit-transition: all 0.4s;
  -o-transition: all 0.4s;
  -moz-transition: all 0.4s;
  transition: all 0.4s;

  -webkit-transform: scaleX(1.1) scaleY(1.3);
  -moz-transform: scaleX(1.1) scaleY(1.3);
  -ms-transform: scaleX(1.1) scaleY(1.3);
  -o-transform: scaleX(1.1) scaleY(1.3);
  transform: scaleX(1.1) scaleY(1.3);
}

.login-input:focus + .input-anim {
  visibility: visible;
  opacity: 1;
  -webkit-transform: scale(1);
  -moz-transform: scale(1);
  -ms-transform: scale(1);
  -o-transform: scale(1);
  transform: scale(1);
}

.rmb-check {
  display: none;
}

.lbl-check {
  font-size: 16px;
  color: white;
  line-height: 1.2;

  display: block;
  position: relative;
  padding-left: 26px;
  cursor: pointer;
}

.lbl-check::before {
  content: "\f00c";
  font-family: FontAwesome;
  font-size: 13px;
  color: transparent;

  display: -webkit-box;
  display: -webkit-flex;
  display: -moz-box;
  display: -ms-flexbox;
  display: flex;
  justify-content: center;
  align-items: center;
  position: absolute;
  width: 18px;
  height: 18px;
  border-radius: 3px;
  background: #fff;
  left: 0;
  top: 50%;
  -webkit-transform: translateY(-50%);
  -moz-transform: translateY(-50%);
  -ms-transform: translateY(-50%);
  -o-transform: translateY(-50%);
  transform: translateY(-50%);
}

.rmb-check:checked + .lbl-check::before {
  color: #827ffe;
}

.options {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 390px;
  margin-top: 20px;
}

.forgot a {
  color: white;
  text-decoration: none;
}

.btn-container {
  width: 100%;
  display: -webkit-box;
  display: -webkit-flex;
  display: -moz-box;
  display: -ms-flexbox;
  display: flex;
  flex-wrap: wrap;
  width: 390px;
  margin-top: 20px;
}

.login-btn {
  font-size: 16px;
  color: #fff;
  line-height: 1.2;
  text-transform: uppercase;

  display: -webkit-box;
  display: -webkit-flex;
  display: -moz-box;
  display: -ms-flexbox;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 0 20px;
  width: 100%;
  height: 62px;
  background-color: #1683b5;
  border-radius: 3px;

  -webkit-transition: all 0.4s;
  -o-transition: all 0.4s;
  -moz-transition: all 0.4s;
  transition: all 0.4s;
}

.login-btn:hover {
  background-color: rgba(0, 0, 0, 0.5);
}
</style>