using UnityEngine;

//展示器类，继承自MonoBehavio
//ur，挂载在一个空的GameObject上
public class TimerPresenter : MonoBehaviour
{
    //模型的引用
    private TimerModel model;

    //视图的引用
    private ITimerView view;

    void Awake()
    {
        //获取模型和视图的引用
        model = new TimerModel();
        view = FindObjectOfType<TimerViewMVP>();
    }

    void Update()
    {
        //如果模型正在计时，就更新模型的时间
        if (model.IsTiming)
        {
            model.UpdateTime(Time.deltaTime);
            view.UpdateDisplay(model.Time);
        }
    }

    //开始计时
    public void StartTiming()
    {
        //修改模型的计时状态
        model.StartTiming();
        //更新视图的显示
        view.UpdateButtons(model.IsTiming);
    }

    //暂停计时
    public void PauseTiming()
    {
        //修改模型的计时状态
        model.PauseTiming();
        //更新视图的显示
        view.UpdateButtons(model.IsTiming);
    }

    //重置计时
    public void ResetTiming()
    {
        //修改模型的计时状态和时间
        model.ResetTiming();
        //更新视图的显示
        view.UpdateDisplay(model.Time);
        view.UpdateButtons(model.IsTiming);
    }

    //更新视图的显示
    public void UpdateView()
    {
        view.UpdateDisplay(model.Time);
        view.UpdateButtons(model.IsTiming);
    }
}