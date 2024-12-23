using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Music.Models
{
    public partial class BandList_dbContext : DbContext
    {
        public BandList_dbContext()
        {
        }

        public BandList_dbContext(DbContextOptions<BandList_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BandList> BandLists { get; set; } = null!;
        public virtual DbSet<BandMember> BandMembers { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<GenreList> GenreLists { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<ReleaseList> ReleaseLists { get; set; } = null!;
        public virtual DbSet<ReleaseType> ReleaseTypes { get; set; } = null!;
        public virtual DbSet<SongList> SongLists { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserFavorite> UserFavorites { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BandList>(entity =>
            {
                entity.ToTable("Band_list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Lang).HasColumnName("lang");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.BandLists)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Band_list__count__7B5B524B");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.BandLists)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Band_list__genre__797309D9");

                entity.HasOne(d => d.LangNavigation)
                    .WithMany(p => p.BandLists)
                    .HasForeignKey(d => d.Lang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Band_list__lang__7A672E12");
            });

            modelBuilder.Entity<BandMember>(entity =>
            {
                entity.ToTable("Band_members");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BandId).HasColumnName("band_id");

                entity.Property(e => e.IsInBand).HasColumnName("is_in_band");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Pseudonym)
                    .HasMaxLength(50)
                    .HasColumnName("pseudonym");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.BandMembers)
                    .HasForeignKey(d => d.BandId)
                    .HasConstraintName("FK__Band_memb__band___07C12930");

                entity.HasMany(d => d.Bands)
                    .WithMany(p => p.Members)
                    .UsingEntity<Dictionary<string, object>>(
                        "BandMembersBand",
                        l => l.HasOne<BandList>().WithMany().HasForeignKey("BandId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Band_memb__band___0B91BA14"),
                        r => r.HasOne<BandMember>().WithMany().HasForeignKey("MemberId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Band_memb__membe__0A9D95DB"),
                        j =>
                        {
                            j.HasKey("MemberId", "BandId").HasName("PK__Band_mem__FE73863ECE9C38AA");

                            j.ToTable("Band_members_bands");

                            j.IndexerProperty<int>("MemberId").HasColumnName("member_id");

                            j.IndexerProperty<int>("BandId").HasColumnName("band_id");
                        });
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GenreList>(entity =>
            {
                entity.ToTable("Genre_list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ReleaseList>(entity =>
            {
                entity.ToTable("Release_list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Band).HasColumnName("band");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SongAmmount).HasColumnName("song_ammount");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.BandNavigation)
                    .WithMany(p => p.ReleaseLists)
                    .HasForeignKey(d => d.Band)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Release_li__band__7E37BEF6");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.ReleaseLists)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Release_l__genre__7F2BE32F");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.ReleaseLists)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Release_li__type__00200768");
            });

            modelBuilder.Entity<ReleaseType>(entity =>
            {
                entity.ToTable("Release_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<SongList>(entity =>
            {
                entity.ToTable("Song_list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Band).HasColumnName("band");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SongReleaseId).HasColumnName("song_release_id");

                entity.HasOne(d => d.BandNavigation)
                    .WithMany(p => p.SongLists)
                    .HasForeignKey(d => d.Band)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Song_list__band__02FC7413");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.SongLists)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Song_list__genre__03F0984C");

                entity.HasOne(d => d.SongRelease)
                    .WithMany(p => p.SongLists)
                    .HasForeignKey(d => d.SongReleaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Song_list__song___04E4BC85");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Regdate)
                    .HasColumnType("datetime")
                    .HasColumnName("regdate");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserFavorite>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.BandId, e.ReleaseId, e.SongId })
                    .HasName("PK__User_fav__E85EE7727ACAB677");

                entity.ToTable("User_favorite");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BandId).HasColumnName("band_id");

                entity.Property(e => e.ReleaseId).HasColumnName("release_id");

                entity.Property(e => e.SongId).HasColumnName("song_id");

                entity.Property(e => e.Review)
                    .HasMaxLength(100)
                    .HasColumnName("review");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_favo__band___0F624AF8");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_favorit__id__0E6E26BF");

                entity.HasOne(d => d.Release)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.ReleaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_favo__relea__10566F31");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_favo__song___114A936A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
