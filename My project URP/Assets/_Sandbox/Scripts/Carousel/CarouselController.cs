using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarouselManager))]
public class CarouselController : MonoBehaviour
{
    CarouselManager m_CarouselManager;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_CarouselManager = GetComponent<CarouselManager>();
    }

    [ContextMenu("Index Carousel Fwd")]
    public void IndexRight()
    {
        //print(index);
        m_CarouselManager.MoveObjectLeft();
    }

    [ContextMenu("Index Carousel Bwd")]
    public void IndexLeft()
    {
        m_CarouselManager.MoveObjectRight();
    }
}
