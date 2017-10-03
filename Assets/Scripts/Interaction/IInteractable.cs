public interface IInteractable
{
    bool IsInteractable { get; set; }
    event InteractabilityChangedEventHandler InteractabilityChanged;
}

