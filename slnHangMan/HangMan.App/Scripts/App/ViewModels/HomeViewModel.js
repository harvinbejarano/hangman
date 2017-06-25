$(document).ready(Init());

function Init() {
    function HomeViewModel() {
        var self = this;
        var urlpic = "Content/images/";
        self.Categories = ko.observableArray([]);
        self.CategoryId = ko.observable();
        self.PhotoName = ko.observable(urlpic + "0.png");
        self.picVisible = ko.observable(false);
        self.gameStarted = ko.observable(false);

        self.GeneratedWord = ko.observable('');
        self.singleWord = ko.observable('');
        self.SelectedWords = ko.observable('');
        self.pictoShow = ko.observable(0);

        self.PlayWord = function () {
            var actualWords = self.SelectedWords();
            self.SelectedWords(actualWords + self.singleWord());


            var n = self.GeneratedWord().toUpperCase().indexOf(self.singleWord().toUpperCase());
            if (n == -1) {
                var actualPic = parseInt($("#npic").val());
                actualPic++;
                self.pictoShow(actualPic);

                var picname = actualPic.toString() + ".png";
                self.PhotoName(urlpic + picname);
                self.picVisible(true);
                $("#npic").val(actualPic);

                if (actualPic == 10) {
                    alert("Game Over");
                    return;
                }
            }
            else
            {
                var indexes = Findchar(self.singleWord());
                var arrayLen = indexes.length;
                for (i = 0; i < arrayLen; i++)
                {
                    var _control = "_" + indexes[i].toString();
                    var _object = $("#" + _control);
                    $(_object).val(self.singleWord());
                }

            }
        }

        self.onCategoryChange = function () {
            GenerateWord(self.CategoryId());

        }

        function GenerateWord(_categoryId) {
            $("#chars").empty();
            var _uri = "/api/WordApi/GetByCategoryId/" + _categoryId;
            var wordlist = ReturnRequest(_uri, onSuccess, onError, false, "GET")
            if (wordlist == undefined) {
                self.gameStarted(false);
                return;
            }
            var maxWords = wordlist.Data.length;
            if (maxWords > 0) {
                var wordIndex = Math.floor((Math.random() * maxWords) + 1);
                self.GeneratedWord(wordlist.Data[wordIndex - 1].Name);
                self.gameStarted(true);
                var imp = '<table> <tr>';

                var nChars = self.GeneratedWord().length;
                for (i = 0; i < nChars; i++)
                {
                    imp = imp + ' <td> <input type="text" class="form-control input-sm" maxlength="1" readonly="readonly" style="width:40px;" id="_' + i.toString() + '" name="f"/> </td> ';

                }
                imp = imp + '</tr> </table> ';
                $("#chars").append(imp);
            }
            else
            {
                self.gameStarted(false);
            }
        }

        function onSuccess(_data) {

        }

        function LoadData() {
            var uriCat = "/api/CategoryApi/GetAll/";
            Request(uriCat, onCategorySucces, onError, true, "GET");
        }

        //Callback Function
        function Findchar(_char)
        {
            var result = [];

            var wordlen = self.GeneratedWord().length;
            for (i = 0; i < wordlen; i++)
            {
                var _char = self.GeneratedWord().substr(i, 1).toUpperCase();
                if (_char === self.singleWord().toUpperCase())
                {
                    result.push(i);
                }
            }

            return result;
        }

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

        LoadData();
    }

    var viewModel = new HomeViewModel();
    ko.applyBindings(viewModel, $("#mainView")[0]);
}