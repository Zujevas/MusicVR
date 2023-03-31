using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Extensions : MonoBehaviour
{
    public static IEnumerable<TItem> ZipAll<TItem>(this IReadOnlyCollection<IEnumerable<TItem>> enumerables)
    {
        var enumerators = enumerables.Select(enumerable => enumerable.GetEnumerator()).ToList();
        bool anyHit;
        do
        {
            anyHit = false;
            foreach (var enumerator in enumerators.Where(enumerator => enumerator.MoveNext()))
            {
                anyHit = true;
                yield return enumerator.Current;
            }
        } while (anyHit);

        foreach (var enumerator in enumerators)
        {
            enumerator.Dispose();
        }
    }
}
