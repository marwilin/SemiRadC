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

public partial class Aplikacija_Seminari : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //omogući ulaz onome koji se loginao na stranici prijave pomoću sessiona
        if (Session["Zaposlenik"] == null)
        {
            Response.Redirect("Prijava.aspx");

        }
        if (!IsPostBack) //prikaz svih seminara po defaultu
        {
            napuniSeminare();
        }
    }
    protected void napuniSeminare()
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
                    se.BrojPredbiljezbi = (int)reader["BrojPredbiljezbi"];
                    se.MaxBrojPredbiljezbi = (int)reader["MaxBrojPredbiljezbi"];
                    se.Status = (bool)reader["status"];

                    if (se.BrojPredbiljezbi == se.MaxBrojPredbiljezbi)
                    {
                        se.Status = true;
                    }

                    lista.Add(se);
                }


            }

            gvSeminari.DataSource = lista;
            gvSeminari.DataBind();

        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Stvarno sam loš, opet radim greške. Detalji: {0}", greska.Message);
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

    // kod dodavanja seminara, namjerno je maknut broj predbiljezbi jer je logično da je 0 ako je seminar tek dodan
    // isto tako nema smisla staviti ni status (kao što sam ja probao jel.. :D)

    protected void btnDodaj_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("INSERT INTO Seminar(Naziv, Opis, Datum, Status, BrojPredbiljezbi, MaxBrojPredbiljezbi) VALUES(@Naziv, @Opis, @Datum, @Status, @BrojPredbiljezbi, @MaxBrojPredbiljezbi)", conn);
        try
        {
            double hours = Double.Parse(txtSati.Text);
            double minutes = Double.Parse(txtMinute.Text);
            double seconds = Double.Parse(txtSec.Text);


            DateTime vrijeme = Convert.ToDateTime(txtDatum.SelectedDate);
            vrijeme = vrijeme.AddHours(hours);
            vrijeme = vrijeme.AddMinutes(minutes);
            vrijeme = vrijeme.AddSeconds(seconds);
            cmd.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
            cmd.Parameters.AddWithValue("@Opis", txtOpis.Text);
            cmd.Parameters.AddWithValue("@Datum", vrijeme);
            cmd.Parameters.AddWithValue("@BrojPredbiljezbi", Convert.ToInt32(0));
            cmd.Parameters.AddWithValue("@Status", (false));
            cmd.Parameters.AddWithValue("@MaxBrojPredbiljezbi", Convert.ToInt32(txtMaksimalanBrojPredbiljezbi.Text));
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Došlo je do neke greške. Detalji : {0}", greska.Message);
        }
        finally
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        lblStatus.Text = string.Format("Dodano u bazu!!!!!");
        txtNaziv.Text = txtOpis.Text = txtMaksimalanBrojPredbiljezbi.Text = txtSati.Text = txtMinute.Text = txtSec.Text = "";
    }

    private string ConnString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["SeminarskiRad"].ConnectionString;
        }
    }

    //punjenje drop down liste za potrebe filtriranja gridviewa
    protected void ddlPrikaz_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrikaz.SelectedValue == "1")
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
                        se.Status = (bool)reader["Status"];
                        se.BrojPredbiljezbi = (int)reader["BrojPredbiljezbi"];
                        se.MaxBrojPredbiljezbi = (int)reader["MaxBrojPredbiljezbi"];

                        if (se.BrojPredbiljezbi == se.MaxBrojPredbiljezbi)
                        {
                            se.Status = true;
                        }
                        lista.Add(se);

                    }
                    gvSeminari.DataSource = lista;
                    gvSeminari.DataBind();
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

        if (ddlPrikaz.SelectedValue == "3") //prikaz slobodnih
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
                        se.Status = (bool)reader["Status"];
                        se.BrojPredbiljezbi = (int)reader["BrojPredbiljezbi"];
                        se.MaxBrojPredbiljezbi = (int)reader["MaxBrojPredbiljezbi"];

                        if (se.BrojPredbiljezbi == se.MaxBrojPredbiljezbi)
                        {
                            se.Status = true;
                        }
                        if (se.Status == false)
                        {
                            lista.Add(se);
                        }


                    }

                    gvSeminari.DataSource = lista;
                    gvSeminari.DataBind();
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

        if (ddlPrikaz.SelectedValue == "2") // prikaz popunjenih
        {
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
                            if (se.Status == true)
                            {
                                lista.Add(se);
                            }


                        }
                        gvSeminari.DataSource = lista;
                        gvSeminari.DataBind();
                    }

                }
                catch (Exception greska)
                {
                    lblStatus.Text = string.Format("Došlo je do neke greškice kod prikaza popunjenih seminara. Detalji: {0}", greska.Message);
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
        }
    }

    //brisanje seminara iz reda kad se klikne Brisanje link-button
    protected void gvSeminari_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        object dohvatReda = gvSeminari.DataKeys[e.RowIndex].Values[0].ToString(); ;

        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("DELETE FROM Seminar WHERE IdSeminar=@IdSeminar", conn);
        try
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@IdSeminar", dohvatReda);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Hmm opet sam loše programirao, detalji: {0}.", greska.Message);
            DataBind();
        }
        gvSeminari.DataKeys[e.RowIndex].Values[0].ToString();
        gvSeminari.DataBind();
        Response.Redirect(Request.RawUrl);
    }

    protected void gvSeminari_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSeminari.EditIndex = e.NewEditIndex;
        napuniSeminare();
    }

    //kao i kod dodavanja seminara, nije moguce editirati broj prijava, te status, ali se max broj predbiljezbi moze editirati!
    protected void gvSeminari_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConnString);
        // find student id of edit row
        string IdSeminar = gvSeminari.DataKeys[e.RowIndex].Value.ToString();
        // find updated values for update
        TextBox naziv = (TextBox)gvSeminari.Rows[e.RowIndex].FindControl("txtNaziv");
        TextBox opis = (TextBox)gvSeminari.Rows[e.RowIndex].FindControl("txtOpis");
        TextBox datum = (TextBox)gvSeminari.Rows[e.RowIndex].FindControl("txtDatum");
        TextBox maxBrojPredb = (TextBox)gvSeminari.Rows[e.RowIndex].FindControl("txtMaxBrojPredbiljezbi");


        SqlCommand cmd = new SqlCommand("update Seminar set Naziv='" + naziv.Text + "', Opis = '" + opis.Text + "', Datum = '" + datum.Text + "', MaxBrojPredbiljezbi = '" + maxBrojPredb.Text + "' where IdSeminar = " + IdSeminar, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        gvSeminari.EditIndex = -1;
        ShowData();
    }

    protected void ShowData()
    {
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(ConnString);
        conn.Open();
        SqlDataAdapter adapt = new SqlDataAdapter("Select * from Seminar", conn);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            gvSeminari.DataSource = dt;
            gvSeminari.DataBind();
        }
        conn.Close();
    }

    protected void gvSeminari_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSeminari.EditIndex = -1;
        napuniSeminare();
    }

    protected void gvSeminari_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        object dohvatReda = gvSeminari.DataKeys[e.RowIndex].Values[0].ToString(); ;

        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand("DELETE FROM Seminar WHERE IdSeminar=@IdSeminar", conn);
        try
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@IdSeminar", dohvatReda);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception greska)
        {
            lblStatus.Text = string.Format("Hmm opet sam loše programirao, detalji: {0}.", greska.Message);
            DataBind();
        }
        gvSeminari.DataKeys[e.RowIndex].Values[0].ToString();
        gvSeminari.DataBind();
        Response.Redirect(Request.RawUrl);
    }
}