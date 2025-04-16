using Assets.Scripts.Market;
using UnityEngine;

public class ShopButtonOperations : MonoBehaviour
{
    [SerializeField] private GameObject[] Panels;

    #region callbacks
    public void Callback_ShowWeaponPanel_BtnClick() => ShowOnePanel("Weapons");
    public void Callback_ShowEquipmentPanel_BtnClick() => ShowOnePanel("Equipment");
    public void Callback_ShowConsumablesPanel_BtnClick() => ShowOnePanel("Consumables");
    public void Callback_ShowBasketPanel_BtnClick() => ShowOnePanel("Basket");
    public void Callback_BasketBuyAll_BtnClick() => Basket.BuyAll();
    public void Callback_BasketDeclineAll_BtnClick() => Basket.DeclineAll();
    #endregion

    #region HelpMethods
    private void HideAllPanels()
    {
        foreach (var panel in Panels)
            panel.SetActive(false);
    }

    private void ShowPanelByName(string name)
    {
        for (int i = 0; i < Panels.Length; i++)
            if (Panels[i].name == $"{name}Panel")
                Panels[i].SetActive(true);
    }

    private void ShowOnePanel(string name)
    {
        HideAllPanels();
        ShowPanelByName(name);
    }
    #endregion
}

