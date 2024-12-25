using UnityEngine;

//模型类  管理数据及业务逻辑
public class TimerModel    //不继承MonoBehaviour,不受unity生命周期管理   new
{
    //当前的时间
    public float Time { get; set; }   //属性  数据

    //是否正在计时
    public bool IsTiming { get; set; }   //数据

    public TimerModel()
    {
        //初始化数据   
        Time = 0f;
        IsTiming = false;
    }
 
    //开始计时  业务逻辑
    public void StartTiming()   
    {
        IsTiming = true;
    }

    //暂停计时  业务逻辑
    public void PauseTiming()
    {
        IsTiming = false;
    }

    //重置计时  业务逻辑
    public void ResetTiming()
    {
        IsTiming = false;
        Time = 0f;
    }

    //更新时间  业务逻辑
    public void UpdateTime(float deltaTime)
    {
        Time += deltaTime;
    }
}