using UnityEngine;
using System.Collections;

public interface ISelectable
{
    bool IsSelected { get; set; }

    event SelectedEventHandler Selected;
    event DeselectedEventHandler Deselected;
}
