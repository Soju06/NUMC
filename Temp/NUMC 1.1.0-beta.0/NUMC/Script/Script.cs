using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace NUMC.Script
{
    public class Script
    {
        public Script()
        {
            Simulator = new InputSimulator();
        }

        public void StopInput() // 모든 키 떼기
        {
            foreach (Keys item in Enum.GetValues(typeof(Keys)))
            {
                if (Simulator.InputDeviceState.IsKeyDown(item))
                    Simulator.Keyboard.KeyUp(item);
            }
        }

        private readonly InputSimulator Simulator;
        public ScriptObject Object = new ScriptObject();

        public void SetScriptObject(ScriptObject script)
        {
            Object = script;
        }

        public void KeyDown(int vkCode)
        {
            if (IsAccessible) // 개체가 접근 가능한지
            {
                KeyObject key = Object.GetKeyObject((Keys)vkCode, true); // 작동할 키 개체

                // 지정되지 않은 키 또는 설정
                if (key == null || key.KeyScript == null)
                    return;

                for (int i = 0; i < key.KeyScript.Length; i++) // 스트립트 실행
                {
                    if (key.KeyScript[i] != null)
                        RunKeyScript(key.KeyScript[i], true);
                }
            }
        }

        public void KeyUp(int vkCode)
        {
            if (IsAccessible) // 개체가 접근 가능한지
            {
                KeyObject key = Object.GetKeyObject((Keys)vkCode, true); // 작동할 키 개체

                // 지정되지 않은 키 또는 설정
                if (key == null || key.KeyScript == null)
                    return;

                for (int i = 0; i < key.KeyScript.Length; i++) // 스트립트 실행
                {
                    if (key.KeyScript[i] != null)
                        RunKeyScript(key.KeyScript[i], false);
                }
            }
        }

        private void RunKeyScript(KeyScript script, bool IsDown)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(script.Type) && script.Macro == null) //타입이 없고 매크로도 없으면
                    return;

                if (IsDown) // 키를 눌렀을때
                {
                    if (script.SendKeys != null && script.SendKeys.Text.Length >= 1) // WinForm SendKeys
                    {
                        if (script.Type == "SendKeys")
                            for (int i = 0; i < script.SendKeys.Text.Length; i++)
                                System.Windows.Forms.SendKeys.SendWait(script.SendKeys.Text[i]);
                        else if (script.Type == "TextEntry")
                            for (int i = 0; i < script.SendKeys.Text.Length; i++)
                                Simulator.Keyboard.TextEntry(script.SendKeys.Text[i]);
                    }
                    else if (script.VirtualKey != null && script.VirtualKey.Keys.Length >= 1) // Virtual Keyboard
                    {
                        if (script.Type == "VirtualKey")
                            for (int i = 0; i < script.VirtualKey.Keys.Length; i++)
                            {
                                Console.WriteLine("KeyDown; {0}", script.VirtualKey.Keys[i]);
                                Simulator.Keyboard.KeyDown(script.VirtualKey.Keys[i]);
                            }
                        if (script.Type == "VirtualSendKeys")
                        {
                            // 키 누름
                            for (int i = 0; i < script.VirtualKey.Keys.Length; i++)
                            {
                                Simulator.Keyboard.KeyDown(script.VirtualKey.Keys[i]);
                            }

                            // 키 뗌
                            for (int i = 0; i < script.VirtualKey.Keys.Length; i++)
                            {
                                Simulator.Keyboard.KeyUp(script.VirtualKey.Keys[i]);
                            }
                        }
                    }

                    // 독립 코드 실행

                    if (script.Macro != null && script.Macro.Code.Length >= 1)
                    {
                        Task task = new Task(delegate ()
                        {
                            script.Macro.Compiler(Simulator);
                        });

                        task.Start();
                    }
                }
                else // 키를 때었을때
                {
                    if (script.VirtualKey != null) // Virtual Keyboard KeyUp
                    {
                        if (script.Type == "VirtualKey")
                            for (int i = 0; i < script.VirtualKey.Keys.Length; i++)
                            {
                                Console.WriteLine("KeyUp; {0}", script.VirtualKey.Keys[i]);
                                Simulator.Keyboard.KeyUp(script.VirtualKey.Keys[i]);
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Setting.Setting.GetTitleName("RunScript"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool GetIgnoreStatus(Keys key)
        {
            if (IsAccessible)
            {
                for (int i = 0; i < Object.KeyObject.Length; i++)
                {
                    if (Object.KeyObject[i].Key == key)
                        return Object.KeyObject[i].Ignore;
                }
            }

            return true;
        }

        private bool IsAccessible
        {
            get
            {
                if (Object != null && Object.KeyObject != null)
                    return true;
                return false;
            }
        }
    }
}