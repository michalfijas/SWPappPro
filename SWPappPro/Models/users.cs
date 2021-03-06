//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SWPappPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public partial class users
    {
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }


    //metoda do sprawdzania danych logowania
    public bool ValidateUser(users entity, HttpContextBase current)
        {

            var db = new SWPappDBEntities5();
            //pobranie z bazy danych rekordu o nazwie uzytkownika takiej jak podanej w entity(czyli danych z formularza)
            var pass = db.users.Where(s => s.username == entity.username.Trim()).FirstOrDefault();
            //jesli rekord istnieje
            if (pass != null)
            {
                //por�wnanie hase�
                if (entity.password.Equals(pass.password.Trim()))
                {
                    //ustawienie odpowiednich zmiennych sesji
                    if (pass.type.Trim().Equals("lekarz"))
                    {
                        current.Session["typ"] = "lekarz";
                    }
                    else
                    {
                        current.Session["typ"] = "pacjent";
                    }
                    current.Session["login"] = pass.username;
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }  
        }
    }

}
