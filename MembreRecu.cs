//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetGo
{
    using System;
    using System.Collections.Generic;
    
    public partial class MembreRecu
    {
        public int codeRecuMembre { get; set; }
        public Nullable<System.DateTime> dateRecuMembre { get; set; }
        public Nullable<decimal> totalRecuMembre { get; set; }
        public Nullable<decimal> numeroCarteBancaire { get; set; }
    
        public virtual CarteBancaire CarteBancaire { get; set; }
    }
}
