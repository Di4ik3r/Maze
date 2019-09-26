﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MapRules : MonoBehaviour
{

    private const int WIDTH = 35;
    private const int LENGTH = 25;

    private Voxel[,] voxelMap;
    private int[,] digitalMap;

    [Range(0, 100)]
    public int wallPercent = 60;

    private float TIME = 0, TIME_STEP = 0.1f;
    private List<Unit> units;

    void Start()
    {
        this.digitalMap = new int[WIDTH, LENGTH];
        for(int z = 0; z < LENGTH ; z++) {
            // this.digitalMap[0, z] = 1;
            this.digitalMap[WIDTH-1, z] = 1;
        }
        for(int x = 0; x < WIDTH ; x++) {
            this.digitalMap[x, 0] = 1;
            this.digitalMap[x, LENGTH-1] = 1;
        }
        for(int x = 5; x < WIDTH - 1; x++) {
            if(x % 2 == 0)
                for(int z = 1; z < LENGTH - 1; z++) {
                    this.digitalMap[x, z] = Random.Range(0, 100) <= wallPercent ? 1 : 0;
                }
            else 
                for(int z = LENGTH - 2; z >= 1; z--) {
                    this.digitalMap[x, z] = Random.Range(0, 100) <= wallPercent ? 1 : 0;
                }
        }



        voxelMap = new Voxel[WIDTH, LENGTH];
        for(int x = 0; x < WIDTH; x++)
            for(int z = 0; z < LENGTH; z++) {
                if(this.digitalMap[x, z] == 0) {
                    voxelMap[x, z] = new Voxel(new Vector3(x, 0, z));
                    voxelMap[x, z].ChangeColor(Color.green);
                }
                else {
                    voxelMap[x, z] = new Voxel(new Vector3(x, this.digitalMap[x, z] == 0 ? 0 : Random.Range(0.9f, 1.2f), z));
                    voxelMap[x, z].ChangeColor(Color.red);
                }                
            }

        for(int z = 0; z < WIDTH ; z++)
            for(int y = 0; y < LENGTH; y++) {
                if(y == 0) 
                    voxelMap[z, y].genereteBottomBorderer();
                if(z == 0)
                    voxelMap[z, y].genereteLeftBorderer();
                if(z == WIDTH - 1)
                    voxelMap[z, y].genereteRightBorderer();
                if(y == LENGTH - 1)
                    voxelMap[z, y].genereteTopBorderer();

                if(y + 1 < LENGTH) 
                    if(voxelMap[z,y].Height > voxelMap[z, y+1].Height) 
                        voxelMap[z,y].genereteTopConnector(voxelMap[z, y + 1]);
                if(y - 1 >= 0) 
                    if(voxelMap[z,y].Height > voxelMap[z, y-1].Height) 
                        voxelMap[z,y].genereteBottomConnector(voxelMap[z, y - 1]);
                if(z - 1 >= 0) 
                    if(voxelMap[z,y].Height > voxelMap[z-1, y].Height) 
                        voxelMap[z,y].genereteLeftConnector(voxelMap[z-1, y]);
                if(z + 1 < WIDTH) 
                    if(voxelMap[z,y].Height > voxelMap[z+1, y].Height) 
                        voxelMap[z,y].genereteRightConnector(voxelMap[z+1, y]);
            }

        Unit.digitalMap = this.digitalMap;
        Unit.objectMap = this.voxelMap;

        Unit u1 = new Unit(new Vector2(0, 1));
        Unit u2 = new Unit(new Vector2(0, 3));
        Unit u3 = new Unit(new Vector2(0, 6));
        Unit u4 = new Unit(new Vector2(0, 8));
        Unit u5 = new Unit(new Vector2(0, 10));
        Unit u6 = new Unit(new Vector2(0, 12));


        units = new List<Unit>();
        units.Add(u1);
        units.Add(u2);
        units.Add(u3);
        units.Add(u4);
        units.Add(u5);
        units.Add(u6);
    }

    void Update() {
        // if(MapGenerator.TIME % 2 == 0) {
        if(System.Math.Round(TIME, 1) % 2 == 0) {
            creatureCycle();
        }
            

        TIME += TIME_STEP;
    }

    private void creatureCycle() {
        foreach(Unit unit in units) {
            unit.MakeMove();
        }
    }



}