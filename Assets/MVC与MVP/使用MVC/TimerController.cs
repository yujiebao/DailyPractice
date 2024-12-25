using UnityEngine;

//控制器类，继承自MonoBehaviour，挂载在一个空的GameObject上
public class TimerController : MonoBehaviour
{
    //模型的引用
    private TimerModel model;
    //视图的引用
    private TimerView view;

    void Awake()
    {
        //获取模型和视图的引用
        model = new TimerModel();
        view = FindObjectOfType<TimerView>();
        //注册视图的事件
        view.startButton.onClick.AddListener(OnStartButtonClick);
        view.pauseButton.onClick.AddListener(OnPauseButtonClick);
        view.resetButton.onClick.AddListener(OnResetButtonClick);
    }
    
    void Start()
    {
        //更新视图的显示
        // view.UpdateView(model);
        view.UpdateView(model.Time, model.IsTiming);
    }
    
    void Update()
    {
        //如果模型正在计时，就更新模型的时间
        if (model.IsTiming)
        {
            model.UpdateTime(Time.deltaTime);
            view.UpdateView(model.Time, model.IsTiming);
        }
    }
    
    //处理开始按钮的点击事件
    private void OnStartButtonClick()
    {
        //修改模型的计时状态
        model.StartTiming();
        //更新视图的显示
        view.UpdateView(model.Time, model.IsTiming);

    }
    
    //处理暂停按钮的点击事件
    private void OnPauseButtonClick()
    {
        //修改模型的计时状态
        model.PauseTiming();
        //更新视图的显示
        //可在此处添加判断合法的逻辑
        view.UpdateView(model.Time, model.IsTiming);

    }
    
    //处理重置按钮的点击事件
    private void OnResetButtonClick()
    {
        //修改模型的计时状态和时间
        model.ResetTiming();
        //更新视图的显示
        view.UpdateView(model.Time, model.IsTiming);
    }
}