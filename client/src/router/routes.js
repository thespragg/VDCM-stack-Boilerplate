const Home = () => import('../Views/Home.vue');
const Login = () => import('../Views/Login');
const Components = () => import('../Views/Components');
const Colours = () => import('../Views/Colours');

export default [
    { name: "Home", path: '/', component: Home},
    { name: "Login", path: '/login', component:Login},
    { name: "Components", path: '/components', component: Components},
    { name: "Colours", path: '/colours', component: Colours},
    { name:'Default', path: '*', redirect: '/'}
]