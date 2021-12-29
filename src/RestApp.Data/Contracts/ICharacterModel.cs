using System.Collections.Generic;

namespace RestApp.Data.Contracts
{
    public interface ICharacterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// episodes
        /// </summary>
        List<string> Episodes { get; set; }

        /// <summary>
        /// Friends
        /// </summary>
        List<string> Friends { get; set; }
    }
}
