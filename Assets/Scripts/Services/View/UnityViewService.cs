using System;
using System.Collections.Generic;
using Entitas;
using TowerDefence;
using UnityEngine;
using Object = UnityEngine.Object;

public sealed class UnityViewService : IViewService
{
    private readonly Transform _root;
    private Contexts _contexts;
    public UnityViewService(Contexts contexts, IConfigurationService configuration)
    {
        _contexts = contexts;
        _root = configuration.Spawner;
    }
    public GameObject LoadAsset(string asset)
    {
        var viewObject = Object.Instantiate(Resources.Load<GameObject>(string.Format("Prefabs/{0}", asset)), 
            _root);
        if (viewObject == null)
            throw new NullReferenceException(string.Format("Prefabs/{0} not found!", asset));
        return viewObject;
    }
}