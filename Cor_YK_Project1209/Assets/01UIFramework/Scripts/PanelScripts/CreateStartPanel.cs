using UnityEngine;
/// <summary>
/// 创建开始界面 在StartScene中 已禁用
/// 作为最开始的UIFramework测试脚本
/// </summary>
public class CreateStartPanel : MonoBehaviour
{
    void Start()
    {
        PanelStack.Instance.Push(new StartPanel());
    }
}