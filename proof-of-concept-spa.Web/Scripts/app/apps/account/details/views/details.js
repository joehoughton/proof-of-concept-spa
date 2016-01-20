define([
  'jquery',
  'backbone',
  'Marionette',
  'hbs!../templates/details'
], function ($, Backbone, Marionette, DetailsTemplate) {
  'use strict';

  return Marionette.LayoutView.extend({
    initialize: function (options) {
      this.layout = options.layout;
    },

    className: 'details-view',

    template: DetailsTemplate,

    events: {
      'click #undo': 'undoChanges',
      'submit #details-form': 'saveChanges',
      'click #apply' : 'saveChanges'
    },

    undoChanges: function (e) {
      e.preventDefault();
      this.render();
    },

    saveChanges: function (e) {
      e.preventDefault();

      var name = $('#name').val();
      var email = $('#email').val();
      var emailAlerts = $('#email-alerts').prop('checked');
      var telephone = $('#telephone').val();
      var mobile = $('#mobile').val();
      var smsAlerts = $('#mobile-alerts').prop('checked');

      this.model.set({
        name: name,
        email: email,
        emailAlerts: emailAlerts,
        telephone: telephone,
        mobile: mobile,
        smsAlerts: smsAlerts
      });

      this.model.save();
    }
  });
});