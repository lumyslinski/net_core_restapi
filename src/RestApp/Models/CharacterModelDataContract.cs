/*
 * Star Wars API
 *
 * This is a REST API for managing Star Wars characters
 *
 * OpenAPI spec version: 1.0.0
 * Contact: luk@mysl.tech
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using RestApp.Data.Contracts;

namespace RestApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CharacterModelDataContract : IEquatable<CharacterModelDataContract>, ICharacterModel
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets episodes
        /// </summary>
        [Required]
        [DataMember(Name="episodes")]
        public List<string> Episodes { get; set; }

        /// <summary>
        /// Gets or Sets Friends
        /// </summary>
        [Required]
        [DataMember(Name="friends")]
        public List<string> Friends { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CharacterItem {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  episodes: ").Append(Episodes).Append("\n");
            sb.Append("  Friends: ").Append(Friends).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CharacterModelDataContract)obj);
        }

        /// <summary>
        /// Returns true if CharacterItem instances are equal
        /// </summary>
        /// <param name="other">Instance of CharacterItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CharacterModelDataContract other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id && Id.Equals(other.Id)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Episodes == other.Episodes ||
                    Episodes != null &&
                    Episodes.SequenceEqual(other.Episodes)
                ) && 
                (
                    Friends == other.Friends ||
                    Friends != null &&
                    Friends.SequenceEqual(other.Friends)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Episodes != null)
                    hashCode = hashCode * 59 + Episodes.GetHashCode();
                    if (Friends != null)
                    hashCode = hashCode * 59 + Friends.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CharacterModelDataContract left, CharacterModelDataContract right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CharacterModelDataContract left, CharacterModelDataContract right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
