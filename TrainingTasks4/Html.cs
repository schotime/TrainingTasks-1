using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks4
{
    public class Html
    {
        private string _tagName;
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();
        private List<string> _classes = new List<string>(); 

        public Html(string tagName)
        {
            this._tagName = tagName;
        }

        public static Html Tag(string tagName)
        {
            var html = new Html(tagName);
            return html;
        }

        public Html Attr(string key, string value)
        {
            _attributes.Add(key, value);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("<" + _tagName);

            if (_attributes.Count > 0)
            {
                foreach (var attribute in _attributes)
                {
                    sb.Append(" ");
                    sb.Append(attribute.Key + "=\"" + attribute.Value + "\"");
                }
            }

            if (_classes.Count > 0)
            {
                sb.Append(" class=\"" + string.Join(" ", _classes.ToArray()) + "\"");
            }
            
            sb.Append(">");
            sb.Append("</" + _tagName + ">");

            return sb.ToString();
        }

        public Html AddClass(string className)
        {
            _classes.Add(className);
            return this;
        }

        public Html Modify(Action<Html> func)
        {
            func(this);
            return this;
        }

        public static implicit operator string(Html html)
        {
            return html.ToString();
        }
    }
}
