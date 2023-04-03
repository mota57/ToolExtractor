using System.Collections.Generic;
using System.Linq;

namespace ToolExtractor.Lib.Utils
{

    public class SheetObjectMeta
    {
        public SheetObjectMeta(string name, List<Dictionary<string, string>> rows, string keys = null)
        {
            Name = name;
            _keys = keys != null ? keys.Split(',').ToList() : new List<string>();
            Rows = rows;
        }

        public string Name { get; }
        private List<string> _keys;
        public List<string> Keys
        {

            get
            {
                if (_keys == null || _keys.Count == 0)
                {
                    _keys = Rows.First().Keys.ToList();
                }
                return _keys;
            }
            set
            {
                _keys = value;
            }
        }
        public List<Dictionary<string, string>> Rows { get; }
    }
}