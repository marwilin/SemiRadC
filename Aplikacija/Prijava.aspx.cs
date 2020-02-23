using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security;

public partial class Aplikacija_Prijava : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    bool zastavica = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        txtKorisnickoIme.Focus();
        conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["SeminarskiRad"].ToString();
        cmd = new SqlCommand();

        //za ispis korisnika koji je prijavljen
        if (Session["Zaposlenik"] != null)
            lblUser.Text = "Pozdrav: " + Session["Zaposlenik"].ToString();
    }



    protected void btnPrijava_Click(object sender, EventArgs e)
    {
        conn.Open();
        string provjeriKorisnika = "SELECT COUNT(*) from Zaposlenik where KorisnickoIme='" + txtKorisnickoIme.Text + "'";
        SqlCommand komanda = new SqlCommand(provjeriKorisnika, conn);
        int provjera = Convert.ToInt32(komanda.ExecuteScalar().ToString());
        conn.Close();
        if (provjera == 1)
        {
            conn.Open();
            string provjeraLozinke = "SELECT Lozinka from Zaposlenik where KorisnickoIme='" + txtKorisnickoIme.Text + "'";
            SqlCommand komandaLozinka = new SqlCommand(provjeraLozinke, conn);
            string lozinka = komandaLozinka.ExecuteScalar().ToString();
            if (lozinka == txtLozinka.Text)
            {
                Session["Zaposlenik"] = txtKorisnickoIme.Text;
                Response.Redirect("Predbiljezbe.aspx");
            }
            else
            {
                lblPotvrda.Text = "Lozinka nije točna!";
            }
        }
        else
        {
            lblPotvrda.Text = "Korisničko ime nije točno!";
        }
    }

    //logout button, ako je stisnut, dakle prebrise korisnika koji je prijavljen, ako nije nitko, ispise lblpotvrda i ako je netko prijavljen - ocisti sve i refresha
    protected void btnOdjava_Click(object sender, EventArgs e)
    {
        lblUser.Text = "";
        if (Session["Zaposlenik"] == null)
        {
            lblPotvrda.Text = "Morate se prijaviti da biste se odjavili!";
        }
        else
        {
            lblPotvrda.Text = "Odjavili ste se! Stranica će se sama osvježiti za 5 sekundi.";
            Session.Clear();
            Session.Abandon();
            Response.AppendHeader("REFRESH", "5;URL=Prijava.aspx");
        }

    }
}
