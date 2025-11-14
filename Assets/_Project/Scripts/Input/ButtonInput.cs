using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public WordInputManager manager;

    public void Letter(string l)
    {
        Debug.Log("Lettera cliccata: " + l);
        manager.PressLetter(l);
    }

    public void Delete()
    {
        Debug.Log("DELETE premuto");
        manager.PressDelete();
    }

    public void Enter()
    {
        Debug.Log("ENTER premuto");
        manager.PressEnter();
    }
}
