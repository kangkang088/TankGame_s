using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class {
    private static T instance;
    public static T Instance => instance;
    private void Awake() {
        instance = this as T;
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public virtual void ShowMe() {
        this.gameObject.SetActive(true);
    }
    public virtual void HideMe() {
        this.gameObject.SetActive(false);
    }
}
