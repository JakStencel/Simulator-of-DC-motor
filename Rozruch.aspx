﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rozruch.aspx.cs" Inherits="Rozruch" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Aplikacja internetowa obwodowego symulatora silnika prądu stałego ARBZc132SZ</title>
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
                    <a href="Dydaktyka.aspx"><img src="img/004-agenda.png" style="margin-left:15px;"/> Dydaktyka</a>
                </li> 
                <li>
                    <a href="Kontakt.aspx"><img src="img/003-mail.png" style="margin-left:15px;"/> Kontakt</a>
                </li>
                <li id="rozwijane">
                    <a id="toggle_menu" href="#"><img src="img/007-bar-chart.png" style="margin-left:15px;"/> Symulacje</a>
                    <ul id="rozwijane_menu">
                        <li style="margin-left:-120px;padding-left:0px;"><a href="Bieg_jalowy.aspx"><img src="img/001-presentation.png" /> Bieg jałowy</a></li>
                        <li><a href="#"><img src="img/003-presentation.png" /> Rozruch</a></li>
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
                         <h2 style="color:darkgrey; margin-left:auto; margin-right:auto; text-align:center;">Symulator rozruchu silnika ARBZc132SZ</h2>
                         <br />
                            <asp:Image ID="imgRozruch" runat="server" AlternateText="schemat rozruchu" ImageUrl="~/img/schemat_rozruch.jpg" 
                                ImageAlign="Middle" HorizontalAlign="Center" Width="460px" Height="366px" 
                                style="margin-left:auto; margin-right:auto; text-align:center;"/>
                            <h6 style="margin-left:auto; margin-right:auto; text-align:center;">Schemat układu dla rozruchu silnika</h6>
                            <br />
                            <asp:Panel ID="validation" runat="server"  Width="600px"
                                    Visible="false"   HorizontalAlign="Center" Font-Size="10"
                                     BorderColor="dimgray" BorderStyle="Dotted" 
                                    style="margin-left:auto; margin-right:auto; text-align:center;">
                                <p>
                                <asp:Label ID="labErrorMessage" runat="server" Text="[tu wiadomosc]"  Font-Bold="true" ForeColor="Green"></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_time" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Voltage" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Reza" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Rezf" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Inda" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Indf" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Jr" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Dr" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p><p>
                                <asp:Label ID="labErrorMessage_Text" runat="server" Text="[tu wiadomosc]" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                </p>
                            </asp:Panel>
                    <!---------------------------------------Parametry-------------------------------------->
                            <asp:Panel ID="params" runat="server" HorizontalAlign="Center" style="margin-left:auto; margin-right:auto; text-align:center;">
                                <table style=" border-color: black; width:100%;">
                                    <tr>
                                        <td style="width:50%; padding-top:10px;"> 
                                            <fieldset style="width: 100%;">                                  
                                                <legend align="center"><b>Parametry czasowe</b></legend>
                                                <table style="border-color: black;">
                                                    <tr>
                                                        <td width="300px">Czas rozpoczęcia symulacji t<sub>min</sub></td>
                                                        <td width="40px"><asp:TextBox ID="txtTmin" runat="server" Width="40px" Text="0"></asp:TextBox></td>
                                                        <td>[s]</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Czas zakończenia symulacji t<sub>max</sub></td>
                                                        <td><asp:TextBox ID="txtTmax" runat="server" Width="40px" Text="4"></asp:TextBox></td>
                                                        <td>[s]</td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </table>
                                <table style=" border-color: black; width:100%;">
                                    <tr>
                                        <td rowspan="2" style="padding-top:10px;">
                                            <fieldset style="width: 100%; height:100%;" >
                                                <legend align="center"><b>Parametry zewnętrzne obwodów stojana i wzbudzenia</b></legend>
                                                <table style="border-color: black; margin-left:auto; 
                                                       margin-right:auto; text-align:center;">
                                                    <tr>
                                                        <td width="80px">Rezystancja obwodu twornika R<sub>a_add</sub>
                                                        </td>
                                                        <td width="40px">
                                                            <asp:TextBox ID="txtRa_ext" runat="server" Width="40px" Text="0"></asp:TextBox>
                                                        </td>
                                                        <td width="10px">[Ω]
                                                        </td>
                                                        <td width="80px">Rezystancja obwodu wzbudzenia R<sub>f_add</sub>
                                                        </td>
                                                        <td width="40px">
                                                            <asp:TextBox ID="txtRf_ext" runat="server" Width="40px" Text="0"></asp:TextBox>
                                                        </td>
                                                        <td width="10px">[Ω]
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Indukcyjność obwodu twornika M<sub>a_add</sub>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMa_ext" runat="server" Width="40px" Text="0"></asp:TextBox>
                                                        </td>
                                                        <td>[mH]
                                                        </td>
                                                        <td>Indukcyjność obwodu wzbudzenia M<sub>f_add</sub>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMf_ext" runat="server" Width="40px" Text="0"></asp:TextBox>
                                                        </td>
                                                        <td>[mH]
                                                        </td>
                                                    </tr>                                    
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </table>
                                <table style=" border-color: black; width:100%;">
                                    <tr>
                                        <td style="padding-top:10px;">
                                            <fieldset style="width: 100%;">
                                                <legend align="center"><b>Parametry zasilania </b></legend>
                                                <table style="border-color: black;">
                                                    <tr>
                                                        <td width="250px">Warość napięcia twornika U<sub>a</sub>
                                                        </td>
                                                        <td width="60px">
                                                            <asp:TextBox ID="txtUa" runat="server" Width="40px" Text="230"></asp:TextBox>
                                                        </td>
                                                        <td>[V]
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Warość napięcia wzbudzenia U<sub>f</sub>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUf" runat="server" Width="40px" Text="230"></asp:TextBox>
                                                        </td>
                                                        <td>[V]
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>   
                                        </td>
                                    </tr>
                                </table>
                                <br />            
                                <table style=" border-color: black; width:95%;">
                                    <tr>
                                        <td>
                                            <fieldset style="width: 90%">
                                                <legend align="center"><b>Ustawienia momentu zewnętrznego </b></legend>
                                                <table style=" border-color: black;">
                                                    <tr>
                                                        <td width="400px" rowspan="3"><asp:Image ID="imgMoment" runat="server" AlternateText="wykres momentu" ImageUrl="img/schemat_momentu.jpg" ImageAlign="Middle" width="90%" /> </td>
                                                        <td width="350px">Wartość momentu zewnętrznego T<sub>ext</sub></td>
                                                        <td width="50px"><asp:TextBox ID="txtText" runat="server" Width="40px" Text="0"></asp:TextBox></td>
                                                        <td>[Nm]</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Czas rozpoczęcia narastania momentu t<sub>1</sub></td>
                                                        <td><asp:TextBox ID="txtText_t1" runat="server" Width="40px" Text="0"></asp:TextBox></td>
                                                        <td>[s]</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Czas wyrównania momentu t<sub>2</sub></td>
                                                        <td><asp:TextBox ID="txtText_t2" runat="server" Width="40px" Text="0"></asp:TextBox></td>
                                                        <td>[s]</td>
                                                    </tr>
                                                </table>
                                             </fieldset>
                                           </td>
                                        </tr>
                                    </table>
                                    <table style=" border-color: black; width:95%;">
                                        <tr>
                                            <td style="padding-top:10px;">
                                                <fieldset style="width: 90%">
                                                    <legend align="center"><b>Parametry mechaniczne </b></legend>
                                                    <table style=" border-color: black;">
                                                        <tr>
                                                            <td width="450px" rowspan="3"> </td>
                                                            <td width="320px">Moment bezwładności J<sub>rext</sub></td>
                                                            <td width="60px"><asp:TextBox ID="txtJr_ext" runat="server" Width="40px" Text="0,07"></asp:TextBox></td>
                                                            <td>[kg*m<sup>2</sup>]</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Współczynnik tłumienia D<sub>rext</sub></td>
                                                            <td><asp:TextBox ID="txtDr_ext" runat="server" Width="40px" Text="0,01"></asp:TextBox></td>
                                                            <td>[(Nm*s)/rad]</td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
                             </asp:Panel>
                    </div>
                    <asp:Button ID="btnOblicz" runat="server" Text="Symulacja" OnClick="btnOblicz_Click" />
                    <br />
                    <br />
                    <br />
                    <!----------------------------------Wykresy--------------------------------->
                    <asp:Chart ID="Chart1" runat="server"  Height="300px" 
                                Width="721px" BackGradientStyle="TopBottom" style="margin-left:auto; 
                                margin-right:auto; text-align:center; align-items:center" >
                        <Titles>
                            <asp:Title Font="Segoe UI, 18pt, style=Bold" Text="Prądy przy rozruchu"></asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series ChartType="Spline" Name="Series1" BorderWidth="3">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Docking="Top"></asp:Legend>
                        </Legends>
                     </asp:Chart>

                     <asp:Chart ID="Chart2" runat="server" Height="237px" >
                        <Titles>
                            <asp:Title Font="Segoe UI, 18pt, style=Bold" Text="Prędkość kątowa oraz moment"></asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series ChartType="Spline" Name="Series1" BorderWidth="2">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Docking="Top"></asp:Legend>
                        </Legends>
                    </asp:Chart>
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

