using TMPro;
using UnityEngine;
using UnityEngine.UI;

//视图接口，定义视图需要实现的方法   可以便捷的更换界面
public interface ITimerView
{
    //更新文本框的显示
    void UpdateDisplay(float time);

    //更新按钮的显示
    void UpdateButtons(bool isTiming);
}

//视图类，继承自MonoBehaviour，实现视图接口，挂载在计时器的UI元素上，例如Canvas或Panel
public class TimerViewMVP : MonoBehaviour, ITimerView
{
    //文本框
    private TMP_Text displayText;

    //开始按钮
    [HideInInspector] public Button startButton;

    //暂停按钮
    [HideInInspector] public Button pauseButton;

    //重置按钮
    [HideInInspector] public Button resetButton;

    //展示器的引用
    private TimerPresenter presenter;

    void Awake()
    {
        //获取UI元素的引用
        displayText = transform.Find("DisplayText").GetComponent<TMP_Text>();
        startButton = transform.Find("Buttons/StartButton").GetComponent<Button>();
        pauseButton = transform.Find("Buttons/PauseButton").GetComponent<Button>();
        resetButton = transform.Find("Buttons/ResetButton").GetComponent<Button>();
        //获取展示器的引用
        presenter = FindObjectOfType<TimerPresenter>();
        //注册UI元素的事件
        startButton.onClick.AddListener(OnStartButtonClick);
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        resetButton.onClick.AddListener(OnResetButtonClick);
    }

    void Start()
    {
        //更新视图的显示
        presenter.UpdateView();
    }

    //更新文本框的显示
    public void UpdateDisplay(float time)
    {
        displayText.text = FormatTime(time);
    }

    //更新按钮的显示
    public void UpdateButtons(bool isTiming)
    {
        startButton.interactable = !isTiming;
        pauseButton.interactable = isTiming;
        resetButton.interactable = isTiming;
    }

    //处理开始按钮的点击事件
    private void OnStartButtonClick()
    {
        //通知展示器开始计时
        presenter.StartTiming();
    }

    //处理暂停按钮的点击事件
    private void OnPauseButtonClick()
    {
        //通知展示器暂停计时
        presenter.PauseTiming();
    }

    //处理重置按钮的点击事件
    private void OnResetButtonClick()
    {
        //通知展示器重置计时
        presenter.ResetTiming();
    }

    //格式化时间为分:秒.毫秒的形式
    private string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        int milliseconds = (int)(time * 1000) % 1000;
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}