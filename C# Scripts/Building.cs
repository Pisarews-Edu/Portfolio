using System.Collections;
using UnityEngine;


public class Building : MonoBehaviour
{
    //Ten skrypt docelowo będzie zawierać szereg funkcji dotyczących budynku jako obiektu. 
    [Header("Informacje")]
    public float WaitTimeX;
    public int   buildingLvl;
    public float RessourcesCost;

    [Header("Surowce")]
    public float RessourcesMultiplicator;
    public float GoldMultiplicator;
    public float GoldCost;

    public float RessourcesProduction;
    public float GoldProduction;

    [Header("Obiekty i mapa")]
    public GameObject prefab;
    public GameObject target;

    public GameObject mapa;
    public float yPosmapa;

    [Header("Aktualnie wybrana opcja")]
    public int optionSwitcher;

    [Header("Constraints Position")]

    public float minX = 5.0f, maxX = 50.0f; //Wartosci podane wedlug mapy
    public float minZ = 5.0f, maxZ = 50.0f; //Wartosci podane wedlug mapy
    public Vector3 position;
    public float moveSpeed = 2f;

    public bool Permission;



    void Start()
    {
        SceneManager.RessourcesCost1 = RessourcesCost;
        mapa = GameObject.Find("Tiles");
        target = SceneManager.BuildingSelected1;
       
        buildingLvl = 0; 
    }



void Update()
{
       

        switch (optionSwitcher)

    {
            case 0:
                {
                    Debug.Log("Budynek Biednej Pierdolonej Piechoty Czeka Na Rozkaz");
                }break; 
              case 1:
            {
                    if ((SceneManager.Ressources1 >= RessourcesCost) && (SceneManager.Gold1 >= GoldCost))
                    {
                        EditPosition();
                        
                        Debug.Log(Permission + " Kurwa");

                        if (Input.GetMouseButtonUp(0) && Permission == true)
                        {
                            SceneManager.Ressources1 = SceneManager.Ressources1 - RessourcesCost;
                            SceneManager.Gold1 = SceneManager.Gold1 - GoldCost;
                            upgradeBuilding();
                        
                            optionSwitcher = 0;
                        }
                    }
                    else
                    {
                        Object.Destroy(target);
                        Debug.Log("Nie masz wystarczajaco surowcow lub zlota"); //Tu bedzie komunikat dla gracza
                        optionSwitcher = 0;
                    }
                    break; 
            }

            case 2: // To pozwoli niszczyc budynek 
                {
                    destroyBuilding();
                    mapa.tag = "Untagged";
                    break;
                }
            case 3:
               // {
                    // if (EditPositionCost <= SceneManager.Ressources1) 
                    {
                    EditPosition();
                    optionSwitcher = 0; 
                    break; 
                    }
                   // else Debug.Log("Nie ma wystarczajaco surowcow"); break; 
                //}

            case 4:
                {
                    RessourcesCost = (RessourcesCost * (6 / 5));
                    GoldCost = (GoldCost * (6 / 5));

                    if ((SceneManager.Ressources1 >= RessourcesCost) && (SceneManager.Gold1 >= GoldCost)) //Zdefiniowac Zmienna w SCENEMANAGER
                    {
                        SceneManager.Ressources1 = SceneManager.Ressources1 - RessourcesCost;
                        SceneManager.Gold1 = SceneManager.Gold1 - GoldCost;
                        
                        upgradeBuilding();
                        optionSwitcher = 0;
                    }
                    else Debug.Log("Nie ma wystarczajaco surowcow lub zlota"); break;
                } 


            default: Debug.Log("No i chuj nie dziala"); break; //A to jest jakby coś się zjebało 
    }

}

    IEnumerator Waiting(float x)
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(x);
        print(Time.time);
    }


    public void EditPosition()
    {
        //Modyfikacja Pozycji obiektu.
        WithForeachLoop();

        float xMove = Input.GetAxis("Mouse X") * moveSpeed;
        float zMove = Input.GetAxis("Mouse Y") * moveSpeed;


        position.y = yPosmapa; //y budynku == y terenu

        position.x += xMove;
        position.x = Mathf.Clamp(position.x, minX, maxX);

        position.z += zMove;
        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        target.transform.position = position;
    }

    IEnumerator Example(float x)
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(x);
        print(Time.time);
    }

    void upgradeBuilding()
    {
        buildingLvl++; 
        SceneManager.RessourcesProd1 = SceneManager.RessourcesProd1 + RessourcesProduction;
        SceneManager.GoldProd1 = SceneManager.GoldProd1 + GoldProduction; 
        Debug.Log(buildingLvl);
    }

    void destroyBuilding()
    {
        SceneManager.RessourcesProd1 = SceneManager.RessourcesProd1 - (buildingLvl * RessourcesProduction);
        Object.Destroy(SceneManager.BuildingSelected1);
    }
    void WithForeachLoop()
    {
        foreach (Transform child in transform)
        { 
            CollisionDetect x = child.GetComponent<CollisionDetect>();
            if (x.permission == true)
            {
                Permission = true;
            }
            else
            {
                Permission = false;
                Debug.Log("Big Permission Value: " + Permission);
                return;
            } 
            
            Debug.Log("Big Permission Value: " + Permission);
        }
  




    }
    }


