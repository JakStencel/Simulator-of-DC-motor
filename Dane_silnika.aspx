<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dane_silnika.aspx.cs" Inherits="Dane_silnika" %>

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
    <link href="css/MotorDataStyleSheet.css" rel="stylesheet" />
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
                    <a href="#"><img src="img/001-folder.png" style="margin-left:15px;"/> Dane silnika ARBZc132SZ</a>
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
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1>Dane znamionowe silnika</h1>
                        <asp:Image ID="rysunek_techniczny" runat="server" ImageUrl="img/rysunek_techniczny_v3.png" />
                        <asp:Panel ID="panel" runat="server" CssClass="DaneZnam">

                            <asp:Table ID="tabElements" runat="server" Caption="Dane znamionowe:" GroupingText="Dane Znamionowe:" CaptionAlign="Top" GridLines="Both" BorderColor="Gray">
                                <asp:TableRow TableSection="TableHeader" HorizontalAlign="Center" BackColor="transparent" Font-Bold="true" Height="25px">
                                    <asp:TableCell Width="250px" Text="Wielkość"></asp:TableCell>
                                    <asp:TableCell Width="100px" Text="Symbol"></asp:TableCell>
                                    <asp:TableCell Width="160px" Text="Jednostka"></asp:TableCell>
                                    <asp:TableCell Width="100px" Text="Wartość"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Moc znamionowa"></asp:TableCell>
                                    <asp:TableCell Text="Pn"></asp:TableCell>
                                    <asp:TableCell Text="kW"></asp:TableCell>
                                    <asp:TableCell Text="1,2"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Napięcie znamionowe twornika"></asp:TableCell>
                                    <asp:TableCell Text="Uan"></asp:TableCell>
                                    <asp:TableCell Text="V"></asp:TableCell>
                                    <asp:TableCell Text="230"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Napięcie znamionowe wzbudzenia"></asp:TableCell>
                                    <asp:TableCell Text="Ufn"></asp:TableCell>
                                    <asp:TableCell Text="V"></asp:TableCell>
                                    <asp:TableCell Text="230"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Prąd znamionowy twornika"></asp:TableCell>
                                    <asp:TableCell Text="Ia"></asp:TableCell>
                                    <asp:TableCell Text="A"></asp:TableCell>
                                    <asp:TableCell Text="5,2"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Prąd wzbudzenia"></asp:TableCell>
                                    <asp:TableCell Text="If"></asp:TableCell>
                                    <asp:TableCell Text="A"></asp:TableCell>
                                    <asp:TableCell Text="0,37"></asp:TableCell>
                                </asp:TableRow>                                
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Prędkość znamionowa"></asp:TableCell>
                                    <asp:TableCell Text="nn"></asp:TableCell>
                                    <asp:TableCell Text="obr/min"></asp:TableCell>
                                    <asp:TableCell Text="1450"></asp:TableCell>
                                </asp:TableRow>                                
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Rodzaj wzbudzenia"></asp:TableCell>
                                    <asp:TableCell Text=""></asp:TableCell>
                                    <asp:TableCell Text="obcowzbudne"></asp:TableCell>
                                    <asp:TableCell Text=""></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody" HorizontalAlign="Center" BackColor="transparent">
                                    <asp:TableCell Text="Numer seryjny"></asp:TableCell>
                                    <asp:TableCell Text=""></asp:TableCell>
                                    <asp:TableCell Text="ARBZc132SZ"></asp:TableCell>
                                    <asp:TableCell Text=""></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        <br />
                        </asp:Panel>
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
