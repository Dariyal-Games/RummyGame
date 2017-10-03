public delegate void InteractabilityChangedEventHandler(object sender, InteractabilityChangedEventArgs e);

public class InteractabilityChangedEventArgs : System.EventArgs
{
    public bool NewValue { get; private set; }

    public InteractabilityChangedEventArgs(bool newValue)
    {
        NewValue = newValue;
    }
}