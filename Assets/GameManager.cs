using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public class Nivo
    {
        public string flight_code;
        public string city;
        public string airport;
        public Nivo(string flightCode, string city, string airport)
        {
            this.flight_code = flightCode;
            this.city = city;
            this.airport = airport;
        }
    }
    public Nivo[] nivoi = new Nivo[4];
    [SerializeField] TextMeshProUGUI flight_code;
    [SerializeField] TextMeshProUGUI airport_name;
    [SerializeField] TextMeshProUGUI city;
    public int current = 0;
    public void DisplayNames()
    {
        flight_code.text = nivoi[current].flight_code;
        city.text = nivoi[current].city;
        airport_name.text = nivoi[current].airport;
    }
    void Start()
    {
        nivoi[0] = new Nivo("V3CUHY", "Belgrade", "Nikola Tesla");
        nivoi[1] = new Nivo("QL6PLM", "Murcia", "Regi�n de Murcia International Airport");
        nivoi[2] = new Nivo("2P6GYI", "Basel", "EuroAirport Basel Mulhouse Freiburg");
        nivoi[3] = new Nivo("M478AT", "Free Play", "######");
        DisplayNames();
    }
}