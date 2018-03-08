<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Model_matematyczny.aspx.cs" Inherits="Model_matematyczny" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Aplikacja internetowa obwodowego symulatora silnika prądu stałego ARBZc132SZ</title>
    <!--<link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Lato:400,700&amp;subset=latin-ext" rel="stylesheet" />
    <link href="css/fontello.css" rel="stylesheet" type="text/css" />-->
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/Other_style_sheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div id="wrapper">

         <!-- Sidebar -->
        <div id="sidebar-wrapper">
            <ul class="sidebar-nav">
                <li class="sidebar-brand">
                    <a href="Strona_glowna.aspx"><img src="img/006-home.png" />
                         Strona główna
                    </a>
                </li>
                <li>
                    <a href="O_projekcie.aspx" class="transition"><img src="img/005-note.png" style="margin-left:15px;"/> O projekcie</a>
                </li>
                <li>
                    <a href="Dane_silnika.aspx"><img src="img/001-folder.png" style="margin-left:15px;"/> Dane silnika ARBZc132SZ</a>
                </li>
                <li>
                    <a href="#"><img src="img/002-abacus.png" style="margin-left:15px;"/> Model matematyczny</a>
                </li>
                <!--<li>
                    <a href="#">Events</a>
                </li>-->
               
                <li>
                    <a href="Dydaktyka.aspx"><img src="img/004-agenda.png" style="margin-left:15px;"/> Dydaktyka</a>
                </li> 
                <li>
                    <a href="Kontakt.aspx"><img src="img/003-mail.png" style="margin-left:15px;"/> Kontakt</a>
                </li>
                <li id="rozwijane">
                    <a id="toggle_menu" href="#"><img src="img/007-bar-chart.png" style="margin-left:15px;"/> Symulacje</a>
                    <ul id="rozwijane_menu">
                        <li style="margin-left:-120px;padding-left:0px;"><a href="Bieg_jalowy.aspx"><img src="img/001-presentation.png" /> Bieg jałowy</a></li>
                        <li><a href="Rozruch.aspx"><img src="img/003-presentation.png" /> Rozruch</a></li>
                        <li><a href="Chatyka_mechaniczna_v2.aspx"><img src="img/002-presentation.png" /> Praca przy obciążeniu</a></li>
                    </ul>
                </li> 
            </ul>
            <div class="sidebar-social">
                <a href="https://www.facebook.com/PolitechnikaGdanska/" class="iconss"><img src="img/006-social-media.png"/></a>
                <a href="https://twitter.com/politechnikagda" class="iconss"><img src="img/005-social-media-1.png"/></a>
                <a href="https://www.youtube.com/watch?v=ktImPJebut4" class="iconss"><img src="img/004-youtube.png"/></a>
                <a href="https://docs.microsoft.com/en-us/dotnet/csharp/csharp" class="iconss"><img src="img/001-hashtag.png" /></a>
                <a href="https://msdn.microsoft.com/pl-pl/default.aspx" class="iconss"><img src="img/002-logo.png"/></a>
                <a href="https://www.google.com/maps/d/viewer?mid=15cL3gfmO8eVDYut4GSic_jioXFQ&hl=en_US&ll=54.37138900000002%2C18.618888999999967&z=17" class="iconss"><img src="img/003-windows.png"/></a>
            </div>
        </div>
        <!-- /#sidebar-wrapper -->

        <!-- Page Content -->
        <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1>Model matematyczny</h1>
                        <p>
                            Schemat maszyny prądu stałego  został przedstawiony na poniższym rysunku 1. 
                            Uzwojenie wzbudzenia oraz uzwojenie twornika  skupione zostały do pojedynczych cewek. 
                            Elementy skupione zewnętrzne czyli  dodatkowe indukcyjności (M<sub>t_add</sub>, M<sub>f_add</sub>) oraz rezystancje 
                            (R<sub>t_add</sub>, R<sub>f_add</sub>) są możliwe do  modyfikacji. Użytkownik aplikacji internetowej ma również możliwość 
                            zmiany wartości napięć zasilanych obwodów: twornika U<sub>t</sub> oraz wzbudzenia U<sub>f</sub>. Parametry M<sub>t</sub>, M<sub>f</sub>, R<sub>t</sub>, R<sub>f</sub>  
                            są zadeklarowane na stałe i niezmienne. Kolejne rysunki (Rys.2 oraz Rys.3) orazobrazują schematy zastępcze związane z obwodem elektrycznym 
                            oraz mechanicznym silnika komutatrowego prądu stałego.
                        </p>
                        <asp:Image ID="schemat_obwodu" runat="server" AlternateText="schemat obwodu maszyny  prądu stałego" ImageAlign="Middle" 
                                    ImageUrl="img/schemat_obwodu_silnika.jpg" style="display:block; margin-left:auto; margin-right:auto; margin-top:25px; 
                                    opacity:0.7; border-radius:10%;" Height="470px" Width="460px"/>
                        <h6 style="margin-left:auto; margin-right:auto; text-align:center;">Rys.1. Schemat obwodu silnika ARBZc132SZ</h6>
                        <br />
                        <asp:Image ID="schemat" runat="server" AlternateText="schemat zastępczy obwodu" ImageAlign="Middle" ImageUrl="img/schemat_zastępczy.jpg" 
                                    Height="209px" Width="466px" style="display:block; margin-left:auto; margin-right:auto; margin-top:20px;"/>
                        <h6 style="margin-left:auto; margin-right:auto; text-align:center;">Rys.2. Schemat zastępczy obwodu elektrycznego maszyny prądu stałego</h6>
                        <asp:Image ID="schemat_mechaniczny" runat="server" AlternateText="schemat mechaniczny obwodu" ImageAlign="Middle" 
                                    ImageUrl="img/schemat_rownania_mechanicznego.jpg" style="display:block; margin-left:auto; margin-right:auto; margin-top:25px;"/>
                        <h6 style="margin-left:auto; margin-right:auto; text-align:center;">Rys.3. Przykładowy schemat obwodu mechanicznego maszyny prądu stałego</h6>
                        <p>
                            Modelowanie obwodowe abstrahuje od przestrzennej struktury maszyny. Rozwiązanie sformułowanego modelu obwodowego 
                            maszyny elektrycznej oznacza rozwiązanie równań różniczkowych zwyczajnych przy określonych warunkach początkowych 
                            lub równań algebraicznych w przypadku rozpatrywania stanów ustalonych.
                        </p>
                        <p>
                            Szczegółową postać równań dla maszyny komutatorowej prądu stałego można sformułować równaniami elektrycznymi 
                            (3.1), (3.2) oraz równaniem mechanicznym (3.3).
                        </p>
                        <p>
                        <asp:Image ID="Wzory" runat="server" AlternateText="wzory opisujące silnik DC" ImageAlign="Middle" 
                                    ImageUrl="img/wzory.png" style="display:block; margin-left:auto; margin-right:auto; margin-top:25px;"/>
                        </p>
                        <p>
                            Na podstawie powyższych równań sformułowano równanie macierzowe (3.5) o czterech stopniach swobody: 
                            prąd twornika i<sub>t</sub>, prąd wzbudzenia i<sub>f</sub>, prędkość kątowa ω oraz kąt φ. Równanie to zostało 
                            zaimplementowane w programie <asp:HyperLink ID="hyperlink5" runat="server" Target="_new" Text="Mathcad" NavigateUrl="http://www.mathcad.pl/" />, co pozwoliło 
                            opracować model matematyczny silnika komutatorowego prądu stałego ARBZc132SZ.
                        </p>
                        <p>
                        <asp:Image ID="macierz" runat="server" AlternateText="równanie macierzowa" ImageAlign="Middle" 
                                    ImageUrl="img/macierz.png" style="display:block; margin-left:auto; margin-right:auto; margin-top:25px;"/>
                        </p>
                        <br />
                        <a href="#menu-toggle" class="btn btn-default" id="menu-toggle">Menu</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /#page-content-wrapper -->

    </div>
    <!-- /#wrapper -->

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Menu Toggle Script -->
    <script>
    $("#menu-toggle").click(function(e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
    });
    </script>
    <script src="js/my_fade_effect.js"></script> 
    </form>
</body>
</html>
