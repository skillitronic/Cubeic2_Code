using UnityEngine;
using UnityEngine.UI;
public class LanguageController : MonoBehaviour
{
    public Text[] textToBeSwitched;
    private SaveSystem saveSystem;
    private void Awake()
    {
        saveSystem = GetComponent<SaveSystem>();
    }
    private void Start()
    {
        if (saveSystem.localLangSwitched == false)
        {
            SwitchToEnglish();
        }
        else
        {
            SwitchToRussian();
        }
    }
    public void SwitchToRussian()
    {
        textToBeSwitched[0].text = "ЗАЖМИТЕ ЧТОБЫ ЛЕТАТЬ";
        textToBeSwitched[1].text = "Магазин";
        textToBeSwitched[2].text = "Магазин";
        textToBeSwitched[3].text = "Магазин";
        textToBeSwitched[4].text = "Надеть";
        textToBeSwitched[5].text = "ПАУЗА";
        textToBeSwitched[6].text = "ПАУЗА";
        textToBeSwitched[7].text = "ПАУЗА";
        textToBeSwitched[8].text = "Уровень пройден";
        textToBeSwitched[9].text = "Уровень пройден";
        textToBeSwitched[10].text = "Уровень пройден";
        textToBeSwitched[11].text = "Получить";
        textToBeSwitched[12].text = "Вы проиграли";
        textToBeSwitched[13].text = "Вы проиграли";
        textToBeSwitched[14].text = "Вы проиграли";
        textToBeSwitched[15].text = "Пропустить";
        textToBeSwitched[16].text = "Нет, спасибо";
        textToBeSwitched[17].text = "Следующий уровень";

        textToBeSwitched[15].fontSize = 70;
        saveSystem.localLangSwitched = true;
        saveSystem.SaveLanguageData();
    }
    public void SwitchToEnglish()
    {
        textToBeSwitched[0].text = "HOLD TO FLY";
        textToBeSwitched[1].text = "Shop";
        textToBeSwitched[2].text = "Shop";
        textToBeSwitched[3].text = "Shop";
        textToBeSwitched[4].text = "Equip";
        textToBeSwitched[5].text = "PAUSE";
        textToBeSwitched[6].text = "PAUSE";
        textToBeSwitched[7].text = "PAUSE";
        textToBeSwitched[8].text = "Level Completed";
        textToBeSwitched[9].text = "Level Completed";
        textToBeSwitched[10].text = "Level Completed";
        textToBeSwitched[11].text = "Get";
        textToBeSwitched[12].text = "You lose";
        textToBeSwitched[13].text = "You lose";
        textToBeSwitched[14].text = "You lose";
        textToBeSwitched[15].text = "Skip";
        textToBeSwitched[16].text = "no, thanks";
        textToBeSwitched[17].text = "next level";

        textToBeSwitched[15].fontSize = 100;
        saveSystem.localLangSwitched = false;
        saveSystem.SaveLanguageData();
    }
}
