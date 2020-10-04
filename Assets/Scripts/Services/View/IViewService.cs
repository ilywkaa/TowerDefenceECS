using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public interface IViewService
    {
        GameObject LoadAsset(string assetName);
    }
}