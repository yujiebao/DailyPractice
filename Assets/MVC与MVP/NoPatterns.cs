using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoPatterns : MonoBehaviour
{
    //文本框
    private TMP_Text displayText;

    //开始按钮
    private Button startButton;

    //暂停按钮
    private Button pauseButton;

    //重置按钮
    private Button resetButton;

    //当前的时间
    private float time;

    //是否正在计时
    private bool isTiming;

    void Awake()
    {
        //获取UI元素的引用
        displayText = transform.Find("DisplayText").GetComponent<TMP_Text>();
        startButton = transform.Find("Buttons/StartButton").GetComponent<Button>();  //Buttons下的StartButton按钮
        pauseButton = transform.Find("Buttons/PauseButton").GetComponent<Button>();
        resetButton = transform.Find("Buttons/ResetButton").GetComponent<Button>();
        //注册按钮的点击事件
        startButton.onClick.AddListener(OnStartButtonClick);
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        resetButton.onClick.AddListener(OnResetButtonClick);
    }

    void Start()
    {
        //初始化数据
        time = 0f;
        isTiming = false;
        //更新UI元素的显示
        displayText.text = FormatTime(time);
        startButton.interactable = true;
        pauseButton.interactable = false;
        resetButton.interactable = false;
    }

    void Update()
    {
        //如果正在计时，就更新时间
        if (isTiming)
        {
            time += Time.deltaTime;
            displayText.text = FormatTime(time);
        }
    }

    //处理开始按钮的点击事件
    private void OnStartButtonClick()
    {
        //设置计时状态为真
        isTiming = true;
        //更新UI元素的显示
        startButton.interactable = false;
        pauseButton.interactable = true;
        resetButton.interactable = true;
    }

    //处理暂停按钮的点击事件
    private void OnPauseButtonClick()
    {
        //设置计时状态为假
        isTiming = false;
        //更新UI元素的显示
        startButton.interactable = true;
        pauseButton.interactable = false;
        resetButton.interactable = true;
    }

    //处理重置按钮的点击事件
    private void OnResetButtonClick()
    {
        //设置计时状态为假
        isTiming = false;
        //重置时间为零
        time = 0f;
        //更新UI元素的显示
        displayText.text = FormatTime(time);
        startButton.interactable = true;
        pauseButton.interactable = false;
        resetButton.interactable = false;
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