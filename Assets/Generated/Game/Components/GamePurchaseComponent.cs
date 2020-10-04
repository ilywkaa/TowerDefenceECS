//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TowerDefence.PurchaseComponent purchase { get { return (TowerDefence.PurchaseComponent)GetComponent(GameComponentsLookup.Purchase); } }
    public bool hasPurchase { get { return HasComponent(GameComponentsLookup.Purchase); } }

    public void AddPurchase(int newValue) {
        var index = GameComponentsLookup.Purchase;
        var component = (TowerDefence.PurchaseComponent)CreateComponent(index, typeof(TowerDefence.PurchaseComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePurchase(int newValue) {
        var index = GameComponentsLookup.Purchase;
        var component = (TowerDefence.PurchaseComponent)CreateComponent(index, typeof(TowerDefence.PurchaseComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePurchase() {
        RemoveComponent(GameComponentsLookup.Purchase);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPurchase;

    public static Entitas.IMatcher<GameEntity> Purchase {
        get {
            if (_matcherPurchase == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Purchase);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPurchase = matcher;
            }

            return _matcherPurchase;
        }
    }
}