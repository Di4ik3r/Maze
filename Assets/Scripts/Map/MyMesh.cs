﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyMesh
{
    public static float CUBE_SIZE = 1;

    // static Vector3[] vertices;
    // static int[] triangles;

    public static void GenerateMesh(Vector3 position, ref Vector3[] vertices, ref int[] triangles) {
        vertices = new Vector3[] {
            new Vector3(position.x, position.y, position.z),                                        // 0 0
            new Vector3(position.x, position.y, position.z  + MyMesh.CUBE_SIZE),                    // 0 1
            new Vector3(position.x + MyMesh.CUBE_SIZE, position.y, position.z),                     // 1 0
            new Vector3(position.x, position.y, position.z  + MyMesh.CUBE_SIZE),                    // 0 1
            new Vector3(position.x + MyMesh.CUBE_SIZE, position.y, position.z + MyMesh.CUBE_SIZE),  // 1 1
            new Vector3(position.x + MyMesh.CUBE_SIZE, position.y, position.z),                     // 1 0
        };

        triangles = new int[] { 0, 1, 2, 3, 4, 5 };
    }

    public static Vector3[] generateVertices(Vector3 position) {
        return new Vector3[] {
            new Vector3(position.x, position.y, position.z),                                        // 0 0
            new Vector3(position.x, position.y, position.z  + MyMesh.CUBE_SIZE),                    // 0 1
            new Vector3(position.x + MyMesh.CUBE_SIZE, position.y, position.z),                     // 1 0
            new Vector3(position.x, position.y, position.z  + MyMesh.CUBE_SIZE),                    // 0 1
            new Vector3(position.x + MyMesh.CUBE_SIZE, position.y, position.z + MyMesh.CUBE_SIZE),  // 1 1
            new Vector3(position.x + MyMesh.CUBE_SIZE, position.y, position.z),                     // 1 0
        };
    }

    public static int[] generateTriangles() {
        return new int[] { 0, 1, 2, 3, 4, 5 };
    }
}