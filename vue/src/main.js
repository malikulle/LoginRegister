import Vue from 'vue'
import App from './App.vue'
import {router} from "./router"
import store from "./store/store"
import axios from "axios"

const regeneratorRuntime = require("regenerator-runtime");

axios.defaults.baseURL="https://localhost:44323/api/"
const Api = axios.create({
	baseURL: axios.defaults.baseURL, // Build Location
	headers: {
		'Accept': 'application/json',
		'Content-Type': 'application/json'
	}
})
export default Api  
Vue.prototype.$http = axios


new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
