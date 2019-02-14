(function (app) {
    var listaFilme = function ($scope, $http) {
        $http.get("http://copadosfilmes.azurewebsites.net/api/filmes")
            .success(function (data) {
                $scope.filmes = data;
            });
    };

    app.controller('ctrlFilme', listaFilme);
}(angular.module("filmeModulo",[])))
