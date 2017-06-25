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
            debugger;
            var actualWords = self.SelectedWords();
            self.SelectedWords(actualWords + self.singleWord());


            var n = self.GeneratedWord().indexOf( self.singleWord() );
            if (n == -1) {

                var actualPic = parseInt( $("#npic").val());
                actualPic++;
                self.pictoShow(actualPic);
                
                var picname = actualPic.toString() + ".png";
                self.PhotoName(urlpic+picname);
                self.picVisible(true);
                $("#npic").val(actualPic);

                if (actualPic == 10) {
                    alert("Game Over");
                    return;
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
            debugger;
            var maxWords = wordlist.Data.length;
            if (maxWords > 0) {
                var wordIndex = Math.floor((Math.random() * maxWords) + 1);
                self.GeneratedWord(wordlist.Data[wordIndex - 1].Name);
                self.gameStarted(true);
                
                var nChars = self.GeneratedWord().length;
                for (i = 0; i < nChars; i++)
                {
                    var imp = '<input type="text" class="form-control input-sm" maxlength="1" style="width:15px;" id="' + i.toString() + '"/>';

                    $("#chars").append(imp);
                }
                
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