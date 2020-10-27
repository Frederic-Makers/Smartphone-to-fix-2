using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphone_to_fix
{
    class ReparationPhone
    {
        public String nom { get; set; }
        public String prenom { get; set; }
        public String contact { get; set; }
        public String modelPhone { get; set; }
        public String email { get; set; }     
        public String dateRecue { get; set; }
        public String status { get; set; }
        public String prix { get; set; }
        public String Description { get; set; }

        /*
        public ReparationPhone()
        {
            nom = "Ajouter un NOM";
            prenom = "un prénom";
            contact = "numero tel/phone";
            modelPhone = "Marque phone";
            email = "example@mail.com";
            dateRecue = "00/00/0000";
            Description = "Téléphone a réparé";
            status = "en réparation";
            prix = "non-rensegner";
        }
        */
        public ReparationPhone(String nom, String prenom, String contact, String modelPhone, String email, String dateRecue, String status, String prix, String Description)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.contact = contact;
            this.modelPhone = modelPhone;
            this.email = email;
            this.dateRecue = dateRecue;
            this.status = status;
            this.prix = prix;
            this.Description = Description;
        }

    }
    
}
