using Hook;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace NUMC.Script
{
    public class Macro
    {
        public Macro()
        {
        }

        public Macro(string code, bool ad)
        {
            Code = code;
            AD = ad;
        }

        public string Code { get; set; }
        public bool AD = true;
        private bool isRunning = false;

        public void Compiler(InputSimulator simulator)
        {
            string[] code = Code.Split('\n');

            if (isRunning && AD)
                return;

            isRunning = true;

            string line;
            List<Function> functions = GetFunctions(code);

            long length, i = 0;

            while (true)
            {
                if (i < 0 || i >= code.Length)
                    break;

                // 코드가 없으면
                if (string.IsNullOrWhiteSpace(code[i]))
                    continue;

                line = code[i].TrimStart().Split(new string[] { "//" }, StringSplitOptions.None)[0];

                // 자주 사용되는 변수
                length = line.Length;

                if (length > 1)
                {
                    string data = line.Substring(1);

                    //goto
                    if (line[0] == '>')
                    {
                        for (int fs = 0; fs < functions.Count; fs++)
                        {
                            if (functions[fs].name == data)
                            {
                                i = functions[fs].line;
                                continue;
                            }
                        }
                    }
                    // delay
                    else if (line[0] == '|')
                    {
                        if (int.TryParse(data, out int delay))
                        {
                            Task.Delay(delay).Wait();
                        }
                    }
                    // keyDown
                    else if (line[0] == '-')
                    {
                        if (int.TryParse(data, out int key))
                        {
                            simulator.Keyboard.KeyDown((Keys)key);
                        }
                    }
                    // keyUp
                    else if (line[0] == '+')
                    {
                        if (int.TryParse(data, out int key))
                        {
                            simulator.Keyboard.KeyUp((Keys)key);
                        }
                    }
                    // keyClick
                    else if (line[0] == '=')
                    {
                        if (int.TryParse(data, out int key))
                        {
                            KeyboardSimulation.MakeKeyEvent(key, KeyboardEventType.KEYCLICK);
                        }
                    }
                    // text
                    else if (line[0] == '#')
                    {
                        simulator.Keyboard.TextEntry(data);
                    }
                    // keyUp All
                    else if (line[0] == '^')
                    {
                        foreach (Keys item in Enum.GetValues(typeof(Keys)))
                        {
                            if (simulator.InputDeviceState.IsKeyDown(item))
                                simulator.Keyboard.KeyUp(item);
                        }
                    }
                    // exit
                    else if (line[0] == '!')
                    {
                        break;
                    }
                    else
                    {
                        List<_Macro.IMacroModule> modules = _Macro.Menu.GET_ALL_MACRO_MODULE();

                        for (int m = 0; m < modules.Count; m++)
                        {
                            if (modules[m].MODULE_NAME == line[0])
                            {
                                if (modules[m].GET_FULL_CODE)
                                    modules[m].RUN_CODE(data, ref code, ref i);
                                else
                                {
                                    string[] tmp = null;
                                    modules[m].RUN_CODE(data, ref tmp, ref i);
                                }
                            }
                        }
                    }
                }

                i++;
            }

            isRunning = false;
        }

        public class Function
        {
            public int line;
            public string name;
        }

        public static string CreateFunction(string Name)
        {
            return ":" + Name;
        }

        public static string CreateGotoFunction(string Name)
        {
            return ">" + Name;
        }

        public static string CreateDelay(int msc)
        {
            return "|" + msc.ToString();
        }

        public static string CreateKeyDown(Keys key)
        {
            return "-" + ((int)key).ToString();
        }

        public static string CreateKeyUp(Keys key)
        {
            return "+" + ((int)key).ToString();
        }

        public static string CreateKeyClick(Keys key)
        {
            return "=" + ((int)key).ToString();
        }

        public static string CreateTextEntry(string text)
        {
            return "#" + text;
        }

        public static string CreateKeyUpAll()
        {
            return "^";
        }

        public static string CreateExit()
        {
            return "!";
        }

        public static List<Function> GetFunctions(string[] code)
        {
            string line;
            List<Function> functions = new List<Function>();

            for (int i = 0; i < code.Length; i++)
            {
                // 코드가 없으면
                if (string.IsNullOrWhiteSpace(code[i]))
                    continue;

                line = code[i].TrimStart().Split(new string[] { "//" }, StringSplitOptions.None)[0].Replace("\\n", "\n");

                if (line.Length > 1 && line[0] == ':')
                {
                    if (line[0] == ':')
                    {
                        functions.Add(new Function() { line = i, name = line.Substring(1) });
                        continue;
                    }
                }
            }

            return functions;
        }

        public static int GetInt(string line)
        {
            if (line.Length > 1)
            {
                string data = line.Substring(1);
                if (int.TryParse(data, out int delay))
                {
                    return delay;
                }
            }

            return -1;
        }

        public static Keys GetKeys(string line)
        {
            if (line.Length > 1)
            {
                string data = line.Substring(1);
                if (int.TryParse(data, out int key))
                {
                    return (Keys)key;
                }
            }

            return Keys.None;
        }

        public static string GetString(string line)
        {
            if (line.Length > 1)
                return line.Substring(1);
            else
                return null;
        }
    }
}