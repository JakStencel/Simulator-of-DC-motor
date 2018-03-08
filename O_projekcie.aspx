<%@ Page Language="C#" AutoEventWireup="true" CodeFile="O_projekcie.aspx.cs" Inherits="O_projekcie" %>

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
                    <a href="#" class="transition"><img src="img/005-note.png" style="margin-left:15px;"/> O projekcie</a>
                </li>
                <li>
                    <a href="Dane_silnika.aspx"><img src="img/001-folder.png" style="margin-left:15px;"/> Dane silnika ARBZc132SZ</a>
                </li>
                <li>
                    <a href="Model_matematyczny.aspx"><img src="img/002-abacus.png" style="margin-left:15px;"/> Model matematyczny</a>
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
            <div class="container-fluid" style="min-height:100%; position:relative;">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 style="text-align:justify; display:inline-block; padding-left: 50px;"><asp:Image ID="DCmotor" runat="server" ImageUrl="img/obudowa3.png" /> Kilka słów o projekcie</h1>
                        <br /><br />
                        <p>
                            Koncepcja wirtualnego laboratorium maszyn elektrycznych juz od pewnego czasu rozwijała się na Wydziale 
                            Elektrotechniki i Automatyki Politechniki Gdańskiej. Poprzez coraz większy udział e-learningu w nauczaniu 
                            studenta postanowiono wykorzystać możliwości płynące z sieci internetowych w celach nauczania na odległość.
                            Tak oto powstała aplikacja internetowa będąca obwodowym symulatorem silnika 
                            komutatorowego prądu stałego typu ARBZc132 SZ.
                            Użytkownik dzięki niej będzie miał możliwość nakreślenia przebiegów maszyny z własnymi, zadanymi wczesniej
                            parametrami. Utworzone charakterystyki będą odzwierciedleniem rzeczywistych przebiegów otrzymanych w 
                            laboratorium. 
                        </p>
                        <p>Aplikacja umożliwia wykonanie następujacych stanów silnika:</p>
                        <ul>
                            <li>biegu jałowego - charakterystyka magnesowania</li>
                            <li>rozruchu</li>
                            <li>pracy przy obciążeniu</li>
                        </ul>
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

    <script src="js/my_fade_effect_v2.js"></script> 
    <script>
    $("#menu-toggle").click(function(e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
    });
    </script>
    </form>
</body>
</html>
