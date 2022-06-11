using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
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
    }
}
