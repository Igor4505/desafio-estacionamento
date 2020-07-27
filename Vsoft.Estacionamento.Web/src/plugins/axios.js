"use strict";

import Vue from 'vue';
import axios from "axios";

Vue.use({
  install(Vue) {
    Vue.prototype.$http = axios.create({
      baseURL: 'https://localhost:44314/api/'
    })
  }
})

export default Plugin;
