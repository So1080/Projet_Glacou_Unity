using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;
    [SerializeField] private Transform _slotParent;
    [SerializeField] private int poubelle;




    private bool _dragging, _placed;

    private Vector2 _offset, _originalPosition;

    [SerializeField] private PuzzleSlot _slot;

    
    public void Init()
    {
        var spawnedSlot = Instantiate(_slot, _slotParent.GetChild(poubelle).position, Quaternion.identity);
        _slot = spawnedSlot;

       

        print(_slot);

    }

    private void Start()
    {
        _placed = false;
    }

    private void Awake()
    {
        _originalPosition = transform.position;
        
    }

    private void Update()
    {
        if (_placed) return;
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown()
    {
        if(_placed == false)
        {
            _dragging = true;
            _source.PlayOneShot(_pickUpClip);

            _offset = GetMousePos() - (Vector2)transform.position;
        }
        
    }

    internal void Init(int poubelle)
    {
        throw new NotImplementedException();
    }

    private void OnMouseUp()
    {
        if (_placed == false)
        {
            if (Vector2.Distance(transform.position, _slot.transform.position) < 1)
            {
                transform.position = _slot.transform.position;
                _slot.Placed();
                _renderer.sortingOrder = 0;
                _placed = true;
                print("maintenant on a bien true : " + _placed);
                Destroy(gameObject);
            }
            else
            {
                print("maintenant on a bien false : " + _placed);
                transform.position = _originalPosition;
                _dragging = false;
                _placed = false;
                _source.PlayOneShot(_dropClip);

            }
        }
        
        
    }



    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }




}
