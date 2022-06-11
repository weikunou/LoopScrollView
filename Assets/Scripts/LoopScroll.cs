using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopScroll : MonoBehaviour
{
    /// <summary>
    /// 数据项
    /// </summary>
    public Transform item;

    /// <summary>
    /// 滚动视图
    /// </summary>
    ScrollRect scrollRect;

    /// <summary>
    /// 视图内容
    /// </summary>
    Transform content;

    /// <summary>
    /// 预制体列表
    /// </summary>
    /// <typeparam name="Transform">预制体的坐标信息</typeparam>
    /// <returns></returns>
    List<Transform> itemList = new List<Transform>();

    void Start()
    {
        // 获取组件
        scrollRect = GetComponent<ScrollRect>();
        content = scrollRect.transform.Find("Viewport/Content");

        // 构造数据
        List<string> data = new List<string>();
        for(int i = 0; i < 100; i++)
        {
            data.Add("这是一条消息 " + i);
        }

        // 刷新视图
        Refresh(data);
    }

    /// <summary>
    /// 刷新视图
    /// </summary>
    public void Refresh(List<string> data)
    {
        for(int i = 0; i < data.Count; i++)
        {
            AddItem(data[i]);
        }

        Debug.Log("item count " + itemList.Count);
    }

    /// <summary>
    /// 添加单条内容
    /// </summary>
    public void AddItem(string message)
    {
        GameObject obj = Instantiate(item.gameObject, content.transform);
        obj.SetActive(true);
        obj.GetComponent<Item>().UpdateSelf(message);
        itemList.Add(obj.transform);
    }
}
