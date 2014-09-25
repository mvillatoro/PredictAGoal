'use strict';
angular.module('app.controllers', [])   

    .controller('AdminSettingsCtrl', [
        '$scope', '$location', '$window', 'League', 'Teams', function ($scope, $location, $window, League, Teams) {
            $scope.$root.title = 'AngularJS SPA | Admin Settings';

            $scope.availableLeagues = [];
            $scope.suscribedLeages = [];

            //Muestra el modo de edicion de liga
            $scope.AddLiga = function () {
                if ($scope.ShowEdit1 === true) {
                    $scope.ShowEdit1 = false;
                } else {
                    $scope.ShowEdit1 = true;
                }
            };

            //Muestra el modo de edicion de team
            $scope.AddTeam = function () {
                if ($scope.ShowEdit2 === true) {
                    $scope.ShowEdit2 = false;
                } else {
                    $scope.ShowEdit2 = true;
                }
            };
            //Crear Liga
            $scope.AddLeague = function () {
                League.AddLeague($scope.league, function (response) {

                    $scope.AddLiga();
                    $scope.loadLeagues();
                    alert('Success');

                }, function (error) {
                    alert('Adding Failed');
                });
                $scope.league = {};
            };

            //Modif Liga
            $scope.UpdateLeague = function () {
                League.UpdateLeague($scope.league, function (response) {

                    $scope.ModifyingTrigger();
                    alert('Success');

                }, function (error) {
                    alert('Modify Failed');
                });
                $scope.league = {};
            };

            //DELETE LEAGUE
            $scope.Deleter = function (Id) {
                League.DeleteLeague(Id, function (response) {

                    //  alert('Success');

                }, function (error) {
                    //   alert('Delete Failed');
                });
                $scope.league = {};
            };


            $scope.MyDeleter = function (myleague) {
                $scope.league = myleague;
                $scope.Deleter(myleague.Id);
                $scope.league = {};
            };

            $scope.$on('$viewContentLoaded', function () {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });

            $scope.loadLeagues = function () {
                League.getAvailableLeagues(function (availableLeagues) {
                    $scope.availableLeagues = availableLeagues;
                }, function (error) {
                    alert('error loading available leagues');
                });

                League.getSuscribedLeagues(function (suscribedLeagues) {
                    $scope.suscribedLeages = suscribedLeagues;
                }, function (error) {
                    alert('error loading available leagues');
                });


            };

            $scope.$on('$viewContentLoaded', function () {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });

            $scope.availableTeams= [];

            $scope.loadTeams = function () {
                Team.getTeams(function (availableTeams) {
                    $scope.availableTeams = availableTeams;
                }, function (error) {
                    alert('error loading available leagues');
                });
            };

        }
    ]);