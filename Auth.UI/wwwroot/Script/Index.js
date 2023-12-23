//Controller
App.controller('IndexCtrl', function ($scope, $filter, Service) {

    //clear all function
    $scope.ClearAll = function () {
        $scope.AllData = {};
        $scope.MasterData = {};
        $scope.MasterDetailsGridData = [];
        $scope.GetCorporateCustomer();
        $scope.RowData = 0;
        $scope.ClearGrid();
        $scope.MasterData.CorporateCustomerID = 0;
        $scope.MasterData.IndividualCustomerID = 0;
    }
    //clear grid function
    $scope.ClearGrid = function () {
        $scope.MasterDetailsObj = {};
        $scope.AddGridButtonText = "Add";
        Service.GetAll('/api/Main/GetAllProductInfo').then(function (data) {
            $scope.ProductInfo = data.data;
        });
    }

    //get customer info
    $scope.GetCorporateCustomer = function () {
        $scope.HideCorporateCustomer = false;
        $scope.HideIndividualCustomer = true;
        $scope.MasterData.IndividualCustomerID = 0;
        Service.GetAll('/api/Main/GetAllCorporateCustomer').then(function (data) {
            $scope.CorporateCustomerInfo = data.data;
        });
    }

    //get customer info
    $scope.GetIndividualCustomer = function () {
        $scope.HideCorporateCustomer = true;
        $scope.HideIndividualCustomer = false;
        $scope.MasterData.CorporateCustomerID = 0;
        Service.GetAll('/api/Main/GetAllIndividualCustomer').then(function (data) {
            $scope.IndividualCustomerInfo = data.data;
        });
    }
    $scope.ClearAll();

    //get product info
    $scope.GetProductInfo = function () {
        Service.GetByID('/api/Main/GetProductInfoByID', $scope.MasterDetailsObj.ProductID).then(function (data) {
            $scope.Unit = data.data.Unit;
            $scope.ProductName = data.data.ProductName;
        });
    }

    //row id create
    $scope.getRowId = function () {
        $scope.MasterDetailsObj.RowId = $scope.RowData + 1;
        $scope.RowData = $scope.MasterDetailsObj.RowId;
        return $scope.MasterDetailsObj.RowId;
    }

    // ValidationFuntion
    $scope.ValidationFuntion = function () {
        $('.form-control').css('border-color', '');
        $('.validation').hide();
        if ($scope.MasterData.CorporateCustomerID == 0 && $scope.MasterData.IndividualCustomerID == 0) {
            alert("Customer Can not be empty");
            $('#CustomerName').css('border-color', 'red');
            $('#CustomerName').focus();
            return false;
        } else if ($scope.MasterData.Date == "" || $scope.MasterData.Date == undefined) {
            alert("Date Can not be empty");
            $('#Date').css('border-color', 'red');
            $('#Date').focus();
            return false;
        }
        else if ($scope.MasterData.Time == "" || $scope.MasterData.Time == undefined) {
            alert("Time Can not be empty");
            $('#Time').css('border-color', 'red');
            $('#Time').focus();
            return false;
        } else if ($scope.MasterData.MeetingPlace == "" || $scope.MasterData.MeetingPlace == undefined) {
            alert("Meeting place can not be empty");
            $('#MeetingPlace').css('border-color', 'red');
            $('#MeetingPlace').focus();
            return false;
        } else if ($scope.MasterData.AttendsFromClient == "" || $scope.MasterData.AttendsFromClient == undefined) {
            alert("Attends from client side can not be empty");
            $('#AttendsFromClient').css('border-color', 'red');
            $('#AttendsFromClient').focus();
            return false;
        } else if ($scope.MasterData.AttendsFromHost == "" || $scope.MasterData.AttendsFromHost == undefined) {
            alert("Attends from host side can not be empty");
            $('#AttendsFromHost').css('border-color', 'red');
            $('#AttendsFromHost').focus();
            return false;
        } else if ($scope.MasterData.MeetingAgenda == "" || $scope.MasterData.MeetingAgenda == undefined) {
            alert("Meeting agenda can not be empty");
            $('#MeetingAgenda').css('border-color', 'red');
            $('#MeetingAgenda').focus();
            return false;
        } else if ($scope.MasterData.MeetingDiscussion == "" || $scope.MasterData.MeetingDiscussion == undefined) {
            alert("Meeting discussion can not be empty");
            $('#MeetingDiscussion').css('border-color', 'red');
            $('#MeetingDiscussion').focus();
            return false;
        } else if ($scope.MasterData.MeetingDecision == "" || $scope.MasterData.MeetingDecision == undefined) {
            alert("Meeting decision can not be empty");
            $('#MeetingDecision').css('border-color', 'red');
            $('#MeetingDecision').focus();
            return false;
        } else if ($scope.MasterDetailsGridData.length == 0) {
            alert("Please add product in list");
            return false;
        }
        else {
            return true;
        }
    }

    //grid validation
    $scope.GridValidationFuntion = function () {
        $('.form-control').css('border-color', '');
        $('.validation').hide();
        if ($scope.MasterDetailsObj.ProductID == 0 || $scope.MasterDetailsObj.ProductID == undefined) {
            alert("Product Can not be empty");
            $('#InterestedProduct').css('border-color', 'red');
            $('#InterestedProduct').focus();
            return false;
        } else if ($scope.MasterDetailsObj.Qnty == "" || $scope.MasterDetailsObj.Qnty == undefined) {
            alert("Quantity not be empty");
            $('#Quantity').css('border-color', 'red');
            $('#Quantity').focus();
            return false;
        }
        else {
            return true;
        }
    }

    //edit product table
    $scope.editProductInfo = function (row) {
        $scope.MasterDetailsObj = row;
        $scope.AddGridButtonText = 'Update';
    }


    //delete product from table
    $scope.deleteProductFromList = function (row) {
        var retValue = confirm('Do you want to delete this record?');
        if (retValue == true) {
            var index = -1;
            for (var i = 0; i < $scope.MasterDetailsGridData.length; i++) {
                if ($scope.MasterDetailsGridData[i].RowId === row.RowId) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                toastr.error("Something gone wrong");
            }
            $scope.MasterDetailsGridData.splice(index, 1);
        }
    }

    //add product to table
    $scope.SaveDetails = function (MasterDetailsObj) {
        if ($scope.AddGridButtonText == "Add") {
            if ($scope.GridValidationFuntion() == true) {
                $scope.MasterDetailsGridData.push({
                    RowId: $scope.getRowId(),
                    MasterDetailsID: 0,
                    MasterTableID: 0,
                    ProductID: $scope.MasterDetailsObj.ProductID,
                    Qnty: $scope.MasterDetailsObj.Qnty,
                    Unit: $scope.Unit,
                    ProductName: $scope.ProductName
                });
            }
        }

        if ($scope.AddGridButtonText == "Update") {
            for (i in $scope.MasterDetailsGridData) {
                if ($scope.MasterDetailsGridData[i].RowId == $scope.MasterDetailsObj.RowId) {
                    $scope.MasterDetailsGridData[i] = $scope.MasterDetailsObj;
                }
            }
        };
        $scope.ClearGrid();
    };

    //save data in database
    $scope.Save = function () {
        if ($scope.ValidationFuntion() == true) {
            $scope.MasterData.Time = $filter('date')($scope.MasterData.Time, 'HH:mm:ss');
            $scope.AllData.MasterData = $scope.MasterData;
            $scope.AllData.MasterDetailsData = $scope.MasterDetailsGridData;
            Service.Save('/api/Main/SaveData', $scope.AllData).then(function (data) {
                if (data.data.MsgCode == 200) {
                    alert("Save Succesfull")
                    $scope.ClearAll();
                }
                else {
                    alert("Error")
                }
            });
        }

    }
});