define([
  'jquery',
  'backbone',
  'backbone.radio',
  'Marionette',
  'hbs!../templates/navigation'
], function ($, Backbone, Radio, Marionette, navigationTemplate) {
  'use strict';

  return Marionette.ItemView.extend({
    template: navigationTemplate,

    tagName: 'ul',

    className: 'nav navbar-nav',

    events: {
      'click #account-nav': 'navigateAccount',
      'click #bookings-nav': 'navigateBookings'
    },

    navigateAccount: function (e) {
      e.preventDefault();
      Backbone.history.navigate('account/organisation', {trigger: true});
    },

    navigateBookings: function (e) {
      e.preventDefault();
      Backbone.history.navigate('bookings', {trigger: true});
    }

  });
});