define([
  'backbone'
], function (Backbone) {
  'use strict';

  return Backbone.Model.extend({
    initialize: function () {
      this.on('change', function () {
        Backbone.Radio.channel('alert').trigger('success', 'Your account details have been saved.');
      });
    },

    urlRoot: '/api/users/current/details',

    validation: {
      name: [{
        required: true,
        minLength: 5
      }, {
        pattern: /^[a-zA-Z\s]+$/,
        msg: 'Name can only contain alphabet characters.'
      }],

      email: [{
        required: true,
        msg: 'Email address can not be blank.'
      }, {
        pattern: 'email',
        msg: 'Please enter a valid email address.'
      }],

      telephone: {
        required: true,
        pattern: 'digits',
        length: 11
      },

      mobile: {
        required: true,
        pattern: 'digits',
        length: 11
      }
    }
  });
});