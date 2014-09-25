'use strict';
angular.module('app.controllers', [])   

    .controller('AdminSettingsCtrl', [
        '$scope', '$location', '$window', 'League', function ($scope, $location, $window, League) {
            $scope.$root.title = 'AngularJS SPA | Admin Settings';


            $scope.$on('$viewContentLoaded', function () {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });

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
            $scope.AddEquipo = function () {
                if ($scope.ShowEdit2 === true) {
                    $scope.ShowEdit2 = false;
                } else {
                    $scope.ShowEdit2 = true;
                }
            };

            //Muestra el modo de edicion de partido
            $scope.AddPartido = function () {
                if ($scope.ShowEdit3 === true) {
                    $scope.ShowEdit3 = false;
                } else {
                    $scope.ShowEdit3 = true;
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

            $scope.availableTeams= [];

            $scope.loadTeams = function () {
                League.getTeams(function (availableTeams) {
                    $scope.availableTeams = availableTeams;
                }, function (error) {
                    alert('error loading available teams');
                });
            };

            //Crear Team
            $scope.AddTeam = function () {
                League.AddTeam($scope.team, function (response) {

                    $scope.AddEquipo();
                    $scope.loadTeams();
                    alert('Success');

                }, function (error) {
                    alert('Adding Failed');
                });
                $scope.team = {};
            };


            //########################################################################

            $scope.availableMatches = [];

            $scope.loadMatches = function () {
                League.getMatch(function (availableMatches) {
                    $scope.availableMatches = availableMatches;
                }, function (error) {
                    alert('error loading available teams');
                });
            };

            //Crear Team
            $scope.AddMatch = function () {
                League.AddMatch($scope.match, function (response) {

                    $scope.AddPartido();
                    $scope.loadMatches();
                    alert('Success');

                }, function (error) {
                    alert('Adding Failed');
                });
                $scope.match = {};
            };
            
        }

                // Path: /predict-a-goal
    .controller('PredictAGoalCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | Forgot Password';
        $scope.allCool = function () {
            $scope.ShowMessage = true;
            $location.path('/leagues');

        };

    }])
    ]);