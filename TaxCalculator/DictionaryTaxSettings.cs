using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace TaxCalculator
{
    public class DictionaryTaxSettings : ITaxSettings
    {
        public DictionaryTaxSettings(string json)
        {
            Load(json);
        }

        private Dictionary<string, object> _settings = new Dictionary<string, object>();

        public void Load(string json)
        {
            _settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }
        public T GetValue<T>(string name)
        {
            if (!_settings.ContainsKey(name))
                throw new CalculationException("Key not found in settings");
            object value = _settings[name];
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public void SetValue<T>(string name, T value)
        {
            _settings[name] = value;
        }

        public string this[string name]
        {
            get => GetValue<string>(name);
            set => SetValue(name, value);
        }

        private int Compare(string key1, string key2)
        {
            try
            {
                return Convert.ToDouble(key1).CompareTo(Convert.ToDouble(key2));
            }
            catch (Exception)
            {
                return String.Compare(key1, key2, StringComparison.Ordinal);
            }
        }

        public IEnumerable<(string name, string value)> GetList()
        {
            var keys = _settings.Keys.ToList();
            keys.Sort(Compare);
            foreach (var key in keys)
                yield return (name: key, value: GetValue<string>(key));
        }

        public int GetCount()
        {
            return _settings.Count;
        }
    }
}