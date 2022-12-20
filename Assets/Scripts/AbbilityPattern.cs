using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbilityPattern : MonoBehaviour
{
    [SerializeField]private  List<orbScript> _orbScripts;
    private Ability _ability;

    private void Start()
    {
        _ability = GameObject.FindObjectOfType<Ability>();
    }

    private void Update()
    {
        for(int i = 0; i < _orbScripts.Count; i++)
        {
            if(!_orbScripts[i].istouched)return;
        }

        _ability.is_activated = 2;
        for(int i = 0; i < _orbScripts.Count; i++)
        {
            _orbScripts[i].istouched = false;
        }
    }
}
