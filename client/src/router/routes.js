const Home = () => import('../Views/Home.vue');
const Login = () => import('../Views/Login');
const Components = () => import('../Views/Components');
const Colours = () => import('../Views/Colours');
const Register = () => import('../Views/Register')

export default [
    { name: "Home", path: '/', component: Home },
    { name: "Login", path: '/login', component: Login },
    { name: "Components", path: '/components', component: Components },
    { name: "Colours", path: '/colours', component: Colours },
    { name: "Register", path: '/register', component: Register },
    { name: 'Default', path: '*', redirect: '/' }
]