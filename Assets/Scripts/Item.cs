using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    /// <summary>
    /// Item 最小高度
    /// </summary>
    public float min_height = 140;

    /// <summary>
    /// 内边距
    /// </summary>
    public float padding = 40;

    /// <summary>
    /// 容器
    /// </summary>
    RectTransform m_rect;

    /// <summary>
    /// 头像
    /// </summary>
    Image avatar;

    /// <summary>
    /// 消息
    /// </summary>
    Text txt_message;

    void Awake()
    {
        // 获取组件
        m_rect = transform.GetComponent<RectTransform>();
        avatar = transform.Find("Avatar").GetComponent<Image>();
        txt_message = transform.Find("Message").GetComponent<Text>();
    }

    /// <summary>
    /// 刷新数据
    /// </summary>
    /// <param name="message">消息</param>
    public void UpdateSelf(string message)
    {
        // 刷新消息文本
        txt_message.text = message;
        float current_height = txt_message.preferredHeight + padding;
        if (current_height < min_height)
        {
            current_height = min_height;
        }
        m_rect.sizeDelta = new Vector2(0, current_height);
    }
}
