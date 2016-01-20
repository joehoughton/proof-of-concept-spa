﻿define([
  'jquery',
  'backbone',
  'Marionette'
], function ($, Backbone, Marionette) {
  'use strict';

  return Marionette.Object.extend({
    initialize: function () {
      this.logout();
    },

    logout: function () {
      // delete cookie holding bearer token
      $.removeCookie("accessToken");
      // redirect to login view
      Backbone.history.navigate('login', {trigger: true});
    }
  });
});