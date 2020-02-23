<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Predbiljezbe.aspx.cs" Inherits="Aplikacija_Predbiljezbe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Predbilježbe</title>
    <link rel="shortcut icon" href="http://algebra.hr/wp-content/uploads/2013/09/oua_16.png" type="image/x-icon" />
    <link href="Stylesheets/cssZaSeminar.css" rel="stylesheet" />
    <meta name="Seminarski rad" content="Prijava studenata na seminare" />
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
            <h1 class="auto-style10"><strong><span class="auto-style3">Predbilježbe</span></strong></h1>
            <hr />
            <div class="sadrzaj">Traži po prezimenu:<asp:TextBox ID="txtPretraga" runat="server" Style="border-radius: 15px;"></asp:TextBox><asp:Button ID="btnPrikazi" runat="server" Text="Pretraži" Style="border-radius: 15px;" OnClick="btnPrikazi_Click" /></div>
            <br />
            <asp:DropDownList ID="ddlPrikazz" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPrikazz_SelectedIndexChanged">
                <asp:ListItem Value="1" Selected="True">Prikaz svih</asp:ListItem>
                <asp:ListItem Value="2">Prikaz prihvaćenih</asp:ListItem>
                <asp:ListItem Value="3">Prikaz odbijenih</asp:ListItem>
                <asp:ListItem Value="4">Prikaz neobrađenih</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="gvPredbiljezbe" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdPredbiljezba" ForeColor="#333333" BorderStyle="Solid" GridLines="horizontal" Style="margin-right: 0" OnSelectedIndexChanged="gvPredbiljezbe_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField SelectText="Odaberi" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdPredbiljezba" HeaderText="Redni broj predbiljezbe" ReadOnly="True" SortExpression="IdPredbiljezba">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                    <asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime">
                        <HeaderStyle Width="90px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" SortExpression="Prezime">
                        <HeaderStyle Width="90px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Adresa" HeaderText="Adresa" SortExpression="Adresa">
                        <HeaderStyle Width="90px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdSeminar" HeaderText="Redni broj seminara" SortExpression="IdSeminar">
                        <HeaderStyle Width="90px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                        <HeaderStyle Width="90px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email">
                        <HeaderStyle Width="90px" />
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

        </div>
        <br />
        <br />
        <asp:Button ID="btnPrihvaceno" runat="server" Text="Prihvaćeno" Style="border-radius: 15px;" Enabled="false" OnClick="btnPrihvaceno_Click" />
        <asp:Button ID="btnOdbijeno" runat="server" Text="Odbijeno" Style="border-radius: 15px;" Enabled="False" OnClick="btnOdbijeno_Click" />
        <br />
         <br />
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <div class="detailsViewPredbiljezbe">
            <asp:DetailsView ID="dvPredbiljezbe" runat="server" Height="50px" Width="125px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateRows="False">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <EditRowStyle BackColor="#999999" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="IdPredbiljezba" HeaderText="Broj predbiljezbe">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Datum" HeaderText="Datum"  >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ime" HeaderText="Ime" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Adresa" HeaderText="Adresa" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdSeminar" HeaderText="Redni broj seminara" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="E-mail" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Fields>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:DetailsView>
        </div>

        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
