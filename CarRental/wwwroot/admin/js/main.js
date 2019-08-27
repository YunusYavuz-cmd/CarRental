(function ($) {
    "use strict";

    jQuery(document).ready(function ($) {
        /*global jQuery */
        $("#ddlInstitution").on('change', function () {

            var selValue = $('#ddlInstitution').val();

            $.ajax({
        $.ajax({
        type: 'POST',
        data: selValue,
        url: '/Home/GetLocationPoints',
      //  contentType: 'application/json',
        //dataType: 'json',
        success: alert('Youhou'),
        error: alert('not good')
    });

                },
               
            });
        });
    });

    }());


 