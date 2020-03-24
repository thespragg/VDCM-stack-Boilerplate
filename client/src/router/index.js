import Vue from 'vue';
import VueRouter from 'vue-router';
import routes from './routes';
import jwt from 'jsonwebtoken';

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes,
});

router.beforeEach((to, from, next) => {
  const publicPages = ['/login', '/register'];
  const authRequired = !publicPages.includes(to.path);
  const user = localStorage.token;

  if (authRequired && !user) {
    return next('/login');
  }
  
  if (user) {
    let token = jwt.decode(user);
    if(Date.now() > token.exp * 1000){
      return next('/login')
    }
  }

  next();
})

export default router;