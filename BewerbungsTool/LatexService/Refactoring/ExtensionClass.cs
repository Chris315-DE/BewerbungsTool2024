using System.Text;

namespace BewerbungsTool.LatexService
{
    public static class ExtensionClass
    {
        public static event Action<StringBuilder> HasValueChanged;

        public static StringBuilder AppendLineOnValueChanged(this StringBuilder builder, string value)
        {
            builder.AppendLine(value);
            StringBuilder debugger = new StringBuilder();
            debugger.AppendLine(value);
            HasValueChanged?.Invoke(debugger);
            return builder;
        }

        public static StringBuilder AppendOnValueChanged(this StringBuilder builder, string value)
        {

            builder.Append(value);
            StringBuilder debugger = new StringBuilder();
            debugger.Append(value);
            HasValueChanged?.Invoke(debugger);
            return builder;

        }


    }

}



