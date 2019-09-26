﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel
{

    private static float CUBE_SIZE = 1;
    private static float LOWEST_HEIGHT = -2;

    private GameObject gameObject;

    public Mesh mesh;

    public float Height {
        get;
    }

    public Voxel(Vector3 position) {
        initComponent();
        initFields(position);

        this.Height = position.y;


        generateMesh();

        this.mesh.RecalculateNormals();
    }


    public void ChangeColor(Color color) {
        this.gameObject.GetComponent<Renderer>().material.color = color;
    }




    public void generateConnectors(Voxel top) {
        genereteTopConnector(top);
        genereteBottomBorderer();

        this.mesh.RecalculateNormals();
    }

    // **************************** C *** O *** N *** N *** E *** C *** T *** O *** R *** S ****************************

    public void genereteTopConnector(Voxel toThat) {
        Vector3[] verticesOld = this.mesh.vertices;
        int[] trianglesOld = this.mesh.triangles;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[trianglesOld.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < trianglesOld.Length; i++)
            triangles[i] = trianglesOld[i];
        
        Vector3[] toThatVertices = toThat.mesh.vertices;
        int[] toThatTriangles = toThat.mesh.triangles;

        int indexer = verticesOld.Length;

        vertices[indexer++] = verticesOld[1];
        vertices[indexer++] = new Vector3(toThatVertices[0].x, toThatVertices[0].y, toThatVertices[0].z + CUBE_SIZE);
        vertices[indexer++] = verticesOld[4];
        vertices[indexer++] = new Vector3(toThatVertices[0].x, toThatVertices[0].y, toThatVertices[0].z + CUBE_SIZE);
        vertices[indexer++] = new Vector3(toThatVertices[5].x, toThatVertices[5].y, toThatVertices[5].z + CUBE_SIZE);
        vertices[indexer++] = verticesOld[4];

        for(int i = trianglesOld.Length; i < trianglesOld.Length + 6; i++)
            triangles[i] = i;

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;
        
        this.mesh.RecalculateNormals();
    }

    public void genereteBottomConnector(Voxel toThat) {
        Vector3[] verticesOld = this.mesh.vertices;
        int[] trianglesOld = this.mesh.triangles;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[trianglesOld.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < trianglesOld.Length; i++)
            triangles[i] = trianglesOld[i];
        
        Vector3[] toThatVertices = toThat.mesh.vertices;
        int[] toThatTriangles = toThat.mesh.triangles;

        int indexer = verticesOld.Length;

        vertices[indexer++] = new Vector3(toThatVertices[4].x, toThatVertices[4].y, toThatVertices[4].z - CUBE_SIZE);
        vertices[indexer++] = new Vector3(toThatVertices[1].x, toThatVertices[1].y, toThatVertices[1].z - CUBE_SIZE);
        vertices[indexer++] = verticesOld[0];
        vertices[indexer++] = new Vector3(toThatVertices[4].x, toThatVertices[4].y, toThatVertices[4].z - CUBE_SIZE);
        vertices[indexer++] = verticesOld[0];
        vertices[indexer++] = verticesOld[2];

        for(int i = trianglesOld.Length; i < trianglesOld.Length + 6; i++)
            triangles[i] = i;

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;

        this.mesh.RecalculateNormals();
    }

    public void genereteLeftConnector(Voxel toThat) {
        Vector3[] verticesOld = this.mesh.vertices;
        int[] trianglesOld = this.mesh.triangles;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[trianglesOld.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < trianglesOld.Length; i++)
            triangles[i] = trianglesOld[i];
        
        Vector3[] toThatVertices = toThat.mesh.vertices;
        int[] toThatTriangles = toThat.mesh.triangles;

        int indexer = verticesOld.Length;

        vertices[indexer++] = vertices[0];
        vertices[indexer++] = new Vector3(toThatVertices[2].x - CUBE_SIZE, toThatVertices[2].y, toThatVertices[2].z);
        vertices[indexer++] = new Vector3(toThatVertices[4].x - CUBE_SIZE, toThatVertices[4].y, toThatVertices[4].z);
        vertices[indexer++] = vertices[0];
        vertices[indexer++] = new Vector3(toThatVertices[4].x - CUBE_SIZE, toThatVertices[4].y, toThatVertices[4].z);
        vertices[indexer++] = vertices[1];

        for(int i = trianglesOld.Length; i < trianglesOld.Length + 6; i++)
            triangles[i] = i;

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;

        this.mesh.RecalculateNormals();
    }

        public void genereteRightConnector(Voxel toThat) {
        Vector3[] verticesOld = this.mesh.vertices;
        int[] trianglesOld = this.mesh.triangles;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[trianglesOld.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < trianglesOld.Length; i++)
            triangles[i] = trianglesOld[i];
        
        Vector3[] toThatVertices = toThat.mesh.vertices;
        int[] toThatTriangles = toThat.mesh.triangles;

        int indexer = verticesOld.Length;

        vertices[indexer++] = new Vector3(toThatVertices[0].x + CUBE_SIZE, toThatVertices[0].y, toThatVertices[0].z);
        vertices[indexer++] = vertices[2];
        vertices[indexer++] = vertices[4];
        vertices[indexer++] = new Vector3(toThatVertices[0].x + CUBE_SIZE, toThatVertices[0].y, toThatVertices[0].z);
        vertices[indexer++] = vertices[4];
        vertices[indexer++] = new Vector3(toThatVertices[1].x  + CUBE_SIZE, toThatVertices[1].y, toThatVertices[1].z);

        for(int i = trianglesOld.Length; i < trianglesOld.Length + 6; i++)
            triangles[i] = i;

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;

        this.mesh.RecalculateNormals();
    }



    // ************************************** B *** O *** R *** D *** E *** R *** S **************************************

    public void genereteTopBorderer() {
        Vector3[] verticesOld = this.mesh.vertices;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[this.mesh.triangles.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < triangles.Length; i++)
            triangles[i] = i;
        
        int indexer = verticesOld.Length;

        vertices[indexer++] = new Vector3(vertices[1].x, Voxel.LOWEST_HEIGHT, vertices[1].z);
        vertices[indexer++] = new Vector3(vertices[4].x, Voxel.LOWEST_HEIGHT, vertices[4].z);
        vertices[indexer++] = vertices[4];
        vertices[indexer++] = new Vector3(vertices[1].x, Voxel.LOWEST_HEIGHT, vertices[1].z);
        vertices[indexer++] = vertices[4];
        vertices[indexer++] = vertices[1];

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;

        
        this.mesh.RecalculateNormals();
    }

    public void genereteBottomBorderer() {
        Vector3[] verticesOld = this.mesh.vertices;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[this.mesh.triangles.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < triangles.Length; i++)
            triangles[i] = i;
        
        int indexer = verticesOld.Length;

        vertices[indexer++] = new Vector3(vertices[2].x, Voxel.LOWEST_HEIGHT, vertices[2].z);
        vertices[indexer++] = new Vector3(vertices[0].x, Voxel.LOWEST_HEIGHT, vertices[0].z);
        vertices[indexer++] = vertices[0];
        vertices[indexer++] = new Vector3(vertices[2].x, Voxel.LOWEST_HEIGHT, vertices[2].z);
        vertices[indexer++] = vertices[0];
        vertices[indexer++] = vertices[2];

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;

        
        this.mesh.RecalculateNormals();
    }

    public void genereteLeftBorderer() {
        Vector3[] verticesOld = this.mesh.vertices;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[this.mesh.triangles.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < triangles.Length; i++)
            triangles[i] = i;
        
        int indexer = verticesOld.Length;

        vertices[indexer++] = new Vector3(vertices[0].x, LOWEST_HEIGHT, vertices[0].z);
        vertices[indexer++] = new Vector3(vertices[1].x, LOWEST_HEIGHT, vertices[1].z);
        vertices[indexer++] = vertices[1];
        vertices[indexer++] = new Vector3(vertices[0].x, LOWEST_HEIGHT, vertices[0].z);
        vertices[indexer++] = vertices[1];
        vertices[indexer++] = vertices[0];

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;

        this.mesh.RecalculateNormals();
    }

    public void genereteRightBorderer() {
        Vector3[] verticesOld = this.mesh.vertices;
        int[] trianglesOld = this.mesh.triangles;
        Vector3[] vertices = new Vector3[verticesOld.Length + 6];
        int[] triangles = new int[trianglesOld.Length + 6];
        for(int i = 0; i < verticesOld.Length; i++)
            vertices[i] = verticesOld[i];
        for(int i = 0; i < trianglesOld.Length; i++)
            triangles[i] = trianglesOld[i];
        
        int indexer = verticesOld.Length;

        vertices[indexer++] = new Vector3(vertices[4].x, LOWEST_HEIGHT, vertices[4].z);
        vertices[indexer++] = new Vector3(vertices[2].x, LOWEST_HEIGHT, vertices[2].z);
        vertices[indexer++] = vertices[2];
        vertices[indexer++] = new Vector3(vertices[4].x, LOWEST_HEIGHT, vertices[4].z);
        vertices[indexer++] = vertices[2];
        vertices[indexer++] = vertices[4];

        for(int i = trianglesOld.Length; i < trianglesOld.Length + 6; i++)
            triangles[i] = i;

        this.mesh.vertices = vertices;
        this.mesh.triangles = triangles;

        
        this.mesh.RecalculateNormals();
    }

    // private void generateMesh() {
    //     this.mesh.vertices = MyMesh.generateVertices(Vector3.zero);
    //     this.mesh.triangles = MyMesh.generateTriangles(Vector3.zero);
    // }

    private void generateMesh() {
        this.mesh.vertices = MyMesh.generateVertices(new Vector3(0, this.Height, 0));
        this.mesh.triangles = MyMesh.generateTriangles();
    }    

    private void initFields(Vector3 position) {
        this.mesh = gameObject.GetComponent<MeshFilter>().mesh;
        this.gameObject.transform.position = new Vector3(position.x, 0, position.z);

        this.gameObject.GetComponent<Renderer>().materials[0] = Resources.Load("BasicMaterial", typeof(Material)) as Material;
        // this.gameObject.GetComponent<Renderer>().material.color = 
                // new Color32((byte)Random.Range(100, 255), (byte)Random.Range(100, 255), (byte)Random.Range(100, 255), 255);
    }

    private void initComponent() {
        gameObject = new GameObject("Voxel");

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
    }


    public Transform GetTransform(){ 
        return this.gameObject.transform;
    }

    public Vector3 getPosition() {
        return this.gameObject.transform.position;
    }

    public float getHeight() {
        return this.gameObject.transform.position.y;
    }
}