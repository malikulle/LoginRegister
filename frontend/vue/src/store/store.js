import Vue from "vue";
import vuex from "vuex";
import axios from "axios";
import { router } from "../router";

Vue.use(vuex);

const store = new vuex.Store({
  state: {
    token: null
  },
  mutations: {
    setToken(state, token) {
      state.token = token;
    },
    clearToken(state) {
      state.token = null;
    }
  },
  actions: {
    initAuth({ commit, dispatch }) {
      let token = localStorage.getItem("token");
      if (token) {
        let expirationDate = localStorage.getItem("expiresionDate");
        let time = new Date().getTime();

        if (time >= expirationDate) {
          dispatch("logout");
        } else {
          commit("setToken", token);
          let timeSecond = +expirationDate -time
          dispatch("setTimeOutTimer",timeSecond);
          router.push("/");
        }
      } else {
        router.push("/login");
        return false;
      }
    },
    login({ commit, dispatch, state }, authData) {
      if (authData.isUser) {
        const { isUser, ...user } = authData;
        return axios
          .post("auth/login", user)
          .then(result => {
            let expiration = new Date(result.data.expiration);
            let diff = expiration - Date.now();
            let diffMins =
              Math.round(((diff % 86400000) % 3600000) / 60000) * 60 * 1000; //*1000 yaparsak dk olur
            commit("setToken", result.data.token);
            localStorage.setItem("token", result.data.token);
            localStorage.setItem(
              "expiresionDate",
              new Date().getTime() + +diffMins
            );
            dispatch("setTimeOutTimer", +diffMins);
          })
          .catch(err => {
            console.log(err);
          });
      } else {
        const { isUser, ...user } = authData;
        axios
          .post("auth/register", user)
          .then(result => {
            console.log(result);
            let expiration = new Date(result.data.expiration);
            let diff = expiration - Date.now();
            let diffMins =
              Math.round(((diff % 86400000) % 3600000) / 60000) * 60; // second
            commit("setToken".result.data.token);
          })
          .catch(err => {
            console.log(err);
          });
      }
    },
    logout({ commit, dispatch, state }) {
      commit("clearToken");
      localStorage.removeItem("token");
      localStorage.removeItem("expiresionDate");
      router.replace("/login");
    },
    setTimeOutTimer({ dispatch }, expiresIn) {
      setTimeout(() => {
        dispatch("logout");
      }, expiresIn);
    }
  },
  getters: {
    isAuthenticated(state) {
      return state.token !== null;
    }
  }
});

export default store;
