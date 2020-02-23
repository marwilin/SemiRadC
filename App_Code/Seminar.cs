using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Seminar
/// </summary>
public class Seminar
{
    public Seminar()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int IdSeminar { get; set; }

    public string Naziv { get; set; }

    public string Opis { get; set; }

    public DateTime Datum { get; set; }

    public int MaxBrojPredbiljezbi { get; set; }

    public bool Status { get; set; }

    public int BrojPredbiljezbi { get; set; }

}