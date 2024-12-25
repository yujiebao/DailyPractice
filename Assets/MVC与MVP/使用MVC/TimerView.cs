using TMPro;
using UnityEngine;
using UnityEngine.UI;

//视图类，继承自MonoBehaviour，挂载在计时器的UI元素上，例如Canvas或Panel
public class TimerView : MonoBehaviour
{
    //文本框
    private TMP_Text displayText;

    //开始按钮
    [HideInInspector] public Button startButton;

    //暂停按钮
    [HideInInspector] public Button pauseButton;

    //重置按钮
    [HideInInspector] public Button resetButton;

    void Awake()
    {
        //获取UI元素的引用
        displayText = transform.Find("DisplayText").GetComponent<TMP_Text>();
        startButton = transform.Find("Buttons/StartButton").GetComponent<Button>();
        pauseButton = transform.Find("Buttons/PauseButton").GetComponent<Button>();
        resetButton = transform.Find("Buttons/ResetButton").GetComponent<Button>();
    }

    //更新视图----传参为model
    // public void UpdateView(TimerModel model)
    // {
    //     displayText.text = FormatTime(model.Time);
    //     startButton.interactable = !model.IsTiming;
    //     pauseButton.interactable = model.IsTiming;
    //     resetButton.interactable = model.IsTiming;
    // }
    
    public void UpdateView(float Time, bool IsTiming)   //改为model中的属性，低耦合
    {
        displayText.text = FormatTime(Time);
        startButton.interactable = !IsTiming;
        pauseButton.interactable = IsTiming;
        resetButton.interactable = IsTiming;
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