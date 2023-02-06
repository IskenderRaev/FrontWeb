function TinCheckTaxPayer() {
    var pin = $('#Pin').val();
    $("#Surname").val('');
    $("#Firstname").val('');
    $("#Patronymic").val('');
    if (pin.length === 14) {
        ajaxRequestMade = true;
        $.ajax({
            type: 'GET',
            url: '/TinCheck/GetTaxPayer',
            dataType: 'json',
            data: {
                Tin: pin
            },
            statusCode: {
                200: function (data)
                {
                    if (data) {
                        $("#Surname").val(data.surname);
                        $("#Firstname").val(data.firstname);
                        $("#Patronymic").val(data.patronymic);
                    }
                }
            }
        });
    }
    else {
        ajaxRequestMade = false;
    }
};