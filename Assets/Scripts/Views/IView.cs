using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView<T>
{
    void UpdateView(T t);
}
