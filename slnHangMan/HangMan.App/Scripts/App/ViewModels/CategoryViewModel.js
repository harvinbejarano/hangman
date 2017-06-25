$(document).ready(Init());

function Init()
{
    function CategoryViewModel() {
        var self = this;

        self.Id = ko.observable();
        self.Name = ko.observable('');
        self.list = ko.observableArray([]);

        self.New = function () {
           self.Id();
           self.Name('');
        }

        self.Save = function () {
            var uri = "/api/CategoryApi/Insert";
            if (self.Id() !== undefined && self.Id() !== "")
            {
                var uri = "/api/CategoryApi/Update";
            }
            PostRequest(uri, ko.toJSON(self), onCreateUpdateSucces, onError, true);
        }

        self.Edit = function ($data) {
            self.Id($data.Id);
            self.Name($data.Name);
        }

        function LoadData() {
            var uri = "/api/CategoryApi/GetAll/";
            Request(uri, onLoadDataSucces, onError, true, "GET");
        }

        //Callback Function
        function onError(_errro) {

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
                self.list.push(value);
            });

        }

        LoadData();


    }

    var viewModel = new CategoryViewModel();
    ko.applyBindings(viewModel, $("#mainView")[0]);
}