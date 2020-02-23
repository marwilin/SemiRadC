<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Predbiljezba.aspx.cs" Inherits="Predbiljezba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Predbilježba</title>
    <link rel="shortcut icon" href="http://algebra.hr/wp-content/uploads/2013/09/oua_16.png" type="image/x-icon" />
    <link href="Stylesheets/cssZaSeminar.css" rel="stylesheet" />
</head>
<body runat="server" style="height: 656px; width: auto;">
    <div class="logo">
        <a href="/Aplikacija/Predbiljezba.aspx">
            <img src="https://pbs.twimg.com/profile_images/487581034561536002/TzVoq_nd.jpeg" alt="Algebra" height="122" />
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

            <table style="width: 100%; height: 420px;">
                <tr>
                    <td class="auto-style2" colspan="2">
                        <h1 class="auto-style10"><strong><span class="auto-style3">Predbilježba</span></strong></h1>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Pretraga po nazivu:
                        <asp:TextBox ID="txtPretraga" runat="server" Width="160px" Style="border-radius: 15px;"></asp:TextBox>
                        <asp:Button ID="btnPretrazi" Style="position: absolute; border-radius: 15px;" runat="server" OnClick="btnPretrazi_Click" Text="Pretraži" Width="58px" />

                    </td>
                    <td class="auto-style8">&nbsp;&nbsp;
                    <br />
                        <asp:Button ID="btnPrijava" runat="server" OnClick="btnPrijava_Click" Text="Prijava" Style="border-radius: 15px;" />
                        <br />
                        <span class="auto-style11">Samo za profesore!<br />
                        </span></td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:GridView ID="gvSeminari" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateSelectButton="true" GridLines="horizontal" OnSelectedIndexChanged="gvSeminari_SelectedIndexChanged" AutoGenerateColumns="False" style="text-decoration: none" BorderStyle="Solid">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="IdSeminar" HeaderText="Redni broj seminara" SortExpression="IdSeminar">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Naziv" HeaderText="Naziv" SortExpression="Naziv" />
                                <asp:BoundField DataField="Opis" HeaderText="Opis" SortExpression="Opis" />
                                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                        <br />
                        <br />
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style9">Ime:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:TextBox ID="txtIme" runat="server" Style="border-radius: 15px; margin-left: 5px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIme" runat="server" ControlToValidate="txtIme" ErrorMessage="Obavezno polje" ValidationGroup="Predbiljezba"></asp:RequiredFieldValidator>
                        <br />
                        Prezime:&nbsp;
                    <asp:TextBox ID="txtPrezime" runat="server" Style="border-radius: 15px; margin-left: 2px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrezime" runat="server" ControlToValidate="txtPrezime" ErrorMessage="Obavezno polje" ValidationGroup="Predbiljezba"></asp:RequiredFieldValidator>
                        <br />
                        Adresa:&nbsp;&nbsp;
                    <asp:TextBox ID="txtAdresa" runat="server" Style="border-radius: 15px; margin-left: 5px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAdresa" runat="server" ControlToValidate="txtAdresa" ErrorMessage="Obavezno polje" ValidationGroup="Predbiljezba"></asp:RequiredFieldValidator>
                        <br />
                        E-mail:&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Style="border-radius: 15px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Obavezno polje" ValidationGroup="Predbiljezba"></asp:RequiredFieldValidator>
                        &nbsp;
                    <br />
                        <br />
                        <asp:Label ID="lblOdabir" runat="server" Text="Odabrali ste seminar:" Visible="False"></asp:Label>
                        <br />
                        <div class="detailsViewPredbiljezbe">
                        <asp:DetailsView ID="dvDetalji" runat="server" Height="50px" Width="150px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateRows="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <EditRowStyle BackColor="#999999" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="IdSeminar" HeaderText="Redni broj seminara" />
                                <asp:BoundField DataField="Naziv" HeaderText="Naziv" />
                                <asp:BoundField DataField="Opis" HeaderText="Opis" />
                                <asp:BoundField DataField="Datum" HeaderText="Datum"/>
                            </Fields>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        </asp:DetailsView>
                            
                            </div>
                        <br />
                        <br />
                        <asp:Button ID="btnPosalji" runat="server" OnClick="btnPosalji_Click" Text="Pošalji predbilježbu" ValidationGroup="Predbiljezba" Style="border-radius: 15px;" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
