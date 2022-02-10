using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    private List<Resource> _resources = new List<Resource>();

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Instance of ResourceManager already exist");
            return;
        }

        Instance = this;
    }
}
