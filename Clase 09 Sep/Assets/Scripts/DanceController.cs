using UnityEngine;

public class DanceController : MonoBehaviour
{
    [SerializeField] private Animator[] animators;
    [SerializeField] private AudioClip[] audios;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject[] characters;
    public int indexCharacter = 0;
    public bool[] estaBailando;
    public bool BaileGlobal = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estaBailando = new bool[characters.Length];

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == 0);
            estaBailando[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            estaBailando[indexCharacter] = animators[indexCharacter].GetBool("Baila");

            characters[indexCharacter].SetActive(false);

            if (indexCharacter < characters.Length - 1)
            {
                indexCharacter++;
            }
            else
            {
                indexCharacter = 0;

            }

            characters[indexCharacter].SetActive(true);

            animators[indexCharacter].SetBool("Baila", estaBailando[indexCharacter]);

            if (BaileGlobal)
            {
                audioSource.Stop();
                audioSource.clip = audios[indexCharacter];
                audioSource.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            BaileGlobal = true;

            for (int i = 0; i < animators.Length; i++)
            {
                estaBailando[i] = true;

                if (characters[i].activeSelf)
                {

                    animators[i].SetBool("Baila", true);
                }
            }

            audioSource.clip = audios[indexCharacter];
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            BaileGlobal = false;

            for (int i = 0; i < animators.Length; i++)
            {
                estaBailando[i] = false;

                if (characters[i].activeSelf)
                {

                    animators[i].SetBool("Baila", false);
                }
            }
            audioSource.Stop();
        }
    }

    public void ActivaBaile()
    {
        BaileGlobal = true;

        for (int i = 0; i < animators.Length; i++)
        {
            estaBailando[i] = true;

            if (characters[i].activeSelf)
            {

                animators[i].SetBool("Baila", true);
            }
        }

        audioSource.clip = audios[indexCharacter];
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void CambiaPersonaje()
    {
        estaBailando[indexCharacter] = animators[indexCharacter].GetBool("Baila");

            characters[indexCharacter].SetActive(false);

            if (indexCharacter < characters.Length - 1)
            {
                indexCharacter++;
            }
            else
            {
                indexCharacter = 0;

            }

            characters[indexCharacter].SetActive(true);

            animators[indexCharacter].SetBool("Baila", estaBailando[indexCharacter]);

            if (BaileGlobal)
            {
                audioSource.Stop();
                audioSource.clip = audios[indexCharacter];
                audioSource.Play();
            }
    }
}