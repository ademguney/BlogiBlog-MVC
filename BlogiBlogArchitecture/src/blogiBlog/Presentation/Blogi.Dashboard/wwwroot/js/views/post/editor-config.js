$(document).ready(function () {

    /* -----  Form Editor - Tinymce ----- */
    if ($("#xp-tinymce").length > 0) {
        tinymce.init({
            selector: 'textarea#xp-tinymce',  // change this value according to your HTML
         
            theme: "modern",
            height: 600,
            plugins: [
                "advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
                "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                "save table contextmenu directionality emoticons template paste textcolor",
                "codesample code"
            ],
            toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons | codesample code",
        });
    }

    $('.js-example-basic-multiple').select2();
    

});