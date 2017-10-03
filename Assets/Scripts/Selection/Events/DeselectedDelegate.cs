using System;
using UnityEngine;

public delegate void DeselectedEventHandler(object sender, DeselectedEventArgs e);

public class DeselectedEventArgs : EventArgs
{
    public GameObject SelectedObject { get; private set; }

    public DeselectedEventArgs(GameObject go)
    {
        SelectedObject = go;
    }
}