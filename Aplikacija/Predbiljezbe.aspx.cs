using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Collections;
using System.Data.SqlClient;

public partial class Aplikacija_Predbiljezbe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //omogući ulaz onome koji se loginao na stranici prijave pomoću sessiona
        if (Session["Zaposlenik"] == null)
        {
            Response.Redirect("Prijava.aspx");
        }
        if (!IsPostBack)
        {
            DohvatiPredbiljezbe();
            dvPredbiljezbe.DataSource = null;
        }
    }

    protected void DohvatiPredbiljezbe()
    {
        txtPretraga.Focus();
        ArrayList lista = new ArrayList();

        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM Predbiljezba", conn);
        SqlDataReader reader = null;
        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Predbiljezbe unos = new Predbiljezbe();
                    unos.IdPredbiljezba = (int)reader["IdPredbiljezba"];
                    unos.Datum = (DateTime)reader["Datum"];
                    unos.Ime = (string)reader["Ime"];
                    unos.Prezime = (string)reader["Prezime"];
                    unos.Adresa = (string)reader["Adresa"];
                    unos.IdSeminar = (int)reader["IdSeminar"];
                    unos.Status = (string)reader["Status"];
                    unos.email = (string)reader["Email"];

                    lista.Add(unos);
                }



            }
            gvPredbiljezbe.DataSource = lista;
            gvPredbiljezbe.DataBind();

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

    protected void ddlPrikazz_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlPrikazz.SelectedValue == "1") //prikaz svih
        {
            ArrayList lista = new ArrayList();

            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Predbiljezba", conn);
            SqlDataReader reader = null;


            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Predbiljezbe unos = new Predbiljezbe();
                    unos.IdPredbiljezba = (int)reader["IdPredbiljezba"];
                    unos.Datum = (DateTime)reader["Datum"];
                    unos.Ime = (string)reader["Ime"];
                    unos.Prezime = (string)reader["Prezime"];
                    unos.Adresa = (string)reader["Adresa"];
                    unos.IdSeminar = (int)reader["IdSeminar"];
                    unos.Status = (string)reader["Status"];
                    unos.email = (string)reader["Email"];


                    lista.Add(unos);
                }

            }
            gvPredbiljezbe.DataSource = lista;
            gvPredbiljezbe.DataBind();

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
        if (ddlPrikazz.SelectedValue == "2") //prikaz prihvaćenih
        {
            ArrayList lista = new ArrayList();

            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Predbiljezba where Status='Prihvaćeno'", conn);
            SqlDataReader reader = null;


            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Predbiljezbe unos2 = new Predbiljezbe();
                    unos2.IdPredbiljezba = (int)reader["IdPredbiljezba"];
                    unos2.Datum = (DateTime)reader["Datum"];
                    unos2.Ime = (string)reader["Ime"];
                    unos2.Prezime = (string)reader["Prezime"];
                    unos2.Adresa = (string)reader["Adresa"];
                    unos2.IdSeminar = (int)reader["IdSeminar"];
                    unos2.Status = (string)reader["Status"];
                    unos2.email = (string)reader["Email"];


                    lista.Add(unos2);
                }

            }
            gvPredbiljezbe.DataSource = lista;
            gvPredbiljezbe.DataBind();

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


        if (ddlPrikazz.SelectedValue == "3") //prikaz odbijenih
        {
            ArrayList lista = new ArrayList();

            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Predbiljezba where Status='Odbijeno'", conn);
            SqlDataReader reader = null;


            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Predbiljezbe unos3 = new Predbiljezbe();
                    unos3.IdPredbiljezba = (int)reader["IdPredbiljezba"];
                    unos3.Datum = (DateTime)reader["Datum"];
                    unos3.Ime = (string)reader["Ime"];
                    unos3.Prezime = (string)reader["Prezime"];
                    unos3.Adresa = (string)reader["Adresa"];
                    unos3.IdSeminar = (int)reader["IdSeminar"];
                    unos3.Status = (string)reader["Status"];
                    unos3.email = (string)reader["Email"];


                    lista.Add(unos3);
                }

            }
            gvPredbiljezbe.DataSource = lista;
            gvPredbiljezbe.DataBind();

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
        if (ddlPrikazz.SelectedValue == "4") //prikaz neobrađenih
        {
            ArrayList lista = new ArrayList();

            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Predbiljezba where Status='Neobrađeno'", conn);
            SqlDataReader reader = null;

            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Predbiljezbe unos4 = new Predbiljezbe();
                    unos4.IdPredbiljezba = (int)reader["IdPredbiljezba"];
                    unos4.Datum = (DateTime)reader["Datum"];
                    unos4.Ime = (string)reader["Ime"];
                    unos4.Prezime = (string)reader["Prezime"];
                    unos4.Adresa = (string)reader["Adresa"];
                    unos4.IdSeminar = (int)reader["IdSeminar"];
                    unos4.Status = (string)reader["Status"];
                    unos4.email = (string)reader["Email"];


                    lista.Add(unos4);
                }

            }
            gvPredbiljezbe.DataSource = lista;
            gvPredbiljezbe.DataBind();

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
    }

    public string ConnString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["SeminarskiRad"].ConnectionString;
        }
    }

    //accept button
    protected void btnPrihvaceno_Click(object sender, EventArgs e)
    {
        string prikazSeminara = dvPredbiljezbe.Rows[5].Cells[1].Text;
        string prikazPredbiljezbe = dvPredbiljezbe.Rows[0].Cells[1].Text;

        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("UPDATE Predbiljezba SET status='Prihvaćeno' WHERE idPredbiljezba=@ID", conn);
        cmd.Parameters.AddWithValue("@ID", prikazPredbiljezbe);

        try
        {
            conn.Open();

            int status = cmd.ExecuteNonQuery();

            lblStatus.Text = string.Format("Prihvatili ste odabranu predbiljezbu.");
            DohvatiPredbiljezbe();
        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Pojavila se neka greškica. Detalji: {0}", greska.Message);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                osvjezavanje(prikazSeminara);
            }
        }
    }
    protected void osvjezavanje(String prikazSeminara)
    {
        SqlConnection conn = new SqlConnection(ConnString);
        try
        {


            SqlCommand cmd = new SqlCommand("UPDATE Seminar SET BrojPredbiljezbi=(SELECT count(IdSeminar) as brojprihvacenih FROM Predbiljezba"
                                          + " where Status = 'Prihvaćeno' and IdSeminar = '" + prikazSeminara + "') where IdSeminar ='" + prikazSeminara + "'", conn);

            conn.Open();
            int status = cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            lblStatus.Text = string.Format("Pojavila se greška jer sam loš programer. Detalji: {0}", e.Message);
        }
        finally
        {
            conn.Close();
        }

    }


    //odbij button
    protected void btnOdbijeno_Click(object sender, EventArgs e)
    {
        string prikazSeminara = dvPredbiljezbe.Rows[5].Cells[1].Text;
        string prikazPredbiljezbe = dvPredbiljezbe.Rows[0].Cells[1].Text;

        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("UPDATE Predbiljezba SET status='Odbijeno' WHERE idPredbiljezba=@ID", conn);
        cmd.Parameters.AddWithValue("@ID", prikazPredbiljezbe);

        try
        {
            conn.Open();

            int status = cmd.ExecuteNonQuery();
            lblStatus.Text = string.Format("Odbili ste odabranu predbiljezbu.");
            DohvatiPredbiljezbe();
        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Pojavila se neka greškica. Detalji: {0}", greska.Message);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                brisanjeBrojaIzSeminara();
            }
        }
    }
    protected void brisanjeBrojaIzSeminara()
    {
        string prikazSeminara = dvPredbiljezbe.Rows[5].Cells[1].Text;
        string prikazPredbiljezbe = dvPredbiljezbe.Rows[0].Cells[1].Text;
        SqlConnection conn = new SqlConnection(ConnString);
        try
        {


            SqlCommand cmd = new SqlCommand("UPDATE Seminar SET BrojPredbiljezbi=(SELECT count(IdSeminar) as brojprihvacenih FROM Predbiljezba"
                                          + " where Status = 'Prihvaćeno' and IdSeminar = '" + prikazSeminara + "') where IdSeminar ='" + prikazSeminara + "'", conn);

            conn.Open();
            int status = cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            lblStatus.Text = string.Format("Pojavila se greška jer sam loš programer. Detalji: {0}", e.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void gvPredbiljezbe_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow brojreda = gvPredbiljezbe.SelectedRow;

        DataTable podaci = new DataTable();

        SqlConnection conn = new SqlConnection(ConnString);
        SqlDataAdapter adap = new SqlDataAdapter();

        adap.SelectCommand = new SqlCommand("SELECT * FROM predbiljezba WHERE IdPredbiljezba=@ids", conn);
        adap.SelectCommand.Parameters.AddWithValue("@ids", brojreda.Cells[1].Text);
        adap.Fill(podaci);

        dvPredbiljezbe.DataSource = podaci;
        dvPredbiljezbe.DataBind();

        btnOdbijeno.Enabled = true;
        btnPrihvaceno.Enabled = true;

        lblStatus.Text = "";
        ViewState["stud"] = int.Parse(brojreda.Cells[1].Text);
        DohvatiPredbiljezbe();
    }

    protected void btnPrikazi_Click(object sender, EventArgs e)
    {

        lblStatus.Text = "";
        if (txtPretraga.Text == "")
        {
            DohvatiPredbiljezbe();
        }
        else
        {
            ArrayList lista = new ArrayList();

            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Predbiljezba WHERE Prezime like @Prezime", conn);
            string prezime = "%" + txtPretraga.Text + "%";
            cmd.Parameters.AddWithValue("@Prezime", prezime);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Predbiljezbe predbiljezba = new Predbiljezbe();
                    predbiljezba.IdPredbiljezba = (int)reader["IdPredbiljezba"];
                    predbiljezba.Datum = (DateTime)reader["Datum"];
                    predbiljezba.Ime = (string)reader["Ime"];
                    predbiljezba.Prezime = (string)reader["Prezime"];
                    predbiljezba.Adresa = (string)reader["Adresa"];
                    predbiljezba.IdSeminar = (int)reader["IdSeminar"];
                    predbiljezba.Status = (string)reader["Status"];
                    predbiljezba.email = (string)reader["Email"];

                    lista.Add(predbiljezba);
                }

                if (reader.IsClosed)
                {
                    reader.Close();
                }

            }
            catch (Exception greska)
            {
                lblStatus.Text = string.Format("Došlo je do greške. Detalji: {0}", greska.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            gvPredbiljezbe.DataSource = lista;
            gvPredbiljezbe.DataBind();
        }
    }
}