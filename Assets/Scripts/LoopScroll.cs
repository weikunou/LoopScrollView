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

        CountItemPos();
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

    /// <summary>
    /// 计算每条内容的位置和content的总高度
    /// </summary>
    public void CountItemPos()
    {
        // 计算 item 位置
        float pos = 0;
        float space = 20; // 间隔
        foreach(Transform item in itemList)
        {
            RectTransform item_rect = item.GetComponent<RectTransform>();
            item_rect.anchoredPosition = new Vector2(0, pos);
            pos = pos - item_rect.rect.height - space;
        }
        // 计算 content 高度
        float full_heihgt = (item.GetComponent<RectTransform>().rect.height + space) * itemList.Count;
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, full_heihgt);
    }
}
