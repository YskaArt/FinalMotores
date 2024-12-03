using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Animator Anim;
    public List<GameObject> diana;
    public int DianasTotales;
    void Start()
    {
        DianasTotales = diana.Count;
        Anim = GetComponent<Animator>();

    }

    
    public void DianaDestroy()
    {
        DianasTotales--;
        if (DianasTotales <= 0)
        {
            Anim.SetBool("TutorialComplete", true);
        }
    }
}
