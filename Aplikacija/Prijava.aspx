<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prijava.aspx.cs" Inherits="Aplikacija_Prijava" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prijava</title>
    <link rel="shortcut icon" href="http://algebra.hr/wp-content/uploads/2013/09/oua_16.png" type="image/x-icon" />
    <link href="Stylesheets/cssZaSeminar.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style12 {
            width: 133px;
        }

        .auto-style13 {
            width: 190px;
        }
        .auto-style14 {
            width: 897px;
        }
    </style>
</head>
<body runat="server" style="height: 656px; width: auto;">
    <div class="logo">
        <a href="/Aplikacija/Predbiljezba.aspx">
            <img src="https://pbs.twimg.com/profile_images/487581034561536002/TzVoq_nd.jpeg" alt="Algebra logo" width="auto" height="122" />
        </a>
    </div>
    <form id="form1" runat="server">
        <div>
              <ul class="nav">
                <li><a href="/Aplikacija/Predbiljezba.aspx">Predbilježba</a></li>
                <li><a href="/Aplikacija/Predbiljezbe.aspx">Predbilježbe</a></li>
                <li><a href="/Aplikacija/Prijava.aspx">Prijava</a></li>
                <li><a href="/Aplikacija/Seminari.aspx">Seminari</a></li>
            </ul>
            <h1 class="auto-style10"><strong><span class="auto-style3">Prijava</span></strong></h1>
           
<hr />
            <div class="content">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style12">Korisničko ime:</td>
                        <td class="auto-style13">
                            <asp:TextBox ID="txtKorisnickoIme" runat="server" Width="190px" Style="border-radius: 15px;" ValidationGroup="loginValidation"></asp:TextBox>
                        </td>
                        <td class="auto-style14">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKorisnickoIme" ErrorMessage="Korisničko ime je obavezno!" ForeColor="Red" ValidationGroup="loginValidation">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12">Lozinka:</td>
                        <td class="auto-style13">
                            <asp:TextBox ID="txtLozinka" runat="server" Width="190px" Style="border-radius: 15px;" ValidationGroup="loginValidation" ToolTip="Ovdje unesite lozinku!" TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="auto-style14">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLozinka" ErrorMessage="Lozinka je obavezna!" ForeColor="Red" ValidationGroup="loginValidation">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12">&nbsp;</td>
                        <td class="auto-style13">
                            <asp:Button ID="btnPrijava" runat="server" Style="border-radius: 15px;" Text="Prijavi se" ValidationGroup="loginValidation" OnClick="btnPrijava_Click" />
                            <asp:Button ID="btnOdjava" runat="server" Style="border-radius: 15px;" Text="Odjavi se" OnClick="btnOdjava_Click" />
                        </td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                </table>
                <asp:Label ID="lblPotvrda" runat="server" Text=""></asp:Label>


              


                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="loginValidation" />

            </div>
              <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
