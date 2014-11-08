using UnityEngine;
using System.Collections;

public class DissolveTrigger : MonoBehaviour {

    public MoveToBoneManager m_mtbManager;

    void OnTriggerStay(Collider other)
    {
        if (other.name == "palm")
        {
            m_mtbManager.dissolve();
        }
    }
}
