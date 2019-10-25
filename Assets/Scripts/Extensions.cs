using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{

    public static IEnumerable<T> EveryNthItem<T> (this IEnumerable<T> sequence, int period)
    {

        //check null exception

        var count = 0;
        foreach (var item in sequence)
        {
            if (++count % period == 0)
            {
                yield return item;
            }
        }
    }

    public static void ForEach<T> (this IEnumerable<T> sequence, Action<T> action)
    {
        if (sequence == null)
            throw new ArgumentNullException (nameof (sequence), "sequence must not be null");

        if (action == null)
            throw new ArgumentNullException ("Action must not be null");

        foreach (T item in sequence)
        {
            action (item);
        }
    }

    public static IEnumerable<Tout> TransformForEach<Tin, Tout> (this IEnumerable<Tin> sequence, Func<Tin, Tout> action)
    {

        if (sequence == null)
            throw new ArgumentNullException (nameof (sequence), "sequence must not be null");

        if (action == null)
            throw new ArgumentNullException ("Action must not be null");

        foreach (Tin item in sequence)
        {
            yield return action (item);
        }
    }

    public static IEnumerable WhereImplement<T> (this IEnumerable<T> sequence, Predicate<T> filterFunc)
    {

        //check null exception

        foreach (var item in sequence)
        {
            if (filterFunc (item))
                yield return item;
        }
    }

}