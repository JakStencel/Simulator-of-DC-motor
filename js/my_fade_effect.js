
    $(document).ready(function() {
        $("#page-content-wrapper").css("display", "none");

 
    $("#page-content-wrapper").fadeIn(2000);
 
    $("a.transition").click(function(event){
        event.preventDefault();
        linkLocation = this.href;
        $("#page-content-wrapper").fadeOut(2000, redirectPage);      
    });
         
    function redirectPage() {
        window.location = linkLocation;
    }
    });