using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ENAapp.tab
{
    public partial class bd_entContext : DbContext
    {
        public bd_entContext()
        {
        }

        public bd_entContext(DbContextOptions<bd_entContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Commentaire> Commentaire { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Emprunt> Emprunt { get; set; }
        public virtual DbSet<Etudiant> Etudiant { get; set; }
        public virtual DbSet<Filiere> Filiere { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Inscrit> Inscrit { get; set; }
        public virtual DbSet<Jour> Jour { get; set; }
        public virtual DbSet<Mention> Mention { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Moyennes> Moyennes { get; set; }
        public virtual DbSet<Nationalite> Nationalite { get; set; }
        public virtual DbSet<Niveau> Niveau { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Ouvrage> Ouvrage { get; set; }
        public virtual DbSet<Periode> Periode { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Programme> Programme { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Resultat> Resultat { get; set; }
        public virtual DbSet<Salle> Salle { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }
        public virtual DbSet<Specialite> Specialite { get; set; }
        public virtual DbSet<Time> Time { get; set; }
        public virtual DbSet<Typeevaluation> Typeevaluation { get; set; }
        public virtual DbSet<Ue> Ue { get; set; }
        public virtual DbSet<Vue> Vue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost; port=3306; database=bd_ent; user=root; password=david");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("categorie");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.Idclasse);

                entity.ToTable("classe");

                entity.HasIndex(e => e.Codgrade)
                    .HasName("CODGRADE");

                entity.HasIndex(e => e.Idspecialite)
                    .HasName("IDSPECIALITE");

                entity.HasIndex(e => new { e.Idfiliere, e.Codgrade, e.Niveau, e.Idspecialite })
                    .HasName("IDFILIERE")
                    .IsUnique();

                entity.Property(e => e.Idclasse)
                    .HasColumnName("IDCLASSE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codgrade)
                    .IsRequired()
                    .HasColumnName("CODGRADE")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Idfiliere)
                    .HasColumnName("IDFILIERE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idspecialite)
                    .HasColumnName("IDSPECIALITE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Niveau)
                    .IsRequired()
                    .HasColumnName("NIVEAU")
                    .HasColumnType("varchar(10)");

                entity.HasOne(d => d.CodgradeNavigation)
                    .WithMany(p => p.Classe)
                    .HasForeignKey(d => d.Codgrade)
                    .HasConstraintName("classe_ibfk_2");

                entity.HasOne(d => d.IdfiliereNavigation)
                    .WithMany(p => p.Classe)
                    .HasForeignKey(d => d.Idfiliere)
                    .HasConstraintName("classe_ibfk_zz");
            });

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.ToTable("commentaire");

                entity.HasIndex(e => e.Matricule)
                    .HasName("matricule");

                entity.HasIndex(e => e.Ouvrage)
                    .HasName("commentaire_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contenu)
                    .IsRequired()
                    .HasColumnName("contenu")
                    .HasColumnType("text");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Matricule)
                    .IsRequired()
                    .HasColumnName("matricule")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Ouvrage)
                    .HasColumnName("ouvrage")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Commentaire)
                    .HasForeignKey(d => d.Matricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commentaire_ibfk_2");

                entity.HasOne(d => d.OuvrageNavigation)
                    .WithMany(p => p.Commentaire)
                    .HasForeignKey(d => d.Ouvrage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commentaire_ibfk_1");
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.ToTable("compte");

                entity.HasIndex(e => e.Matricule)
                    .HasName("matricule");

                entity.HasIndex(e => e.Profil)
                    .HasName("profil");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConfirmatAt)
                    .HasColumnName("confirmat_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConfirmationToken)
                    .HasColumnName("confirmation_token")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Imgsrc)
                    .HasColumnName("imgsrc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Matricule)
                    .IsRequired()
                    .HasColumnName("matricule")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Passhash)
                    .IsRequired()
                    .HasColumnName("passhash")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Profil)
                    .HasColumnName("profil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ResetAt)
                    .HasColumnName("reset_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetToken)
                    .HasColumnName("reset_token")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Compte)
                    .HasForeignKey(d => d.Matricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compte_ibfk_1");

                entity.HasOne(d => d.ProfilNavigation)
                    .WithMany(p => p.Compte)
                    .HasForeignKey(d => d.Profil)
                    .HasConstraintName("compte_ibfk_2");
            });

            modelBuilder.Entity<Emprunt>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Etudiant, e.Ouvrage });

                entity.ToTable("emprunt");

                entity.HasIndex(e => e.Etudiant)
                    .HasName("etudiant");

                entity.HasIndex(e => e.Ouvrage)
                    .HasName("emprunt_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Etudiant)
                    .HasColumnName("etudiant")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Ouvrage)
                    .HasColumnName("ouvrage")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateEmprunt)
                    .HasColumnName("dateEmprunt")
                    .HasColumnType("date");

                entity.Property(e => e.DateRetourEff)
                    .HasColumnName("dateRetourEff")
                    .HasColumnType("date");

                entity.Property(e => e.DateRetourTheo)
                    .HasColumnName("dateRetourTheo")
                    .HasColumnType("date");

                entity.Property(e => e.NbAvertissements)
                    .HasColumnName("nbAvertissements")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Statut)
                    .IsRequired()
                    .HasColumnName("statut")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.EtudiantNavigation)
                    .WithMany(p => p.Emprunt)
                    .HasForeignKey(d => d.Etudiant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emprunt_ibfk_2");

                entity.HasOne(d => d.OuvrageNavigation)
                    .WithMany(p => p.Emprunt)
                    .HasForeignKey(d => d.Ouvrage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emprunt_ibfk_1");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.HasKey(e => e.Matricule);

                entity.ToTable("etudiant");

                entity.HasIndex(e => e.Codnat)
                    .HasName("CODNAT");

                entity.HasIndex(e => e.Codprovince)
                    .HasName("CODPROVINCE");

                entity.Property(e => e.Matricule)
                    .HasColumnName("MATRICULE")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Adresse)
                    .HasColumnName("ADRESSE")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Codnat)
                    .HasColumnName("CODNAT")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Codprovince)
                    .HasColumnName("CODPROVINCE")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Dateins)
                    .HasColumnName("DATEINS")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datenaissance)
                    .HasColumnName("DATENAISSANCE")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Diplome)
                    .HasColumnName("DIPLOME")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Handicape)
                    .HasColumnName("handicape")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Langue)
                    .HasColumnName("LANGUE")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Mere)
                    .HasColumnName("MERE")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Pere)
                    .HasColumnName("PERE")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Refugie)
                    .HasColumnName("REFUGIE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Session)
                    .HasColumnName("SESSION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sexe)
                    .IsRequired()
                    .HasColumnName("SEXE")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Villenaissance)
                    .HasColumnName("VILLENAISSANCE")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.CodnatNavigation)
                    .WithMany(p => p.Etudiant)
                    .HasForeignKey(d => d.Codnat)
                    .HasConstraintName("etudiant_ibfk_1");

                entity.HasOne(d => d.CodprovinceNavigation)
                    .WithMany(p => p.Etudiant)
                    .HasForeignKey(d => d.Codprovince)
                    .HasConstraintName("etudiant_ibfk_2");
            });

            modelBuilder.Entity<Filiere>(entity =>
            {
                entity.HasKey(e => e.Idfiliere);

                entity.ToTable("filiere");

                entity.HasIndex(e => e.Codfiliere)
                    .HasName("filiere_index1402")
                    .IsUnique();

                entity.Property(e => e.Idfiliere)
                    .HasColumnName("IDFILIERE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codfiliere)
                    .IsRequired()
                    .HasColumnName("CODFILIERE")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.Codgrade);

                entity.ToTable("grade");

                entity.Property(e => e.Codgrade)
                    .HasColumnName("CODGRADE")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Intitule)
                    .HasColumnName("INTITULE")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Inscrit>(entity =>
            {
                entity.HasKey(e => new { e.Idclasse, e.Matricule, e.Annee });

                entity.ToTable("inscrit");

                entity.HasIndex(e => e.Annee)
                    .HasName("ANNEE");

                entity.HasIndex(e => e.Idclasse)
                    .HasName("IDCLASSE");

                entity.HasIndex(e => e.Matricule)
                    .HasName("MATRICULE");

                entity.Property(e => e.Idclasse)
                    .HasColumnName("IDCLASSE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Matricule)
                    .HasColumnName("MATRICULE")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Annee)
                    .HasColumnName("ANNEE")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdclasseNavigation)
                    .WithMany(p => p.Inscrit)
                    .HasForeignKey(d => d.Idclasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resultat_ibfk_j");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Inscrit)
                    .HasForeignKey(d => d.Matricule)
                    .HasConstraintName("resultat_ibfk_jj");
            });

            modelBuilder.Entity<Jour>(entity =>
            {
                entity.ToTable("jour");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Mention>(entity =>
            {
                entity.HasKey(e => new { e.Codmention, e.Valeurmin });

                entity.ToTable("mention");

                entity.Property(e => e.Codmention)
                    .HasColumnName("CODMENTION")
                    .HasColumnType("char(3)");

                entity.Property(e => e.Valeurmin)
                    .HasColumnName("VALEURMIN")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Etat)
                    .HasColumnName("ETAT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Qualitepoints)
                    .HasColumnName("QUALITEPOINTS")
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Valeurmax)
                    .HasColumnName("VALEURMAX")
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("module");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Route)
                    .HasColumnName("route")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Moyennes>(entity =>
            {
                entity.HasKey(e => new { e.Matricule, e.Idue, e.Idsemestre, e.Annee });

                entity.ToTable("moyennes");

                entity.HasIndex(e => e.Annee)
                    .HasName("ANNEE");

                entity.HasIndex(e => e.Codmention)
                    .HasName("FK_moyennes_3");

                entity.HasIndex(e => e.Idsemestre)
                    .HasName("IDSEMESTRE");

                entity.HasIndex(e => e.Idue)
                    .HasName("IDUE");

                entity.HasIndex(e => e.Matricule)
                    .HasName("MATRICULE");

                entity.HasIndex(e => e.Moyenne)
                    .HasName("MOYENNE");

                entity.Property(e => e.Matricule)
                    .HasColumnName("MATRICULE")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Idue).HasColumnName("IDUE");

                entity.Property(e => e.Idsemestre)
                    .HasColumnName("IDSEMESTRE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Annee)
                    .HasColumnName("ANNEE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codmention)
                    .HasColumnName("CODMENTION")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Credit)
                    .HasColumnName("CREDIT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Decision)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasDefaultValueSql("'NC'");

                entity.Property(e => e.Moyenne)
                    .HasColumnName("MOYENNE")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.QdP)
                    .HasColumnType("decimal(6,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.IdsemestreNavigation)
                    .WithMany(p => p.Moyennes)
                    .HasForeignKey(d => d.Idsemestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resultage");

                entity.HasOne(d => d.IdueNavigation)
                    .WithMany(p => p.Moyennes)
                    .HasForeignKey(d => d.Idue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resultatl");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Moyennes)
                    .HasForeignKey(d => d.Matricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resultag");
            });

            modelBuilder.Entity<Nationalite>(entity =>
            {
                entity.HasKey(e => e.Codnat);

                entity.ToTable("nationalite");

                entity.Property(e => e.Codnat)
                    .HasColumnName("CODNAT")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Pays)
                    .IsRequired()
                    .HasColumnName("PAYS")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Niveau>(entity =>
            {
                entity.HasKey(e => e.Niveau1);

                entity.ToTable("niveau");

                entity.Property(e => e.Niveau1)
                    .HasColumnName("NIVEAU")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => new { e.Idue, e.Matricule, e.Codeevaluation, e.Idsemestre, e.Annee });

                entity.ToTable("notes");

                entity.HasIndex(e => e.Annee)
                    .HasName("ANNEE");

                entity.HasIndex(e => e.Codeevaluation)
                    .HasName("CODEEVALUATION");

                entity.HasIndex(e => e.Idsemestre)
                    .HasName("IDSEMESTRE");

                entity.HasIndex(e => e.Idue)
                    .HasName("IDUE");

                entity.HasIndex(e => e.Matricule)
                    .HasName("MATRICULE");

                entity.Property(e => e.Idue).HasColumnName("IDUE");

                entity.Property(e => e.Matricule)
                    .HasColumnName("MATRICULE")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Codeevaluation)
                    .HasColumnName("CODEEVALUATION")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Idsemestre)
                    .HasColumnName("IDSEMESTRE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Annee)
                    .HasColumnName("ANNEE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Anonymat)
                    .HasColumnName("ANONYMAT")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Note)
                    .HasColumnName("NOTE")
                    .HasColumnType("decimal(12,9)");

                entity.HasOne(d => d.IdsemestreNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.Idsemestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notes_ibfk_3");

                entity.HasOne(d => d.IdueNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.Idue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notes_ibfk_1");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.Matricule)
                    .HasConstraintName("notes_ibfk_2");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notification");

                entity.HasIndex(e => e.Matricule)
                    .HasName("notification_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Matricule)
                    .IsRequired()
                    .HasColumnName("matricule")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Objet)
                    .HasColumnName("objet")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Sms)
                    .HasColumnName("sms")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.Matricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notification_ibfk_1");
            });

            modelBuilder.Entity<Ouvrage>(entity =>
            {
                entity.ToTable("ouvrage");

                entity.HasIndex(e => e.IdCategorie)
                    .HasName("idCategorie");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnneePublication)
                    .HasColumnName("anneePublication")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Auteur)
                    .IsRequired()
                    .HasColumnName("auteur")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Discipline)
                    .IsRequired()
                    .HasColumnName("discipline")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.IdCategorie)
                    .HasColumnName("idCategorie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImgCouverture).HasColumnType("varchar(16)");

                entity.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Titre)
                    .IsRequired()
                    .HasColumnName("titre")
                    .HasColumnType("varchar(60)");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Ouvrage)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ouvrage_ibfk_1");
            });

            modelBuilder.Entity<Periode>(entity =>
            {
                entity.ToTable("periode");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HeureDebut)
                    .HasColumnName("heure_debut")
                    .HasColumnType("int(2)");

                entity.Property(e => e.HeureFin)
                    .HasColumnName("heure_fin")
                    .HasColumnType("int(2)");

                entity.Property(e => e.MinuteDebut)
                    .HasColumnName("minute_debut")
                    .HasColumnType("int(2)");

                entity.Property(e => e.MinuteFin)
                    .HasColumnName("minute_fin")
                    .HasColumnType("int(2)");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Programme>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Idclasse, e.Semestre, e.Annee, e.Idue });

                entity.ToTable("programme");

                entity.HasIndex(e => e.Enseignant)
                    .HasName("enseignant");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.HasIndex(e => e.Idclasse)
                    .HasName("idclasse");

                entity.HasIndex(e => e.Idue)
                    .HasName("idue");

                entity.HasIndex(e => e.Semestre)
                    .HasName("semestre");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idclasse)
                    .HasColumnName("idclasse")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Semestre)
                    .HasColumnName("semestre")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Annee)
                    .HasColumnName("annee")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Idue)
                    .HasColumnName("idue")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Categorie)
                    .HasColumnName("categorie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Enseignant)
                    .HasColumnName("enseignant")
                    .HasColumnType("varchar(15)");

                entity.HasOne(d => d.EnseignantNavigation)
                    .WithMany(p => p.Programme)
                    .HasForeignKey(d => d.Enseignant)
                    .HasConstraintName("programme_ibfk_3");

                entity.HasOne(d => d.IdclasseNavigation)
                    .WithMany(p => p.Programme)
                    .HasForeignKey(d => d.Idclasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("programme_ibfk_1");

                entity.HasOne(d => d.IdueNavigation)
                    .WithMany(p => p.Programme)
                    .HasForeignKey(d => d.Idue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("programme_ibfk_4");

                entity.HasOne(d => d.SemestreNavigation)
                    .WithMany(p => p.Programme)
                    .HasForeignKey(d => d.Semestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("programme_ibfk_2");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Codprovince);

                entity.ToTable("province");

                entity.Property(e => e.Codprovince)
                    .HasColumnName("CODPROVINCE")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Nomprovince)
                    .IsRequired()
                    .HasColumnName("NOMPROVINCE")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Provname)
                    .HasColumnName("PROVNAME")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Resultat>(entity =>
            {
                entity.HasKey(e => new { e.Idclasse, e.Matricule, e.Annee, e.Semestre });

                entity.ToTable("resultat");

                entity.HasIndex(e => e.Grade)
                    .HasName("resultat_ik_2");

                entity.HasIndex(e => e.Matricule)
                    .HasName("MATRICULE");

                entity.HasIndex(e => e.Semestre)
                    .HasName("resultat_ibkgg_2");

                entity.Property(e => e.Idclasse)
                    .HasColumnName("IDCLASSE")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Matricule)
                    .HasColumnName("MATRICULE")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Annee)
                    .HasColumnName("ANNEE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Semestre)
                    .HasColumnName("SEMESTRE")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.Creditcap)
                    .HasColumnName("CREDITCAP")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Creditchoisis)
                    .HasColumnName("CREDITCHOISIS")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Decision)
                    .HasColumnName("DECISION")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Grade)
                    .HasColumnName("GRADE")
                    .HasColumnType("varchar(11)")
                    .HasDefaultValueSql("'L'");

                entity.Property(e => e.Mgp)
                    .HasColumnName("MGP")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Newgrade)
                    .HasColumnName("NEWGRADE")
                    .HasColumnType("varchar(11)")
                    .HasDefaultValueSql("'L'");

                entity.Property(e => e.Newidclasse)
                    .HasColumnName("NEWIDCLASSE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pourcentcap)
                    .HasColumnName("POURCENTCAP")
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.GradeNavigation)
                    .WithMany(p => p.Resultat)
                    .HasForeignKey(d => d.Grade)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("resultat_ik_2");

                entity.HasOne(d => d.IdclasseNavigation)
                    .WithMany(p => p.Resultat)
                    .HasForeignKey(d => d.Idclasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resultat_ibfk_1");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Resultat)
                    .HasForeignKey(d => d.Matricule)
                    .HasConstraintName("resultat_ibfk_2");

                entity.HasOne(d => d.SemestreNavigation)
                    .WithMany(p => p.Resultat)
                    .HasForeignKey(d => d.Semestre)
                    .HasConstraintName("resultat_ibkgg_2");
            });

            modelBuilder.Entity<Salle>(entity =>
            {
                entity.ToTable("salle");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Capacite).HasColumnName("capacite");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Semestre>(entity =>
            {
                entity.HasKey(e => e.Idsemestre);

                entity.ToTable("semestre");

                entity.Property(e => e.Idsemestre)
                    .HasColumnName("IDSEMESTRE")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasKey(e => e.Idspecialite);

                entity.ToTable("specialite");

                entity.HasIndex(e => e.Idfiliere)
                    .HasName("IDFILIERE");

                entity.HasIndex(e => new { e.Codspecialite, e.Idfiliere })
                    .HasName("options_index1395")
                    .IsUnique();

                entity.Property(e => e.Idspecialite)
                    .HasColumnName("IDSPECIALITE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codspecialite)
                    .IsRequired()
                    .HasColumnName("CODSPECIALITE")
                    .HasColumnType("varchar(14)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Entitle)
                    .HasColumnName("ENTITLE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Idfiliere)
                    .HasColumnName("IDFILIERE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Intitule)
                    .IsRequired()
                    .HasColumnName("INTITULE")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdfiliereNavigation)
                    .WithMany(p => p.Specialite)
                    .HasForeignKey(d => d.Idfiliere)
                    .HasConstraintName("specialite_ibfk_tiken");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.ToTable("time");

                entity.HasIndex(e => e.Idjour)
                    .HasName("idjour");

                entity.HasIndex(e => e.Idperiode)
                    .HasName("idperiode");

                entity.HasIndex(e => e.Idprogramme)
                    .HasName("idprogramme");

                entity.HasIndex(e => e.Idsalle)
                    .HasName("idsalle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idjour)
                    .HasColumnName("idjour")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idperiode)
                    .HasColumnName("idperiode")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idprogramme)
                    .HasColumnName("idprogramme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idsalle)
                    .HasColumnName("idsalle")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdjourNavigation)
                    .WithMany(p => p.Time)
                    .HasForeignKey(d => d.Idjour)
                    .HasConstraintName("time_ibfk_4");

                entity.HasOne(d => d.IdperiodeNavigation)
                    .WithMany(p => p.Time)
                    .HasForeignKey(d => d.Idperiode)
                    .HasConstraintName("time_ibfk_3");

                entity.HasOne(d => d.IdsalleNavigation)
                    .WithMany(p => p.Time)
                    .HasForeignKey(d => d.Idsalle)
                    .HasConstraintName("time_ibfk_2");
            });

            modelBuilder.Entity<Typeevaluation>(entity =>
            {
                entity.HasKey(e => new { e.Codeevaluation, e.Nom });

                entity.ToTable("typeevaluation");

                entity.HasIndex(e => e.Codeevaluation)
                    .HasName("CODEEVALUATION");

                entity.Property(e => e.Codeevaluation)
                    .HasColumnName("CODEEVALUATION")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Note).HasColumnName("NOTE");
            });

            modelBuilder.Entity<Ue>(entity =>
            {
                entity.HasKey(e => e.IdUe);

                entity.ToTable("ue");

                entity.HasIndex(e => e.Idfiliere)
                    .HasName("IDFILIERE");

                entity.HasIndex(e => new { e.Codue, e.Idfiliere, e.Annee })
                    .HasName("CODUE")
                    .IsUnique();

                entity.Property(e => e.IdUe).HasColumnName("IdUE");

                entity.Property(e => e.Annee)
                    .HasColumnName("ANNEE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codue)
                    .IsRequired()
                    .HasColumnName("CODUE")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Idfiliere)
                    .HasColumnName("IDFILIERE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Intitule)
                    .IsRequired()
                    .HasColumnName("INTITULE")
                    .HasColumnType("varchar(512)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdfiliereNavigation)
                    .WithMany(p => p.Ue)
                    .HasForeignKey(d => d.Idfiliere)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ue_ibfk_1");
            });

            modelBuilder.Entity<Vue>(entity =>
            {
                entity.HasKey(e => new { e.IdProfile, e.IdModule });

                entity.ToTable("vue");

                entity.HasIndex(e => e.IdModule)
                    .HasName("idModule");

                entity.Property(e => e.IdProfile)
                    .HasColumnName("idProfile")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IdModule)
                    .HasColumnName("idModule")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.Vue)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vue_ibfk_2");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.Vue)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vue_ibfk_1");
            });
        }
    }
}
