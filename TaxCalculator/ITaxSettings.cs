using System.Collections.Generic;

namespace TaxCalculator
{
    public interface ITaxSettings
    {
        void Load(string json);
        T GetValue<T>(string name);
        void SetValue<T>(string name, T value);
        IEnumerable<(string name, string value)> GetList();
        int GetCount();
    }
}