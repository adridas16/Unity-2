using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plato : MonoBehaviour
{
    private bool yaLavado = false;
    private MeshRenderer m_Renderer;
    [SerializeField] private Material limpio;
    public bool YaLavado { get => yaLavado; set => yaLavado = value; }

    // Start is called before the first frame update
    void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LavaPlatos"))
        {
            m_Renderer.material = limpio;
        }   
            
    }
}
