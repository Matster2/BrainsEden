﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float movementSpeed = 40f;
    public float maxSpeed = 15f;

    [Header("Controls")]
    public MouseLook mouseLook = new MouseLook();

    private GameManager gameManager;
    // Cache of input values
    private Dictionary<InputMappings.EAction, float> InputValues = new Dictionary<InputMappings.EAction, float>() {
        {InputMappings.EAction.MOVE_FORWARD, 0},
        {InputMappings.EAction.MOVE_RIGHT, 0},
        {InputMappings.EAction.JUMP, 0},
        {InputMappings.EAction.PUSH, 0},
        {InputMappings.EAction.PULL, 0},
        {InputMappings.EAction.SWITCH_PHASE, 0}
    };
    // Input Values last frame
    private Dictionary<InputMappings.EAction, float> LastInputValues;

    private CapsuleCollider collider;
    private Rigidbody body;


    void Start() {
        mouseLook.Init(transform, Camera.main.transform);
    }

    void OnEnable() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null) {
            throw new UnityException("Scene needs a GameManager instance with tag 'GameManager'");
        }
        body = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

	void Update () {
        mouseLook.LookRotation(transform, Camera.main.transform);
        HandleInput();

        LastInputValues = InputValues;
	}

    void FixedUpdate() {
        if (InputValues[InputMappings.EAction.MOVE_FORWARD] > 0) {
            body.AddForce(body.transform.forward * movementSpeed, ForceMode.Acceleration);
        }
    }

    /// <summary>
    /// Gets input and stores it in InputValues and handles non-physics input
    /// </summary>
    private void HandleInput() {
        InputValues[InputMappings.EAction.MOVE_FORWARD] = InputMappings.GetInput(InputMappings.EAction.MOVE_FORWARD);
        InputValues[InputMappings.EAction.MOVE_RIGHT] = InputMappings.GetInput(InputMappings.EAction.MOVE_RIGHT);
        InputValues[InputMappings.EAction.JUMP] = InputMappings.GetInput(InputMappings.EAction.JUMP);
        InputValues[InputMappings.EAction.SWITCH_PHASE] = InputMappings.GetInput(InputMappings.EAction.SWITCH_PHASE);
        InputValues[InputMappings.EAction.PUSH] = InputMappings.GetInput(InputMappings.EAction.PUSH);
        InputValues[InputMappings.EAction.PULL] = InputMappings.GetInput(InputMappings.EAction.PULL); 
    }
}
