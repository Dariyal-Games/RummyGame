using System;
using UnityEngine;

public delegate void SelectedEventHandler(object sender, SelectedEventArgs e);

public class SelectedEventArgs : EventArgs
{
    public GameObject SelectedObject { get; private set; }

    public SelectedEventArgs(GameObject go)
    {
        SelectedObject = go;
    }
}