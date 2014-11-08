using UnityEngine;
using System.Collections;

public class MoveToBoneManager : MonoBehaviour {

    public MoveToBone[] m_mtbScripts;

    public void dissolve()
    {
        foreach (MoveToBone mtb in m_mtbScripts)
        {
            mtb.dissolve();
        }
    }
}
