using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;



/// <summary>
/// //* 迭代器方式 
/// *可以在使用到序列中某个元素时才创建
/// *不用先创建整个序列在进行第二步操作 
/// *在某些操作中 
/// *生成整个序列开销可能很大 
/// *例如某些操作可能是对生成的序列进行查找操作（仅查找前几个或一个就停止） 
/// *那么使用这种这种方式可以有效减小消耗 
/// *因为这样不会创建出后面的不必要元素 
/// *或者要对某一序列中的元素进行一系列操作时 
/// *这种方式的优点就更佳明显
/// </summary>
public class MyIterator : MonoBehaviour
{

    public List<int> Numbers;

    private void Start ()
    {
        // Where ();
        var result = Numbers.Where (x => x < 5);
        result.TakeWhile (x => x < 5);
        result.TakeWhile (delegate (int num) { return num < 5; });
        Transform_cs ();
    }

    private void Transform_cs ()
    {
        Numbers.TransformForEach (x => (x + 10).ToString ()).ForEach (x => print (x));
    }

    private void EveryN (int n = 2)
    {
        Numbers.EveryNthItem (n).ForEach (x => print (x));
    }

    private void Where ()
    {
        var result = Numbers.Where (x => x < 4);
        result.ForEach (x => print (x));
    }

}