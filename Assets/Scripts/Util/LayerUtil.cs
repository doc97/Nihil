using UnityEngine;

public static class LayerUtil
{
    public static bool IsInLayerMask(LayerMask mask, int layer)
    {
        // If the bitmask contains the bit 'layer'
        return mask == (mask | (1 << layer));
    }
}