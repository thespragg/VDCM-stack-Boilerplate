const Home = () => import('../Views/Home.vue');
const Login = () => import('../Views/Login');

export default [
    { name: "Home", path: '/', component: Home},
    { name: "Login", path: '/login', component:Login},

    { name:'Default', path: '*', redirect: '/'}
]