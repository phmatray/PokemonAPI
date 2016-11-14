using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PokemonAPI.WebService.Models;

// ReSharper disable once CheckNamespace
namespace PokemonAPI.WebService
{
    public class VeekunContext : DbContext
    {
        public VeekunContext(DbContextOptions<VeekunContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EFAbilities>(entity =>
            {
                entity.ToTable("abilities");

                entity.HasIndex(e => e.IsMainSeries)
                    .HasName("ix_abilities_is_main_series");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IsMainSeries).HasColumnName("is_main_series");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.Abilities)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__abilities__gener__76619304");
            });

            modelBuilder.Entity<EFAbilityChangelog>(entity =>
            {
                entity.ToTable("ability_changelog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.ChangedInVersionGroupId).HasColumnName("changed_in_version_group_id");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.AbilityChangelog)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_c__abili__54CB950F");

                entity.HasOne(d => d.ChangedInVersionGroup)
                    .WithMany(p => p.AbilityChangelog)
                    .HasForeignKey(d => d.ChangedInVersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_c__chang__55BFB948");
            });

            modelBuilder.Entity<EFAbilityChangelogProse>(entity =>
            {
                entity.HasKey(e => new { e.AbilityChangelogId, e.LocalLanguageId })
                    .HasName("PK__ability___DBE8365D8E8B4030");

                entity.ToTable("ability_changelog_prose");

                entity.Property(e => e.AbilityChangelogId).HasColumnName("ability_changelog_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect");

                entity.HasOne(d => d.AbilityChangelog)
                    .WithMany(p => p.AbilityChangelogProse)
                    .HasForeignKey(d => d.AbilityChangelogId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_c__abili__473C8FC7");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.AbilityChangelogProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_c__local__4830B400");
            });

            modelBuilder.Entity<EFAbilityFlavorText>(entity =>
            {
                entity.HasKey(e => new { e.AbilityId, e.VersionGroupId, e.LanguageId })
                    .HasName("PK__ability___06A0348CDD215EAD");

                entity.ToTable("ability_flavor_text");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FlavorText)
                    .IsRequired()
                    .HasColumnName("flavor_text");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.AbilityFlavorText)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_f__abili__4865BE2A");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.AbilityFlavorText)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_f__langu__4A4E069C");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.AbilityFlavorText)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_f__versi__4959E263");
            });

            modelBuilder.Entity<EFAbilityNames>(entity =>
            {
                entity.HasKey(e => new { e.AbilityId, e.LocalLanguageId })
                    .HasName("PK__ability___8C380F12A8CB8760");

                entity.ToTable("ability_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_ability_names_name");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.AbilityNames)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_n__abili__40C49C62");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.AbilityNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_n__local__41B8C09B");
            });

            modelBuilder.Entity<EFAbilityProse>(entity =>
            {
                entity.HasKey(e => new { e.AbilityId, e.LocalLanguageId })
                    .HasName("PK__ability___8C380F12217DFCA0");

                entity.ToTable("ability_prose");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect).HasColumnName("effect");

                entity.Property(e => e.ShortEffect).HasColumnName("short_effect");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.AbilityProse)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_p__abili__4D2A7347");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.AbilityProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ability_p__local__4E1E9780");
            });

            modelBuilder.Entity<EFBerries>(entity =>
            {
                entity.ToTable("berries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirmnessId).HasColumnName("firmness_id");

                entity.Property(e => e.GrowthTime).HasColumnName("growth_time");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.MaxHarvest).HasColumnName("max_harvest");

                entity.Property(e => e.NaturalGiftPower).HasColumnName("natural_gift_power");

                entity.Property(e => e.NaturalGiftTypeId).HasColumnName("natural_gift_type_id");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Smoothness).HasColumnName("smoothness");

                entity.Property(e => e.SoilDryness).HasColumnName("soil_dryness");

                entity.HasOne(d => d.Firmness)
                    .WithMany(p => p.Berries)
                    .HasForeignKey(d => d.FirmnessId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__berries__firmnes__361203C5");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Berries)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__berries__item_id__351DDF8C");

                entity.HasOne(d => d.NaturalGiftType)
                    .WithMany(p => p.Berries)
                    .HasForeignKey(d => d.NaturalGiftTypeId)
                    .HasConstraintName("FK__berries__natural__370627FE");
            });

            modelBuilder.Entity<EFBerryFirmness>(entity =>
            {
                entity.ToTable("berry_firmness");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFBerryFirmnessNames>(entity =>
            {
                entity.HasKey(e => new { e.BerryFirmnessId, e.LocalLanguageId })
                    .HasName("PK__berry_fi__0DC2BD4D8813E1FD");

                entity.ToTable("berry_firmness_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_berry_firmness_names_name");

                entity.Property(e => e.BerryFirmnessId).HasColumnName("berry_firmness_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.BerryFirmness)
                    .WithMany(p => p.BerryFirmnessNames)
                    .HasForeignKey(d => d.BerryFirmnessId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__berry_fir__berry__3F115E1A");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.BerryFirmnessNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__berry_fir__local__40058253");
            });

            modelBuilder.Entity<EFBerryFlavors>(entity =>
            {
                entity.HasKey(e => new { e.BerryId, e.ContestTypeId })
                    .HasName("PK__berry_fl__E6F327CB79B4A2D7");

                entity.ToTable("berry_flavors");

                entity.Property(e => e.BerryId).HasColumnName("berry_id");

                entity.Property(e => e.ContestTypeId).HasColumnName("contest_type_id");

                entity.Property(e => e.Flavor).HasColumnName("flavor");

                entity.HasOne(d => d.Berry)
                    .WithMany(p => p.BerryFlavors)
                    .HasForeignKey(d => d.BerryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__berry_fla__berry__6C6E1476");

                entity.HasOne(d => d.ContestType)
                    .WithMany(p => p.BerryFlavors)
                    .HasForeignKey(d => d.ContestTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__berry_fla__conte__6D6238AF");
            });

            modelBuilder.Entity<EFCharacteristicText>(entity =>
            {
                entity.HasKey(e => new { e.CharacteristicId, e.LocalLanguageId })
                    .HasName("PK__characte__BAB5BF0D037023EE");

                entity.ToTable("characteristic_text");

                entity.HasIndex(e => e.Message)
                    .HasName("ix_characteristic_text_message");

                entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.CharacteristicText)
                    .HasForeignKey(d => d.CharacteristicId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__character__chara__29AC2CE0");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.CharacteristicText)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__character__local__2AA05119");
            });

            modelBuilder.Entity<EFCharacteristics>(entity =>
            {
                entity.ToTable("characteristics");

                entity.HasIndex(e => e.GeneMod5)
                    .HasName("ix_characteristics_gene_mod_5");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GeneMod5).HasColumnName("gene_mod_5");

                entity.Property(e => e.StatId).HasColumnName("stat_id");

                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.Characteristics)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__character__stat___1F63A897");
            });

            modelBuilder.Entity<EFConquestEpisodeNames>(entity =>
            {
                entity.HasKey(e => new { e.EpisodeId, e.LocalLanguageId })
                    .HasName("PK__conquest__106D067F2001E0E1");

                entity.ToTable("conquest_episode_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_conquest_episode_names_name");

                entity.Property(e => e.EpisodeId).HasColumnName("episode_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Episode)
                    .WithMany(p => p.ConquestEpisodeNames)
                    .HasForeignKey(d => d.EpisodeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___episo__0E6E26BF");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestEpisodeNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__0F624AF8");
            });

            modelBuilder.Entity<EFConquestEpisodeWarriors>(entity =>
            {
                entity.HasKey(e => new { e.EpisodeId, e.WarriorId })
                    .HasName("PK__conquest__6262FE3C5FCDD03D");

                entity.ToTable("conquest_episode_warriors");

                entity.Property(e => e.EpisodeId).HasColumnName("episode_id");

                entity.Property(e => e.WarriorId).HasColumnName("warrior_id");

                entity.HasOne(d => d.Episode)
                    .WithMany(p => p.ConquestEpisodeWarriors)
                    .HasForeignKey(d => d.EpisodeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___episo__22401542");

                entity.HasOne(d => d.Warrior)
                    .WithMany(p => p.ConquestEpisodeWarriors)
                    .HasForeignKey(d => d.WarriorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__2334397B");
            });

            modelBuilder.Entity<EFConquestEpisodes>(entity =>
            {
                entity.ToTable("conquest_episodes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFConquestKingdomNames>(entity =>
            {
                entity.HasKey(e => new { e.KingdomId, e.LocalLanguageId })
                    .HasName("PK__conquest__2E837C6B3ED3E3C5");

                entity.ToTable("conquest_kingdom_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_conquest_kingdom_names_name");

                entity.Property(e => e.KingdomId).HasColumnName("kingdom_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Kingdom)
                    .WithMany(p => p.ConquestKingdomNames)
                    .HasForeignKey(d => d.KingdomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___kingd__740F363E");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestKingdomNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__75035A77");
            });

            modelBuilder.Entity<EFConquestKingdoms>(entity =>
            {
                entity.ToTable("conquest_kingdoms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ConquestKingdoms)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___type___1F2E9E6D");
            });

            modelBuilder.Entity<EFConquestMaxLinks>(entity =>
            {
                entity.HasKey(e => new { e.WarriorRankId, e.PokemonSpeciesId })
                    .HasName("PK__conquest__77F8B733733949D4");

                entity.ToTable("conquest_max_links");

                entity.Property(e => e.WarriorRankId).HasColumnName("warrior_rank_id");

                entity.Property(e => e.PokemonSpeciesId).HasColumnName("pokemon_species_id");

                entity.Property(e => e.MaxLink).HasColumnName("max_link");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithMany(p => p.ConquestMaxLinks)
                    .HasForeignKey(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___pokem__546180BB");

                entity.HasOne(d => d.WarriorRank)
                    .WithMany(p => p.ConquestMaxLinks)
                    .HasForeignKey(d => d.WarriorRankId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__536D5C82");
            });

            modelBuilder.Entity<EFConquestMoveData>(entity =>
            {
                entity.HasKey(e => e.MoveId)
                    .HasName("PK__conquest__2037E4BDC0192F39");

                entity.ToTable("conquest_move_data");

                entity.Property(e => e.MoveId)
                    .HasColumnName("move_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Accuracy).HasColumnName("accuracy");

                entity.Property(e => e.DisplacementId).HasColumnName("displacement_id");

                entity.Property(e => e.EffectChance).HasColumnName("effect_chance");

                entity.Property(e => e.EffectId).HasColumnName("effect_id");

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.RangeId).HasColumnName("range_id");

                entity.HasOne(d => d.Displacement)
                    .WithMany(p => p.ConquestMoveData)
                    .HasForeignKey(d => d.DisplacementId)
                    .HasConstraintName("FK__conquest___displ__3CBF0154");

                entity.HasOne(d => d.Effect)
                    .WithMany(p => p.ConquestMoveData)
                    .HasForeignKey(d => d.EffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___effec__3AD6B8E2");

                entity.HasOne(d => d.Move)
                    .WithOne(p => p.ConquestMoveData)
                    .HasForeignKey<EFConquestMoveData>(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___move___39E294A9");

                entity.HasOne(d => d.Range)
                    .WithMany(p => p.ConquestMoveData)
                    .HasForeignKey(d => d.RangeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___range__3BCADD1B");
            });

            modelBuilder.Entity<EFConquestMoveDisplacementProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveDisplacementId, e.LocalLanguageId })
                    .HasName("PK__conquest__0ECEA225718B42B8");

                entity.ToTable("conquest_move_displacement_prose");

                entity.Property(e => e.MoveDisplacementId).HasColumnName("move_displacement_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect).HasColumnName("effect");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.Property(e => e.ShortEffect).HasColumnName("short_effect");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestMoveDisplacementProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__3493CFA7");

                entity.HasOne(d => d.MoveDisplacement)
                    .WithMany(p => p.ConquestMoveDisplacementProse)
                    .HasForeignKey(d => d.MoveDisplacementId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___move___339FAB6E");
            });

            modelBuilder.Entity<EFConquestMoveDisplacements>(entity =>
            {
                entity.ToTable("conquest_move_displacements");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AffectsTarget).HasColumnName("affects_target");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFConquestMoveEffectProse>(entity =>
            {
                entity.HasKey(e => new { e.ConquestMoveEffectId, e.LocalLanguageId })
                    .HasName("PK__conquest__111D63394155D035");

                entity.ToTable("conquest_move_effect_prose");

                entity.Property(e => e.ConquestMoveEffectId).HasColumnName("conquest_move_effect_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect).HasColumnName("effect");

                entity.Property(e => e.ShortEffect).HasColumnName("short_effect");

                entity.HasOne(d => d.ConquestMoveEffect)
                    .WithMany(p => p.ConquestMoveEffectProse)
                    .HasForeignKey(d => d.ConquestMoveEffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___conqu__70DDC3D8");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestMoveEffectProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__71D1E811");
            });

            modelBuilder.Entity<EFConquestMoveEffects>(entity =>
            {
                entity.ToTable("conquest_move_effects");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<EFConquestMoveRangeProse>(entity =>
            {
                entity.HasKey(e => new { e.ConquestMoveRangeId, e.LocalLanguageId })
                    .HasName("PK__conquest__7883795284F9C9D1");

                entity.ToTable("conquest_move_range_prose");

                entity.Property(e => e.ConquestMoveRangeId).HasColumnName("conquest_move_range_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.ConquestMoveRange)
                    .WithMany(p => p.ConquestMoveRangeProse)
                    .HasForeignKey(d => d.ConquestMoveRangeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___conqu__55F4C372");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestMoveRangeProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__56E8E7AB");
            });

            modelBuilder.Entity<EFConquestMoveRanges>(entity =>
            {
                entity.ToTable("conquest_move_ranges");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.Targets).HasColumnName("targets");
            });

            modelBuilder.Entity<EFConquestPokemonAbilities>(entity =>
            {
                entity.HasKey(e => new { e.PokemonSpeciesId, e.Slot })
                    .HasName("PK__conquest__95AA72878CD0CE98");

                entity.ToTable("conquest_pokemon_abilities");

                entity.Property(e => e.PokemonSpeciesId).HasColumnName("pokemon_species_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.ConquestPokemonAbilities)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___abili__47FBA9D6");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithMany(p => p.ConquestPokemonAbilities)
                    .HasForeignKey(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___pokem__4707859D");
            });

            modelBuilder.Entity<EFConquestPokemonEvolution>(entity =>
            {
                entity.HasKey(e => e.EvolvedSpeciesId)
                    .HasName("PK__conquest__A4E233A9CB929B17");

                entity.ToTable("conquest_pokemon_evolution");

                entity.Property(e => e.EvolvedSpeciesId)
                    .HasColumnName("evolved_species_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.KingdomId).HasColumnName("kingdom_id");

                entity.Property(e => e.MinimumLink).HasColumnName("minimum_link");

                entity.Property(e => e.MinimumStat).HasColumnName("minimum_stat");

                entity.Property(e => e.RecruitingKoRequired).HasColumnName("recruiting_ko_required");

                entity.Property(e => e.RequiredStatId).HasColumnName("required_stat_id");

                entity.Property(e => e.WarriorGenderId).HasColumnName("warrior_gender_id");

                entity.HasOne(d => d.EvolvedSpecies)
                    .WithOne(p => p.ConquestPokemonEvolution)
                    .HasForeignKey<EFConquestPokemonEvolution>(d => d.EvolvedSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___evolv__15702A09");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ConquestPokemonEvolution)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__conquest___item___1940BAED");

                entity.HasOne(d => d.Kingdom)
                    .WithMany(p => p.ConquestPokemonEvolution)
                    .HasForeignKey(d => d.KingdomId)
                    .HasConstraintName("FK__conquest___kingd__1758727B");

                entity.HasOne(d => d.RequiredStat)
                    .WithMany(p => p.ConquestPokemonEvolution)
                    .HasForeignKey(d => d.RequiredStatId)
                    .HasConstraintName("FK__conquest___requi__16644E42");

                entity.HasOne(d => d.WarriorGender)
                    .WithMany(p => p.ConquestPokemonEvolution)
                    .HasForeignKey(d => d.WarriorGenderId)
                    .HasConstraintName("FK__conquest___warri__184C96B4");
            });

            modelBuilder.Entity<EFConquestPokemonMoves>(entity =>
            {
                entity.HasKey(e => e.PokemonSpeciesId)
                    .HasName("PK__conquest__F687A066E912B5E2");

                entity.ToTable("conquest_pokemon_moves");

                entity.Property(e => e.PokemonSpeciesId)
                    .HasColumnName("pokemon_species_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.ConquestPokemonMoves)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___move___38B96646");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithOne(p => p.ConquestPokemonMoves)
                    .HasForeignKey<EFConquestPokemonMoves>(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___pokem__37C5420D");
            });

            modelBuilder.Entity<EFConquestPokemonStats>(entity =>
            {
                entity.HasKey(e => new { e.PokemonSpeciesId, e.ConquestStatId })
                    .HasName("PK__conquest__5529CE8751AEE3C4");

                entity.ToTable("conquest_pokemon_stats");

                entity.Property(e => e.PokemonSpeciesId).HasColumnName("pokemon_species_id");

                entity.Property(e => e.ConquestStatId).HasColumnName("conquest_stat_id");

                entity.Property(e => e.BaseStat).HasColumnName("base_stat");

                entity.HasOne(d => d.ConquestStat)
                    .WithMany(p => p.ConquestPokemonStats)
                    .HasForeignKey(d => d.ConquestStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___conqu__1293BD5E");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithMany(p => p.ConquestPokemonStats)
                    .HasForeignKey(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___pokem__119F9925");
            });

            modelBuilder.Entity<EFConquestStatNames>(entity =>
            {
                entity.HasKey(e => new { e.ConquestStatId, e.LocalLanguageId })
                    .HasName("PK__conquest__AEF3EB314DE7FCF2");

                entity.ToTable("conquest_stat_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_conquest_stat_names_name");

                entity.Property(e => e.ConquestStatId).HasColumnName("conquest_stat_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.ConquestStat)
                    .WithMany(p => p.ConquestStatNames)
                    .HasForeignKey(d => d.ConquestStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___conqu__656C112C");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestStatNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__66603565");
            });

            modelBuilder.Entity<EFConquestStats>(entity =>
            {
                entity.ToTable("conquest_stats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IsBase).HasColumnName("is_base");
            });

            modelBuilder.Entity<EFConquestTransformationPokemon>(entity =>
            {
                entity.HasKey(e => new { e.TransformationId, e.PokemonSpeciesId })
                    .HasName("PK__conquest__86DB86AAE1D6545F");

                entity.ToTable("conquest_transformation_pokemon");

                entity.Property(e => e.TransformationId).HasColumnName("transformation_id");

                entity.Property(e => e.PokemonSpeciesId).HasColumnName("pokemon_species_id");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithMany(p => p.ConquestTransformationPokemon)
                    .HasForeignKey(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___pokem__405A880E");

                entity.HasOne(d => d.Transformation)
                    .WithMany(p => p.ConquestTransformationPokemon)
                    .HasForeignKey(d => d.TransformationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___trans__3F6663D5");
            });

            modelBuilder.Entity<EFConquestTransformationWarriors>(entity =>
            {
                entity.HasKey(e => new { e.TransformationId, e.PresentWarriorId })
                    .HasName("PK__conquest__85AB98215F09CB18");

                entity.ToTable("conquest_transformation_warriors");

                entity.Property(e => e.TransformationId).HasColumnName("transformation_id");

                entity.Property(e => e.PresentWarriorId).HasColumnName("present_warrior_id");

                entity.HasOne(d => d.PresentWarrior)
                    .WithMany(p => p.ConquestTransformationWarriors)
                    .HasForeignKey(d => d.PresentWarriorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___prese__408F9238");

                entity.HasOne(d => d.Transformation)
                    .WithMany(p => p.ConquestTransformationWarriors)
                    .HasForeignKey(d => d.TransformationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___trans__3F9B6DFF");
            });

            modelBuilder.Entity<EFConquestWarriorArchetypes>(entity =>
            {
                entity.ToTable("conquest_warrior_archetypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFConquestWarriorNames>(entity =>
            {
                entity.HasKey(e => new { e.WarriorId, e.LocalLanguageId })
                    .HasName("PK__conquest__F5BAD3B5D065B03C");

                entity.ToTable("conquest_warrior_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_conquest_warrior_names_name");

                entity.Property(e => e.WarriorId).HasColumnName("warrior_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestWarriorNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__0D44F85C");

                entity.HasOne(d => d.Warrior)
                    .WithMany(p => p.ConquestWarriorNames)
                    .HasForeignKey(d => d.WarriorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__0C50D423");
            });

            modelBuilder.Entity<EFConquestWarriorRankStatMap>(entity =>
            {
                entity.HasKey(e => new { e.WarriorRankId, e.WarriorStatId })
                    .HasName("PK__conquest__96C591FF9FAB7365");

                entity.ToTable("conquest_warrior_rank_stat_map");

                entity.Property(e => e.WarriorRankId).HasColumnName("warrior_rank_id");

                entity.Property(e => e.WarriorStatId).HasColumnName("warrior_stat_id");

                entity.Property(e => e.BaseStat).HasColumnName("base_stat");

                entity.HasOne(d => d.WarriorRank)
                    .WithMany(p => p.ConquestWarriorRankStatMap)
                    .HasForeignKey(d => d.WarriorRankId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__44952D46");

                entity.HasOne(d => d.WarriorStat)
                    .WithMany(p => p.ConquestWarriorRankStatMap)
                    .HasForeignKey(d => d.WarriorStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__4589517F");
            });

            modelBuilder.Entity<EFConquestWarriorRanks>(entity =>
            {
                entity.ToTable("conquest_warrior_ranks");

                entity.HasIndex(e => new { e.WarriorId, e.Rank })
                    .HasName("UQ__conquest__7D05595400889713")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.WarriorId).HasColumnName("warrior_id");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.ConquestWarriorRanks)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___skill__27F8EE98");

                entity.HasOne(d => d.Warrior)
                    .WithMany(p => p.ConquestWarriorRanks)
                    .HasForeignKey(d => d.WarriorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__2704CA5F");
            });

            modelBuilder.Entity<EFConquestWarriorSkillNames>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.LocalLanguageId })
                    .HasName("PK__conquest__6FAF8653F3085789");

                entity.ToTable("conquest_warrior_skill_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_conquest_warrior_skill_names_name");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestWarriorSkillNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__1AD3FDA4");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.ConquestWarriorSkillNames)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___skill__19DFD96B");
            });

            modelBuilder.Entity<EFConquestWarriorSkills>(entity =>
            {
                entity.ToTable("conquest_warrior_skills");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFConquestWarriorSpecialties>(entity =>
            {
                entity.HasKey(e => new { e.WarriorId, e.TypeId, e.Slot })
                    .HasName("PK__conquest__E55D0BE8173E5BDF");

                entity.ToTable("conquest_warrior_specialties");

                entity.Property(e => e.WarriorId).HasColumnName("warrior_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ConquestWarriorSpecialties)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___type___51EF2864");

                entity.HasOne(d => d.Warrior)
                    .WithMany(p => p.ConquestWarriorSpecialties)
                    .HasForeignKey(d => d.WarriorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__50FB042B");
            });

            modelBuilder.Entity<EFConquestWarriorStatNames>(entity =>
            {
                entity.HasKey(e => new { e.WarriorStatId, e.LocalLanguageId })
                    .HasName("PK__conquest__7140C9827C7F56E8");

                entity.ToTable("conquest_warrior_stat_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_conquest_warrior_stat_names_name");

                entity.Property(e => e.WarriorStatId).HasColumnName("warrior_stat_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ConquestWarriorStatNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___local__07C12930");

                entity.HasOne(d => d.WarriorStat)
                    .WithMany(p => p.ConquestWarriorStatNames)
                    .HasForeignKey(d => d.WarriorStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___warri__06CD04F7");
            });

            modelBuilder.Entity<EFConquestWarriorStats>(entity =>
            {
                entity.ToTable("conquest_warrior_stats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFConquestWarriorTransformation>(entity =>
            {
                entity.HasKey(e => e.TransformedWarriorRankId)
                    .HasName("PK__conquest__F0F63296F723C694");

                entity.ToTable("conquest_warrior_transformation");

                entity.Property(e => e.TransformedWarriorRankId)
                    .HasColumnName("transformed_warrior_rank_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CollectionTypeId).HasColumnName("collection_type_id");

                entity.Property(e => e.CompletedEpisodeId).HasColumnName("completed_episode_id");

                entity.Property(e => e.CurrentEpisodeId).HasColumnName("current_episode_id");

                entity.Property(e => e.DistantWarriorId).HasColumnName("distant_warrior_id");

                entity.Property(e => e.FemaleWarlordCount).HasColumnName("female_warlord_count");

                entity.Property(e => e.IsAutomatic).HasColumnName("is_automatic");

                entity.Property(e => e.PokemonCount).HasColumnName("pokemon_count");

                entity.Property(e => e.RequiredLink).HasColumnName("required_link");

                entity.Property(e => e.WarriorCount).HasColumnName("warrior_count");

                entity.HasOne(d => d.CollectionType)
                    .WithMany(p => p.ConquestWarriorTransformation)
                    .HasForeignKey(d => d.CollectionTypeId)
                    .HasConstraintName("FK__conquest___colle__324172E1");

                entity.HasOne(d => d.CompletedEpisode)
                    .WithMany(p => p.ConquestWarriorTransformationCompletedEpisode)
                    .HasForeignKey(d => d.CompletedEpisodeId)
                    .HasConstraintName("FK__conquest___compl__2F650636");

                entity.HasOne(d => d.CurrentEpisode)
                    .WithMany(p => p.ConquestWarriorTransformationCurrentEpisode)
                    .HasForeignKey(d => d.CurrentEpisodeId)
                    .HasConstraintName("FK__conquest___curre__30592A6F");

                entity.HasOne(d => d.DistantWarrior)
                    .WithMany(p => p.ConquestWarriorTransformation)
                    .HasForeignKey(d => d.DistantWarriorId)
                    .HasConstraintName("FK__conquest___dista__314D4EA8");

                entity.HasOne(d => d.TransformedWarriorRank)
                    .WithOne(p => p.ConquestWarriorTransformation)
                    .HasForeignKey<EFConquestWarriorTransformation>(d => d.TransformedWarriorRankId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___trans__2D7CBDC4");
            });

            modelBuilder.Entity<EFConquestWarriors>(entity =>
            {
                entity.ToTable("conquest_warriors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArchetypeId).HasColumnName("archetype_id");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Archetype)
                    .WithMany(p => p.ConquestWarriors)
                    .HasForeignKey(d => d.ArchetypeId)
                    .HasConstraintName("FK__conquest___arche__2180FB33");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.ConquestWarriors)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__conquest___gende__208CD6FA");
            });

            modelBuilder.Entity<EFContestCombos>(entity =>
            {
                entity.HasKey(e => new { e.FirstMoveId, e.SecondMoveId })
                    .HasName("PK__contest___456AD1D30792A6CA");

                entity.ToTable("contest_combos");

                entity.Property(e => e.FirstMoveId).HasColumnName("first_move_id");

                entity.Property(e => e.SecondMoveId).HasColumnName("second_move_id");

                entity.HasOne(d => d.FirstMove)
                    .WithMany(p => p.ContestCombosFirstMove)
                    .HasForeignKey(d => d.FirstMoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contest_c__first__09FE775D");

                entity.HasOne(d => d.SecondMove)
                    .WithMany(p => p.ContestCombosSecondMove)
                    .HasForeignKey(d => d.SecondMoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contest_c__secon__0AF29B96");
            });

            modelBuilder.Entity<EFContestEffectProse>(entity =>
            {
                entity.HasKey(e => new { e.ContestEffectId, e.LocalLanguageId })
                    .HasName("PK__contest___66D916E0F2428503");

                entity.ToTable("contest_effect_prose");

                entity.Property(e => e.ContestEffectId).HasColumnName("contest_effect_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect).HasColumnName("effect");

                entity.Property(e => e.FlavorText).HasColumnName("flavor_text");

                entity.HasOne(d => d.ContestEffect)
                    .WithMany(p => p.ContestEffectProse)
                    .HasForeignKey(d => d.ContestEffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contest_e__conte__4A8310C6");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ContestEffectProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contest_e__local__4B7734FF");
            });

            modelBuilder.Entity<EFContestEffects>(entity =>
            {
                entity.ToTable("contest_effects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Appeal).HasColumnName("appeal");

                entity.Property(e => e.Jam).HasColumnName("jam");
            });

            modelBuilder.Entity<EFContestTypeNames>(entity =>
            {
                entity.HasKey(e => new { e.ContestTypeId, e.LocalLanguageId })
                    .HasName("PK__contest___2017DBB3DB5EE9A9");

                entity.ToTable("contest_type_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_contest_type_names_name");

                entity.Property(e => e.ContestTypeId).HasColumnName("contest_type_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Flavor).HasColumnName("flavor");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.ContestType)
                    .WithMany(p => p.ContestTypeNames)
                    .HasForeignKey(d => d.ContestTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contest_t__conte__282DF8C2");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ContestTypeNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contest_t__local__29221CFB");
            });

            modelBuilder.Entity<EFContestTypes>(entity =>
            {
                entity.ToTable("contest_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFEggGroupProse>(entity =>
            {
                entity.HasKey(e => new { e.EggGroupId, e.LocalLanguageId })
                    .HasName("PK__egg_grou__3195380DBB41B354");

                entity.ToTable("egg_group_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_egg_group_prose_name");

                entity.Property(e => e.EggGroupId).HasColumnName("egg_group_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.EggGroup)
                    .WithMany(p => p.EggGroupProse)
                    .HasForeignKey(d => d.EggGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__egg_group__egg_g__4E53A1AA");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.EggGroupProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__egg_group__local__4F47C5E3");
            });

            modelBuilder.Entity<EFEggGroups>(entity =>
            {
                entity.ToTable("egg_groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFEncounterConditionProse>(entity =>
            {
                entity.HasKey(e => new { e.EncounterConditionId, e.LocalLanguageId })
                    .HasName("PK__encounte__214144F2425E0CEE");

                entity.ToTable("encounter_condition_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_encounter_condition_prose_name");

                entity.Property(e => e.EncounterConditionId).HasColumnName("encounter_condition_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.EncounterCondition)
                    .WithMany(p => p.EncounterConditionProse)
                    .HasForeignKey(d => d.EncounterConditionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__160F4887");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.EncounterConditionProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__local__17036CC0");
            });

            modelBuilder.Entity<EFEncounterConditionValueMap>(entity =>
            {
                entity.HasKey(e => new { e.EncounterId, e.EncounterConditionValueId })
                    .HasName("PK__encounte__7D09CDF17F573180");

                entity.ToTable("encounter_condition_value_map");

                entity.Property(e => e.EncounterId).HasColumnName("encounter_id");

                entity.Property(e => e.EncounterConditionValueId).HasColumnName("encounter_condition_value_id");

                entity.HasOne(d => d.EncounterConditionValue)
                    .WithMany(p => p.EncounterConditionValueMap)
                    .HasForeignKey(d => d.EncounterConditionValueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__0ABD916C");

                entity.HasOne(d => d.Encounter)
                    .WithMany(p => p.EncounterConditionValueMap)
                    .HasForeignKey(d => d.EncounterId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__09C96D33");
            });

            modelBuilder.Entity<EFEncounterConditionValueProse>(entity =>
            {
                entity.HasKey(e => new { e.EncounterConditionValueId, e.LocalLanguageId })
                    .HasName("PK__encounte__9B9A9AC0CBA89442");

                entity.ToTable("encounter_condition_value_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_encounter_condition_value_prose_name");

                entity.Property(e => e.EncounterConditionValueId).HasColumnName("encounter_condition_value_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.EncounterConditionValue)
                    .WithMany(p => p.EncounterConditionValueProse)
                    .HasForeignKey(d => d.EncounterConditionValueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__0880433F");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.EncounterConditionValueProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__local__09746778");
            });

            modelBuilder.Entity<EFEncounterConditionValues>(entity =>
            {
                entity.ToTable("encounter_condition_values");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EncounterConditionId).HasColumnName("encounter_condition_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.HasOne(d => d.EncounterCondition)
                    .WithMany(p => p.EncounterConditionValues)
                    .HasForeignKey(d => d.EncounterConditionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__693CA210");
            });

            modelBuilder.Entity<EFEncounterConditions>(entity =>
            {
                entity.ToTable("encounter_conditions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFEncounterMethodProse>(entity =>
            {
                entity.HasKey(e => new { e.EncounterMethodId, e.LocalLanguageId })
                    .HasName("PK__encounte__5E3A51BCB68D7E27");

                entity.ToTable("encounter_method_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_encounter_method_prose_name");

                entity.Property(e => e.EncounterMethodId).HasColumnName("encounter_method_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.EncounterMethod)
                    .WithMany(p => p.EncounterMethodProse)
                    .HasForeignKey(d => d.EncounterMethodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__671F4F74");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.EncounterMethodProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__local__681373AD");
            });

            modelBuilder.Entity<EFEncounterMethods>(entity =>
            {
                entity.ToTable("encounter_methods");

                entity.HasIndex(e => e.Identifier)
                    .HasName("UQ__encounte__D112ED4813702B4C")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("UQ__encounte__2158ED36319CAF32")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<EFEncounterSlots>(entity =>
            {
                entity.ToTable("encounter_slots");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EncounterMethodId).HasColumnName("encounter_method_id");

                entity.Property(e => e.Rarity).HasColumnName("rarity");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.HasOne(d => d.EncounterMethod)
                    .WithMany(p => p.EncounterSlots)
                    .HasForeignKey(d => d.EncounterMethodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__59904A2C");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.EncounterSlots)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__versi__589C25F3");
            });

            modelBuilder.Entity<EFEncounters>(entity =>
            {
                entity.ToTable("encounters");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EncounterSlotId).HasColumnName("encounter_slot_id");

                entity.Property(e => e.LocationAreaId).HasColumnName("location_area_id");

                entity.Property(e => e.MaxLevel).HasColumnName("max_level");

                entity.Property(e => e.MinLevel).HasColumnName("min_level");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.HasOne(d => d.EncounterSlot)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.EncounterSlotId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__encou__68687968");

                entity.HasOne(d => d.LocationArea)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.LocationAreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__locat__6774552F");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__pokem__695C9DA1");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__encounter__versi__668030F6");
            });

            modelBuilder.Entity<EFEvolutionChains>(entity =>
            {
                entity.ToTable("evolution_chains");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BabyTriggerItemId).HasColumnName("baby_trigger_item_id");

                entity.HasOne(d => d.BabyTriggerItem)
                    .WithMany(p => p.EvolutionChains)
                    .HasForeignKey(d => d.BabyTriggerItemId)
                    .HasConstraintName("FK__evolution__baby___1C5231C2");
            });

            modelBuilder.Entity<EFEvolutionTriggerProse>(entity =>
            {
                entity.HasKey(e => new { e.EvolutionTriggerId, e.LocalLanguageId })
                    .HasName("PK__evolutio__9E2DD70599BCD2A6");

                entity.ToTable("evolution_trigger_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_evolution_trigger_prose_name");

                entity.Property(e => e.EvolutionTriggerId).HasColumnName("evolution_trigger_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.EvolutionTrigger)
                    .WithMany(p => p.EvolutionTriggerProse)
                    .HasForeignKey(d => d.EvolutionTriggerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__evolution__evolu__3B40CD36");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.EvolutionTriggerProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__evolution__local__3C34F16F");
            });

            modelBuilder.Entity<EFEvolutionTriggers>(entity =>
            {
                entity.ToTable("evolution_triggers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFExperience>(entity =>
            {
                entity.HasKey(e => new { e.GrowthRateId, e.Level })
                    .HasName("PK__experien__C0E5A517EE10D360");

                entity.ToTable("experience");

                entity.Property(e => e.GrowthRateId).HasColumnName("growth_rate_id");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Experience1).HasColumnName("experience");

                entity.HasOne(d => d.GrowthRate)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.GrowthRateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__experienc__growt__1DB06A4F");
            });

            modelBuilder.Entity<EFGenders>(entity =>
            {
                entity.ToTable("genders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFGenerationNames>(entity =>
            {
                entity.HasKey(e => new { e.GenerationId, e.LocalLanguageId })
                    .HasName("PK__generati__6C92D370B83AB166");

                entity.ToTable("generation_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_generation_names_name");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.GenerationNames)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__generatio__gener__13F1F5EB");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.GenerationNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__generatio__local__14E61A24");
            });

            modelBuilder.Entity<EFGenerations>(entity =>
            {
                entity.ToTable("generations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.MainRegionId).HasColumnName("main_region_id");

                entity.HasOne(d => d.MainRegion)
                    .WithMany(p => p.Generations)
                    .HasForeignKey(d => d.MainRegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__generatio__main___7C4F7684");
            });

            modelBuilder.Entity<EFGrowthRateProse>(entity =>
            {
                entity.HasKey(e => new { e.GrowthRateId, e.LocalLanguageId })
                    .HasName("PK__growth_r__F8F3017D58006C43");

                entity.ToTable("growth_rate_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_growth_rate_prose_name");

                entity.Property(e => e.GrowthRateId).HasColumnName("growth_rate_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.GrowthRate)
                    .WithMany(p => p.GrowthRateProse)
                    .HasForeignKey(d => d.GrowthRateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__growth_ra__growt__02FC7413");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.GrowthRateProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__growth_ra__local__03F0984C");
            });

            modelBuilder.Entity<EFGrowthRates>(entity =>
            {
                entity.ToTable("growth_rates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasColumnName("formula");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFItemCategories>(entity =>
            {
                entity.ToTable("item_categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.PocketId).HasColumnName("pocket_id");

                entity.HasOne(d => d.Pocket)
                    .WithMany(p => p.ItemCategories)
                    .HasForeignKey(d => d.PocketId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_cate__pocke__6442E2C9");
            });

            modelBuilder.Entity<EFItemCategoryProse>(entity =>
            {
                entity.HasKey(e => new { e.ItemCategoryId, e.LocalLanguageId })
                    .HasName("PK__item_cat__A0BC1FE043A15B7D");

                entity.ToTable("item_category_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_item_category_prose_name");

                entity.Property(e => e.ItemCategoryId).HasColumnName("item_category_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.ItemCategoryProse)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_cate__item___04AFB25B");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ItemCategoryProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_cate__local__05A3D694");
            });

            modelBuilder.Entity<EFItemFlagMap>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.ItemFlagId })
                    .HasName("PK__item_fla__B874091F6F08FB7A");

                entity.ToTable("item_flag_map");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemFlagId).HasColumnName("item_flag_id");

                entity.HasOne(d => d.ItemFlag)
                    .WithMany(p => p.ItemFlagMap)
                    .HasForeignKey(d => d.ItemFlagId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flag__item___753864A1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemFlagMap)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flag__item___74444068");
            });

            modelBuilder.Entity<EFItemFlagProse>(entity =>
            {
                entity.HasKey(e => new { e.ItemFlagId, e.LocalLanguageId })
                    .HasName("PK__item_fla__33756905417A6AF2");

                entity.ToTable("item_flag_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_item_flag_prose_name");

                entity.Property(e => e.ItemFlagId).HasColumnName("item_flag_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.ItemFlag)
                    .WithMany(p => p.ItemFlagProse)
                    .HasForeignKey(d => d.ItemFlagId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flag__item___37703C52");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ItemFlagProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flag__local__3864608B");
            });

            modelBuilder.Entity<EFItemFlags>(entity =>
            {
                entity.ToTable("item_flags");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFItemFlavorSummaries>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.LocalLanguageId })
                    .HasName("PK__item_fla__C6170AF7F782633E");

                entity.ToTable("item_flavor_summaries");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.FlavorSummary).HasColumnName("flavor_summary");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemFlavorSummaries)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flav__item___603D47BB");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ItemFlavorSummaries)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flav__local__61316BF4");
            });

            modelBuilder.Entity<EFItemFlavorText>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.VersionGroupId, e.LanguageId })
                    .HasName("PK__item_fla__4C8F3169B62ADF3B");

                entity.ToTable("item_flavor_text");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FlavorText)
                    .IsRequired()
                    .HasColumnName("flavor_text");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemFlavorText)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flav__item___6BAEFA67");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ItemFlavorText)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flav__langu__6D9742D9");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.ItemFlavorText)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flav__versi__6CA31EA0");
            });

            modelBuilder.Entity<EFItemFlingEffectProse>(entity =>
            {
                entity.HasKey(e => new { e.ItemFlingEffectId, e.LocalLanguageId })
                    .HasName("PK__item_fli__4DA7B86E307A0939");

                entity.ToTable("item_fling_effect_prose");

                entity.Property(e => e.ItemFlingEffectId).HasColumnName("item_fling_effect_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect");

                entity.HasOne(d => d.ItemFlingEffect)
                    .WithMany(p => p.ItemFlingEffectProse)
                    .HasForeignKey(d => d.ItemFlingEffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flin__item___607251E5");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ItemFlingEffectProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_flin__local__6166761E");
            });

            modelBuilder.Entity<EFItemFlingEffects>(entity =>
            {
                entity.ToTable("item_fling_effects");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<EFItemGameIndices>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.GenerationId })
                    .HasName("PK__item_gam__ED8A72B8F7DFF401");

                entity.ToTable("item_game_indices");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.ItemGameIndices)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_game__gener__7167D3BD");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemGameIndices)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_game__item___7073AF84");
            });

            modelBuilder.Entity<EFItemNames>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.LocalLanguageId })
                    .HasName("PK__item_nam__C6170AF7E26AB727");

                entity.ToTable("item_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_item_names_name");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemNames)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_name__item___5C6CB6D7");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ItemNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_name__local__5D60DB10");
            });

            modelBuilder.Entity<EFItemPocketNames>(entity =>
            {
                entity.HasKey(e => new { e.ItemPocketId, e.LocalLanguageId })
                    .HasName("PK__item_poc__B94D561377303403");

                entity.ToTable("item_pocket_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_item_pocket_names_name");

                entity.Property(e => e.ItemPocketId).HasColumnName("item_pocket_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.ItemPocket)
                    .WithMany(p => p.ItemPocketNames)
                    .HasForeignKey(d => d.ItemPocketId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_pock__item___42E1EEFE");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ItemPocketNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_pock__local__43D61337");
            });

            modelBuilder.Entity<EFItemPockets>(entity =>
            {
                entity.ToTable("item_pockets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFItemProse>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.LocalLanguageId })
                    .HasName("PK__item_pro__C6170AF7C7555520");

                entity.ToTable("item_prose");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect).HasColumnName("effect");

                entity.Property(e => e.ShortEffect).HasColumnName("short_effect");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemProse)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_pros__item___7CD98669");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.ItemProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__item_pros__local__7DCDAAA2");
            });

            modelBuilder.Entity<EFItems>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.FlingEffectId).HasColumnName("fling_effect_id");

                entity.Property(e => e.FlingPower).HasColumnName("fling_power");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__items__category___10216507");

                entity.HasOne(d => d.FlingEffect)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.FlingEffectId)
                    .HasConstraintName("FK__items__fling_eff__11158940");
            });

            modelBuilder.Entity<EFLanguageNames>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.LocalLanguageId })
                    .HasName("PK__language__1459F39996E6BF75");

                entity.ToTable("language_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_language_names_name");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LanguageNamesLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__language___langu__72910220");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.LanguageNamesLocalLanguage)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__language___local__73852659");
            });

            modelBuilder.Entity<EFLanguages>(entity =>
            {
                entity.ToTable("languages");

                entity.HasIndex(e => e.Official)
                    .HasName("ix_languages_official");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.Iso3166)
                    .IsRequired()
                    .HasColumnName("iso3166")
                    .HasMaxLength(79);

                entity.Property(e => e.Iso639)
                    .IsRequired()
                    .HasColumnName("iso639")
                    .HasMaxLength(79);

                entity.Property(e => e.Official).HasColumnName("official");

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<EFLocationAreaEncounterRates>(entity =>
            {
                entity.HasKey(e => new { e.LocationAreaId, e.EncounterMethodId, e.VersionId })
                    .HasName("PK__location__AF7A15D5BEDC8B65");

                entity.ToTable("location_area_encounter_rates");

                entity.Property(e => e.LocationAreaId).HasColumnName("location_area_id");

                entity.Property(e => e.EncounterMethodId).HasColumnName("encounter_method_id");

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.HasOne(d => d.EncounterMethod)
                    .WithMany(p => p.LocationAreaEncounterRates)
                    .HasForeignKey(d => d.EncounterMethodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___encou__7D98A078");

                entity.HasOne(d => d.LocationArea)
                    .WithMany(p => p.LocationAreaEncounterRates)
                    .HasForeignKey(d => d.LocationAreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___locat__7CA47C3F");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.LocationAreaEncounterRates)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___versi__7E8CC4B1");
            });

            modelBuilder.Entity<EFLocationAreaProse>(entity =>
            {
                entity.HasKey(e => new { e.LocationAreaId, e.LocalLanguageId })
                    .HasName("PK__location__2FCA403E01DEC2D1");

                entity.ToTable("location_area_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_location_area_prose_name");

                entity.Property(e => e.LocationAreaId).HasColumnName("location_area_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.LocationAreaProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___local__3DE82FB7");

                entity.HasOne(d => d.LocationArea)
                    .WithMany(p => p.LocationAreaProse)
                    .HasForeignKey(d => d.LocationAreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___locat__3CF40B7E");
            });

            modelBuilder.Entity<EFLocationAreas>(entity =>
            {
                entity.ToTable("location_areas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationAreas)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___locat__7A3223E8");
            });

            modelBuilder.Entity<EFLocationGameIndices>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.GenerationId, e.GameIndex })
                    .HasName("PK__location__A6EA3804EE0DB799");

                entity.ToTable("location_game_indices");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.LocationGameIndices)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___gener__01D345B0");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationGameIndices)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___locat__00DF2177");
            });

            modelBuilder.Entity<EFLocationNames>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.LocalLanguageId })
                    .HasName("PK__location__E30D34C03B6BFB7C");

                entity.ToTable("location_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_location_names_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.LocationNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___local__1C873BEC");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationNames)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__location___locat__1B9317B3");
            });

            modelBuilder.Entity<EFLocations>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK__locations__regio__5D95E53A");
            });

            modelBuilder.Entity<EFMachines>(entity =>
            {
                entity.HasKey(e => new { e.MachineNumber, e.VersionGroupId })
                    .HasName("PK__machines__1CA5287D881B0184");

                entity.ToTable("machines");

                entity.Property(e => e.MachineNumber).HasColumnName("machine_number");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__machines__item_i__62E4AA3C");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__machines__move_i__63D8CE75");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__machines__versio__61F08603");
            });

            modelBuilder.Entity<EFMoveBattleStyleProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveBattleStyleId, e.LocalLanguageId })
                    .HasName("PK__move_bat__3E7F9AB0FE82405A");

                entity.ToTable("move_battle_style_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_move_battle_style_prose_name");

                entity.Property(e => e.MoveBattleStyleId).HasColumnName("move_battle_style_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveBattleStyleProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_batt__local__6E01572D");

                entity.HasOne(d => d.MoveBattleStyle)
                    .WithMany(p => p.MoveBattleStyleProse)
                    .HasForeignKey(d => d.MoveBattleStyleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_batt__move___6D0D32F4");
            });

            modelBuilder.Entity<EFMoveBattleStyles>(entity =>
            {
                entity.ToTable("move_battle_styles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFMoveChangelog>(entity =>
            {
                entity.HasKey(e => new { e.MoveId, e.ChangedInVersionGroupId })
                    .HasName("PK__move_cha__744A61DDCE6A5AEE");

                entity.ToTable("move_changelog");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.Property(e => e.ChangedInVersionGroupId).HasColumnName("changed_in_version_group_id");

                entity.Property(e => e.Accuracy).HasColumnName("accuracy");

                entity.Property(e => e.EffectChance).HasColumnName("effect_chance");

                entity.Property(e => e.EffectId).HasColumnName("effect_id");

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.Pp).HasColumnName("pp");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.ChangedInVersionGroup)
                    .WithMany(p => p.MoveChangelog)
                    .HasForeignKey(d => d.ChangedInVersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_chan__chang__67A95F59");

                entity.HasOne(d => d.Effect)
                    .WithMany(p => p.MoveChangelog)
                    .HasForeignKey(d => d.EffectId)
                    .HasConstraintName("FK__move_chan__effec__6991A7CB");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.MoveChangelog)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_chan__move___66B53B20");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.MoveChangelog)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__move_chan__type___689D8392");
            });

            modelBuilder.Entity<EFMoveDamageClassProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveDamageClassId, e.LocalLanguageId })
                    .HasName("PK__move_dam__6129E414E2F35F8A");

                entity.ToTable("move_damage_class_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_move_damage_class_prose_name");

                entity.Property(e => e.MoveDamageClassId).HasColumnName("move_damage_class_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveDamageClassProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_dama__local__797309D9");

                entity.HasOne(d => d.MoveDamageClass)
                    .WithMany(p => p.MoveDamageClassProse)
                    .HasForeignKey(d => d.MoveDamageClassId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_dama__move___787EE5A0");
            });

            modelBuilder.Entity<EFMoveDamageClasses>(entity =>
            {
                entity.ToTable("move_damage_classes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFMoveEffectChangelog>(entity =>
            {
                entity.ToTable("move_effect_changelog");

                entity.HasIndex(e => new { e.EffectId, e.ChangedInVersionGroupId })
                    .HasName("UQ__move_eff__F804575A9BBDE4D5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChangedInVersionGroupId).HasColumnName("changed_in_version_group_id");

                entity.Property(e => e.EffectId).HasColumnName("effect_id");

                entity.HasOne(d => d.ChangedInVersionGroup)
                    .WithMany(p => p.MoveEffectChangelog)
                    .HasForeignKey(d => d.ChangedInVersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_effe__chang__79FD19BE");

                entity.HasOne(d => d.Effect)
                    .WithMany(p => p.MoveEffectChangelog)
                    .HasForeignKey(d => d.EffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_effe__effec__7908F585");
            });

            modelBuilder.Entity<EFMoveEffectChangelogProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveEffectChangelogId, e.LocalLanguageId })
                    .HasName("PK__move_eff__B7FA025F11FA833D");

                entity.ToTable("move_effect_changelog_prose");

                entity.Property(e => e.MoveEffectChangelogId).HasColumnName("move_effect_changelog_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveEffectChangelogProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_effe__local__0EC32C7A");

                entity.HasOne(d => d.MoveEffectChangelog)
                    .WithMany(p => p.MoveEffectChangelogProse)
                    .HasForeignKey(d => d.MoveEffectChangelogId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_effe__move___0DCF0841");
            });

            modelBuilder.Entity<EFMoveEffectProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveEffectId, e.LocalLanguageId })
                    .HasName("PK__move_eff__F8C9BD71C3E759A6");

                entity.ToTable("move_effect_prose");

                entity.Property(e => e.MoveEffectId).HasColumnName("move_effect_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Effect).HasColumnName("effect");

                entity.Property(e => e.ShortEffect).HasColumnName("short_effect");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveEffectProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_effe__local__531856C7");

                entity.HasOne(d => d.MoveEffect)
                    .WithMany(p => p.MoveEffectProse)
                    .HasForeignKey(d => d.MoveEffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_effe__move___5224328E");
            });

            modelBuilder.Entity<EFMoveEffects>(entity =>
            {
                entity.ToTable("move_effects");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<EFMoveFlagMap>(entity =>
            {
                entity.HasKey(e => new { e.MoveId, e.MoveFlagId })
                    .HasName("PK__move_fla__4864B7B6D690A26D");

                entity.ToTable("move_flag_map");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.Property(e => e.MoveFlagId).HasColumnName("move_flag_id");

                entity.HasOne(d => d.MoveFlag)
                    .WithMany(p => p.MoveFlagMap)
                    .HasForeignKey(d => d.MoveFlagId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flag__move___4FD1D5C8");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.MoveFlagMap)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flag__move___4EDDB18F");
            });

            modelBuilder.Entity<EFMoveFlagProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveFlagId, e.LocalLanguageId })
                    .HasName("PK__move_fla__1120359DFA7DAE09");

                entity.ToTable("move_flag_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_move_flag_prose_name");

                entity.Property(e => e.MoveFlagId).HasColumnName("move_flag_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveFlagProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flag__local__5AEE82B9");

                entity.HasOne(d => d.MoveFlag)
                    .WithMany(p => p.MoveFlagProse)
                    .HasForeignKey(d => d.MoveFlagId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flag__move___59FA5E80");
            });

            modelBuilder.Entity<EFMoveFlags>(entity =>
            {
                entity.ToTable("move_flags");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFMoveFlavorSummaries>(entity =>
            {
                entity.HasKey(e => new { e.MoveId, e.LocalLanguageId })
                    .HasName("PK__move_fla__B422E197C5E739B5");

                entity.ToTable("move_flavor_summaries");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.FlavorSummary).HasColumnName("flavor_summary");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveFlavorSummaries)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flav__local__4460231C");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.MoveFlavorSummaries)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flav__move___436BFEE3");
            });

            modelBuilder.Entity<EFMoveFlavorText>(entity =>
            {
                entity.HasKey(e => new { e.MoveId, e.VersionGroupId, e.LanguageId })
                    .HasName("PK__move_fla__3EBADA094E1156D8");

                entity.ToTable("move_flavor_text");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FlavorText)
                    .IsRequired()
                    .HasColumnName("flavor_text");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.MoveFlavorText)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flav__langu__79C80F94");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.MoveFlavorText)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flav__move___77DFC722");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.MoveFlavorText)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_flav__versi__78D3EB5B");
            });

            modelBuilder.Entity<EFMoveMeta>(entity =>
            {
                entity.HasKey(e => e.MoveId)
                    .HasName("PK__move_met__2037E4BDCCDBE814");

                entity.ToTable("move_meta");

                entity.HasIndex(e => e.AilmentChance)
                    .HasName("ix_move_meta_ailment_chance");

                entity.HasIndex(e => e.CritRate)
                    .HasName("ix_move_meta_crit_rate");

                entity.HasIndex(e => e.Drain)
                    .HasName("ix_move_meta_drain");

                entity.HasIndex(e => e.FlinchChance)
                    .HasName("ix_move_meta_flinch_chance");

                entity.HasIndex(e => e.Healing)
                    .HasName("ix_move_meta_healing");

                entity.HasIndex(e => e.MaxHits)
                    .HasName("ix_move_meta_max_hits");

                entity.HasIndex(e => e.MaxTurns)
                    .HasName("ix_move_meta_max_turns");

                entity.HasIndex(e => e.MinHits)
                    .HasName("ix_move_meta_min_hits");

                entity.HasIndex(e => e.MinTurns)
                    .HasName("ix_move_meta_min_turns");

                entity.HasIndex(e => e.StatChance)
                    .HasName("ix_move_meta_stat_chance");

                entity.Property(e => e.MoveId)
                    .HasColumnName("move_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AilmentChance).HasColumnName("ailment_chance");

                entity.Property(e => e.CritRate).HasColumnName("crit_rate");

                entity.Property(e => e.Drain).HasColumnName("drain");

                entity.Property(e => e.FlinchChance).HasColumnName("flinch_chance");

                entity.Property(e => e.Healing).HasColumnName("healing");

                entity.Property(e => e.MaxHits).HasColumnName("max_hits");

                entity.Property(e => e.MaxTurns).HasColumnName("max_turns");

                entity.Property(e => e.MetaAilmentId).HasColumnName("meta_ailment_id");

                entity.Property(e => e.MetaCategoryId).HasColumnName("meta_category_id");

                entity.Property(e => e.MinHits).HasColumnName("min_hits");

                entity.Property(e => e.MinTurns).HasColumnName("min_turns");

                entity.Property(e => e.StatChance).HasColumnName("stat_chance");

                entity.HasOne(d => d.MetaAilment)
                    .WithMany(p => p.MoveMeta)
                    .HasForeignKey(d => d.MetaAilmentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__meta___07220AB2");

                entity.HasOne(d => d.MetaCategory)
                    .WithMany(p => p.MoveMeta)
                    .HasForeignKey(d => d.MetaCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__meta___062DE679");

                entity.HasOne(d => d.Move)
                    .WithOne(p => p.MoveMeta)
                    .HasForeignKey<EFMoveMeta>(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__move___0539C240");
            });

            modelBuilder.Entity<EFMoveMetaAilmentNames>(entity =>
            {
                entity.HasKey(e => new { e.MoveMetaAilmentId, e.LocalLanguageId })
                    .HasName("PK__move_met__5A7ED5356FD110E9");

                entity.ToTable("move_meta_ailment_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_move_meta_ailment_names_name");

                entity.Property(e => e.MoveMetaAilmentId).HasColumnName("move_meta_ailment_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveMetaAilmentNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__local__75A278F5");

                entity.HasOne(d => d.MoveMetaAilment)
                    .WithMany(p => p.MoveMetaAilmentNames)
                    .HasForeignKey(d => d.MoveMetaAilmentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__move___74AE54BC");
            });

            modelBuilder.Entity<EFMoveMetaAilments>(entity =>
            {
                entity.ToTable("move_meta_ailments");

                entity.HasIndex(e => e.Identifier)
                    .HasName("ix_move_meta_ailments_identifier")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFMoveMetaCategories>(entity =>
            {
                entity.ToTable("move_meta_categories");

                entity.HasIndex(e => e.Identifier)
                    .HasName("ix_move_meta_categories_identifier")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFMoveMetaCategoryProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveMetaCategoryId, e.LocalLanguageId })
                    .HasName("PK__move_met__41C12A60EC228807");

                entity.ToTable("move_meta_category_prose");

                entity.Property(e => e.MoveMetaCategoryId).HasColumnName("move_meta_category_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveMetaCategoryProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__local__25518C17");

                entity.HasOne(d => d.MoveMetaCategory)
                    .WithMany(p => p.MoveMetaCategoryProse)
                    .HasForeignKey(d => d.MoveMetaCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__move___245D67DE");
            });

            modelBuilder.Entity<EFMoveMetaStatChanges>(entity =>
            {
                entity.HasKey(e => new { e.MoveId, e.StatId })
                    .HasName("PK__move_met__3BBDB6EB4F5EBC51");

                entity.ToTable("move_meta_stat_changes");

                entity.HasIndex(e => e.Change)
                    .HasName("ix_move_meta_stat_changes_change");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.Property(e => e.StatId).HasColumnName("stat_id");

                entity.Property(e => e.Change).HasColumnName("change");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.MoveMetaStatChanges)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__move___52AE4273");

                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.MoveMetaStatChanges)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_meta__stat___53A266AC");
            });

            modelBuilder.Entity<EFMoveNames>(entity =>
            {
                entity.HasKey(e => new { e.MoveId, e.LocalLanguageId })
                    .HasName("PK__move_nam__B422E19750420CF9");

                entity.ToTable("move_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_move_names_name");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_name__local__025D5595");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.MoveNames)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_name__move___0169315C");
            });

            modelBuilder.Entity<EFMoveTargetProse>(entity =>
            {
                entity.HasKey(e => new { e.MoveTargetId, e.LocalLanguageId })
                    .HasName("PK__move_tar__CA9D3447E739B3F9");

                entity.ToTable("move_target_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_move_target_prose_name");

                entity.Property(e => e.MoveTargetId).HasColumnName("move_target_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.MoveTargetProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_targ__local__30C33EC3");

                entity.HasOne(d => d.MoveTarget)
                    .WithMany(p => p.MoveTargetProse)
                    .HasForeignKey(d => d.MoveTargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__move_targ__move___2FCF1A8A");
            });

            modelBuilder.Entity<EFMoveTargets>(entity =>
            {
                entity.ToTable("move_targets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFMoves>(entity =>
            {
                entity.ToTable("moves");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accuracy).HasColumnName("accuracy");

                entity.Property(e => e.ContestEffectId).HasColumnName("contest_effect_id");

                entity.Property(e => e.ContestTypeId).HasColumnName("contest_type_id");

                entity.Property(e => e.DamageClassId).HasColumnName("damage_class_id");

                entity.Property(e => e.EffectChance).HasColumnName("effect_chance");

                entity.Property(e => e.EffectId).HasColumnName("effect_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.Pp).HasColumnName("pp");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.SuperContestEffectId).HasColumnName("super_contest_effect_id");

                entity.Property(e => e.TargetId).HasColumnName("target_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.ContestEffect)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.ContestEffectId)
                    .HasConstraintName("FK__moves__contest_e__14B10FFA");

                entity.HasOne(d => d.ContestType)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.ContestTypeId)
                    .HasConstraintName("FK__moves__contest_t__13BCEBC1");

                entity.HasOne(d => d.DamageClass)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.DamageClassId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__moves__damage_cl__11D4A34F");

                entity.HasOne(d => d.Effect)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.EffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__moves__effect_id__12C8C788");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__moves__generatio__0EF836A4");

                entity.HasOne(d => d.SuperContestEffect)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.SuperContestEffectId)
                    .HasConstraintName("FK__moves__super_con__15A53433");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__moves__target_id__10E07F16");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__moves__type_id__0FEC5ADD");
            });

            modelBuilder.Entity<EFNatureBattleStylePreferences>(entity =>
            {
                entity.HasKey(e => new { e.NatureId, e.MoveBattleStyleId })
                    .HasName("PK__nature_b__7B4AD51B86BF54F7");

                entity.ToTable("nature_battle_style_preferences");

                entity.Property(e => e.NatureId).HasColumnName("nature_id");

                entity.Property(e => e.MoveBattleStyleId).HasColumnName("move_battle_style_id");

                entity.Property(e => e.HighHpPreference).HasColumnName("high_hp_preference");

                entity.Property(e => e.LowHpPreference).HasColumnName("low_hp_preference");

                entity.HasOne(d => d.MoveBattleStyle)
                    .WithMany(p => p.NatureBattleStylePreferences)
                    .HasForeignKey(d => d.MoveBattleStyleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__nature_ba__move___22FF2F51");

                entity.HasOne(d => d.Nature)
                    .WithMany(p => p.NatureBattleStylePreferences)
                    .HasForeignKey(d => d.NatureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__nature_ba__natur__220B0B18");
            });

            modelBuilder.Entity<EFNatureNames>(entity =>
            {
                entity.HasKey(e => new { e.NatureId, e.LocalLanguageId })
                    .HasName("PK__nature_n__55F979C8C403A8E6");

                entity.ToTable("nature_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_nature_names_name");

                entity.Property(e => e.NatureId).HasColumnName("nature_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.NatureNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__nature_na__local__084B3915");

                entity.HasOne(d => d.Nature)
                    .WithMany(p => p.NatureNames)
                    .HasForeignKey(d => d.NatureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__nature_na__natur__075714DC");
            });

            modelBuilder.Entity<EFNaturePokeathlonStats>(entity =>
            {
                entity.HasKey(e => new { e.NatureId, e.PokeathlonStatId })
                    .HasName("PK__nature_p__B7E2297D1028F748");

                entity.ToTable("nature_pokeathlon_stats");

                entity.Property(e => e.NatureId).HasColumnName("nature_id");

                entity.Property(e => e.PokeathlonStatId).HasColumnName("pokeathlon_stat_id");

                entity.Property(e => e.MaxChange).HasColumnName("max_change");

                entity.HasOne(d => d.Nature)
                    .WithMany(p => p.NaturePokeathlonStats)
                    .HasForeignKey(d => d.NatureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__nature_po__natur__67DE6983");

                entity.HasOne(d => d.PokeathlonStat)
                    .WithMany(p => p.NaturePokeathlonStats)
                    .HasForeignKey(d => d.PokeathlonStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__nature_po__pokea__68D28DBC");
            });

            modelBuilder.Entity<EFNatures>(entity =>
            {
                entity.ToTable("natures");

                entity.HasIndex(e => e.GameIndex)
                    .HasName("UQ__natures__7A748B6E6E419828")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DecreasedStatId).HasColumnName("decreased_stat_id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.Property(e => e.HatesFlavorId).HasColumnName("hates_flavor_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IncreasedStatId).HasColumnName("increased_stat_id");

                entity.Property(e => e.LikesFlavorId).HasColumnName("likes_flavor_id");

                entity.HasOne(d => d.DecreasedStat)
                    .WithMany(p => p.NaturesDecreasedStat)
                    .HasForeignKey(d => d.DecreasedStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__natures__decreas__2F9A1060");

                entity.HasOne(d => d.HatesFlavor)
                    .WithMany(p => p.NaturesHatesFlavor)
                    .HasForeignKey(d => d.HatesFlavorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__natures__hates_f__318258D2");

                entity.HasOne(d => d.IncreasedStat)
                    .WithMany(p => p.NaturesIncreasedStat)
                    .HasForeignKey(d => d.IncreasedStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__natures__increas__308E3499");

                entity.HasOne(d => d.LikesFlavor)
                    .WithMany(p => p.NaturesLikesFlavor)
                    .HasForeignKey(d => d.LikesFlavorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__natures__likes_f__32767D0B");
            });

            modelBuilder.Entity<EFPalPark>(entity =>
            {
                entity.HasKey(e => e.SpeciesId)
                    .HasName("PK__pal_park__B23DC5C23459BD64");

                entity.ToTable("pal_park");

                entity.Property(e => e.SpeciesId)
                    .HasColumnName("species_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.BaseScore).HasColumnName("base_score");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.PalPark)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pal_park__area_i__442B18F2");

                entity.HasOne(d => d.Species)
                    .WithOne(p => p.PalPark)
                    .HasForeignKey<EFPalPark>(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pal_park__specie__4336F4B9");
            });

            modelBuilder.Entity<EFPalParkAreaNames>(entity =>
            {
                entity.HasKey(e => new { e.PalParkAreaId, e.LocalLanguageId })
                    .HasName("PK__pal_park__7249099876F18E0F");

                entity.ToTable("pal_park_area_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pal_park_area_names_name");

                entity.Property(e => e.PalParkAreaId).HasColumnName("pal_park_area_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PalParkAreaNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pal_park___local__1332DBDC");

                entity.HasOne(d => d.PalParkArea)
                    .WithMany(p => p.PalParkAreaNames)
                    .HasForeignKey(d => d.PalParkAreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pal_park___pal_p__123EB7A3");
            });

            modelBuilder.Entity<EFPalParkAreas>(entity =>
            {
                entity.ToTable("pal_park_areas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFPokeathlonStatNames>(entity =>
            {
                entity.HasKey(e => new { e.PokeathlonStatId, e.LocalLanguageId })
                    .HasName("PK__pokeathl__F4F05CDC16345186");

                entity.ToTable("pokeathlon_stat_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pokeathlon_stat_names_name");

                entity.Property(e => e.PokeathlonStatId).HasColumnName("pokeathlon_stat_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokeathlonStatNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokeathlo__local__6FB49575");

                entity.HasOne(d => d.PokeathlonStat)
                    .WithMany(p => p.PokeathlonStatNames)
                    .HasForeignKey(d => d.PokeathlonStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokeathlo__pokea__6EC0713C");
            });

            modelBuilder.Entity<EFPokeathlonStats>(entity =>
            {
                entity.ToTable("pokeathlon_stats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFPokedexProse>(entity =>
            {
                entity.HasKey(e => new { e.PokedexId, e.LocalLanguageId })
                    .HasName("PK__pokedex___FD3A611E2E92FECE");

                entity.ToTable("pokedex_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pokedex_prose_name");

                entity.Property(e => e.PokedexId).HasColumnName("pokedex_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokedexProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokedex_p__local__36470DEF");

                entity.HasOne(d => d.Pokedex)
                    .WithMany(p => p.PokedexProse)
                    .HasForeignKey(d => d.PokedexId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokedex_p__poked__3552E9B6");
            });

            modelBuilder.Entity<EFPokedexVersionGroups>(entity =>
            {
                entity.HasKey(e => new { e.PokedexId, e.VersionGroupId })
                    .HasName("PK__pokedex___C5221676196AFB71");

                entity.ToTable("pokedex_version_groups");

                entity.Property(e => e.PokedexId).HasColumnName("pokedex_id");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.HasOne(d => d.Pokedex)
                    .WithMany(p => p.PokedexVersionGroups)
                    .HasForeignKey(d => d.PokedexId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokedex_v__poked__640DD89F");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.PokedexVersionGroups)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokedex_v__versi__6501FCD8");
            });

            modelBuilder.Entity<EFPokedexes>(entity =>
            {
                entity.ToTable("pokedexes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IsMainSeries).HasColumnName("is_main_series");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Pokedexes)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK__pokedexes__regio__5DCAEF64");
            });

            modelBuilder.Entity<EFPokemon>(entity =>
            {
                entity.ToTable("pokemon");

                entity.HasIndex(e => e.IsDefault)
                    .HasName("ix_pokemon_is_default");

                entity.HasIndex(e => e.Order)
                    .HasName("ix_pokemon_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BaseExperience).HasColumnName("base_experience");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.SpeciesId)
                    .HasConstraintName("FK__pokemon__species__20E1DCB5");
            });

            modelBuilder.Entity<EFPokemonAbilities>(entity =>
            {
                entity.HasKey(e => new { e.PokemonId, e.Slot })
                    .HasName("PK__pokemon___4BB604E4F568D2BD");

                entity.ToTable("pokemon_abilities");

                entity.HasIndex(e => e.IsHidden)
                    .HasName("ix_pokemon_abilities_is_hidden");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.IsHidden).HasColumnName("is_hidden");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.PokemonAbilities)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_a__abili__70FDBF69");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonAbilities)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_a__pokem__70099B30");
            });

            modelBuilder.Entity<EFPokemonColorNames>(entity =>
            {
                entity.HasKey(e => new { e.PokemonColorId, e.LocalLanguageId })
                    .HasName("PK__pokemon___622AE750DF7A23B0");

                entity.ToTable("pokemon_color_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pokemon_color_names_name");

                entity.Property(e => e.PokemonColorId).HasColumnName("pokemon_color_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonColorNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_c__local__6BE40491");

                entity.HasOne(d => d.PokemonColor)
                    .WithMany(p => p.PokemonColorNames)
                    .HasForeignKey(d => d.PokemonColorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_c__pokem__6AEFE058");
            });

            modelBuilder.Entity<EFPokemonColors>(entity =>
            {
                entity.ToTable("pokemon_colors");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFPokemonDexNumbers>(entity =>
            {
                entity.HasKey(e => new { e.SpeciesId, e.PokedexId })
                    .HasName("PK__pokemon___E4AF33814F793847");

                entity.ToTable("pokemon_dex_numbers");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.PokedexId).HasColumnName("pokedex_id");

                entity.Property(e => e.PokedexNumber).HasColumnName("pokedex_number");

                entity.HasOne(d => d.Pokedex)
                    .WithMany(p => p.PokemonDexNumbers)
                    .HasForeignKey(d => d.PokedexId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_d__poked__1E05700A");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.PokemonDexNumbers)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_d__speci__1D114BD1");
            });

            modelBuilder.Entity<EFPokemonEggGroups>(entity =>
            {
                entity.HasKey(e => new { e.SpeciesId, e.EggGroupId })
                    .HasName("PK__pokemon___D865C610ADEDE2C8");

                entity.ToTable("pokemon_egg_groups");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.EggGroupId).HasColumnName("egg_group_id");

                entity.HasOne(d => d.EggGroup)
                    .WithMany(p => p.PokemonEggGroups)
                    .HasForeignKey(d => d.EggGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_e__egg_g__25A691D2");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.PokemonEggGroups)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_e__speci__24B26D99");
            });

            modelBuilder.Entity<EFPokemonEvolution>(entity =>
            {
                entity.ToTable("pokemon_evolution");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EvolutionTriggerId).HasColumnName("evolution_trigger_id");

                entity.Property(e => e.EvolvedSpeciesId).HasColumnName("evolved_species_id");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.HeldItemId).HasColumnName("held_item_id");

                entity.Property(e => e.KnownMoveId).HasColumnName("known_move_id");

                entity.Property(e => e.KnownMoveTypeId).HasColumnName("known_move_type_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MinimumAffection).HasColumnName("minimum_affection");

                entity.Property(e => e.MinimumBeauty).HasColumnName("minimum_beauty");

                entity.Property(e => e.MinimumHappiness).HasColumnName("minimum_happiness");

                entity.Property(e => e.MinimumLevel).HasColumnName("minimum_level");

                entity.Property(e => e.NeedsOverworldRain).HasColumnName("needs_overworld_rain");

                entity.Property(e => e.PartySpeciesId).HasColumnName("party_species_id");

                entity.Property(e => e.PartyTypeId).HasColumnName("party_type_id");

                entity.Property(e => e.RelativePhysicalStats).HasColumnName("relative_physical_stats");

                entity.Property(e => e.TimeOfDay)
                    .HasColumnName("time_of_day")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.TradeSpeciesId).HasColumnName("trade_species_id");

                entity.Property(e => e.TriggerItemId).HasColumnName("trigger_item_id");

                entity.Property(e => e.TurnUpsideDown).HasColumnName("turn_upside_down");

                entity.HasOne(d => d.EvolutionTrigger)
                    .WithMany(p => p.PokemonEvolution)
                    .HasForeignKey(d => d.EvolutionTriggerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_e__evolu__297722B6");

                entity.HasOne(d => d.EvolvedSpecies)
                    .WithMany(p => p.PokemonEvolutionEvolvedSpecies)
                    .HasForeignKey(d => d.EvolvedSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_e__evolv__2882FE7D");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.PokemonEvolution)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__pokemon_e__gende__2B5F6B28");

                entity.HasOne(d => d.HeldItem)
                    .WithMany(p => p.PokemonEvolutionHeldItem)
                    .HasForeignKey(d => d.HeldItemId)
                    .HasConstraintName("FK__pokemon_e__held___2D47B39A");

                entity.HasOne(d => d.KnownMove)
                    .WithMany(p => p.PokemonEvolution)
                    .HasForeignKey(d => d.KnownMoveId)
                    .HasConstraintName("FK__pokemon_e__known__2F2FFC0C");

                entity.HasOne(d => d.KnownMoveType)
                    .WithMany(p => p.PokemonEvolutionKnownMoveType)
                    .HasForeignKey(d => d.KnownMoveTypeId)
                    .HasConstraintName("FK__pokemon_e__known__30242045");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PokemonEvolution)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__pokemon_e__locat__2C538F61");

                entity.HasOne(d => d.PartySpecies)
                    .WithMany(p => p.PokemonEvolutionPartySpecies)
                    .HasForeignKey(d => d.PartySpeciesId)
                    .HasConstraintName("FK__pokemon_e__party__3118447E");

                entity.HasOne(d => d.PartyType)
                    .WithMany(p => p.PokemonEvolutionPartyType)
                    .HasForeignKey(d => d.PartyTypeId)
                    .HasConstraintName("FK__pokemon_e__party__320C68B7");

                entity.HasOne(d => d.TradeSpecies)
                    .WithMany(p => p.PokemonEvolutionTradeSpecies)
                    .HasForeignKey(d => d.TradeSpeciesId)
                    .HasConstraintName("FK__pokemon_e__trade__33008CF0");

                entity.HasOne(d => d.TriggerItem)
                    .WithMany(p => p.PokemonEvolutionTriggerItem)
                    .HasForeignKey(d => d.TriggerItemId)
                    .HasConstraintName("FK__pokemon_e__trigg__2A6B46EF");
            });

            modelBuilder.Entity<EFPokemonFormGenerations>(entity =>
            {
                entity.HasKey(e => new { e.PokemonFormId, e.GenerationId })
                    .HasName("PK__pokemon___7BC254EA685116A8");

                entity.ToTable("pokemon_form_generations");

                entity.Property(e => e.PokemonFormId).HasColumnName("pokemon_form_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.PokemonFormGenerations)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_f__gener__031C6FA4");

                entity.HasOne(d => d.PokemonForm)
                    .WithMany(p => p.PokemonFormGenerations)
                    .HasForeignKey(d => d.PokemonFormId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_f__pokem__02284B6B");
            });

            modelBuilder.Entity<EFPokemonFormNames>(entity =>
            {
                entity.HasKey(e => new { e.PokemonFormId, e.LocalLanguageId })
                    .HasName("PK__pokemon___505F2CA5F8EA1A4C");

                entity.ToTable("pokemon_form_names");

                entity.HasIndex(e => e.FormName)
                    .HasName("ix_pokemon_form_names_form_name");

                entity.HasIndex(e => e.PokemonName)
                    .HasName("ix_pokemon_form_names_pokemon_name");

                entity.Property(e => e.PokemonFormId).HasColumnName("pokemon_form_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.FormName)
                    .HasColumnName("form_name")
                    .HasMaxLength(79);

                entity.Property(e => e.PokemonName)
                    .HasColumnName("pokemon_name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonFormNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_f__local__06ED0088");

                entity.HasOne(d => d.PokemonForm)
                    .WithMany(p => p.PokemonFormNames)
                    .HasForeignKey(d => d.PokemonFormId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_f__pokem__05F8DC4F");
            });

            modelBuilder.Entity<EFPokemonFormPokeathlonStats>(entity =>
            {
                entity.HasKey(e => new { e.PokemonFormId, e.PokeathlonStatId })
                    .HasName("PK__pokemon___B2447C10FCFC6310");

                entity.ToTable("pokemon_form_pokeathlon_stats");

                entity.Property(e => e.PokemonFormId).HasColumnName("pokemon_form_id");

                entity.Property(e => e.PokeathlonStatId).HasColumnName("pokeathlon_stat_id");

                entity.Property(e => e.BaseStat).HasColumnName("base_stat");

                entity.Property(e => e.MaximumStat).HasColumnName("maximum_stat");

                entity.Property(e => e.MinimumStat).HasColumnName("minimum_stat");

                entity.HasOne(d => d.PokeathlonStat)
                    .WithMany(p => p.PokemonFormPokeathlonStats)
                    .HasForeignKey(d => d.PokeathlonStatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_f__pokea__0E8E2250");

                entity.HasOne(d => d.PokemonForm)
                    .WithMany(p => p.PokemonFormPokeathlonStats)
                    .HasForeignKey(d => d.PokemonFormId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_f__pokem__0D99FE17");
            });

            modelBuilder.Entity<EFPokemonForms>(entity =>
            {
                entity.ToTable("pokemon_forms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormIdentifier)
                    .HasColumnName("form_identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.FormOrder).HasColumnName("form_order");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IntroducedInVersionGroupId).HasColumnName("introduced_in_version_group_id");

                entity.Property(e => e.IsBattleOnly).HasColumnName("is_battle_only");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.IsMega).HasColumnName("is_mega");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.HasOne(d => d.IntroducedInVersionGroup)
                    .WithMany(p => p.PokemonForms)
                    .HasForeignKey(d => d.IntroducedInVersionGroupId)
                    .HasConstraintName("FK__pokemon_f__intro__60C757A0");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonForms)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_f__pokem__5FD33367");
            });

            modelBuilder.Entity<EFPokemonGameIndices>(entity =>
            {
                entity.HasKey(e => new { e.PokemonId, e.VersionId })
                    .HasName("PK__pokemon___A8E18E83C80A06C6");

                entity.ToTable("pokemon_game_indices");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonGameIndices)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_g__pokem__7A8729A3");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.PokemonGameIndices)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_g__versi__7B7B4DDC");
            });

            modelBuilder.Entity<EFPokemonHabitatNames>(entity =>
            {
                entity.HasKey(e => new { e.PokemonHabitatId, e.LocalLanguageId })
                    .HasName("PK__pokemon___3C8CACCDCFBAFFC2");

                entity.ToTable("pokemon_habitat_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pokemon_habitat_names_name");

                entity.Property(e => e.PokemonHabitatId).HasColumnName("pokemon_habitat_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonHabitatNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_h__local__2CF2ADDF");

                entity.HasOne(d => d.PokemonHabitat)
                    .WithMany(p => p.PokemonHabitatNames)
                    .HasForeignKey(d => d.PokemonHabitatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_h__pokem__2BFE89A6");
            });

            modelBuilder.Entity<EFPokemonHabitats>(entity =>
            {
                entity.ToTable("pokemon_habitats");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFPokemonItems>(entity =>
            {
                entity.HasKey(e => new { e.PokemonId, e.VersionId, e.ItemId })
                    .HasName("PK__pokemon___74B38C8CEF2396B6");

                entity.ToTable("pokemon_items");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Rarity).HasColumnName("rarity");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PokemonItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_i__item___5CF6C6BC");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonItems)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_i__pokem__5B0E7E4A");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.PokemonItems)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_i__versi__5C02A283");
            });

            modelBuilder.Entity<EFPokemonMoveMethodProse>(entity =>
            {
                entity.HasKey(e => new { e.PokemonMoveMethodId, e.LocalLanguageId })
                    .HasName("PK__pokemon___722CA42878130931");

                entity.ToTable("pokemon_move_method_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pokemon_move_method_prose_name");

                entity.Property(e => e.PokemonMoveMethodId).HasColumnName("pokemon_move_method_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonMoveMethodProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_m__local__0B91BA14");

                entity.HasOne(d => d.PokemonMoveMethod)
                    .WithMany(p => p.PokemonMoveMethodProse)
                    .HasForeignKey(d => d.PokemonMoveMethodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_m__pokem__0A9D95DB");
            });

            modelBuilder.Entity<EFPokemonMoveMethods>(entity =>
            {
                entity.ToTable("pokemon_move_methods");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFPokemonMoves>(entity =>
            {
                entity.HasKey(e => new { e.PokemonId, e.VersionGroupId, e.MoveId, e.PokemonMoveMethodId, e.Level })
                    .HasName("PK__pokemon___3C8230039D19A62B");

                entity.ToTable("pokemon_moves");

                entity.HasIndex(e => e.Level)
                    .HasName("ix_pokemon_moves_level");

                entity.HasIndex(e => e.MoveId)
                    .HasName("ix_pokemon_moves_move_id");

                entity.HasIndex(e => e.PokemonId)
                    .HasName("ix_pokemon_moves_pokemon_id");

                entity.HasIndex(e => e.PokemonMoveMethodId)
                    .HasName("ix_pokemon_moves_pokemon_move_method_id");

                entity.HasIndex(e => e.VersionGroupId)
                    .HasName("ix_pokemon_moves_version_group_id");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.Property(e => e.MoveId).HasColumnName("move_id");

                entity.Property(e => e.PokemonMoveMethodId).HasColumnName("pokemon_move_method_id");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.PokemonMoves)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_m__move___76B698BF");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonMoves)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_m__pokem__74CE504D");

                entity.HasOne(d => d.PokemonMoveMethod)
                    .WithMany(p => p.PokemonMoves)
                    .HasForeignKey(d => d.PokemonMoveMethodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_m__pokem__77AABCF8");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.PokemonMoves)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_m__versi__75C27486");
            });

            modelBuilder.Entity<EFPokemonShapeProse>(entity =>
            {
                entity.HasKey(e => new { e.PokemonShapeId, e.LocalLanguageId })
                    .HasName("PK__pokemon___F3FD34C2C4B06D16");

                entity.ToTable("pokemon_shape_prose");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pokemon_shape_prose_name");

                entity.Property(e => e.PokemonShapeId).HasColumnName("pokemon_shape_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.AwesomeName)
                    .HasColumnName("awesome_name")
                    .HasMaxLength(79);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonShapeProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__local__5AB9788F");

                entity.HasOne(d => d.PokemonShape)
                    .WithMany(p => p.PokemonShapeProse)
                    .HasForeignKey(d => d.PokemonShapeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__pokem__59C55456");
            });

            modelBuilder.Entity<EFPokemonShapes>(entity =>
            {
                entity.ToTable("pokemon_shapes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFPokemonSpecies>(entity =>
            {
                entity.ToTable("pokemon_species");

                entity.HasIndex(e => e.ConquestOrder)
                    .HasName("ix_pokemon_species_conquest_order");

                entity.HasIndex(e => e.Order)
                    .HasName("ix_pokemon_species_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BaseHappiness).HasColumnName("base_happiness");

                entity.Property(e => e.CaptureRate).HasColumnName("capture_rate");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ConquestOrder).HasColumnName("conquest_order");

                entity.Property(e => e.EvolutionChainId).HasColumnName("evolution_chain_id");

                entity.Property(e => e.EvolvesFromSpeciesId).HasColumnName("evolves_from_species_id");

                entity.Property(e => e.FormsSwitchable).HasColumnName("forms_switchable");

                entity.Property(e => e.GenderRate).HasColumnName("gender_rate");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.GrowthRateId).HasColumnName("growth_rate_id");

                entity.Property(e => e.HabitatId).HasColumnName("habitat_id");

                entity.Property(e => e.HasGenderDifferences).HasColumnName("has_gender_differences");

                entity.Property(e => e.HatchCounter).HasColumnName("hatch_counter");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IsBaby).HasColumnName("is_baby");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.ShapeId).HasColumnName("shape_id");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.PokemonSpecies)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__color__595B4002");

                entity.HasOne(d => d.EvolutionChain)
                    .WithMany(p => p.PokemonSpecies)
                    .HasForeignKey(d => d.EvolutionChainId)
                    .HasConstraintName("FK__pokemon_s__evolu__58671BC9");

                entity.HasOne(d => d.EvolvesFromSpecies)
                    .WithMany(p => p.InverseEvolvesFromSpecies)
                    .HasForeignKey(d => d.EvolvesFromSpeciesId)
                    .HasConstraintName("FK__pokemon_s__evolv__5772F790");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.PokemonSpecies)
                    .HasForeignKey(d => d.GenerationId)
                    .HasConstraintName("FK__pokemon_s__gener__567ED357");

                entity.HasOne(d => d.GrowthRate)
                    .WithMany(p => p.PokemonSpecies)
                    .HasForeignKey(d => d.GrowthRateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__growt__5E1FF51F");

                entity.HasOne(d => d.Habitat)
                    .WithMany(p => p.PokemonSpecies)
                    .HasForeignKey(d => d.HabitatId)
                    .HasConstraintName("FK__pokemon_s__habit__5B438874");

                entity.HasOne(d => d.Shape)
                    .WithMany(p => p.PokemonSpecies)
                    .HasForeignKey(d => d.ShapeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__shape__5A4F643B");
            });

            modelBuilder.Entity<EFPokemonSpeciesFlavorSummaries>(entity =>
            {
                entity.HasKey(e => new { e.PokemonSpeciesId, e.LocalLanguageId })
                    .HasName("PK__pokemon___6292A54C1F107F50");

                entity.ToTable("pokemon_species_flavor_summaries");

                entity.Property(e => e.PokemonSpeciesId).HasColumnName("pokemon_species_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.FlavorSummary).HasColumnName("flavor_summary");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonSpeciesFlavorSummaries)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__local__3C89F72A");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithMany(p => p.PokemonSpeciesFlavorSummaries)
                    .HasForeignKey(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__pokem__3B95D2F1");
            });

            modelBuilder.Entity<EFPokemonSpeciesFlavorText>(entity =>
            {
                entity.HasKey(e => new { e.SpeciesId, e.VersionId, e.LanguageId })
                    .HasName("PK__pokemon___80C7D1B2586BE6D1");

                entity.ToTable("pokemon_species_flavor_text");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FlavorText)
                    .IsRequired()
                    .HasColumnName("flavor_text");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PokemonSpeciesFlavorText)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__langu__5090EFD7");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.PokemonSpeciesFlavorText)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__speci__4EA8A765");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.PokemonSpeciesFlavorText)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__versi__4F9CCB9E");
            });

            modelBuilder.Entity<EFPokemonSpeciesNames>(entity =>
            {
                entity.HasKey(e => new { e.PokemonSpeciesId, e.LocalLanguageId })
                    .HasName("PK__pokemon___6292A54CD8D323EE");

                entity.ToTable("pokemon_species_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_pokemon_species_names_name");

                entity.Property(e => e.PokemonSpeciesId).HasColumnName("pokemon_species_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Genus).HasColumnName("genus");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonSpeciesNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__local__5832119F");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithMany(p => p.PokemonSpeciesNames)
                    .HasForeignKey(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__pokem__573DED66");
            });

            modelBuilder.Entity<EFPokemonSpeciesProse>(entity =>
            {
                entity.HasKey(e => new { e.PokemonSpeciesId, e.LocalLanguageId })
                    .HasName("PK__pokemon___6292A54C319AF31C");

                entity.ToTable("pokemon_species_prose");

                entity.Property(e => e.PokemonSpeciesId).HasColumnName("pokemon_species_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.FormDescription).HasColumnName("form_description");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.PokemonSpeciesProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__local__4BCC3ABA");

                entity.HasOne(d => d.PokemonSpecies)
                    .WithMany(p => p.PokemonSpeciesProse)
                    .HasForeignKey(d => d.PokemonSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__pokem__4AD81681");
            });

            modelBuilder.Entity<EFPokemonStats>(entity =>
            {
                entity.HasKey(e => new { e.PokemonId, e.StatId })
                    .HasName("PK__pokemon___331184538265E274");

                entity.ToTable("pokemon_stats");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.StatId).HasColumnName("stat_id");

                entity.Property(e => e.BaseStat).HasColumnName("base_stat");

                entity.Property(e => e.Effort).HasColumnName("effort");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonStats)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__pokem__7E57BA87");

                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.PokemonStats)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_s__stat___7F4BDEC0");
            });

            modelBuilder.Entity<EFPokemonTypes>(entity =>
            {
                entity.HasKey(e => new { e.PokemonId, e.Slot })
                    .HasName("PK__pokemon___4BB604E436502848");

                entity.ToTable("pokemon_types");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonTypes)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_t__pokem__6C390A4C");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PokemonTypes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pokemon_t__type___6D2D2E85");
            });

            modelBuilder.Entity<EFRegionNames>(entity =>
            {
                entity.HasKey(e => new { e.RegionId, e.LocalLanguageId })
                    .HasName("PK__region_n__95016E84F268F2C2");

                entity.ToTable("region_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_region_names_name");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.RegionNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__region_na__local__00200768");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.RegionNames)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__region_na__regio__7F2BE32F");
            });

            modelBuilder.Entity<EFRegions>(entity =>
            {
                entity.ToTable("regions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);
            });

            modelBuilder.Entity<EFStatNames>(entity =>
            {
                entity.HasKey(e => new { e.StatId, e.LocalLanguageId })
                    .HasName("PK__stat_nam__2CB0204AB0638E73");

                entity.ToTable("stat_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_stat_names_name");

                entity.Property(e => e.StatId).HasColumnName("stat_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.StatNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__stat_name__local__7E02B4CC");

                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.StatNames)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__stat_name__stat___7D0E9093");
            });

            modelBuilder.Entity<EFStats>(entity =>
            {
                entity.ToTable("stats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DamageClassId).HasColumnName("damage_class_id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.IsBattleOnly).HasColumnName("is_battle_only");

                entity.HasOne(d => d.DamageClass)
                    .WithMany(p => p.Stats)
                    .HasForeignKey(d => d.DamageClassId)
                    .HasConstraintName("FK__stats__damage_cl__619B8048");
            });

            modelBuilder.Entity<EFSuperContestCombos>(entity =>
            {
                entity.HasKey(e => new { e.FirstMoveId, e.SecondMoveId })
                    .HasName("PK__super_co__456AD1D36E05CE75");

                entity.ToTable("super_contest_combos");

                entity.Property(e => e.FirstMoveId).HasColumnName("first_move_id");

                entity.Property(e => e.SecondMoveId).HasColumnName("second_move_id");

                entity.HasOne(d => d.FirstMove)
                    .WithMany(p => p.SuperContestCombosFirstMove)
                    .HasForeignKey(d => d.FirstMoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__super_con__first__703EA55A");

                entity.HasOne(d => d.SecondMove)
                    .WithMany(p => p.SuperContestCombosSecondMove)
                    .HasForeignKey(d => d.SecondMoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__super_con__secon__7132C993");
            });

            modelBuilder.Entity<EFSuperContestEffectProse>(entity =>
            {
                entity.HasKey(e => new { e.SuperContestEffectId, e.LocalLanguageId })
                    .HasName("PK__super_co__1D9CD2C4D79C4D05");

                entity.ToTable("super_contest_effect_prose");

                entity.Property(e => e.SuperContestEffectId).HasColumnName("super_contest_effect_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.FlavorText)
                    .IsRequired()
                    .HasColumnName("flavor_text");

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.SuperContestEffectProse)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__super_con__local__47A6A41B");

                entity.HasOne(d => d.SuperContestEffect)
                    .WithMany(p => p.SuperContestEffectProse)
                    .HasForeignKey(d => d.SuperContestEffectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__super_con__super__46B27FE2");
            });

            modelBuilder.Entity<EFSuperContestEffects>(entity =>
            {
                entity.ToTable("super_contest_effects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Appeal).HasColumnName("appeal");
            });

            modelBuilder.Entity<EFTypeEfficacy>(entity =>
            {
                entity.HasKey(e => new { e.DamageTypeId, e.TargetTypeId })
                    .HasName("PK__type_eff__8F341AAAD7A8BF69");

                entity.ToTable("type_efficacy");

                entity.Property(e => e.DamageTypeId).HasColumnName("damage_type_id");

                entity.Property(e => e.TargetTypeId).HasColumnName("target_type_id");

                entity.Property(e => e.DamageFactor).HasColumnName("damage_factor");

                entity.HasOne(d => d.DamageType)
                    .WithMany(p => p.TypeEfficacyDamageType)
                    .HasForeignKey(d => d.DamageTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__type_effi__damag__39237A9A");

                entity.HasOne(d => d.TargetType)
                    .WithMany(p => p.TypeEfficacyTargetType)
                    .HasForeignKey(d => d.TargetTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__type_effi__targe__3A179ED3");
            });

            modelBuilder.Entity<EFTypeGameIndices>(entity =>
            {
                entity.HasKey(e => new { e.TypeId, e.GenerationId })
                    .HasName("PK__type_gam__938878FD45073882");

                entity.ToTable("type_game_indices");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.GameIndex).HasColumnName("game_index");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.TypeGameIndices)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__type_game__gener__26CFC035");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TypeGameIndices)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__type_game__type___25DB9BFC");
            });

            modelBuilder.Entity<EFTypeNames>(entity =>
            {
                entity.HasKey(e => new { e.TypeId, e.LocalLanguageId })
                    .HasName("PK__type_nam__B81500B290F23E96");

                entity.ToTable("type_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_type_names_name");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.TypeNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__type_name__local__047AA831");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TypeNames)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__type_name__type___038683F8");
            });

            modelBuilder.Entity<EFTypes>(entity =>
            {
                entity.ToTable("types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DamageClassId).HasColumnName("damage_class_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.HasOne(d => d.DamageClass)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.DamageClassId)
                    .HasConstraintName("FK__types__damage_cl__18B6AB08");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__types__generatio__17C286CF");
            });

            modelBuilder.Entity<EFVersionGroupPokemonMoveMethods>(entity =>
            {
                entity.HasKey(e => new { e.VersionGroupId, e.PokemonMoveMethodId })
                    .HasName("PK__version___FEB4BE3B73D8DD11");

                entity.ToTable("version_group_pokemon_move_methods");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.Property(e => e.PokemonMoveMethodId).HasColumnName("pokemon_move_method_id");

                entity.HasOne(d => d.PokemonMoveMethod)
                    .WithMany(p => p.VersionGroupPokemonMoveMethods)
                    .HasForeignKey(d => d.PokemonMoveMethodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__version_g__pokem__0C1BC9F9");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.VersionGroupPokemonMoveMethods)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__version_g__versi__0B27A5C0");
            });

            modelBuilder.Entity<EFVersionGroupRegions>(entity =>
            {
                entity.HasKey(e => new { e.VersionGroupId, e.RegionId })
                    .HasName("PK__version___30C66291A7D097D3");

                entity.ToTable("version_group_regions");

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.VersionGroupRegions)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__version_g__regio__1975C517");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.VersionGroupRegions)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__version_g__versi__1881A0DE");
            });

            modelBuilder.Entity<EFVersionGroups>(entity =>
            {
                entity.ToTable("version_groups");

                entity.HasIndex(e => e.Identifier)
                    .HasName("UQ__version___D112ED48B74082D3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.Order).HasColumnName("order");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.VersionGroups)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__version_g__gener__2BC97F7C");
            });

            modelBuilder.Entity<EFVersionNames>(entity =>
            {
                entity.HasKey(e => new { e.VersionId, e.LocalLanguageId })
                    .HasName("PK__version___93B08D4340848693");

                entity.ToTable("version_names");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_version_names_name");

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.LocalLanguageId).HasColumnName("local_language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(79);

                entity.HasOne(d => d.LocalLanguage)
                    .WithMany(p => p.VersionNames)
                    .HasForeignKey(d => d.LocalLanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__version_n__local__4C0144E4");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.VersionNames)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__version_n__versi__4B0D20AB");
            });

            modelBuilder.Entity<EFVersions>(entity =>
            {
                entity.ToTable("versions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(79);

                entity.Property(e => e.VersionGroupId).HasColumnName("version_group_id");

                entity.HasOne(d => d.VersionGroup)
                    .WithMany(p => p.Versions)
                    .HasForeignKey(d => d.VersionGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__versions__versio__00AA174D");
            });
        }

        public virtual DbSet<EFAbilities> Abilities { get; set; }
        public virtual DbSet<EFAbilityChangelog> AbilityChangelog { get; set; }
        public virtual DbSet<EFAbilityChangelogProse> AbilityChangelogProse { get; set; }
        public virtual DbSet<EFAbilityFlavorText> AbilityFlavorText { get; set; }
        public virtual DbSet<EFAbilityNames> AbilityNames { get; set; }
        public virtual DbSet<EFAbilityProse> AbilityProse { get; set; }
        public virtual DbSet<EFBerries> Berries { get; set; }
        public virtual DbSet<EFBerryFirmness> BerryFirmness { get; set; }
        public virtual DbSet<EFBerryFirmnessNames> BerryFirmnessNames { get; set; }
        public virtual DbSet<EFBerryFlavors> BerryFlavors { get; set; }
        public virtual DbSet<EFCharacteristicText> CharacteristicText { get; set; }
        public virtual DbSet<EFCharacteristics> Characteristics { get; set; }
        public virtual DbSet<EFConquestEpisodeNames> ConquestEpisodeNames { get; set; }
        public virtual DbSet<EFConquestEpisodeWarriors> ConquestEpisodeWarriors { get; set; }
        public virtual DbSet<EFConquestEpisodes> ConquestEpisodes { get; set; }
        public virtual DbSet<EFConquestKingdomNames> ConquestKingdomNames { get; set; }
        public virtual DbSet<EFConquestKingdoms> ConquestKingdoms { get; set; }
        public virtual DbSet<EFConquestMaxLinks> ConquestMaxLinks { get; set; }
        public virtual DbSet<EFConquestMoveData> ConquestMoveData { get; set; }
        public virtual DbSet<EFConquestMoveDisplacementProse> ConquestMoveDisplacementProse { get; set; }
        public virtual DbSet<EFConquestMoveDisplacements> ConquestMoveDisplacements { get; set; }
        public virtual DbSet<EFConquestMoveEffectProse> ConquestMoveEffectProse { get; set; }
        public virtual DbSet<EFConquestMoveEffects> ConquestMoveEffects { get; set; }
        public virtual DbSet<EFConquestMoveRangeProse> ConquestMoveRangeProse { get; set; }
        public virtual DbSet<EFConquestMoveRanges> ConquestMoveRanges { get; set; }
        public virtual DbSet<EFConquestPokemonAbilities> ConquestPokemonAbilities { get; set; }
        public virtual DbSet<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual DbSet<EFConquestPokemonMoves> ConquestPokemonMoves { get; set; }
        public virtual DbSet<EFConquestPokemonStats> ConquestPokemonStats { get; set; }
        public virtual DbSet<EFConquestStatNames> ConquestStatNames { get; set; }
        public virtual DbSet<EFConquestStats> ConquestStats { get; set; }
        public virtual DbSet<EFConquestTransformationPokemon> ConquestTransformationPokemon { get; set; }
        public virtual DbSet<EFConquestTransformationWarriors> ConquestTransformationWarriors { get; set; }
        public virtual DbSet<EFConquestWarriorArchetypes> ConquestWarriorArchetypes { get; set; }
        public virtual DbSet<EFConquestWarriorNames> ConquestWarriorNames { get; set; }
        public virtual DbSet<EFConquestWarriorRankStatMap> ConquestWarriorRankStatMap { get; set; }
        public virtual DbSet<EFConquestWarriorRanks> ConquestWarriorRanks { get; set; }
        public virtual DbSet<EFConquestWarriorSkillNames> ConquestWarriorSkillNames { get; set; }
        public virtual DbSet<EFConquestWarriorSkills> ConquestWarriorSkills { get; set; }
        public virtual DbSet<EFConquestWarriorSpecialties> ConquestWarriorSpecialties { get; set; }
        public virtual DbSet<EFConquestWarriorStatNames> ConquestWarriorStatNames { get; set; }
        public virtual DbSet<EFConquestWarriorStats> ConquestWarriorStats { get; set; }
        public virtual DbSet<EFConquestWarriorTransformation> ConquestWarriorTransformation { get; set; }
        public virtual DbSet<EFConquestWarriors> ConquestWarriors { get; set; }
        public virtual DbSet<EFContestCombos> ContestCombos { get; set; }
        public virtual DbSet<EFContestEffectProse> ContestEffectProse { get; set; }
        public virtual DbSet<EFContestEffects> ContestEffects { get; set; }
        public virtual DbSet<EFContestTypeNames> ContestTypeNames { get; set; }
        public virtual DbSet<EFContestTypes> ContestTypes { get; set; }
        public virtual DbSet<EFEggGroupProse> EggGroupProse { get; set; }
        public virtual DbSet<EFEggGroups> EggGroups { get; set; }
        public virtual DbSet<EFEncounterConditionProse> EncounterConditionProse { get; set; }
        public virtual DbSet<EFEncounterConditionValueMap> EncounterConditionValueMap { get; set; }
        public virtual DbSet<EFEncounterConditionValueProse> EncounterConditionValueProse { get; set; }
        public virtual DbSet<EFEncounterConditionValues> EncounterConditionValues { get; set; }
        public virtual DbSet<EFEncounterConditions> EncounterConditions { get; set; }
        public virtual DbSet<EFEncounterMethodProse> EncounterMethodProse { get; set; }
        public virtual DbSet<EFEncounterMethods> EncounterMethods { get; set; }
        public virtual DbSet<EFEncounterSlots> EncounterSlots { get; set; }
        public virtual DbSet<EFEncounters> Encounters { get; set; }
        public virtual DbSet<EFEvolutionChains> EvolutionChains { get; set; }
        public virtual DbSet<EFEvolutionTriggerProse> EvolutionTriggerProse { get; set; }
        public virtual DbSet<EFEvolutionTriggers> EvolutionTriggers { get; set; }
        public virtual DbSet<EFExperience> Experience { get; set; }
        public virtual DbSet<EFGenders> Genders { get; set; }
        public virtual DbSet<EFGenerationNames> GenerationNames { get; set; }
        public virtual DbSet<EFGenerations> Generations { get; set; }
        public virtual DbSet<EFGrowthRateProse> GrowthRateProse { get; set; }
        public virtual DbSet<EFGrowthRates> GrowthRates { get; set; }
        public virtual DbSet<EFItemCategories> ItemCategories { get; set; }
        public virtual DbSet<EFItemCategoryProse> ItemCategoryProse { get; set; }
        public virtual DbSet<EFItemFlagMap> ItemFlagMap { get; set; }
        public virtual DbSet<EFItemFlagProse> ItemFlagProse { get; set; }
        public virtual DbSet<EFItemFlags> ItemFlags { get; set; }
        public virtual DbSet<EFItemFlavorSummaries> ItemFlavorSummaries { get; set; }
        public virtual DbSet<EFItemFlavorText> ItemFlavorText { get; set; }
        public virtual DbSet<EFItemFlingEffectProse> ItemFlingEffectProse { get; set; }
        public virtual DbSet<EFItemFlingEffects> ItemFlingEffects { get; set; }
        public virtual DbSet<EFItemGameIndices> ItemGameIndices { get; set; }
        public virtual DbSet<EFItemNames> ItemNames { get; set; }
        public virtual DbSet<EFItemPocketNames> ItemPocketNames { get; set; }
        public virtual DbSet<EFItemPockets> ItemPockets { get; set; }
        public virtual DbSet<EFItemProse> ItemProse { get; set; }
        public virtual DbSet<EFItems> Items { get; set; }
        public virtual DbSet<EFLanguageNames> LanguageNames { get; set; }
        public virtual DbSet<EFLanguages> Languages { get; set; }
        public virtual DbSet<EFLocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
        public virtual DbSet<EFLocationAreaProse> LocationAreaProse { get; set; }
        public virtual DbSet<EFLocationAreas> LocationAreas { get; set; }
        public virtual DbSet<EFLocationGameIndices> LocationGameIndices { get; set; }
        public virtual DbSet<EFLocationNames> LocationNames { get; set; }
        public virtual DbSet<EFLocations> Locations { get; set; }
        public virtual DbSet<EFMachines> Machines { get; set; }
        public virtual DbSet<EFMoveBattleStyleProse> MoveBattleStyleProse { get; set; }
        public virtual DbSet<EFMoveBattleStyles> MoveBattleStyles { get; set; }
        public virtual DbSet<EFMoveChangelog> MoveChangelog { get; set; }
        public virtual DbSet<EFMoveDamageClassProse> MoveDamageClassProse { get; set; }
        public virtual DbSet<EFMoveDamageClasses> MoveDamageClasses { get; set; }
        public virtual DbSet<EFMoveEffectChangelog> MoveEffectChangelog { get; set; }
        public virtual DbSet<EFMoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public virtual DbSet<EFMoveEffectProse> MoveEffectProse { get; set; }
        public virtual DbSet<EFMoveEffects> MoveEffects { get; set; }
        public virtual DbSet<EFMoveFlagMap> MoveFlagMap { get; set; }
        public virtual DbSet<EFMoveFlagProse> MoveFlagProse { get; set; }
        public virtual DbSet<EFMoveFlags> MoveFlags { get; set; }
        public virtual DbSet<EFMoveFlavorSummaries> MoveFlavorSummaries { get; set; }
        public virtual DbSet<EFMoveFlavorText> MoveFlavorText { get; set; }
        public virtual DbSet<EFMoveMeta> MoveMeta { get; set; }
        public virtual DbSet<EFMoveMetaAilmentNames> MoveMetaAilmentNames { get; set; }
        public virtual DbSet<EFMoveMetaAilments> MoveMetaAilments { get; set; }
        public virtual DbSet<EFMoveMetaCategories> MoveMetaCategories { get; set; }
        public virtual DbSet<EFMoveMetaCategoryProse> MoveMetaCategoryProse { get; set; }
        public virtual DbSet<EFMoveMetaStatChanges> MoveMetaStatChanges { get; set; }
        public virtual DbSet<EFMoveNames> MoveNames { get; set; }
        public virtual DbSet<EFMoveTargetProse> MoveTargetProse { get; set; }
        public virtual DbSet<EFMoveTargets> MoveTargets { get; set; }
        public virtual DbSet<EFMoves> Moves { get; set; }
        public virtual DbSet<EFNatureBattleStylePreferences> NatureBattleStylePreferences { get; set; }
        public virtual DbSet<EFNatureNames> NatureNames { get; set; }
        public virtual DbSet<EFNaturePokeathlonStats> NaturePokeathlonStats { get; set; }
        public virtual DbSet<EFNatures> Natures { get; set; }
        public virtual DbSet<EFPalPark> PalPark { get; set; }
        public virtual DbSet<EFPalParkAreaNames> PalParkAreaNames { get; set; }
        public virtual DbSet<EFPalParkAreas> PalParkAreas { get; set; }
        public virtual DbSet<EFPokeathlonStatNames> PokeathlonStatNames { get; set; }
        public virtual DbSet<EFPokeathlonStats> PokeathlonStats { get; set; }
        public virtual DbSet<EFPokedexProse> PokedexProse { get; set; }
        public virtual DbSet<EFPokedexVersionGroups> PokedexVersionGroups { get; set; }
        public virtual DbSet<EFPokedexes> Pokedexes { get; set; }
        public virtual DbSet<EFPokemon> Pokemon { get; set; }
        public virtual DbSet<EFPokemonAbilities> PokemonAbilities { get; set; }
        public virtual DbSet<EFPokemonColorNames> PokemonColorNames { get; set; }
        public virtual DbSet<EFPokemonColors> PokemonColors { get; set; }
        public virtual DbSet<EFPokemonDexNumbers> PokemonDexNumbers { get; set; }
        public virtual DbSet<EFPokemonEggGroups> PokemonEggGroups { get; set; }
        public virtual DbSet<EFPokemonEvolution> PokemonEvolution { get; set; }
        public virtual DbSet<EFPokemonFormGenerations> PokemonFormGenerations { get; set; }
        public virtual DbSet<EFPokemonFormNames> PokemonFormNames { get; set; }
        public virtual DbSet<EFPokemonFormPokeathlonStats> PokemonFormPokeathlonStats { get; set; }
        public virtual DbSet<EFPokemonForms> PokemonForms { get; set; }
        public virtual DbSet<EFPokemonGameIndices> PokemonGameIndices { get; set; }
        public virtual DbSet<EFPokemonHabitatNames> PokemonHabitatNames { get; set; }
        public virtual DbSet<EFPokemonHabitats> PokemonHabitats { get; set; }
        public virtual DbSet<EFPokemonItems> PokemonItems { get; set; }
        public virtual DbSet<EFPokemonMoveMethodProse> PokemonMoveMethodProse { get; set; }
        public virtual DbSet<EFPokemonMoveMethods> PokemonMoveMethods { get; set; }
        public virtual DbSet<EFPokemonMoves> PokemonMoves { get; set; }
        public virtual DbSet<EFPokemonShapeProse> PokemonShapeProse { get; set; }
        public virtual DbSet<EFPokemonShapes> PokemonShapes { get; set; }
        public virtual DbSet<EFPokemonSpecies> PokemonSpecies { get; set; }
        public virtual DbSet<EFPokemonSpeciesFlavorSummaries> PokemonSpeciesFlavorSummaries { get; set; }
        public virtual DbSet<EFPokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public virtual DbSet<EFPokemonSpeciesNames> PokemonSpeciesNames { get; set; }
        public virtual DbSet<EFPokemonSpeciesProse> PokemonSpeciesProse { get; set; }
        public virtual DbSet<EFPokemonStats> PokemonStats { get; set; }
        public virtual DbSet<EFPokemonTypes> PokemonTypes { get; set; }
        public virtual DbSet<EFRegionNames> RegionNames { get; set; }
        public virtual DbSet<EFRegions> Regions { get; set; }
        public virtual DbSet<EFStatNames> StatNames { get; set; }
        public virtual DbSet<EFStats> Stats { get; set; }
        public virtual DbSet<EFSuperContestCombos> SuperContestCombos { get; set; }
        public virtual DbSet<EFSuperContestEffectProse> SuperContestEffectProse { get; set; }
        public virtual DbSet<EFSuperContestEffects> SuperContestEffects { get; set; }
        public virtual DbSet<EFTypeEfficacy> TypeEfficacy { get; set; }
        public virtual DbSet<EFTypeGameIndices> TypeGameIndices { get; set; }
        public virtual DbSet<EFTypeNames> TypeNames { get; set; }
        public virtual DbSet<EFTypes> Types { get; set; }
        public virtual DbSet<EFVersionGroupPokemonMoveMethods> VersionGroupPokemonMoveMethods { get; set; }
        public virtual DbSet<EFVersionGroupRegions> VersionGroupRegions { get; set; }
        public virtual DbSet<EFVersionGroups> VersionGroups { get; set; }
        public virtual DbSet<EFVersionNames> VersionNames { get; set; }
        public virtual DbSet<EFVersions> Versions { get; set; }
    }
}