using System;
using System.Collections.Generic;

/// <summary>
/// Priority queue the deques the element with the lowest priority
/// </summary>
public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    private List<(TElement element, TPriority priority)> items = new List<(TElement, TPriority)>();

    public int Count => items.Count;

    public void Enqueue(TElement element, TPriority priority)
    {
        items.Add((element, priority));
    }

    public TElement Dequeue()
    {
        // linear scan for the lowest priority
        int bestIndex = 0;
        for (int i = 1; i < items.Count; i++)
        {
            if (items[i].priority.CompareTo(items[bestIndex].priority) < 0)
            {
                bestIndex = i;
            }
        }

        TElement element = items[bestIndex].element;
        items.RemoveAt(bestIndex);
        return element;
    }
}