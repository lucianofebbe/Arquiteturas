using DTOs.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Dtos.Pokemon
{
    public record PokemonResponseDto : BaseResponse
    {
        public List<abilities> abilities { get; set; }
        public string base_experience { get; set; }
        public cries cries { get; set; }
        public List<forms> forms { get; set; }
        public List<game_indices> game_indices { get; set; }
        public int height { get; set; }
        public List<held_items> held_items { get; set; }
        public int id { get; set; }
        public bool is_default { get; set; }
        public string location_area_encounters { get; set; }
        public List<moves> moves { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public List<past_abilities> past_abilities { get; set; }
        public List<past_types> past_types { get; set; }
        public species species { get; set; }
        public sprites sprites { get; set; }
        public List<stats> stats { get; set; }
        public List<types> types { get; set; }
        public float weight { get; set; }
    }

    #region abilities
    public record abilities : BaseResponse
    {
        public bool is_hidden { get; set; }
        public int slot { get; set; }
        public ability ability { get; set; }
    }

    public record ability : BaseResponse
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region cries
    public record cries
    {
        public string latest { get; set; }
        public string legacy { get; set; }
    }
    #endregion

    #region forms
    public record forms
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region game_indices
    public struct game_indices
    {
        public int game_index { get; set; }
        public version version { get; set; }
    }

    public struct version
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region held_items
    public record held_items
    {
        public item item { get; set; }
        public List<version_details> version_details { get; set; }
    }

    public record item
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public record version_details
    {
        public string rarity { get; set; }
        public version version { get; set; }
    }
    #endregion

    #region moves
    public record moves
    {
        public move move { get; set; }
        public List<version_group_details> version_group_details { get; set; }
    }

    public record move
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public record version_group_details
    {
        public int level_learned_at { get; set; }
        public move_learn_method move_learn_method { get; set; }
        public string order { get; set; }
        public version_group version_group { get; set; }
    }

    public record move_learn_method
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public record version_group
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region past_abilities
    public record past_abilities
    {
        public List<abilities> abilities { get; set; }
        public generation generation { get; set; }
    }

    public record generation
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region past_types
    public record past_types
    {
        public NamedResource Generation { get; set; }

        public List<TypeSlot> Types { get; set; }
    }

    public class TypeSlot
    {
        public int Slot { get; set; }

        public NamedResource Type { get; set; }
    }

    public class NamedResource
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
    #endregion

    #region species
    public record species
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region sprites
    public record sprites
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
        public other other { get; set; }
        public versions versions { get; set; }
    }

    public record other
    {
        public dream_world dream_world { get; set; }
        public home home { get; set; }
        public officialArtwork officialArtwork { get; set; }
        public showdown showdown { get; set; }
    }

    public record dream_world
    {
        public string front_default { get; set; }
        public string front_female { get; set; }
    }

    public record home
    {
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record officialArtwork
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }

    public record showdown
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record versions
    {
        public generationI generationI { get; set; }
        public generationII generationII { get; set; }
        public generationIII generationIII { get; set; }
        public generationIV generationIV { get; set; }
        public generationV generationV { get; set; }
        public generationVI generationVI { get; set; }
        public generationVII generationVII { get; set; }
        public generationVIII generationVIII { get; set; }
    }

    public record generationI
    {
        public redBlue redBlue { get; set; }
        public yellow yellow { get; set; }
    }

    public record redBlue
    {
        public string back_default { get; set; }
        public string back_gray { get; set; }
        public string back_transparent { get; set; }
        public string front_default { get; set; }
        public string front_gray { get; set; }
        public string front_transparent { get; set; }
    }

    public record yellow
    {
        public string back_default { get; set; }
        public string back_gray { get; set; }
        public string back_transparent { get; set; }
        public string front_default { get; set; }
        public string front_gray { get; set; }
        public string front_transparent { get; set; }
    }

    public record generationII
    {
        public crystal crystal { get; set; }
        public gold gold { get; set; }
        public silver silver { get; set; }
    }

    public record crystal
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_transparent { get; set; }
        public string back_transparent { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_transparent { get; set; }
        public string front_transparent { get; set; }
    }

    public record gold
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public string front_transparent { get; set; }
    }

    public record silver
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public string front_transparent { get; set; }
    }

    public record generationIII
    {
        public emerald emerald { get; set; }
        public fireredLeafgreen fireredLeafgreen { get; set; }
        public rubySapphire rubySapphire { get; set; }
    }

    public record emerald
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }

    public record fireredLeafgreen
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }

    public record rubySapphire
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }

    public record generationIV
    {
        public diamondPearl diamondPearl { get; set; }
        public heartgoldSoulsilver heartgoldSoulsilver { get; set; }
        public platinum platinum { get; set; }
    }

    public record diamondPearl
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record heartgoldSoulsilver
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record platinum
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record generationV
    {
        public blackWhite blackWhite { get; set; }
    }

    public record blackWhite
    {
        public animated animated { get; set; }
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record animated
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record generationVI
    {
        public omegarubyAlphasapphire omegarubyAlphasapphireMyProperty { get; set; }
        public xy xy { get; set; }
    }

    public record omegarubyAlphasapphire
    {
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record xy
    {
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record generationVII
    {
        public icons icons { get; set; }
        public ultraSunUltraMoon ultraSunUltraMoon { get; set; }
    }

    public record icons
    {
        public string front_default { get; set; }
        public string front_female { get; set; }
    }

    public record ultraSunUltraMoon
    {
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public record generationVIII
    {
        public icons icons { get; set; }
    }
    #endregion

    #region stats
    public record stats
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public stat stat { get; set; }
    }

    public record stat
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region types
    public record types
    {
        public int slot { get; set; }
        public type type { get; set; }
    }

    public record type
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion
}