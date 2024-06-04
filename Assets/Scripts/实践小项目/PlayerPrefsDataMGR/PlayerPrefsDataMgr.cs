using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// PlayerPrefs管理类
/// </summary>
public class PlayerPrefsDataMgr {
    private static PlayerPrefsDataMgr instance = new PlayerPrefsDataMgr();
    public static PlayerPrefsDataMgr Instance {
        get {
            return instance;
        }
    }
    private PlayerPrefsDataMgr() {

    }
    /// <summary>
    /// 存储数据
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="keyName">数据对象的唯一标识</param>
    public void SaveData(object data, string keyName) {
        #region 第一步 获取传入数据对象的所有字段
        Type dataType = data.GetType();
        FieldInfo[] infos = dataType.GetFields();
        //for (int i = 0; i < infos.Length; i++) {
        //    Debug.Log(infos[i]);
        //}
        #endregion

        #region 第二步 自己定义一个Key的规则，进行数据存储

        #endregion

        #region 第三步 遍历这些字段，进行数据存储
        string saveKeyName = "";
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++) {
            info = infos[i];
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;
            //Debug.Log(saveKeyName);
            SaveValue(info.GetValue(data), saveKeyName);
        }
        #endregion
    }
    private void SaveValue(object value, string keyName) {
        Type fieldType = value.GetType();
        if (fieldType == typeof(int)) {
            PlayerPrefs.SetInt(keyName, (int)value);
        } else if (fieldType == typeof(float)) {
            PlayerPrefs.SetFloat(keyName, (float)value);
        } else if (fieldType == typeof(string)) {
            PlayerPrefs.SetString(keyName, value.ToString());
        } else if (fieldType == typeof(bool)) {
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        } else if (typeof(IList).IsAssignableFrom(fieldType)) {
            IList list = value as IList;
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object obj in list) {
                SaveValue(obj, keyName + index);
                ++index;
            }
        } else if (typeof(IDictionary).IsAssignableFrom(fieldType)) {
            IDictionary dictionary = value as IDictionary;
            PlayerPrefs.SetInt(keyName, dictionary.Count);
            int index = 0;
            foreach (object key in dictionary.Keys) {
                SaveValue(key, keyName + "_key" + index);
                SaveValue(dictionary[key], keyName + "_value" + index);
                ++index;
            }
        } else {
            SaveData(value, keyName);
        }
        PlayerPrefs.Save();
    }
    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取的数据的数据类型</param>
    /// <param name="keyName">数据对象的唯一标识</param>
    /// <returns></returns>
    public object LoadData(Type type, string keyName) {
        //根据传入的type，创建一个对象，用于存储数据
        object data = Activator.CreateInstance(type);
        //得到所有字段
        FieldInfo[] infos = type.GetFields();
        string loadKeyName = "";
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++) {
            info = infos[i];
            loadKeyName = keyName + "_" + type + "_" + info.FieldType.Name + "_" + info.Name;

            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }
        return data;
    }
    /// <summary>
    /// 得到单个数据的方法
    /// </summary>
    /// <param name="fieldType">字段类型，用于判断用哪个API</param>
    /// <param name="keyName">获取具体数据的唯一标识</param>
    /// <returns></returns>
    public object LoadValue(Type fieldType, string keyName) {
        if (fieldType == typeof(int)) {
            return PlayerPrefs.GetInt(keyName);
        } else if (fieldType == typeof(float)) {
            return PlayerPrefs.GetFloat(keyName);
        } else if (fieldType == typeof(string)) {
            return PlayerPrefs.GetString(keyName);
        } else if (fieldType == typeof(bool)) {
            return PlayerPrefs.GetInt(keyName, 0) == 1 ? true : false;
        } else if (typeof(IList).IsAssignableFrom(fieldType)) {
            int count = PlayerPrefs.GetInt(keyName, 0);
            IList list = Activator.CreateInstance(fieldType) as IList;
            for (int i = 0; i < count; i++) {
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
            }
            return list;
        } else if (typeof(IDictionary).IsAssignableFrom(fieldType)) {
            int count = PlayerPrefs.GetInt(keyName, 0);
            IDictionary dictionary = Activator.CreateInstance(fieldType) as IDictionary;
            for (int i = 0; i < count; i++) {
                dictionary.Add(
                    LoadValue(fieldType.GetGenericArguments()[0], keyName + "_key" + i),
                    LoadValue(fieldType.GetGenericArguments()[1], keyName + "_value" + i)
                    );
            }
            return dictionary;
        } else {
            return LoadData(fieldType, keyName);
        }
    }
}
