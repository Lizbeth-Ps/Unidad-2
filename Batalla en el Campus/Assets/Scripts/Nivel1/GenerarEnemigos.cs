using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{

    public GameObject spiderPrefab;

    void Start()
    {
        GenerarEnemigosAleatorios(200); // Ajusta 10 al número de enemigos que deseas generar
    }

    void GenerarEnemigosAleatorios(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            // Tamaño del terreno
            float terrenoSizeX = Terrain.activeTerrain.terrainData.size.x;
            float terrenoSizeZ = Terrain.activeTerrain.terrainData.size.z;

            // Rango de generación aleatoria
            float rangoX = Random.Range(0f, terrenoSizeX);
            float rangoZ = Random.Range(0f, terrenoSizeZ);

            // Genera posiciones aleatorias dentro del terreno
            float posX = Random.Range(0f, terrenoSizeX);
            float posZ = Random.Range(0f, terrenoSizeZ);

            // Altura del terreno en la posición generada
            float alturaTerreno = Terrain.activeTerrain.SampleHeight(new Vector3(posX, 0, posZ));

            // Ajuste de posición según la ubicación del terreno
            posX += 2161f;
            posZ += 448f;

            // Instancia el enemigo (spider) en la posición generada
            Vector3 posicion = new Vector3(posX, alturaTerreno, posZ);
            Instantiate(spiderPrefab, posicion, Quaternion.identity);
        }
    }
}


