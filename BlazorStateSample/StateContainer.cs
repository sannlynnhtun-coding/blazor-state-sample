namespace BlazorStateSample;

public class StateContainer
{
    private int? counter;

    public int Counter
    {
        get => counter ?? 0;
        set
        {
            counter = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
