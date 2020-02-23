using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

public partial class Predbiljezba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DohvatiSeminare();

        }
    }
    protected void btnPosalji_Click(object sender, EventArgs e)
    {
        if (ViewState["seminar"] == null)
        {
            lblStatus.Text = "Molimo da izaberete seminar da biste se predbilježili!";
        }
        else
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("INSERT INTO Predbiljezba (Datum, Ime, Prezime, Adresa, Email, IdSeminar, Status) VALUES (@datum, @ime, @prezime, @adresa, @email, @IdSeminar, @status)", conn);
            cmd.Parameters.AddWithValue("@datum", DateTime.Now); // date, name, last name, adress, email, idseminar, status
            cmd.Parameters.AddWithValue("@ime", txtIme.Text);
            cmd.Parameters.AddWithValue("@prezime", txtPrezime.Text);
            cmd.Parameters.AddWithValue("@adresa", txtAdresa.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@IdSeminar", ViewState["seminar"]);
            cmd.Parameters.AddWithValue("@status", "Neobrađeno");



            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                lblStatus.Text = string.Format("Vaša predbilježba je unesena!");

                txtIme.Text = txtPrezime.Text = txtAdresa.Text = txtEmail.Text = "";
                txtIme.Focus();
            }
            catch (Exception greska)
            {
                lblStatus.Text = string.Format("Ups imam neku grešku i loš sam programer! Detalji: {0}", greska.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        //details view za popunjavanje 

        dvDetalji.DataSource = null;
        dvDetalji.DataBind();

        lblOdabir.Visible = false;

        ViewState["seminar"] = null;

        DohvatiSeminare();
    }
    protected void btnPrijava_Click(object sender, EventArgs e)
    {
        Response.Redirect("Prijava.aspx");
    }

    protected void DohvatiSeminare()
    {

        ArrayList lista = new ArrayList();

        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM Seminar", conn);
        SqlDataReader reader = null;
        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Seminar se = new Seminar();
                    se.IdSeminar = (int)reader["IdSeminar"];
                    se.Naziv = (string)reader["Naziv"];
                    se.Opis = (string)reader["Opis"];
                    se.Datum = (DateTime)reader["Datum"];
                    se.Status = (bool)reader["status"];
                    se.BrojPredbiljezbi = (int)reader["BrojPredbiljezbi"];
                    se.MaxBrojPredbiljezbi = (int)reader["MaxBrojPredbiljezbi"];
                    if (se.BrojPredbiljezbi == se.MaxBrojPredbiljezbi)
                    {
                        se.Status = true;
                    }
                    if (se.Status == false)
                        lista.Add(se);

                }

                gvSeminari.DataSource = lista;
                gvSeminari.DataBind();

                //za promijenu iz generickog Select u Odaberi
                foreach (GridViewRow row in gvSeminari.Rows)
                {
                    LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
                    lb.Text = "Odaberi";

                }
            }

        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Došlo je do neke greškice. Detalji: {0}", greska.Message);
        }
        finally
        {
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
    protected void btnPretrazi_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        if (txtPretraga.Text == "")
        {
            DohvatiSeminare();
        }
        else
        {
            ArrayList lista = new ArrayList();

            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Seminar WHERE naziv like @naziv", conn);
            string naziv = "%" + txtPretraga.Text + "%";
            cmd.Parameters.AddWithValue("@naziv", naziv);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Seminar se = new Seminar();
                    se.IdSeminar = (int)reader["IdSeminar"];
                    se.Naziv = (string)reader["Naziv"];
                    se.Opis = (string)reader["Opis"];
                    se.Datum = (DateTime)reader["Datum"];
                    se.Status = (bool)reader["status"];
                    se.BrojPredbiljezbi = (int)reader["BrojPredbiljezbi"];


                    if (se.Status == false)
                    {
                        lista.Add(se);
                    }
                }

                if (reader.IsClosed)
                {
                    reader.Close();
                }

            }
            catch (Exception greska)
            {
                lblStatus.Text = string.Format("Došlo je do greške jer sam loš programer... Detalji: {0}", greska.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }



            gvSeminari.DataSource = lista;
            gvSeminari.DataBind();

            foreach (GridViewRow row in gvSeminari.Rows)
            {
                LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
                lb.Text = "Odaberi";
            }
        }
    }
    private string ConnString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["SeminarskiRad"].ConnectionString;
        }
    }

    //SELECTirani seminar

    protected void gvSeminari_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList lista = new ArrayList();

        GridViewRow brojreda = gvSeminari.SelectedRow;

        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM seminar WHERE IdSeminar=@ids", conn);
        cmd.Parameters.AddWithValue("@ids", brojreda.Cells[1].Text);
        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Seminar se = new Seminar();
                se.IdSeminar = (int)reader["IdSeminar"];
                se.Naziv = (string)reader["Naziv"];
                se.Opis = (string)reader["Opis"];
                se.Datum = (DateTime)reader["Datum"];
                se.Status = (bool)reader["status"];
                se.BrojPredbiljezbi = (int)reader["BrojPredbiljezbi"];

                lista.Add(se);
            }
        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Došlo je do neke greške u odabiru. Detalji: {0}", greska.Message);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        //punim details View
        dvDetalji.DataSource = lista;
        dvDetalji.DataBind();

        lblOdabir.Visible = true;

        ViewState["seminar"] = int.Parse(brojreda.Cells[1].Text);
    }
}