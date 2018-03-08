<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dydaktyka.aspx.cs" Inherits="Dydaktyka" %>

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
                    <a href="Model_matematyczny.aspx"><img src="img/002-abacus.png" style="margin-left:15px;"/> Model matematyczny</a>
                </li>
                <!--<li>
                    <a href="#">Events</a>
                </li>-->
               
                <li>
                    <a href="#"><img src="img/004-agenda.png" style="margin-left:15px;"/> Dydaktyka</a>
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
                        <h1>Dydaktyka</h1>
                        <p>Celem pogłębienia wiedzy oraz rozwiania wątpliwości polecam zapoznanie się z poniższymi odnośnikami:</p>
                        <ul>
                            <li><asp:HyperLink ID="hyperlink1" runat="server" Target="_new" Text="Maszyny elektryczne wokół nas" NavigateUrl="https://www.google.pl/url?sa=t&rct=j&q=&esrc=s&source=web&cd=5&cad=rja&uact=8&ved=0ahUKEwjhqeK-opPVAhXqFZoKHT-bDIsQFgg_MAQ&url=http%3A%2F%2Fdocplayer.pl%2F6155186-Maszyny-elektryczne-wokol-nas-zastosowanie-budowa-modelowanie-charakterystyki-projektowanie.html&usg=AFQjCNGtHd9wxLkkrOemDtY4Ybiuvv0ukg" /> - zastosowanie, budowa, modelowanie, projektowanie</li>
                            <li><asp:HyperLink ID="hyperlink2" runat="server" Target="_new" Text="Dynamiczna aplikacja internetowa" NavigateUrl="https://www.google.pl/url?sa=t&rct=j&q=&esrc=s&source=web&cd=4&cad=rja&uact=8&ved=0ahUKEwicro_Bo5PVAhWhAJoKHYrjAIUQFggzMAM&url=http%3A%2F%2Fwww.komel.katowice.pl%2FZRODLA%2FFULL%2F104%2Fref_36.pdf&usg=AFQjCNFQMLlOejcUtCjB2-apsaaN2WDVaw"  /> - rozszerzenie informacji na temat dynamicznej aplikacji jako symulatora</li>
                            <li><asp:HyperLink ID="hyperlink3" runat="server" Target="_new" Text="Maszyny prądu stałego" NavigateUrl="http://www.bezel.com.pl/index.php/maszyny-elektryczne/maszyny-pradu-stalego"/> - budowa oraz zasada działania silnika prądu stałego udostępnione przez firmę bezel</li>
                            <li><asp:HyperLink ID="hyperlink5" runat="server" Target="_new" Text="Dokumentacja Microsoft" NavigateUrl="https://msdn.microsoft.com/pl-pl/default.aspx" /> - dokumentacja opisująca każdą funkcję czy metodę</li>
                            <li><asp:HyperLink ID="hyperlink4" runat="server" Target="_new" Text="Kurs programowania C#" NavigateUrl="http://piotrgankiewicz.com/courses/becoming-a-software-developer/" /> - kurs programowania w języku C# autorstwa Piotra Gankiewicza</li>
                            <li><asp:HyperLink ID="hyperlink6" runat="server" Target="_new" Text="C# 6.0 and the .net framework 4.6 7th" NavigateUrl="https://scanlibs.com/c-sharp-6-0-and-the-net-4-6-framework-7th/" /> - jedna z lepszych książek na temat języka C# oraz środowiska .NET</li>
                        </ul>
                        <a href="#menu-toggle" class="btn btn-default" id="menu-toggle">Menu</a>
                    </div>
                    <div class="Images" style="width:100%; margin-left:auto; margin-right:auto; text-align:center;">
                    <asp:HyperLink ID="hyperlink7" runat="server" Target="_new" NavigateUrl="https://www.autodesk.pl/products/img/Inventor/overview" >
                        <asp:Image ID="Inventor" runat="server" ImageUrl="img/Inventor.png" AlternateText="Ikona programu Inventor" />
                    </asp:HyperLink>
                    <asp:HyperLink ID="hyperlink8" runat="server" Target="_new" NavigateUrl="https://www.visualstudio.com/pl/" >
                        <asp:Image ID="Visual_Studio" runat="server" ImageUrl="img/Visual_Studio.png" AlternateText="Ikona programu Visual Studio" />
                    </asp:HyperLink>
                    <asp:HyperLink ID="hyperlink9" runat="server" Target="_new" NavigateUrl="http://www.mathcad.pl/" >
                        <asp:Image ID="Mathcad" runat="server" ImageUrl="img/Mathcad.png" AlternateText="Ikona programu Mathcad" />
                    </asp:HyperLink>
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

