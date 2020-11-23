using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using TMPro;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] GameObject _discardZone = null;
    [SerializeField] GameObject _toSpawn = null;
    [SerializeField] Transform _pHSlotOne = null;
    [SerializeField] Transform _pHSlotTwo = null;
    [SerializeField] Transform _pHSlotThree = null;
    [SerializeField] Transform _pHSlotFour = null;
    [SerializeField] Transform _pHSlotFive = null;
    [SerializeField] GameObject _buttonOne = null;
    [SerializeField] GameObject _buttonTwo = null;
    [SerializeField] GameObject _buttonThree = null;
    [SerializeField] GameObject _buttonFour = null;
    [SerializeField] GameObject _buttonFive = null;
    protected GameObject _phCardOne;
    protected GameObject _phCardTwo;
    protected GameObject _phCardThree;
    protected GameObject _phCardFour;
    protected GameObject _phCardFive;
    public bool phOne = false;
    public bool phTwo = false;
    public bool phThree = false;
    public bool phFour = false;
    public bool phFive = false;
    public float _discardCount = 0;

    public Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    public Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();
    public Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    [SerializeField] [Range(0f, 3f)] private float lerpPct = 0f;
    private int playcard = 0;
    [SerializeField] PlayerCharacter _playerChararcter = null;
    public int numCardsPlayed = 0;
    [SerializeField] GameObject hand = null;

    //[SerializeField] TextMeshProUGUI _countTxtone = null;

    void Start()
    {
        SetUpAbilityDeck();
    }

    private void SetUpAbilityDeck()
    {
        Debug.Log("Creating Ability cards...");

        foreach (AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }
        _abilityDeck.Shuffle();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }

        if (playcard == 1)
        {
            PlayCardOnBoard(_phCardOne, _pHSlotOne);
            lerpPct += .02f;
            if (lerpPct >= 3f)
            {
                lerpPct = 0f;
                playcard = 0;
                SortHand(1);
            }
        }
        else if (playcard == 2)
        {
            PlayCardOnBoard(_phCardTwo, _pHSlotTwo);
            lerpPct += .02f;
            if (lerpPct >= 3f)
            {
                lerpPct = 0f;
                playcard = 0;
                SortHand(2);
            }
        }
        else if (playcard == 3)
        {
            PlayCardOnBoard(_phCardThree, _pHSlotThree);
            lerpPct += .02f;
            if (lerpPct >= 3f)
            {
                lerpPct = 0f;
                playcard = 0;
                SortHand(3);
            }
        }
        else if (playcard == 4)
        {
            PlayCardOnBoard(_phCardFour, _pHSlotFour);
            lerpPct += .02f;
            if (lerpPct >= 3f)
            {
                lerpPct = 0f;
                playcard = 0;
                SortHand(4);
            }
        }
        else if (playcard == 5)
        {
            PlayCardOnBoard(_phCardFive, _pHSlotFive);
            lerpPct += .02f;
            if (lerpPct >= 3f)
            {
                lerpPct = 0f;
                playcard = 0;
                SortHand(5);
            }
        }
        else { }

    }

    public void Draw()
    {
        if (_abilityDeck.IsEmpty == false)
        {
            if (_playerHand.Count < 5)
            {
                AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
                Debug.Log("Drew card: " + newCard.Name);
                _playerHand.Add(newCard, DeckPosition.Top); 
                if (phOne == false)
                {
                    _phCardOne = Instantiate(_toSpawn, _pHSlotOne.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardOne.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    _phCardOne.transform.parent = hand.transform;
                    phOne = true;
                    _pHSlotOne.gameObject.SetActive(true);
                }
                else if (phTwo == false)
                {
                    _phCardTwo = Instantiate(_toSpawn, _pHSlotTwo.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardTwo.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    _phCardTwo.transform.parent = hand.transform;
                    phTwo = true;
                    _pHSlotTwo.gameObject.SetActive(true);

                }
                else if (phThree == false)
                {
                    _phCardThree = Instantiate(_toSpawn, _pHSlotThree.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardThree.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    _phCardThree.transform.parent = hand.transform;
                    phThree = true;
                    _pHSlotThree.gameObject.SetActive(true);

                }
                else if (phFour == false)
                {
                    _phCardFour = Instantiate(_toSpawn, _pHSlotFour.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardFour.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    _phCardFour.transform.parent = hand.transform;
                    phFour = true;
                    _pHSlotFour.gameObject.SetActive(true);

                }
                else if (phFive == false)
                {
                    _phCardFive = Instantiate(_toSpawn, _pHSlotFive.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardFive.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    _phCardFive.transform.parent = hand.transform;
                    phFive = true;
                    _pHSlotFive.gameObject.SetActive(true);

                }
            }
            else
            {
                Debug.Log("Max Hand Size");
            }
        }
        else if ((_abilityDeck.IsEmpty == true) && (_abilityDiscard.IsEmpty == false))
        {
            Debug.Log("Deck empty, shufling discard into deck");
            for (int i = _abilityDiscard.Count; i > 0; i--)
            {
                AbilityCard newCard = _abilityDiscard.Draw(DeckPosition.Top);
                _abilityDeck.Add(newCard, DeckPosition.Top);
            }

            if (_playerHand.Count < 5)
            {
                AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
                Debug.Log("Drew card: " + newCard.Name);
                _playerHand.Add(newCard, DeckPosition.Top); //Changed top to bottom
                if (phOne == false)
                {
                    _phCardOne = Instantiate(_toSpawn, _pHSlotOne.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardOne.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phOne = true;
                    _pHSlotOne.gameObject.SetActive(true);
                }
                else if (phTwo == false)
                {
                    _phCardTwo = Instantiate(_toSpawn, _pHSlotTwo.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardTwo.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phTwo = true;
                    _pHSlotTwo.gameObject.SetActive(true);

                }
                else if (phThree == false)
                {
                    _phCardThree = Instantiate(_toSpawn, _pHSlotThree.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardThree.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phThree = true;
                    _pHSlotThree.gameObject.SetActive(true);

                }
                else if (phFour == false)
                {
                    _phCardFour = Instantiate(_toSpawn, _pHSlotFour.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardFour.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phFour = true;
                    _pHSlotFour.gameObject.SetActive(true);

                }
                else if (phFive == false)
                {
                    _phCardFive = Instantiate(_toSpawn, _pHSlotFive.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardFive.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phFive = true;
                    _pHSlotFive.gameObject.SetActive(true);

                }
            }
            else
            {
                Debug.Log("Max Hand Size");
            }

        }
        else if ((_abilityDeck.IsEmpty == true) && (_abilityDiscard.IsEmpty == true))
        {
            Debug.Log("Deck and Discard Empty");
        }
    }

    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    void PlayTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);


        Destroy(_phCardOne);
        //SortHand(); TODO
    }

    public void PlayCardOne()
    {
        AbilityCard targetCard = _playerHand.FirstItem;
        Debug.Log(_playerHand.FirstIndex.ToString());
        targetCard.Play();
        _playerHand.Remove(_playerHand.FirstIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        if (numCardsPlayed == 0)
        {
            phFive = false;
        }
        else if (numCardsPlayed == 1)
        {
            phFour = false;
        }
        playcard = 1;
        _playerChararcter._resourcePoints -= targetCard.Cost;
        numCardsPlayed++;
        _phCardOne.transform.parent = _discardZone.transform;
    }

    public void PlayCardTwo()
    {
        AbilityCard targetCard = _playerHand.SecondItem;
        targetCard.Play();
        _playerHand.Remove(_playerHand.SecondIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        if (numCardsPlayed == 0)
        {
            phFive = false;
        }
        else if (numCardsPlayed == 1)
        {
            phFour = false;
        }
        playcard = 2;
        _playerChararcter._resourcePoints -= targetCard.Cost;
        numCardsPlayed++;
        _phCardTwo.transform.parent = _discardZone.transform;
    }

    public void PlayCardThree()
    {
        AbilityCard targetCard = _playerHand.ThirdItem;
        targetCard.Play();
        _playerHand.Remove(_playerHand.ThirdIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        if (numCardsPlayed == 0)
        {
            phFive = false;
        }
        else if (numCardsPlayed == 1)
        {
            phFour = false;
        }
        playcard = 3;
        _playerChararcter._resourcePoints -= targetCard.Cost;
        numCardsPlayed++;
        _phCardThree.transform.parent = _discardZone.transform;
    }

    public void PlayCardFour()
    {
        AbilityCard targetCard = _playerHand.FourthItem;
        targetCard.Play();
        _playerHand.Remove(_playerHand.FourthIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        if (numCardsPlayed == 0)
        {
            phFive = false;
        }
        else if (numCardsPlayed == 1)
        {
            phFour = false;
        }
        playcard = 4;
        _playerChararcter._resourcePoints -= targetCard.Cost;
        numCardsPlayed++;
        _phCardFour.transform.parent = _discardZone.transform;
    }

    public void PlayCardFive()
    {
        AbilityCard targetCard = _playerHand.FifthItem;
        targetCard.Play();
        _playerHand.Remove(_playerHand.FifthIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        if (numCardsPlayed == 0)
        {
            phFive = false;
        }
        else if (numCardsPlayed == 1)
        {
            phFour = false;
        }
        playcard = 5;
        _playerChararcter._resourcePoints -= targetCard.Cost;
        numCardsPlayed++;
        _phCardFive.transform.parent = _discardZone.transform;
    }

    public void SortHand(int arg)
    {
        if (_playerHand.Count >= 4)
        {
            if (arg == 1)
            {
                _phCardOne = _phCardTwo;
                _phCardTwo = _phCardThree;
                _phCardThree = _phCardFour;
                _phCardFour = _phCardFive;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 2)
            {
                _phCardTwo = _phCardThree;
                _phCardThree = _phCardFour;
                _phCardFour = _phCardFive;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 3)
            {
                _phCardThree = _phCardFour;
                _phCardFour = _phCardFive;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 4)
            {
                _phCardFour = _phCardFive;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 5)
            {
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else { }
            _phCardOne.transform.position = _pHSlotOne.position;
            _phCardTwo.transform.position = _pHSlotTwo.position;
            _phCardThree.transform.position = _pHSlotThree.position;
            _phCardFour.transform.position = _pHSlotFour.position;
        }
        if (_playerHand.Count == 3)
        {
            if (arg == 1)
            {
                _phCardOne = _phCardTwo;
                _phCardTwo = _phCardThree;
                _phCardThree = _phCardFour;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 2)
            {
                _phCardTwo = _phCardThree;
                _phCardThree = _phCardFour;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 3)
            {
                _phCardThree = _phCardFour;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 4)
            {
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 5)
            {
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else { }
            _phCardOne.transform.position = _pHSlotOne.position;
            _phCardTwo.transform.position = _pHSlotTwo.position;
            _phCardThree.transform.position = _pHSlotThree.position;
        }
        if (_playerHand.Count == 2)
        {
            if (arg == 1)
            {
                _phCardOne = _phCardTwo;
                _phCardTwo = _phCardThree;
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 2)
            {
                _phCardTwo = _phCardThree;
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 3)
            {
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 4)
            {
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 5)
            {
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else { }
            _phCardOne.transform.position = _pHSlotOne.position;
            _phCardTwo.transform.position = _pHSlotTwo.position;
        }
        if (_playerHand.Count == 1)
        {
            if (arg == 1)
            {
                _phCardOne = _phCardTwo;
                _buttonTwo.SetActive(false);
                _phCardTwo = null;
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 2)
            {
                _buttonTwo.SetActive(false);
                _phCardTwo = null;
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 3)
            {
                _buttonTwo.SetActive(false);
                _phCardTwo = null;
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 4)
            {
                _buttonTwo.SetActive(false);
                _phCardTwo = null;
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else if (arg == 5)
            {
                _buttonTwo.SetActive(false);
                _phCardTwo = null;
                _buttonThree.SetActive(false);
                _phCardThree = null;
                _buttonFour.SetActive(false);
                _phCardFour = null;
                _buttonFive.SetActive(false);
                _phCardFive = null;
            }
            else { }
            _phCardOne.transform.position = _pHSlotOne.position;
        }

    }

    public void SetUpHand()
    {
        for (int i = 0; i < 5; i++)
        {
            Draw();
        }
    }

    public void SwitchButtonsOn()
    { 
        _buttonOne.SetActive(true);
        _buttonTwo.SetActive(true);
        _buttonThree.SetActive(true);
        _buttonFour.SetActive(true);
        _buttonFive.SetActive(true);
    }

    public void SwitchButtonsOff()
    {
        _buttonOne.SetActive(false);
        _buttonTwo.SetActive(false);
        _buttonThree.SetActive(false);
        _buttonFour.SetActive(false);
        _buttonFive.SetActive(false);
    }

    public void PlayCardOnBoard(GameObject card, Transform slot)
    {
        card.transform.position = Vector3.Lerp(slot.position, _discardZone.transform.position, lerpPct);
        card.transform.rotation = Quaternion.Lerp(slot.rotation, _discardZone.transform.rotation, lerpPct);
        _discardCount += .01f;
    }

    public void ToggleHand()
    {
        if (hand.activeInHierarchy)
        {
            hand.SetActive(false);
        }
        else 
        {
            hand.SetActive(true);
        }
    }
}
