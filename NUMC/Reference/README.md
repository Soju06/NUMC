# References used

<img src="http://www.darkui.com/images/logo-888.png">

# DarkUI
Dark themed control and docking library for .NET WinForms.

### About DarkUI
DarkUI is an attempt to create a simple, extensible control library which emulates the look and feel of popular tabbed document interfaces such as Visual Studio, Photoshop, WebStorm, and XCode. Originally just a collection of bug fixes and enhancements built on top of WinForms, it has now evolved in to a fully working docking and control library.

Check out our [GitHub pages site](http://www.darkui.com).

### Attribution

Special thanks to the team over at [Ascension Game Dev](https://www.ascensiongamedev.com/) for expanding the library to include `DarkComboBox`, `DarkGroupBox`, and `DarkNumericUpDown`.

### How to use
The best way to learn how to use DarkUI is to check out the Example project included with the source code. It'll show you how to use the majority of the forms, controls, and docking components.

You can also read the [GitHub project wiki](https://github.com/RobinPerris/DarkUI/wiki). This contains all the information you need to get started as well as more detailed information and guides.

### Screenshots
Game map editor

![Game map editor](http://www.darkui.com/images/editor.png)

Lua script editor

![Lua script editor](http://www.darkui.com/images/lua.png)

Example docking application

![Example docking application](http://www.darkui.com/images/docking.png)

Controls preview

![Controls preview](http://www.darkui.com/images/controls.png)

[DarkUI](http://www.darkui.com/)
[Nuget](https://www.nuget.org/packages/DarkUI/2.0.2/ReportAbuse)
[Github](https://github.com/RobinPerris/DarkUI)
[License MIT](https://licenses.nuget.org/MIT)

# GlobalHook

Very simple mouse, keyboard global hooking library written in C#

## HowToUse

### Hooking

Add `KeyboardHook.HookStart()` or `MouseHook.HookStart()` at starts.
**All events must return boolean value**. If returned value is false, that event go out.

### Simulation

Just call method

## Examples

Locking left windows key

```csharp
KeyboardHook.KeyDown += (int vkCode) => (Keys)vkCode != Keys.LWin;
```

Watch all mouse down

```csharp
MouseHook.MouseDown += (MouseEventType type, int x, int y) => {
    Console.WriteLine($"{type} Down at: {x}, {y}");
    return true;
};
```

Press `Escape`

```csharp
KeyboardSimulation.MakeKeyEvent((int)Keys.Escape, KeyboardEventType.KEYCLICK);
```

Scroll mouse down

```csharp
MouseSimulation.MouseScroll(MouseScrollType.DOWN);
```

[Github](https://github.com/20chan/GlobalHook)

# Windows Input Simulator (C# SendInput Wrapper - Simulate Keyboard and Mouse)
============================================================================
The Windows Input Simulator provides a simple .NET (C#) interface to simulate Keyboard or Mouse input using the Win32 SendInput method. All of the Interop is done for you and there's a simple programming model for sending multiple keystrokes.

Windows Forms provides the SendKeys method which can simulate text entry, but not actual key strokes. Windows Input Simulator can be used in WPF, Windows Forms and Console Applications to synthesize or simulate any Keyboard input including Control, Alt, Shift, Tab, Enter, Space, Backspace, the Windows Key, Caps Lock, Num Lock, Scroll Lock, Volume Up/Down and Mute, Web, Mail, Search, Favorites, Function Keys, Back and Forward navigation keys, Programmable keys and any other key defined in the Virtual Key table. It provides a simple API to simulate text entry, key down, key up, key press and complex modified key strokes and chords.

NuGet
------
Install-Package InputSimulator

Examples
==========

Example: Single key press
-------------
```csharp
public void PressTheSpacebar()
{
  InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
}
```

Example: Key-down and Key-up
------------
```csharp
public void ShoutHello()
{
  // Simulate each key stroke
  InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
  InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H);
  InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E);
  InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
  InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
  InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O);
  InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_1);
  InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);

  // Alternatively you can simulate text entry to acheive the same end result
  InputSimulator.SimulateTextEntry("HELLO!");
}
```

Example: Modified keystrokes such as CTRL-C
--------------
```csharp
public void SimulateSomeModifiedKeystrokes()
{
  // CTRL-C (effectively a copy command in many situations)
  InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);

  // You can simulate chords with multiple modifiers
  // For example CTRL-K-C whic is simulated as
  // CTRL-down, K, C, CTRL-up
  InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, new [] {VirtualKeyCode.VK_K, VirtualKeyCode.VK_C});

  // You can simulate complex chords with multiple modifiers and key presses
  // For example CTRL-ALT-SHIFT-ESC-K which is simulated as
  // CTRL-down, ALT-down, SHIFT-down, press ESC, press K, SHIFT-up, ALT-up, CTRL-up
  InputSimulator.SimulateModifiedKeyStroke(
    new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.MENU, VirtualKeyCode.SHIFT },
    new[] { VirtualKeyCode.ESCAPE, VirtualKeyCode.VK_K });
}
```

Example: Simulate text entry
--------
```csharp
public void SayHello()
{
  InputSimulator.SimulateTextEntry("Say hello!");
}
```

Example: Determine the state of different types of keys
------------
```csharp
public void GetKeyStatus()
{
  // Determines if the shift key is currently down
  var isShiftKeyDown = InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT);

  // Determines if the caps lock key is currently in effect (toggled on)
  var isCapsLockOn = InputSimulator.IsTogglingKeyInEffect(VirtualKeyCode.CAPITAL);
}
```

History
============
It was originally written for use in the WpfKB (WPF Touch Screen Keyboard) project to simulate real keyboard entry to the active window. After looking for a comprehensive wrapper for the Win32 and User32 input simulation methods and coming up dry I decided to write and open-source this project. I hope it helps someone out there!

[Github](https://github.com/michaelnoonan/inputsimulator)
[Nuget](https://www.nuget.org/packages/InputSimulator/)
[License MIT](https://raw.githubusercontent.com/michaelnoonan/inputsimulator/master/LICENSE)