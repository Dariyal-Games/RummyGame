using UnityEngine;
using UnityEngine.EventSystems;

public class CardModel : MonoBehaviour, IPointerClickHandler, ISelectable
{
    public int cardIndex;
    public Sprite[] cardFaces;
    public Sprite cardBack;

    private SpriteRenderer spRenderer;
    private bool isSelected;

    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            if (isSelected != value)
            {
                isSelected = value;

                if (isSelected)
                {
                    if (Selected != null) Selected(this, new SelectedEventArgs(gameObject));
                }
                else
                {
                    if (Deselected != null) Deselected(this, new DeselectedEventArgs(gameObject));
                }
            }
        }
    }

    public event SelectedEventHandler Selected;
    public event DeselectedEventHandler Deselected;

    public void OnPointerClick(PointerEventData eventData)
    {
        IsSelected = !IsSelected;
    }

    public void ToggleFace(bool showFace)
    {
        if (showFace)
        {
            spRenderer.sprite = cardFaces[cardIndex];
        }
        else
        {
            spRenderer.sprite = cardBack;
        }
    }

    private void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
    }


}
