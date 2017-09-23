using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils.UI;

[RequireComponent(typeof(Scrollbar))]
public class UITimeLine : UIPanel
{
    public UnityEvent OnTimeLineStart = new UnityEvent();
    public UnityEvent OnTimeLineEnd = new UnityEvent();

    public TimeData timeBegin = new TimeData();
    public TimeData timeEnd = new TimeData();
    public TimeData currentTime = new TimeData();
    public int CompleteTime;

    public bool started = false; 

    private Scrollbar currentScroll;

    protected override void Start()
    {
        base.Start();
        currentScroll = GetComponent<Scrollbar>();
}

    public TimeData CurrentTime()
    {
        return currentTime;
    }

    public void Init(TimeData begin, TimeData end)
    {
        this.timeBegin = begin;
        CompleteTime = (end - begin).ToMinutes();
        started = false;
        
    } 

    public float CalculValue()
    {
        return (float)(CurrentTime() - timeBegin).ToMinutes() / CompleteTime;
    }

    public void UpdateTimeLine()
    {
        float size = CalculValue();
        currentScroll.size = size;

        if (!started && size > 0)
        {
            started = true;
            OnTimeLineStart.Invoke();
        }
        else if(size >= 1)
        {
            OnTimeLineEnd.Invoke();
        }

    }

    private void Update()
    {
        UpdateTimeLine();  
    }

    private void OnValidate()
    {
        currentScroll = GetComponent<Scrollbar>();
        Init(timeBegin, timeEnd);
        UpdateTimeLine();
    }
}
