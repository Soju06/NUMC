using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Macro
{
    public class MacroBuilder : IDisposable
    {
        public MacroDataContainer Container { get; private set; }

        public MacroBuilder(MacroDataContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            Container = container;
        }

        /// <summary>
        /// 컨테이너 컴파일
        /// </summary>
        public void Compile()
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

        }

        /// <summary>
        /// 빌드 레벨에 따라 자동 코드 생성
        /// </summary>
        public string GetFullCode()
        {
            StringBuilder codeBuilder = new StringBuilder();
            int buildLevel = 0;

            int.TryParse(Container.BuilderOptions.GetOptionDataByName("BuildLevel"), out buildLevel);

            var a = Container.BuilderOptions.GetOptionDatasByName("Import");

            for (int i = 0; i < a.Length; i++)
                if(!string.IsNullOrWhiteSpace(a[i]))
                    codeBuilder.AppendLine($"using {a[i]};");

            if()
        }

        public void Dispose()
        {

        }
    }

    public class MacroDataContainer : IDisposable
    {
        public const string DeclareBuilderOption = "/* NUMC Code Builder Options /*";
        public const string BuilderOptionLine = "//";

        public static MacroDataContainer SplitBuilderOptions(string data)
        {
            int splIdx, splEndIdx;

            if ((splIdx = data.IndexOf(DeclareBuilderOption)) != -1 && (splEndIdx = data.LastIndexOf(DeclareBuilderOption)) != -1 && splIdx != splEndIdx)
            {
                var builderOptions = new MacroBuilderOptions();
                var d = splIdx + splEndIdx + DeclareBuilderOption.Length;
                var options = data.Substring(splIdx, splEndIdx).Split('\n');
                var code = data.Remove(splIdx, splEndIdx + DeclareBuilderOption.Length + ((data.Length > d && data[d] == '\n') ? 1 : 0));

                for (int i = 0; i < options.Length; i++)
                {
                    var f = options[i].IndexOf(BuilderOptionLine);

                    if (f != -1)
                        builderOptions.GetOptionList().Add(MacroBuilderOption.Create(options[i].Remove(0, f + BuilderOptionLine.Length)));
                }

                return Create(code, builderOptions);
            }

            return Create(data);
        }

        public static MacroDataContainer Create(string code) =>
            new MacroDataContainer(code, null);

        public static MacroDataContainer Create(string code, MacroBuilderOptions builderOptions) =>
            new MacroDataContainer(code, builderOptions);

        public MacroDataContainer(string code, MacroBuilderOptions builderOptions)
        {
            Code = code;
            BuilderOptions = builderOptions;
        }

        public MacroBuilderOptions BuilderOptions { get; private set; }
        public string Code { get; private set; }

        new public string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(DeclareBuilderOption);
            stringBuilder.AppendLine(BuilderOptions.ToString(BuilderOptionLine + " {0}={1}"));
            stringBuilder.AppendLine(DeclareBuilderOption);
            stringBuilder.AppendLine(Code);
            return stringBuilder.ToString();
        }

        public void Dispose()
        {
            if (BuilderOptions != null)
                BuilderOptions.Dispose();
        }
    }

    public class MacroBuilderOptions : IDisposable
    {
        private readonly List<MacroBuilderOption> Options = new List<MacroBuilderOption>();

        public string GetOptionDataByName(string name) =>
            GetOptionByName(name)?.OptionData;

        public string[] GetOptionDatasByName(string name)
        {
            var f = new List<string>();
            var d = GetOptionsByName(name);

            for (int i = 0; i < d.Length; i++)
                f.Add(d[i].OptionData);

            return f.ToArray();
        }

        public MacroBuilderOption[] GetOptionsByName(string name)
        {
            var options = new List<MacroBuilderOption>();

            for (int i = 0; i < Options.Count; i++)
                if (Options[i].OptionName == name)
                    options.Add(Options[i]);

            return options.ToArray();
        }

        public MacroBuilderOption GetOptionByName(string name)
        {
            for (int i = 0; i < Options.Count; i++)
                if (Options[i].OptionName == name)
                    return Options[i];

            return null;
        }

        public List<MacroBuilderOption> GetOptionList() => Options;

        public string ToString(string format = "{0}={1}")
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Options.Count; i++)
                stringBuilder.AppendLine(Options[i].ToString(format));

            return stringBuilder.ToString();
        }

        public void Dispose()
        {
            if (Options != null)
                Options.Clear();
        }
    }

    public class MacroBuilderOption
    {
        public MacroBuilderOption(string optionName, string optionData)
        {
            OptionName = optionName;
            OptionData = optionData;
        }

        public string OptionName { get; set; }
        public string OptionData { get; set; }

        public static MacroBuilderOption Create(string option)
        {
            int splIdx;

            if((splIdx = option.IndexOf('=')) != -1)
                return new MacroBuilderOption(option.Substring(0, splIdx).Trim(), option.Substring(splIdx + 1));

            return null;
        }

        public string ToString(string format = "{0}={1}") =>
            string.Format(format, OptionName, OptionData);
    }
}
