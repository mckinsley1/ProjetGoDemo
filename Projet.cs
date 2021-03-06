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
    
    public partial class Projet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projet()
        {
            this.BenevolesProjets = new HashSet<BenevolesProjet>();
            this.CampagneLeveeFonds = new HashSet<CampagneLeveeFond>();
            this.Fichiers = new HashSet<Fichier>();
            this.MembresProjets = new HashSet<MembresProjet>();
        }
    
        public int codeProjet { get; set; }
        public string titreProjet { get; set; }
        public string descriptionCourteProjet { get; set; }
        public string butProjet { get; set; }
        public string objectifProjet { get; set; }
        public string statutProjet { get; set; }
        public string beneficesEscomptees { get; set; }
        public Nullable<System.DateTime> dateDebutEstimeeProjet { get; set; }
        public Nullable<decimal> budgetProjet { get; set; }
        public Nullable<System.DateTime> dateDebutReelleProjet { get; set; }
        public Nullable<System.DateTime> dateFinReelleProjet { get; set; }
        public Nullable<int> codefichier { get; set; }
        public Nullable<int> codeProjetCompteRendu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BenevolesProjet> BenevolesProjets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampagneLeveeFond> CampagneLeveeFonds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fichier> Fichiers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MembresProjet> MembresProjets { get; set; }
        public virtual ProjetCompteRendu ProjetCompteRendu { get; set; }
    }

    public enum Statut
    {
        Proposé,
        Soumis,
        Approuvé,
        Refusé,
        Actif,
        Gelé, 
        Terminé
       
    }
}
