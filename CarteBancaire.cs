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
    
    public partial class CarteBancaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarteBancaire()
        {
            this.MembreRecus = new HashSet<MembreRecu>();
        }
    
        public decimal numeroCarteBancaire { get; set; }
        public Nullable<System.DateTime> dateExpirationCateBancaire { get; set; }
        public string nomDetenteurCarteBancaire { get; set; }
        public string adresseDetenteurCarteBaincaire { get; set; }
        public string villeDetenteurCarteBaincaire { get; set; }
        public string provinceDetenteurCarteBaincaire { get; set; }
        public string cpDetenteurCarteBaincaire { get; set; }
        public string numeroControleCarteBancaire { get; set; }
        public Nullable<int> codeMembre { get; set; }
    
        public virtual Membre Membre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MembreRecu> MembreRecus { get; set; }
    }
}
