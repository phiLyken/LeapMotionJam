using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public TriggerBase _trigger;
    private Material m_matButton;

    void OnCollisionEnter(Collision _collision)
    {
        push();
        _trigger.trigger();
    }

    void push()
    {
        m_matButton.SetColor(0, Color.red);
        transform.localPosition = new Vector3(0, -0.4f, 0);
    }


}
