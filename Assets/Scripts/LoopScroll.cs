using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopScroll : MonoBehaviour
{
    /// <summary>
    /// 数据项
    /// </summary>
    public RectTransform item;

    /// <summary>
    /// 滚动视图
    /// </summary>
    ScrollRect scrollRect;

    /// <summary>
    /// 预制体列表
    /// </summary>
    /// <typeparam name="RectTransform">预制体的坐标信息</typeparam>
    /// <returns></returns>
    List<RectTransform> itemList = new List<RectTransform>();

    /// <summary>
    /// 数据列表
    /// </summary>
    /// <typeparam name="string">数据类型</typeparam>
    /// <returns></returns>
    List<string> dataList = new List<string>();

    void Start()
    {
        // 获取组件
        scrollRect = GetComponent<ScrollRect>();

        // 构造数据
        List<string> data = new List<string>();
        for(int i = 0; i < 100; i++)
        {
            data.Add("这是一条消息 " + i);
        }

        Init();
        // 刷新视图
        Refresh(data);
    }

    /// <summary>
    /// 额外的item数量
    /// </summary>
    public int extra;

    public void Init()
    {
        float viewport_height = scrollRect.viewport.rect.height;
        int num = Mathf.CeilToInt(viewport_height / item.rect.height);
        int sum = num + extra;
        tailItem = sum - 1;
        tailData = sum - 1;
        for(int  i = 0; i < sum; i++)
        {
            AddItem();
        }
    }

    /// <summary>
    /// 头节点索引
    /// </summary>
    public int headItem;
    
    /// <summary>
    /// 尾节点索引
    /// </summary>
    public int tailItem;

    /// <summary>
    /// 头数据索引
    /// </summary>
    public int headData;

    /// <summary>
    /// 尾数据索引
    /// </summary>
    public int tailData;

    /// <summary>
    /// 刷新视图
    /// </summary>
    public void Refresh(List<string> data)
    {
        dataList = data;

        CountItemPos();
    }

    /// <summary>
    /// 添加单条内容
    /// </summary>
    public void AddItem()
    {
        GameObject obj = Instantiate(item.gameObject, scrollRect.content.transform);
        obj.SetActive(true);
        itemList.Add(obj.GetComponent<RectTransform>());
    }

    /// <summary>
    /// 计算每条内容的位置和content的总高度
    /// </summary>
    public void CountItemPos()
    {
        // 计算 item 位置
        float pos = 0;
        float space = 20; // 间隔

        int currentItem = headItem; // 从头节点的位置开始
        for(int i = headData; i <= tailData; i++)
        {
            // 如果提前到达末尾，则返回头部继续
            if(currentItem >= itemList.Count)
            {
                currentItem = 0;
            }
            itemList[currentItem].anchoredPosition = new Vector2(0, pos);
            itemList[currentItem].GetComponent<Item>().UpdateSelf(dataList[i]);
            pos = pos - item.rect.height - space;
            currentItem++;
        }
        // 计算 content 高度
        float full_heihgt = (item.rect.height + space) * itemList.Count;
        scrollRect.content.sizeDelta = new Vector2(0, full_heihgt);
    }
}
