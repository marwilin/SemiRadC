<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seminari.aspx.cs" Inherits="Aplikacija_Seminari" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seminari</title>
    <link rel="shortcut icon" href="http://algebra.hr/wp-content/uploads/2013/09/oua_16.png" type="image/x-icon" />
    <link href="Stylesheets/cssZaSeminar.css" rel="stylesheet" />
    <meta name="description" content="Seminarski rad" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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
            <h1 class="auto-style10"><strong><span class="auto-style3">Seminari</span></strong></h1>
            <hr />

            <div class="sadrzaj">
                Pretraga aktivnih i završenih seminara:<br />
                <asp:DropDownList ID="ddlPrikaz" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPrikaz_SelectedIndexChanged">
                    <asp:ListItem Value="1">Prikaz svih</asp:ListItem>
                    <asp:ListItem Value="2">Prikaz popunjenih</asp:ListItem>
                    <asp:ListItem Value="3">Prikaz slobodnih</asp:ListItem>
                </asp:DropDownList>

                <br />
                <br />

                <br />
                Seminari:
            <br />
                <asp:GridView ID="gvSeminari" runat="server" AutoGenerateColumns="False" DataKeyNames="IdSeminar"
                    OnRowCancelingEdit="gvSeminari_RowCancelingEdit" CellPadding="4" ForeColor="#333333"
                    OnRowEditing="gvSeminari_RowEditing" OnRowUpdating="gvSeminari_RowUpdating" OnRowDeleting="gvSeminari_RowDeleting1">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LkB1" runat="server" CommandName="Edit">Uredi</asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LB2" runat="server" CommandName="Update">Spremi</asp:LinkButton>
                                <asp:LinkButton ID="LB3" runat="server" CommandName="Cancel">Odustani</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Redni broj">
                            <ItemTemplate>
                                <asp:Label ID="IdSeminar" runat="server" Text='<%# Eval("IdSeminar") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Naziv">
                            <ItemTemplate>
                                <asp:Label ID="lblNaziv" runat="server" Text='<%# Eval("Naziv") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNaziv" runat="server" Text='<%# Eval("Naziv") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Opis">
                            <ItemTemplate>
                                <asp:Label ID="lblOpis" runat="server" Text='<%# Eval("Opis") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtOpis" runat="server" Text='<%# Eval("Opis") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Datum [mm-dd-yyyy]">
                            <ItemTemplate>
                                <asp:Label ID="lblDatum" runat="server" Text='<%# Eval("Datum","{0:MM/dd/yyyy HH:mm:ss}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDatum" runat="server" Text='<%# Eval("Datum","{0:MM/dd/yyyy HH:mm:ss}") %>'></asp:TextBox> 
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Broj prijava">
                            <ItemTemplate>
                                <asp:Label ID="lblBrojPrijava" runat="server" Text='<%# Eval("BrojPredbiljezbi") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Maksimalan broj prijava">
                            <ItemTemplate>
                                <asp:Label ID="lblMaxBrojPredbiljezbi" runat="server" Text='<%# Eval("MaxBrojPredbiljezbi") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>
                                <asp:TextBox ID="txtMaxBrojPredbiljezbi" runat="server" Text='<%# Eval("MaxBrojPredbiljezbi") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="chkStatus" runat="server" Text='<%# Boolean.Parse(Eval("Status").ToString()) ? "Nema mjesta" : "Ima mjesta" %>' Enabled="False"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:CommandField DeleteText="Obriši seminar" ShowDeleteButton="True" HeaderImageUrl="https://cdn0.iconfinder.com/data/icons/16x16-free-toolbar-icons/16/58.png">
                        <ItemStyle BackColor="#FF3300" ForeColor="White" HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                </asp:GridView>

                <br />
            </div>
            <asp:Button ID="btnDodaj" runat="server" Text="Dodaj seminar" Style="border-radius: 15px;" OnClick="btnDodaj_Click" />
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label><br />
            <br />
            <asp:TextBox ID="txtNaziv" runat="server" placeholder="Naziv seminara" Width="200px"></asp:TextBox><br />
            <asp:TextBox ID="txtOpis" runat="server" placeholder="Opis seminara" Width="200px"></asp:TextBox><br />
            <asp:TextBox ID="txtMaksimalanBrojPredbiljezbi" runat="server" Width="200px" placeholder="Maksimalan broj predbilježbi"></asp:TextBox><br />
            <%--<asp:TextBox ID="txtStatus" runat="server" placeholder="Status seminara" Width="200px"></asp:TextBox><br />--%>
            <br />
            <asp:TextBox ID="txtSati" runat="server" placeholder="Sati" Width="45px"></asp:TextBox>
            <asp:TextBox ID="txtMinute" runat="server" placeholder="Minute" Width="45px"></asp:TextBox>
            <asp:TextBox ID="txtSec" runat="server" placeholder="Sekunde" Width="112px"></asp:TextBox>
            <asp:Calendar ID="txtDatum" runat="server"></asp:Calendar>
            <br />
            <br />

        </div>

        <br />
        <br />
        <br />
    </form>
</body>
</html>
