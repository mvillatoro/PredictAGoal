'use strict';
angular.module('app.services')
    .factory('League', function ($http, Server, $cookieStore) {
        return {
            getAvailableLeagues: function (success, error) {
                $http
                    .get(
                        Server.get() + '/leagues/available', {
                            headers: { 'Authorization': $cookieStore.get('access_token') }
                        })
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            getSuscribedLeagues: function (success, error) {
                $http.get(Server.get() + '/leagues/suscribed', {
                    headers: { 'Authorization': $cookieStore.get('access_token') }

                })
                    .success(function (response) {
                        success(response);
                    }).error(error);
            },

            //ADD NEW LEAGUE
            AddLeague: function (LeaguesModel, success, error) {
                $http.post(Server.get() + '/leagues/addLeague', LeaguesModel, {
                    headers: { 'Authorization': $cookieStore.get('access_token') }
                })
                    .success(function (response) {
                        success(response);
                    }).error(error);
            },

            //MODIFY LEAGUE
            UpdateLeague: function (LeaguesModel, success, error) {
                $http.post(Server.get() + '/leagues/updateLeague', LeaguesModel, {
                    headers: { 'Authorization': $cookieStore.get('access_token') }

                })
                    .success(function (response) {
                        success(response);
                    }).error(error);
            },

            //DELETE LEAGUE
            DeleteLeague: function (Id, success, error) {
                $http.post(Server.get() + '/deleteLeague/' + Id, {
                    headers: { 'Authorization': $cookieStore.get('access_token') }

                })
                .success(function (response) {
                    success(response);
                }).error(error);
            }

        };
    });