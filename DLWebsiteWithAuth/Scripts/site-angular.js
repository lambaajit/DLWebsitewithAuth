var app = angular.module('myApp', []);

//$scope.jobID = 0;

app.controller('myCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.initialise = function () {
        $scope.$apply;
    };

    $scope.initialise = function (dept,SubDepartment) {
        $scope.QueryType = 'Law';
        $scope.changequerytype();
        if (dept != "" && dept != null) {
            $scope.dept = dept.toString();
            $scope.deptfilled = true;
            $scope.changesubDepartment();
            if (SubDepartment != "" && SubDepartment != null) {
                $scope.SubDepartment = SubDepartment.toString();
                $scope.subdeptfilled = true;
            }
        }

        $scope.$apply;
    };



    $scope.changesubDepartment = function () {
        $http({
            method: 'GET',
            url: '/Home/getSubDepartments/' + $scope.dept
        }).then(function mySuccess(response) {
            $scope.subdept = response.data;
        }, function myError(response) {
            alert(response.statusText);
        });
    };


    $scope.QueryType = "";
    $scope.Queryrelatesto = {};
    $scope.changequerytype = function ()
    {
        if ($scope.QueryType == "Law")
        {
            $http({
                method: 'GET',
                url: '/Home/getDepartmentsvalues'
            }).then(function mySuccess(response) {
                $scope.Queryrelatesto = response.data;
            }, function myError(response) {
                alert(response.statusText);
            });

            //$scope.Queryrelatesto = [{
            //    "text": "Child Care", "Value": "1"
            //}, {
            //    "text": "Community Care", "Value": "2"
            //},
            //{
            //    "text": "Clinical Negligence", "Value": "3"
            //}, {
            //    "text": "Crime", "Value": "4"
            //}, {
            //    "text": "Family", "Value": "6"
            //}, {
            //    "text": "Employment", "Value": "7"
            //}, {
            //    "text": "Housing", "Value": "8"
            //}, {
            //    "text": "Immigration – Private and Business", "Value": "12"
            //}, {
            //    "text": "Immigration – Asylum/Human Rights", "Value": "10"
            //}, {
            //    "text": "Civil Litigation", "Value": "11"
            //}, {
            //    "text": "Mental Health", "Value": "13"
            //}, {
            //    "text": "Mental Capacity", "Value": "20"
            //}, {
            //    "text": "Prison Law", "Value": "14"
            //}, {
            //    "text": "Personal Injury", "Value": "15"
            //}, {
            //    "text": "Welfare Benefits", "Value": "18"
            //}, {
            //    "text": "Public Law", "Value": "19"
            //}, {
            //    "text": "Action Against Public Authorities", "Value": "21"
            //}, {
            //    "text": "EU", "Value": "22"
            //}, {
            //    "text": "Wills and Probate", "Value": "23"
            //}, {
            //    "text": "International Disputes", "Value": "24"
            //}, {
            //    "text": "Commercial", "Value": "25"
            //}, {
            //    "text": "Motoring Law", "Value": "26"
            //}, {
            //    "text": "Islamic Law", "Value": "27"
            //}];
        }
        else
        {
            $scope.Queryrelatesto = [{
                "text": "Client Care", "Value": "Client Care"
            }, {
                "text": "Feedback", "Value": "Feedback"
            }, {
                "text": "Complaint", "Value": "Complaint"
            }, {
                "text": "Existing Clients", "Value": "Existing Clients"
            }, {
                "text": "Facilities", "Value": "Facilities"
            }, {
                "text": "Finance", "Value": "Finance"
            }, {
                "text": "Human Resources", "Value": "Human Resources"
            }, {
                "text": "Marketing", "Value": "Marketing"
            }, {
                "text": "Other", "Value": "Other"
            }, {
                "text": "Press Inquiry", "Value": "Press Inquiry"
            }, {
                "text": "Data Protection", "Value": "Data Protection"
            }];
        }
        $scope.$apply;
    }
    


}]);