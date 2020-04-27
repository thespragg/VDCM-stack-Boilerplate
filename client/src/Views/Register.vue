<template>
  <div class="register-container">
    <div class="register-logo">Title</div>
    <div class="register-box">
      <h3>REGISTER</h3>

      <div class="register-input-outer" data-validate="Email is required">
        <input
          v-model="email"
          class="register-input"
          type="text"
          name="username"
          placeholder="Email"
        />
        <span class="register-anim"></span>
      </div>

      <div class="register-input-outer" data-validate="Your name is required">
        <input
          v-model="name"
          class="register-input"
          type="text"
          name="pass"
          placeholder="Full Name"
        />
        <span class="register-anim"></span>
      </div>

      <div class="register-input-outer" data-validate="Password is required">
        <input
          v-model="password"
          class="register-input"
          type="password"
          name="pass"
          placeholder="Password"
        />
        <span class="register-anim"></span>
      </div>

      <div class="register-input-outer" data-validate="Password is required">
        <input
          v-model="passwordVerify"
          class="register-input"
          type="password"
          name="pass"
          placeholder="Confirm Password"
        />
        <span class="register-anim"></span>
      </div>

      <div class="btn-container">
        <button class="register-btn" @click="register()">Register</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: "",
      password: "",
      passwordVerify: "",
      name: ""
    };
  },
  methods: {
    register() {
      if(this.email && this.password && this.passwordVerify && this.name){
        if(this.password === this.passwordVerify){
          this.$http.post("/Account/Register", {
            email: this.email,
            password: this.password,
            name: this.name
          }).then(res=>{
            //Add handling for res
            if(!res.data){
              console.log("Registration failed")
            }
            this.$router.push('/login');
          })
        } else{
          //handle passwords not matching
        }
      } else{
        //Handle empty field
      }
    }
  }
};
</script>

<style scoped>
.register-container {
  width: 100vw;
  height: 100vh;
  background-color: #003f5c;
  overflow: hidden;
  display: flex;
  justify-content: center;
  align-items: center;
}

.register-box {
  width: 50%;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.register-logo {
  font-size: 24pt;
  color: white;
  position: absolute;
  top: 50px;
  left: 50px;
}

.register-input {
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

h3 {
  font-size: 26pt;
  color: white;
}

.register-input-outer {
  width: 390px;
  background: #fff;
  border-radius: 10px;
  position: relative;
  height: 62px;
  display: flex;
  align-content: center;
  margin-top: 30px;
}

.register-anim {
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

.register-input:focus + .register-anim {
  visibility: visible;
  opacity: 1;
  -webkit-transform: scale(1);
  -moz-transform: scale(1);
  -ms-transform: scale(1);
  -o-transform: scale(1);
  transform: scale(1);
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

.register-btn {
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

.register-btn:hover {
  background-color: rgba(0, 0, 0, 0.5);
}
</style>