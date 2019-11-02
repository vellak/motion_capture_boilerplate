﻿namespace Helper
{
    internal class CollectionMap<TKey, TValue> : ThreadSafeDictionary<TKey, TValue> where TValue : new()
    {
        public bool TryAddDefault(TKey key)
        {
            lock (_impl)
            {
                if (!_impl.ContainsKey(key))
                {
                    _impl.Add(key, new TValue());
                    return true;
                }

                return false;
            }
        }
    }
}