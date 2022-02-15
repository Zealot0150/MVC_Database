    function getValueById(id) {
            return document.getElementById(id).value;
        }
    function getValueByName(id) {
            return document.getElementByName(id).value;
        }

    function setValueId(id, value) {
        document.getElementById(id).value = value;
        }

    function setValueName(name, value) {
        document.getElementById(name).value = value;
        }



    function getFromInput() {

    }


    function displayMessage(msg) {
        document.getElementById("message").innerHTML = msg;
        }

    function displayError(error) {
        document.getElementById("error").innerHTML = JSON.stringify(error);
        }

    function handleAjaxError(error) {
        displayError(error);

    switch (error.status) {
                case 404:
    Alert(error.responseText);
    break;
    case 500:
    Alert(error.responseText);
    break;
    default:
    Alert(error.responseText);
    break;
            }
        }

        // Bara exempel som är bra att ha i framtiden   ///////////////////////////////////////////////////

        //function Success(obj) {alert(obj)}

        // AJAX settings object bara exempel

        //ajax_SO =  // exempel på objekt att sända
        //{
        //    url: "Ajax/AddUser",
        //    type: "POST",
        //    contentType: "application/json",
        //    success: function (obj) { Success(obj)},
        //    error: function (obj) { HandleAjaxError(obj) },
        //    complete: function (obj) { }   // som i try catch denna körs alltid
        //};
        // bara testar anropet...
        //  $.ajax(ajax_SO);
        // Promises....
        //$.ajax(ajax_SO).done(function (data) { Success(data); }).fail(function (data) { HandleAjaxError(data) });

        // Ex på Get inget i uppgiften...
        //function GetByURl(_url)
        //{
        //    $.ajax(_url).done(function (data) { })
        //}

        //function get() {
        //    $.ajax(URL)
        //        .done(function (data) {
        //            displayMessage("Products Retrieved");
        //            console.log(data);
        //        })
        //        .fail(function (error) {
        //            handleAjaxError(error);
        //        })
        //        .always(function () {
        //            // Anything you want to happen here on either fail or done
        //            console.log("In the always() method");
        //        });
        //}

        // Updatering = put
        //function updateProduct()
        //{
        //    let product = getFromInput()
        //    $.ajax({
        //        url: URL + "/" + product.productId,
        //        type: "PUT",
        //        contentType: "application/json",
        //        data: JSON.stringify(product)

        //    })
        //}

        //Globala Events ajax
        //$(document).ajaxSend(function () {
        //    console.log("Ajax call is being sent");
        //});

        //$(document).ajaxSend(function (event, xhr, settings) {
        //    console.log(settings);
        //});
        // 
        // $("#header").load(url); laddar elementet id=header med filen på url

        //f Deferred promises alla måste gå igenom
        //let def = $.Deferred();
        //def.then(function () {
        //    return $.get(URL).done()
        //})
        //.then( osv..)

        //let def = $.Deferred();
        //setTimeout(def.resolve, 1000);
        //return def.promise();
        // gör så att then kan köras så och kan användas
        //function SetTimeDefTimout()
        //{
        //    f().then(()=>{})
        //}

        // går även att använda vid notifering

        //$(document).ready(
        //function () {
        //    let msg = $(this).data("onfocus");
        //    msg.....
        //});


        //////////////////////////////////////////////////


        function Delete() {
            var URL = "Ajax/Delete/" + getValueById("myText");

            $.ajax//({ URL,type="DELETE"} Får hela sidan att hänga sig.
                (URL)
                .done(function (data) {
                    document.getElementsByName("target")[0].innerHTML = data;
                }).fail(function (data) {
                    displayError(data);
                });
        }
        

        function GetPeople()
    {
        $.get("Ajax/List", function (List, status) {

            document.getElementsByName("target")[0].innerHTML = List;
        });
        }

    function ShowDetails()
    {

            var URL = "Ajax/Details/" + document.getElementById("myText").value;
        $.post(URL)
        .done(function (data) {
        document.getElementsByName("target")[0].innerHTML = data;})
        .fail(function (data) {
        displayError(data);
            });
        }

    function AddUser() {
        $.get("Ajax/Add", function (Add, status) {
            document.getElementsByName("target")[0].innerHTML = Add;
        });
        }

    function AddUserCalllback3()
    {
        var URL = "Ajax/AddNew2";
        let peopledata = $("#addform").serializeArray();
        document.getElementsByName("target")[0].innerHTML = peopledata;



        displayError(peopledata);
        $.ajax(
        {
            url: URL,
            contentType: "application/json",
            data: JSON.stringify(peopledata),
            type: "POST"
         })
            .done(function (data) {
            // fungerar inte just nu, värderna verkar finnas tills anropet.
            //document.getElementsByName("target")[0].innerHTML = data;
                }).fail(function (data) {
        //    displayError(data);
            //document.getElementsByName("target")[0].innerHTML = "Kunde inte lägga till användare";
                });
    }

function AddUserCalllback2() {
    var dataAdd = {
        City: $("#City").val(),
        Id: $("#Id").val(),
        Name: $("#Name").val(),
        Tele: $("#Tele").val()
    }
    console.log(dataAdd);
    $.post(URL, { DataAdd: dataAdd })
        .success(function (data) {
            $("#target").html(data);
            displayError(data);
        });
}





