using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Predbiljezba
/// </summary>
public class Predbiljezbe
{
    public Predbiljezbe()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int IdPredbiljezba { get; set; }

    public DateTime Datum { get; set; }

    public string Ime { get; set; }

    public string Prezime { get; set; }

    public string Adresa { get; set; }

    public int IdSeminar { get; set; }

    public string Status { get; set; }

    public string email { get; set; }
}