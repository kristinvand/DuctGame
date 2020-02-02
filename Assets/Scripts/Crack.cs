using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    public bool covered = false;
    
    private void OnDestroy()
    {
        if (!covered)
            DuctManController.instance.stats.cracksMissed++;
    }
}