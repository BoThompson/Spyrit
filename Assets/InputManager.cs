using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputTypes { axis, button, key };

public struct Control
{
    public InputTypes type;
    public int impulse;
    public int playerNum;
    public string name;
    public KeyCode keyCode;

    public Control(InputTypes t, int i, int p, string s, KeyCode k)
    {
        type = t;
        impulse = i;
        playerNum = p;
        name = s;
        keyCode = k;
    }   
}

public class InputManager : MonoBehaviour
{
    public Paddle p1;
    public Paddle p2;
    public Paddle p3;
    public Paddle p4;

    List<Paddle> players = new List<Paddle>();
    List<Control> controls = new List<Control>();

    void Awake()
    {
        //Players
        players.Add(p1);

        for (int j = 0; j < players.Count; j++)
        {
            controls.Add(new Control(InputTypes.axis, 0, j, "Horizontal_", KeyCode.Backspace)); // 0
            controls.Add(new Control(InputTypes.axis, 1, j, "Vertical_", KeyCode.Backspace)); // 1
            controls.Add(new Control(InputTypes.button, 2, j, "Switch_Blue_", KeyCode.Backspace)); // 2
            controls.Add(new Control(InputTypes.button, 3, j, "Switch_Yellow_", KeyCode.Backspace)); // 3
            controls.Add(new Control(InputTypes.button, 4, j, "Switch_Red_", KeyCode.Backspace)); // 4
        }

    }

    void Update()
    {
        int numControls = controls.Count;
        for(int x = 0; x < numControls; x++)
        {
            if(controls[x].type == InputTypes.axis)
            {
                float value = Input.GetAxis(controls[x].name + (controls[x].playerNum + 1).ToString());
                players[controls[x].playerNum].ActivateImpulse(controls[x].impulse, value);
            }
            if (controls[x].type == InputTypes.button)
            {
                float value = Input.GetButton(controls[x].name + (controls[x].playerNum + 1).ToString()) ? 1 : -999;
                players[controls[x].playerNum].ActivateImpulse(controls[x].impulse, value);
            }
        }
    }

    /*
    MANAGER CONTROL ARRAY STRUCTURE
    control[
            [type, impulse, playernum, name, keycode]
            [axis, move, 1, "joystick 1 vertical", null]        
            
            ]

MANAGER UPDATE LOGIC PER CONTROL
        if(control[x].type == type_axis)
        {
            float value = Input.GetAxis(control[x].name);
    player[control[x].playernum].ActivateImpulse(control[x].impulse, value);
}else if (control[x].type == type_button)
        {
            int value = Input.GetButtonDown(control[x].name) ? 1 : 0;
player[control[x].playernum].ActivateImpulse(control[x].impulse, value);
        }
        else if (control[x].type == type_key)
        {
            float value = Input.GetKeyDown(control[x].keycode) ? 1 : 0;
player[control[x].playernum].ActivateImpulse(control[x].impulse, value);
        }
        */

}
