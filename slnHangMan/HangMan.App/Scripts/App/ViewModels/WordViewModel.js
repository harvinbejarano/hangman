$(document).ready(Init());

function Init() {
    function WordViewModel() {
        var self = this;

        self.Id = ko.observable();
        self.Name = ko.observable('');
        self.CategoryId = ko.observable();

        self.Categories = ko.observableArray([]);
        self.list = ko.observableArray([]);

        self.New = function () {
            self.Id(undefined);
            self.CategoryId('');
            self.Name('');
        }

        self.Save = function () {
            var uri = "/api/WordApi/Insert";
            if (self.Id() != undefined  ) {
                var uri = "/api/WordApi/Update";
            }
            PostRequest(uri, ko.toJSON(self), onCreateUpdateSucces, onError, true);
        }

        self.Edit = function ($data) {
            self.Id($data.Id);
            self.CategoryId($data.CategoryId);
            self.Name($data.Name);
        }

        function LoadData() {
            var uriCat = "/api/CategoryApi/GetAll/";
            Request(uriCat, onCategorySucces, onError, true, "GET");

            var uri = "/api/WordApi/GetAll/";
            Request(uri, onLoadDataSucces, onError, true, "GET");
        }

        //Callback Function
        function onError(_errro) {

        }

        function onCategorySucces(_data) {
            if (_data.StatusCode != 200) {
                return;
            }
            self.Categories([]);
            var listado = _data.Data;
            $.each(listado, function (key, value) {
                self.Categories.push(value);
            });

        }
        function onCategoryIdSucces(_data) {
            if (_data.StatusCode != 200) {
                return;
            }
        }

        function onCreateUpdateSucces(_data) {
            if (_data.StatusCode != 200) {
                return;
            }
            LoadData();
        }

        function onLoadDataSucces(_data) {
            if (_data.StatusCode != 200) {
                return;
            }
            self.list([]);
            var listado = _data.Data;
            $.each(listado, function (key, value) {

                var uriCat = "/api/CategoryApi/Get/" + value.CategoryId;
                var _name = ReturnRequest(uriCat, onCategoryIdSucces, onError, false, "GET");
                value.CategoryName = _name.Data.Name;
                self.list.push(value );
            });

        }

        LoadData();


    }

    var viewModel = new WordViewModel();
    ko.applyBindings(viewModel, $("#mainView")[0]);
}