$(function () {

   
    $("#orderSpecialDate").datepicker({
      
        dateFormat: "dd-mm-yy",
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        dayNames: ["pazar", "pazartesi", "salı", "çarşamba", "perşembe", "cuma", "cumartesi"],
        dayNamesMin: ["pa", "pzt", "sa", "çar", "per", "cum", "cmt"],
        monthNamesShort: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        nextText: "ileri",
        prevText: "geri",
        showAnim: "drop",
        onSelect: function (datetext) {
            var d = new Date();
            datetext = datetext + " " + d.getHours() + ": " + d.getMinutes() + ": " + d.getSeconds();
            $('#orderSpecialDate').val(datetext);
        },
        yearRange: "2021"
    });
    var yearRange = $(".selector").datepicker("option", "yearRange");
    $("#orderSpecialDate").datepicker("option", "yearRange", "2021:2022");

});