using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected Menu menu;
    public abstract void OnEnter();
    public abstract void OnExit();
}
