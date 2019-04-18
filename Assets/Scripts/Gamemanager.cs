using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Gamemanager : MonoBehaviour
{
    public Text scoreText;
    int score;
    float timer;
    public GameObject palomero;
    public GameObject paloma;
    GameObject palomaclone;
    public GameObject instanciador;
    public float velocidad;
    public float velocidadedificios;
    public GameObject[] callesPrefabs;
    public GameObject[] edificiosPrefabs;
    public GameObject vochito;
    public GameObject parallax;
    Rigidbody vochoRB;
    public float fuerzaSalto;
    public Animator vochoAnimation;
    public Animator uxAnimation;
    public List<GameObject> calles = new List<GameObject>();
    public List<GameObject> edificios = new List<GameObject>();
    bool obsctaclesongame;
    public int espacioObstaculos = 3;
    public bool finDelJuego;
    // Start is called before the first frame update
    void Start()
    {
     
        timer = 1f;
        obsctaclesongame = false;
        vochoRB = vochito.GetComponent<Rigidbody>();
        finDelJuego = false;
        
    }

    

    void Update()
    {
           scoreText.text=score.ToString()+" KM";

        timer -= Time.deltaTime;
       


        if (vochito.GetComponent<vochoScript>().perdiste)
        {
            finDelJuego = true;
            velocidad = 0;
            parallax.GetComponent<FreeParallax>().Speed = 0f;
            uxAnimation.SetTrigger("Loose");
        }

        if (!finDelJuego)
        {

            if (timer <= 0f)
            {
                palomaclone = Instantiate(paloma, palomero.transform.position, palomero.transform.rotation) as GameObject;
                timer = Random.Range(5f, 15f);
            }


            if (vochito.GetComponent<vochoScript>().volar) {
                vochoAnimation.SetTrigger("vuela");
                vochito.GetComponent<vochoScript>().volar = false;
            }

            if (Input.GetMouseButtonDown(0) && vochito.GetComponent<vochoScript>().onGround)
            {
                Debug.Log("hello");
                vochoRB.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                vochoAnimation.SetTrigger("Giro");

            }


            moverobjetitos(edificiosPrefabs, edificios, velocidadedificios);

            foreach (GameObject calle in calles)
            {
                calle.transform.Translate(velocidad, 0, 0);
            }

            if (calles[0].transform.position.x < -40f)
            {
                //aqui se cren las callesitas y aumenta el  score cada que creamos una
                score++;
                Destroy(calles[0]);
                calles.Remove(calles[0]);

                if (!obsctaclesongame)
                {
                    Vector3 position = new Vector3(calles[calles.Count - 1].transform.position.x + 15, calles[calles.Count - 1].transform.position.y, calles[calles.Count - 1].transform.position.z);
                    calles.Add(Instantiate(callesPrefabs[Random.Range(0, callesPrefabs.Length)], position, calles[calles.Count - 1].transform.rotation));
                    obsctaclesongame = true;
                    espacioObstaculos = 3;
                }
                else
                {
                    Vector3 position = new Vector3(calles[calles.Count - 1].transform.position.x + 15, calles[calles.Count - 1].transform.position.y, calles[calles.Count - 1].transform.position.z);
                    calles.Add(Instantiate(callesPrefabs[0], position, calles[calles.Count - 1].transform.rotation));
                    espacioObstaculos--;
                    if (espacioObstaculos <= 0)
                    {
                        obsctaclesongame = false;
                    }
                }

            }
        }

        
        
        
    }

    void moverobjetitos(GameObject[] prefabs, List<GameObject> listadeprefabs, float velocidadMover)
    {
        foreach (GameObject objetito in listadeprefabs)
        {
            objetito.transform.Translate(velocidadMover, 0, 0);
        }

        if (listadeprefabs[0].transform.position.x < -40f)
        {
            Destroy(listadeprefabs[0]);
            listadeprefabs.Remove(listadeprefabs[0]);
            Vector3 position = new Vector3(listadeprefabs[listadeprefabs.Count - 1].transform.position.x + 15, listadeprefabs[listadeprefabs.Count - 1].transform.position.y, listadeprefabs[listadeprefabs.Count - 1].transform.position.z);
            listadeprefabs.Add(Instantiate(prefabs[Random.Range(0,prefabs.Length)], instanciador.transform.position, instanciador.transform.rotation));


        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void irmenu()
    {
        SceneManager.LoadScene(0);
    }
}
