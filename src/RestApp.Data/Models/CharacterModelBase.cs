using System;
using System.Collections.Generic;
using System.Text;
using RestApp.Data.Contracts;

namespace RestApp.Data.Models
{
    public class CharacterModelBase: ICharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Episodes { get; set; }
        public List<string> Friends { get; set; }
    }
}
