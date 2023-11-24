using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{

    public GameObject spiderPrefab;

    void Start()
    {
        GenerarEnemigosAleatorios(200); // Ajusta 10 al n�mero de enemigos que deseas generar
    }

    void GenerarEnemigosAleatorios(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            // Tama�o del terreno
            float terrenoSizeX = Terrain.activeTerrain.terrainData.size.x;
            float terrenoSizeZ = Terrain.activeTerrain.terrainData.size.z;

            // Rango de generaci�n aleatoria
            float rangoX = Random.Range(0f, terrenoSizeX);
            float rangoZ = Random.Range(0f, terrenoSizeZ);

            // Genera posiciones aleatorias dentro del terreno
            float posX = Random.Range(0f, terrenoSizeX);
            float posZ = Random.Range(0f, terrenoSizeZ);

            // Altura del terreno en la posici�n generada
            float alturaTerreno = Terrain.activeTerrain.SampleHeight(new Vector3(posX, 0, posZ));

            // Ajuste de posici�n seg�n la ubicaci�n del terreno
            posX += 2161f;
            posZ += 448f;

            // Instancia el enemigo (spider) en la posici�n generada
            Vector3 posicion = new Vector3(posX, alturaTerreno, posZ);
            Instantiate(spiderPrefab, posicion, Quaternion.identity);
        }
    }
}


