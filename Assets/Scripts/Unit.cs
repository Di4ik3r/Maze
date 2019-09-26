using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit
{
    private GameObject gameObject;
    public Vector3 position { get { return this.gameObject.transform.position; } set { this.gameObject.transform.position = value; } }

    public static int ID_COUNTER = 10;
    public static int[,] digitalMap;
    public static Voxel[,] objectMap;

    private int id;

    private Mesh mesh;
    private float meshHeight;

    private List<Vector3> stepHistory = new List<Vector3>();

    public Unit(Vector2 position)
    {
        this.mesh = PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cube);
        ImplementComponents();

        this.id = Unit.ID_COUNTER++;

        this.position = new Vector3(Unit.objectMap[(int)position.x, (int)position.y].position.x + 0.5f,
                                    0.5f,
                                    Unit.objectMap[(int)position.x, (int)position.y].position.z - 0.5f);
    }

    private void ImplementComponents()
    {
        this.gameObject = new GameObject("Creature");
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();

        this.gameObject.GetComponent<MeshFilter>().mesh = this.mesh;
        this.gameObject.GetComponent<Renderer>().materials[0] = Resources.Load("BasicMaterial", typeof(Material)) as Material;
    }


    public void MakeMove()
    {
        Jump();
    }

    private void Jump()
    {
        this.position = MoveLogic();
    }


    private Vector3 MoveLogic()
    {
        int indexer = 0;
        float x = this.position.x,
                y = this.position.y,
                z = this.position.z;

        // Unit.digitalMap[(int)x, (int)z] = 0;
        Vector3 result;
        Vector2[] possibleChoices = new Vector2[4];

        //possibleChoices[indexer++] = new Vector2(this.position.x - 1,   this.position.z + 1);     // 1    zdelanno
        possibleChoices[indexer++] = new Vector2(this.position.x, this.position.z + 1);             // 2    zdelanno
        // possibleChoices[indexer++] = new Vector2(this.position.x + 1, this.position.z + 1);     // 3    zdelanno
        possibleChoices[indexer++] = new Vector2(this.position.x + 1, this.position.z);             // 4    zdelanno
        // possibleChoices[indexer++] = new Vector2(this.position.x + 1, this.position.z - 1);     // 5    zdelanno
        possibleChoices[indexer++] = new Vector2(this.position.x, this.position.z - 1);             // 6    zdelanno
        //possibleChoices[indexer++] = new Vector2(this.position.x - 1,   this.position.z - 1);     // 7    zdelanno
        possibleChoices[indexer++] = new Vector2(this.position.x - 1,   this.position.z);         // 8    zdelanno

        List<Vector2> provedChoices = new List<Vector2>();
        foreach (Vector2 possibleChoice in possibleChoices)
        {
            if (possibleChoice.x > 0 && possibleChoice.x < Unit.digitalMap.GetLength(0)
                && possibleChoice.y > 0 && possibleChoice.y < Unit.digitalMap.GetLength(1))
                    provedChoices.Add(possibleChoice);
        }

        int choice = Random.Range(0, provedChoices.Count - 1);

        bool available = Unit.digitalMap[(int)provedChoices[choice].x, (int)provedChoices[choice].y] != 1;
        // // if (!available)
        // // {
        //     for (int i = 0; i < provedChoices.Count - 1; i++)
        //     {
        //         choice = Random.Range(0, provedChoices.Count - 1);
        //         available = Unit.digitalMap[(int)provedChoices[choice].x, (int)provedChoices[choice].y] == 0 ? true : false;
        //         if (available)
        //             break;
        //     }
        // // }

        while(!available) {
            choice = Random.Range(0, provedChoices.Count - 1);
            available = digitalMap[(int)provedChoices[choice].x, (int)provedChoices[choice].y] != 1;
        }

        // if (!available)
        // {
        //     // provedChoices[choice].x = stepHistory[stepHistory.Count - 1].x;
        //     // provedChoices[choice].y = stepHistory[stepHistory.Count - 1].y;
        //     Vector2 step = new Vector2(stepHistory[stepHistory.Count - 2].x, stepHistory[stepHistory.Count - 2].z);
        //     provedChoices[choice] = step;
        //     // digitalMap[(int)this.position.x, (int)this.position.y] = 9;
        //     digitalMap[(int)stepHistory[stepHistory.Count - 1].x - 1, (int)stepHistory[stepHistory.Count - 1].z] = 1;
        // }

        x = provedChoices[choice].x;
        z = provedChoices[choice].y;

        // y = Unit.objectMap[(int)x, (int)z].position.y + this.meshHeight;
        y = 0.5f;

        Unit.digitalMap[(int)x, (int)z] = this.id;

        result = new Vector3(x, y, z);

        // if (stepHistory.Count >= 7)
        //     stepHistory.RemoveAt(0);

        // stepHistory.Add(result);

        return result;
    }

    private List<Vector2> GetAvailableCellsIndexes(int r, int type)
    {
        List<Vector2> result = new List<Vector2>();

        for (int x = (int)this.position.x - r; x <= this.position.x + r; x++)
        {
            if (x >= 0 && x < Unit.digitalMap.GetLength(0))
                for (int z = (int)this.position.z - r; z <= this.position.z + r; z++)
                {
                    if (x == (int)this.position.x && z == (int)this.position.z)
                        continue;
                    if (z >= 0 && z < Unit.digitalMap.GetLength(1))
                        if (Unit.digitalMap[x, z] == type)
                            result.Add(new Vector2(x, z));
                }
        }

        return result;
    }
}
