using System.Collections.Generic;

public interface IGenericCharacterModelRepository<CharacterModelDatabase,ModelDatabase> {
    void Create(int id, List<ModelDatabase> items);
    void Create(List<CharacterModelDatabase> items);
    void Update(List<CharacterModelDatabase> items);
    void Delete(List<CharacterModelDatabase> items);
    void Delete(int characterId);
}