'use strict';
angular.module('app.services')
    .factory('Teams', function ($http, Server, $cookieStore) {
        return {
            getTeams: function (success, error) {
                $http
                    .get(
                        Server.get() + 'teams/available', {
                            headers: { 'Authorization': $cookieStore.get('access_token') }
                        })
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }
        };
    });