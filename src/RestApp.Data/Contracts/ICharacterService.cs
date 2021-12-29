using System.Collections.Generic;
using RestApp.Data.Models;

namespace RestApp.Data.Contracts
{
    public interface ICharacterService
    {
        CharacterServiceResult Create(ICharacterModel item);
        IEnumerable<ICharacterModel> Read(string searchString = null, int? skip = null, int? limit = null);
        CharacterServiceResult Update(ICharacterModel item);
        CharacterServiceResult Delete(int id);
    }
}
