using System;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]
public class PlayerDataSo : ScriptableObject
{
    [Header("MovementSettings")]
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;

    [Header("SpeedSettings")]
    public float[] speedOptions = { 500f, 1000f, 2000f }; // opciones de speed
    [NonSerialized] public int speedIndex = 1; //asi lo ponemos en default en la posicion 1 = 1000
    public float speed // este float lo pense para devolver el valor actual FLOAT segun el indice de opciones
                       // pensemos que actualmente en nuestro array guardamos tres opciones
                       // y cada una vale algo. Cuando movement mande a llamar a este float va a buscar en ese array
                       // y devolver el valor que le corresponde 
                       //ESTE ES EL VALOR QUE SE PONE EN EL PLAYER 1 Y PLAYER 2 SEGUN CORRESPONDA
    {
        get //cuando alguien llame a speed ejecuta esto 
        {
            if (speedOptions != null && speedOptions.Length > 0) //si la speed options NO es nula y esta dentro del rango de opciones (mayor a 0)
            {
                return speedOptions[Mathf.Clamp(speedIndex, 0, speedOptions.Length - 1)]; //busca en speed options la posicion que indica mi speedIndex y devuelve el valor que corresponde a esa posicion
            }
            else
            {
                return 0f; //si el array por alguna razon no existe devolvera 0
            }
        }
    }
    public event Action<float> OnSpeedChanged; // este es un evento al que otros pueden llamar especificamente lo cree para los titles y los slider
    public void SetSpeedIndex(int index) //metodo para cambiar el speedIndex
    {
        if (speedOptions == null || speedOptions.Length == 0) return; // si no tengo opciones en speed no hagas nada
        speedIndex = Mathf.Clamp(index, 0, speedOptions.Length - 1); // guarda el indice y actualiza pero no permitas que se salga de el numero de opciones que me dieron (esto es para el slider)
        OnSpeedChanged?.Invoke(speed); // ejecuta el evento OnSpeedChanged ahora
    }

    [Header("VisualSettings")]
    public GameObject [] variantPrefabs = new GameObject[3]; // aqui hice un array de 3 para la informacion de sus sprites

    [NonSerialized] public int variantIndex = 0;

    public GameObject CurrentVariant => (variantPrefabs != null && variantPrefabs.Length > 0)
        ? variantPrefabs[Mathf.Clamp(variantIndex, 0, variantPrefabs.Length - 1)]
        : null;

    public event Action<int> OnVariantChanged;
    public event Action<Color> OnColorChanged;
    public void SetVariantIndex(int index)
    {
        if (variantPrefabs == null || variantPrefabs.Length == 0) return;
        variantIndex = Mathf.Clamp(index, 0, variantPrefabs.Length - 1);
        OnVariantChanged?.Invoke(variantIndex);
    }
    [Header("ColorSettings")]
    public Color[] colorOptions = { Color.white, Color.green, Color.blue };
    [NonSerialized] public int colorIndex = 0;

    public Color color
    {
        get
        {
            if (colorOptions != null && colorOptions.Length > 0)
                return colorOptions[Mathf.Clamp(colorIndex, 0, colorOptions.Length - 1)];
            return Color.white;
        }
    }

    public event Action<Color> OnColorChanged;

    public void SetColorIndex(int index)
    {
        if (colorOptions == null || colorOptions.Length == 0) return;
        colorIndex = Mathf.Clamp(index, 0, colorOptions.Length - 1);
        OnColorChanged?.Invoke(color);
    }


}
