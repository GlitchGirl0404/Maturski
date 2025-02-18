using TMPro;
using UnityEngine;
public class LevelSelectButtons : MonoBehaviour
{
    public class Nivo
    {
        public string flight_code;
        public string city;
        public string airport;
        public int level;
        public Nivo(string flightCode, string city, string airport, int level)
        {
            this.flight_code = flightCode;
            this.city = city;
            this.airport = airport;
            this.level = level;
        }
    }
    public Nivo[] nivoi = new Nivo[4];
    public TextMeshPro flight_code;
    public TextMeshPro airport_name;
    public TextMeshPro City;
    void Start()
    {
        nivoi[0] = new Nivo("V3CUHY", "Belgrade", "Nikola Tesla", 1);
        nivoi[1] = new Nivo("QL6PLM", "Murcia", "Región de Murcia International Airport", 2);
        nivoi[2] = new Nivo("2P6GYI", "Basel", "EuroAirport Basel Mulhouse Freiburg", 3);
        nivoi[3] = new Nivo("M478AT", "Free Play", "######", 4);
    }
    public void Left()
    {

    }
    public void Right()
    {

    }
    public void Play()
    {

    }
}