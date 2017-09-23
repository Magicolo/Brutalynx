using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class UITimeLine : MonoBehaviour
{
    public TimeData timeBegin;
    public int CompleteTime;

    private Scrollbar currentScroll;

    private void Start()
    {
        currentScroll = GetComponent<Scrollbar>();
    }

    public TimeData CurrentTime()
    {
        return null;
    }

    public float CalculValue()
    {
        return (CurrentTime() - timeBegin).ToMinutes() / CompleteTime;
    }

    private void Update()
    {
        currentScroll.size = CalculValue();
    }
}
