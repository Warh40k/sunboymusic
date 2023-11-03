using System.Collections.Generic;

namespace SunBoyMusicStore.Models.Base;

public abstract class Attribute
{
    public string Name { get; set; }
    public Attribute? Search(string field, string value)
    {
        if (string.IsNullOrEmpty(value) || GetData()[field].Contains(value))
        {
            return this;
        }

        return null;
    }

    public Dictionary<string, string> GetData()
    {
        var dict = new Dictionary<string, string>();
        dict["Name"] = Name;
        
        return dict;
    }
    
    
}